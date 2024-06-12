using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTrdSystem
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmAutoTrd());
        }
    }

    public class PriceInfo
    {
        public PriceInfo()
        {
            Dt = DateTime.MinValue;
            Price = 0;
            ShortMovingAverage = 0;
            LongMovingAverage = 0;
            TrendCount = 0;
            TrendFlag = false;
        }

        /// <summary> 日付 </summary>
        public DateTime Dt { set; get; }
        /// <summary> 価格 </summary>
        public double Price { set; get; }
        /// <summary> 短期移動平均 </summary>
        public int ShortMovingAverage { set; get; }
        /// <summary> 長期移動平均 </summary>
        public int LongMovingAverage { set; get; }
        /// <summary> 上昇トレンドカウント </summary>
        public int TrendCount { set; get; }
        /// <summary> 上昇トレンドフラグ </summary>
        public bool TrendFlag { set; get; }
        /// <summary> 値動き上昇下降 </summary>
        public int UpDwCount { set; get; }
        /// <summary> 仕掛け回数 </summary>
        public int SettleCnt { set; get; }
    }

    public class OrderInfo
    {
        public OrderInfo()
        {
            Product = string.Empty;
            Order = string.Empty;
            Side = string.Empty;
            Price = 0;
            Size = 0;
            Expire = 0;
            Force = string.Empty;
            Response = string.Empty;
        }

        /// <summary> 通貨(BTC_JPY...) </summary>
        public string Product { set; get; }
        /// <summary> 注文(指値/成行) </summary>
        public string Order { set; get; }
        /// <summary> 注文(売り/買い) </summary>
        public string Side { set; get; }
        /// <summary> 価格 </summary>
        public int Price { set; get; }
        /// <summary> 枚数 </summary>
        public double Size { set; get; }
        /// <summary> 期限 </summary>
        public int Expire { set; get; }
        /// <summary> 条件 </summary>
        public string Force { set; get; }
        /// <summary> 応答 </summary>
        public string Response { set; get; }
        /// <summary> 合計枚数 </summary>
        public double SumSize { set; get; }
    }

    public class Const
    {
        /// <summary> 指値注文 </summary>
        public const string LIMIT = "LIMIT";
        /// <summary> 成行注文 </summary>
        public const string MARKET = "MARKET";
        /// <summary> 買い注文 </summary>
        public const string BUY = "BUY";
        /// <summary> 売り注文 </summary>
        public const string SELL = "SELL";
        /// <summary> 執行数量条件 GTC </summary>
        public const string GTC = "GTC";
        /// <summary> 執行数量条件 IOC </summary>
        public const string IOC = "IOC";
        /// <summary> 執行数量条件 FOK </summary>
        public const string FOK = "FOK";
        /// <summary> ボタン表示 現在値表示開始 </summary>
        public const string TEXT_LOOP_START = "取引開始";
        /// <summary> ボタン表示 現在値表示停止 </summary>
        public const string TEXT_LOOP_STOP = "取引停止";
    }
}
