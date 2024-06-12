using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTrdSystem
{
    public partial class FrmAutoTrd : Form
    {
        static readonly Uri endpointUri = new Uri("https://api.bitflyer.jp");
        private string _apiKey;
        private string _apiSecret;
        private ushort _interval;
        private string _directoryPath;
        private string _fileNameTrade;
        private string _fileNameOrder;
        private ushort _shortMovingAverage;
        private ushort _longtMovingAverage;
        private ushort _trend;
        private ushort _settle;
        private ushort _settleCnt;

        private bool _loopFlg = true;

        private List<PriceInfo> priceData = new List<PriceInfo>();

        private List<OrderInfo> orderInfo = new List<OrderInfo>();

        public class JsonTicker
        {
            public string product_code { get; set; }
            public DateTime timestamp { get; set; }
            public int tick_id { get; set; }
            public double best_bid { get; set; }
            public double best_ask { get; set; }
            public double best_bid_size { get; set; }
            public double best_ask_size { get; set; }
            public double total_bid_depth { get; set; }
            public double total_ask_depth { get; set; }
            public double ltp { get; set; }
            public double volume { get; set; }
            public double volume_by_product { get; set; }
        }

        public class JsonAccept
        {
            public string child_order_acceptance_id { get; set; }
        }

        public FrmAutoTrd()
        {
            InitializeComponent();
        }

        private void btnGetPrice_Click(object sender, EventArgs e)
        {
            ctrlbtnGetPrice();
        }

        public async Task GetBtcPrice()
        {
            try
            {
                while (true)
                {
                    if (!_loopFlg) break;

                    var method = "GET";
                    var path = "/v1/ticker";
                    var query = "?product_code=BTC_JPY";
                    using (var client = new HttpClient())
                    using (var request = new HttpRequestMessage(new HttpMethod(method), path + query))
                    {
                        client.BaseAddress = endpointUri;
                        var message = await client.SendAsync(request);
                        var response = await message.Content.ReadAsStringAsync();
                        var jRes = JsonConvert.DeserializeObject<JsonTicker>(response);
                        string tm = jRes.timestamp.ToString("HH:mm:ss");
                        string price = jRes.ltp.ToString("N0"); //カンマ区切り
                        txtPrice.AppendText(tm + " " + price + System.Environment.NewLine);

                        PriceInfo item = new PriceInfo();
                        item.Dt = Convert.ToDateTime(jRes.timestamp);
                        item.Price = Convert.ToInt32(jRes.ltp);
                        priceData.Add(item);
                    }

                    //移動平均、
                    SetPriceData(priceData.Count - 1);

                    //ファイルへ書き込み
                    WritePriceData(priceData[priceData.Count - 1]);

                    //一覧へ表示
                    dgvPrice.Rows.Insert(
                        0, 
                        priceData[priceData.Count - 1].Dt, 
                        priceData[priceData.Count - 1].Price.ToString("#,0"),
                        priceData[priceData.Count - 1].ShortMovingAverage.ToString("#,0"),
                        priceData[priceData.Count - 1].LongMovingAverage.ToString("#,0"),
                        priceData[priceData.Count - 1].TrendCount,
                        priceData[priceData.Count - 1].TrendFlag,
                        priceData[priceData.Count - 1].UpDwCount,
                        priceData[priceData.Count - 1].SettleCnt
                        );

                    //インターバル時間
                    await Task.Delay(_interval);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void SetPriceData(int newestCnt)
        {
            try
            {
                int cnt = 0;
                double priceSum = 0;

                //+ 長期移動平均 +
                for (int i = newestCnt; i >= 0; i--)
                {
                    priceSum = priceSum + priceData[i].Price;
                    cnt++;

                    if (cnt >= _longtMovingAverage) break;
                }
                priceData[newestCnt].LongMovingAverage = (int)(priceSum / cnt);

                //+ 短期移動平均 +
                cnt = 0;
                priceSum = 0;
                for (int i = newestCnt; i >= 0; i--)
                {
                    priceSum = priceSum + priceData[i].Price;
                    cnt++;

                    if (cnt >= _shortMovingAverage) break;
                }
                priceData[newestCnt].ShortMovingAverage = (int)(priceSum / cnt);

                //+ 上昇トレンドカウント（長期移動平均＜短期移動平均） +
                if(priceData[newestCnt].LongMovingAverage < priceData[newestCnt].ShortMovingAverage)
                {
                    if(priceData.Count == 1)
                    {
                        priceData[newestCnt].TrendCount = 1;
                    }
                    else
                    {
                        priceData[newestCnt].TrendCount = priceData[priceData.Count - 2].TrendCount + 1;
                    }
                }
                else
                {
                    priceData[newestCnt].TrendCount = 0;
                }

                //+ トレンド判定（上昇トレンドカウントが一定回数を超えたらTrue） +
                if(priceData[newestCnt].TrendCount > _trend)
                {
                    priceData[newestCnt].TrendFlag = true;
                }
                else
                {
                    priceData[newestCnt].TrendFlag = false;
                }

                //+ 値動き判定（連続して上昇／下降をカウント） +
                if(newestCnt != 0)
                {
                    //価格が上昇した時
                    if(priceData[newestCnt - 1].Price < priceData[newestCnt].Price)
                    {
                        //前回価格がフラットまたは上昇の時
                        if(0 <= priceData[newestCnt - 1].UpDwCount)
                        {
                            priceData[newestCnt].UpDwCount = priceData[newestCnt - 1].UpDwCount + 1;
                        }
                        //前回価格が下降の時
                        else if(priceData[newestCnt - 1].UpDwCount < 0)
                        {
                            priceData[newestCnt].UpDwCount = 0;
                        }
                    }
                    //価格が下降した時
                    else if (priceData[newestCnt - 1].Price > priceData[newestCnt].Price)
                    {
                        //前回価格がフラットまたは下降の時
                        if (priceData[newestCnt - 1].UpDwCount <= 0)
                        {
                            priceData[newestCnt].UpDwCount = priceData[newestCnt - 1].UpDwCount - 1;
                        }
                        //前回価格が上昇の時
                        else if (0 < priceData[newestCnt - 1].UpDwCount)
                        {
                            priceData[newestCnt].UpDwCount = 0;
                        }
                    }
                    //価格が同じの場合
                    else
                    {
                        priceData[newestCnt].UpDwCount = priceData[newestCnt - 1].UpDwCount;
                    }
                }

                //+ 仕掛け +
                //上昇トレンド
                if(priceData[newestCnt].TrendFlag == true)
                {
                    //押し目
                    if((priceData[newestCnt].UpDwCount < 0) && (priceData[newestCnt].UpDwCount % _settle == 0))
                    {
                        //仕掛けの回数判定
                        if(priceData[newestCnt].SettleCnt < _settleCnt)
                        {
                            priceData[newestCnt].SettleCnt++;

                            //注文処理（仕掛け/買い）
                            Task task = Order(cmbProductCode.Text, rdoLimit.Text, Const.BUY, (int)numPrice.Value, (double)numSize.Value, (int)numExpire.Value, rdoGTC.Text);
                        }
                    }
                }
                //手仕舞い
                else
                {
                    priceData[newestCnt].SettleCnt = 0;

                    //注文処理（手仕舞い/売り）※一括手仕舞い
                    double size = orderInfo[orderInfo.Count - 1].SumSize;
                    Task task = Order(cmbProductCode.Text, rdoLimit.Text, Const.SELL, (int)numPrice.Value, size, (int)numExpire.Value, rdoGTC.Text);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void WritePriceData(PriceInfo info)
        {
            try
            {
                //フォルダが無ければ作成
                if (!Directory.Exists(_directoryPath))
                {
                    Directory.CreateDirectory(_directoryPath);
                }

                string filePath = _directoryPath + @"\" + _fileNameTrade;
                string buf = info.Dt.ToString("yyyy/MM/dd HH:mm:ss") + "," +
                             info.Price.ToString() + "," +
                             info.ShortMovingAverage.ToString() + "," +
                             info.LongMovingAverage.ToString() + "," +
                             info.TrendCount.ToString() + "," +
                             info.TrendFlag.ToString() + "," +
                             info.UpDwCount.ToString() + "," +
                             info.SettleCnt.ToString()
                             ;
                
                if (!File.Exists(filePath))
                {
                    using (var writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine("Date,Price,ShortMovingAve,LongMovingAve,RiseTrendCount,RiseTreadFlag,PriceUpDW,settleCnt");
                        writer.WriteLine(buf);
                    }
                }
                else
                {
                    using (var writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(buf);
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void WriteOrderData(OrderInfo info)
        {
            try
            {
                //フォルダが無ければ作成
                if (!Directory.Exists(_directoryPath))
                {
                    Directory.CreateDirectory(_directoryPath);
                }

                string filePath = _directoryPath + @"\" + _fileNameOrder;
                string buf = info.Product.ToString() + "," +
                             info.Order.ToString() + "," +
                             info.Side.ToString() + "," +
                             info.Price.ToString() + "," +
                             info.Size.ToString() + "," +
                             info.Expire.ToString() + "," +
                             info.Force.ToString() + "," +
                             info.Response.ToString() + "," +
                             info.SumSize.ToString()
                             ;

                if (!File.Exists(filePath))
                {
                    using (var writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine("Product,Order,Side,Price,Size,Expire,Force,Response,SumSize");
                        writer.WriteLine(buf);
                    }
                }
                else
                {
                    using (var writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(buf);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            txtPrice.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBtcTrd_Load(object sender, EventArgs e)
        {
            _apiKey = ConfigurationManager.AppSettings["API Key"];
            _apiSecret = ConfigurationManager.AppSettings["API Secret"];
            _interval = Convert.ToUInt16(ConfigurationManager.AppSettings["Interval"]);
            _directoryPath = ConfigurationManager.AppSettings["Directory Path"];
            _fileNameTrade = ConfigurationManager.AppSettings["File Name Trade"];
            _fileNameOrder = ConfigurationManager.AppSettings["File Name Order"];
            _shortMovingAverage = Convert.ToUInt16(ConfigurationManager.AppSettings["Short Moving Average"]);
            _longtMovingAverage = Convert.ToUInt16(ConfigurationManager.AppSettings["Long Moving Average"]);
            _trend = Convert.ToUInt16(ConfigurationManager.AppSettings["Trend"]);
            _settle = Convert.ToUInt16(ConfigurationManager.AppSettings["settle"]);
            _settleCnt = Convert.ToUInt16(ConfigurationManager.AppSettings["settleCnt"]);

            ctrlbtnGetPrice();

            InitCtrl();
        }

        private void ctrlbtnGetPrice()
        {
            _loopFlg = !_loopFlg;
            if (_loopFlg)
            {
                Task Job1 = GetBtcPrice();
                btnGetPrice.Text = Const.TEXT_LOOP_STOP;
                btnGetPrice.BackColor = Color.Red;
            }
            else
            {
                btnGetPrice.Text = Const.TEXT_LOOP_START;
                btnGetPrice.BackColor = Color.Orange;
            }
        }

        string[] _priduce = new string[] { "BTC_JPY", "XRP_JPY", "ETH_JPY", "XLM_JPY", "MONA_JPY", "ETH_BTC", "BCH_BTC", "FX_BTC_JPY" };

        private void InitCtrl()
        {
            for (int i = 0; i < _priduce.Length; i++)
            {
                cmbProductCode.Items.Add(_priduce[i]);
            }
            cmbProductCode.SelectedIndex = 0;

            rdoLimit.Checked = true;

            rdoBuy.Checked = true;

            rdoGTC.Checked = true;

            dgvPrice.ReadOnly = true;
            dgvPrice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrice.AllowUserToResizeColumns = false;
            dgvPrice.AllowUserToResizeRows = false;
            dgvPrice.Font = new Font("Meiryo UI", 10);
            dgvPrice.ColumnCount = 8;
            dgvPrice.Columns[0].HeaderText = "日時";
            dgvPrice.Columns[0].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrice.Columns[0].Width = 180;
            dgvPrice.Columns[1].HeaderText = "価格";
            dgvPrice.Columns[1].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrice.Columns[1].Width = 100;
            dgvPrice.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPrice.Columns[2].HeaderText = "移動平均(短期)";
            dgvPrice.Columns[2].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrice.Columns[2].Width = 150;
            dgvPrice.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPrice.Columns[3].HeaderText = "移動平均(長期)";
            dgvPrice.Columns[3].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrice.Columns[3].Width = 150;
            dgvPrice.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPrice.Columns[4].HeaderText = "上昇トレンドカウント";
            dgvPrice.Columns[4].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrice.Columns[4].Width = 150;
            dgvPrice.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPrice.Columns[5].HeaderText = "上昇トレンドフラグ";
            dgvPrice.Columns[5].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrice.Columns[5].Width = 150;
            dgvPrice.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPrice.Columns[6].HeaderText = "値動き(上昇/下降)";
            dgvPrice.Columns[6].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrice.Columns[6].Width = 150;
            dgvPrice.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPrice.Columns[7].HeaderText = "仕掛け回数";
            dgvPrice.Columns[7].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrice.Columns[7].Width = 150;
            dgvPrice.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvOrder.ReadOnly = true;
            dgvOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrder.AllowUserToResizeColumns = false;
            dgvOrder.AllowUserToResizeRows = false;
            dgvOrder.Font = new Font("Meiryo UI", 10);
            dgvOrder.ColumnCount = 9;
            dgvOrder.Columns[0].HeaderText = "通貨";
            dgvOrder.Columns[0].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrder.Columns[0].Width = 100;
            dgvOrder.Columns[1].HeaderText = "注文(指値/成行)";
            dgvOrder.Columns[1].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrder.Columns[1].Width = 150;
            dgvOrder.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrder.Columns[2].HeaderText = "注文(売り/買い)";
            dgvOrder.Columns[2].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrder.Columns[2].Width = 150;
            dgvOrder.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrder.Columns[3].HeaderText = "価格";
            dgvOrder.Columns[3].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrder.Columns[3].Width = 100;
            dgvOrder.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrder.Columns[4].HeaderText = "枚数";
            dgvOrder.Columns[4].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrder.Columns[4].Width = 100;
            dgvOrder.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrder.Columns[5].HeaderText = "期限";
            dgvOrder.Columns[5].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrder.Columns[5].Width = 100;
            dgvOrder.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrder.Columns[6].HeaderText = "条件";
            dgvOrder.Columns[6].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrder.Columns[6].Width = 100;
            dgvOrder.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrder.Columns[7].HeaderText = "応答";
            dgvOrder.Columns[7].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrder.Columns[7].Width = 100;
            dgvOrder.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrder.Columns[8].HeaderText = "合計枚数";
            dgvOrder.Columns[8].DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrder.Columns[8].Width = 100;
            dgvOrder.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public async Task Order(string product, string order, string side, int price, double size, int expire, string force)
        {
            var method = "POST";
            var path = "/v1/me/sendchildorder";
            var query = "";
            var body = @"{
                          ""product_code"": """ + product + @""",
                          ""child_order_type"": """ + order + @""",
                          ""side"": """ + side + @""",
                          ""price"": " + price + @",
                          ""size"": " + size + @",
                          ""minute_to_expire"": " + expire + @",
                          ""time_in_force"": @""" + force + @"""
                        }";

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(new HttpMethod(method), path + query))
            using (var content = new StringContent(body))
            {
                client.BaseAddress = endpointUri;
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Content = content;

                var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
                var data = timestamp + method + path + query + body;
                var hash = SignWithHMACSHA256(data, _apiSecret);
                request.Headers.Add("ACCESS-KEY", _apiKey);
                request.Headers.Add("ACCESS-TIMESTAMP", timestamp);
                request.Headers.Add("ACCESS-SIGN", hash);

                var message = await client.SendAsync(request);
                var response = await message.Content.ReadAsStringAsync();

                txtResponse.Text = response;

                //TODO ステータスコードを取得する必要あり？？
                OrderInfo item = new OrderInfo();
                item.Product = product;
                item.Order = order;
                item.Side = side;
                item.Price = price;
                item.Size = size;
                item.Expire = expire;
                item.Force = force;
                var jRes = JsonConvert.DeserializeObject<JsonAccept>(response);
                item.Response = jRes.child_order_acceptance_id.ToString();

                //買い
                if (side == Const.BUY)
                {
                    if (orderInfo.Count != 1)
                    {
                        item.SumSize = orderInfo[orderInfo.Count - 1].SumSize + item.Size;
                    }
                    item.SumSize = item.Size;
                }
                //売り
                else
                {
                    //売り（手仕舞い）の場合は0クリア
                    item.SumSize = 0;
                }
                orderInfo.Add(item);

                //ファイルへ書き込み
                WriteOrderData(orderInfo[orderInfo.Count - 1]);

                //一覧へ表示
                dgvOrder.Rows.Insert(
                    0,
                    orderInfo[orderInfo.Count - 1].Product,
                    orderInfo[orderInfo.Count - 1].Order,
                    orderInfo[orderInfo.Count - 1].Side,
                    orderInfo[orderInfo.Count - 1].Price.ToString("#,0"),
                    orderInfo[orderInfo.Count - 1].Size.ToString(),
                    orderInfo[orderInfo.Count - 1].Expire,
                    orderInfo[orderInfo.Count - 1].Force,
                    orderInfo[orderInfo.Count - 1].Response,
                    orderInfo[orderInfo.Count - 1].SumSize
                    );
            }
        }

        public async Task CancelAll(string product)
        {
            var method = "POST";
            var path = "/v1/me/cancelallchildorders";
            var query = "";
            var body = @"{
                          ""product_code"": """ + product + @"""
                        }";

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(new HttpMethod(method), path + query))
            using (var content = new StringContent(body))
            {
                client.BaseAddress = endpointUri;
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Content = content;

                var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
                var data = timestamp + method + path + query + body;
                var hash = SignWithHMACSHA256(data, _apiSecret);
                request.Headers.Add("ACCESS-KEY", _apiKey);
                request.Headers.Add("ACCESS-TIMESTAMP", timestamp);
                request.Headers.Add("ACCESS-SIGN", hash);

                var message = await client.SendAsync(request);
                var response = await message.Content.ReadAsStringAsync();

                txtResponse.Text = response;

                //TODO ステータスコードを取得する必要あり？？
                OrderInfo item = new OrderInfo();
                item.Product = product;
                item.Response = response;
                orderInfo.Add(item);
            }
        }

        static string SignWithHMACSHA256(string data, string secret)
        {
            using (var encoder = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
            {
                var hash = encoder.ComputeHash(Encoding.UTF8.GetBytes(data));
                return ToHexString(hash);
            }
        }

        static string ToHexString(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            //通貨(BTC_JPY...)
            string product = cmbProductCode.Text;

            //注文(指値/成行)
            string order = string.Empty;
            if (rdoLimit.Checked)
            {
                order = Const.LIMIT;
            }
            else
            {
                order = Const.MARKET;
            }

            //注文(売り/買い)
            string side = string.Empty;
            if (rdoBuy.Checked)
            {
                side = Const.BUY;
            }
            else
            {
                side = Const.SELL;
            }

            //価格
            int price = (int)numPrice.Value;

            //枚数
            double size = (double)numSize.Value;

            //期限
            int expire = (int)numExpire.Value;

            //条件
            string force = Const.GTC;
            if (rdoGTC.Checked)
            {
                force = Const.GTC;
            }
            else if (rdoIOC.Checked)
            {
                force = Const.IOC;
            }
            else if (rdoFOK.Checked)
            {
                force = Const.FOK;
            }

            //注文処理
            Task task = Order(product, order, side, price, size, expire, force);
        }

        private void FrmAutoTrd_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //全ての注文をキャンセル
                Task task = CancelAll(cmbProductCode.Text);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
