namespace AutoTrdSystem
{
    partial class FrmAutoTrd
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numExpire = new System.Windows.Forms.NumericUpDown();
            this.numSize = new System.Windows.Forms.NumericUpDown();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoFOK = new System.Windows.Forms.RadioButton();
            this.rdoIOC = new System.Windows.Forms.RadioButton();
            this.rdoGTC = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoSell = new System.Windows.Forms.RadioButton();
            this.rdoBuy = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoMarket = new System.Windows.Forms.RadioButton();
            this.rdoLimit = new System.Windows.Forms.RadioButton();
            this.cmbProductCode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClr = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnGetPrice = new System.Windows.Forms.Button();
            this.dgvPrice = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExpire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // txtResponse
            // 
            this.txtResponse.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtResponse.Location = new System.Drawing.Point(860, 151);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(264, 104);
            this.txtResponse.TabIndex = 13;
            this.txtResponse.Tag = "ｖ";
            this.txtResponse.Visible = false;
            // 
            // btnOrder
            // 
            this.btnOrder.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOrder.Location = new System.Drawing.Point(860, 108);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(165, 37);
            this.btnOrder.TabIndex = 12;
            this.btnOrder.Text = "注文実行";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Visible = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numExpire);
            this.groupBox1.Controls.Add(this.numSize);
            this.groupBox1.Controls.Add(this.numPrice);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cmbProductCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(376, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 287);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Body";
            // 
            // numExpire
            // 
            this.numExpire.Location = new System.Drawing.Point(63, 154);
            this.numExpire.Maximum = new decimal(new int[] {
            43200,
            0,
            0,
            0});
            this.numExpire.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numExpire.Name = "numExpire";
            this.numExpire.Size = new System.Drawing.Size(131, 28);
            this.numExpire.TabIndex = 19;
            this.numExpire.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numExpire.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numSize
            // 
            this.numSize.DecimalPlaces = 3;
            this.numSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numSize.Location = new System.Drawing.Point(63, 119);
            this.numSize.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numSize.Name = "numSize";
            this.numSize.Size = new System.Drawing.Size(131, 28);
            this.numSize.TabIndex = 18;
            this.numSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(260, 76);
            this.numPrice.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(131, 28);
            this.numPrice.TabIndex = 17;
            this.numPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPrice.ThousandsSeparator = true;
            this.numPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(62, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(329, 45);
            this.label10.TabIndex = 16;
            this.label10.Text = "※GTC : 注文が約定もしくはキャンセルまで有効\r\n　 IOC : 有利な価格で即時約定、約定しなかった数量はキャンセル\r\n　 FOK : 全数量が即時約定しな" +
    "かった場合はキャンセル";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(200, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "※分 1～43200（30日間）";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "※0.001～1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdoFOK);
            this.groupBox4.Controls.Add(this.rdoIOC);
            this.groupBox4.Controls.Add(this.rdoGTC);
            this.groupBox4.Location = new System.Drawing.Point(63, 181);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(201, 44);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            // 
            // rdoFOK
            // 
            this.rdoFOK.AutoSize = true;
            this.rdoFOK.Location = new System.Drawing.Point(132, 15);
            this.rdoFOK.Name = "rdoFOK";
            this.rdoFOK.Size = new System.Drawing.Size(59, 24);
            this.rdoFOK.TabIndex = 5;
            this.rdoFOK.TabStop = true;
            this.rdoFOK.Text = "FOK";
            this.rdoFOK.UseVisualStyleBackColor = true;
            // 
            // rdoIOC
            // 
            this.rdoIOC.AutoSize = true;
            this.rdoIOC.Location = new System.Drawing.Point(73, 15);
            this.rdoIOC.Name = "rdoIOC";
            this.rdoIOC.Size = new System.Drawing.Size(56, 24);
            this.rdoIOC.TabIndex = 4;
            this.rdoIOC.TabStop = true;
            this.rdoIOC.Text = "IOC";
            this.rdoIOC.UseVisualStyleBackColor = true;
            // 
            // rdoGTC
            // 
            this.rdoGTC.AutoSize = true;
            this.rdoGTC.Location = new System.Drawing.Point(7, 15);
            this.rdoGTC.Name = "rdoGTC";
            this.rdoGTC.Size = new System.Drawing.Size(60, 24);
            this.rdoGTC.TabIndex = 3;
            this.rdoGTC.TabStop = true;
            this.rdoGTC.Text = "GTC";
            this.rdoGTC.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "条件";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "期限";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "数量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "価格";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "取引";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoSell);
            this.groupBox3.Controls.Add(this.rdoBuy);
            this.groupBox3.Location = new System.Drawing.Point(63, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(131, 46);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // rdoSell
            // 
            this.rdoSell.AutoSize = true;
            this.rdoSell.Location = new System.Drawing.Point(67, 16);
            this.rdoSell.Name = "rdoSell";
            this.rdoSell.Size = new System.Drawing.Size(53, 24);
            this.rdoSell.TabIndex = 4;
            this.rdoSell.TabStop = true;
            this.rdoSell.Text = "売り";
            this.rdoSell.UseVisualStyleBackColor = true;
            // 
            // rdoBuy
            // 
            this.rdoBuy.AutoSize = true;
            this.rdoBuy.Location = new System.Drawing.Point(6, 16);
            this.rdoBuy.Name = "rdoBuy";
            this.rdoBuy.Size = new System.Drawing.Size(56, 24);
            this.rdoBuy.TabIndex = 3;
            this.rdoBuy.TabStop = true;
            this.rdoBuy.Text = "買い";
            this.rdoBuy.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "注文";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoMarket);
            this.groupBox2.Controls.Add(this.rdoLimit);
            this.groupBox2.Location = new System.Drawing.Point(260, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 48);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // rdoMarket
            // 
            this.rdoMarket.AutoSize = true;
            this.rdoMarket.Location = new System.Drawing.Point(67, 17);
            this.rdoMarket.Name = "rdoMarket";
            this.rdoMarket.Size = new System.Drawing.Size(59, 24);
            this.rdoMarket.TabIndex = 4;
            this.rdoMarket.TabStop = true;
            this.rdoMarket.Text = "成行";
            this.rdoMarket.UseVisualStyleBackColor = true;
            // 
            // rdoLimit
            // 
            this.rdoLimit.AutoSize = true;
            this.rdoLimit.Location = new System.Drawing.Point(6, 17);
            this.rdoLimit.Name = "rdoLimit";
            this.rdoLimit.Size = new System.Drawing.Size(59, 24);
            this.rdoLimit.TabIndex = 3;
            this.rdoLimit.TabStop = true;
            this.rdoLimit.Text = "指値";
            this.rdoLimit.UseVisualStyleBackColor = true;
            // 
            // cmbProductCode
            // 
            this.cmbProductCode.FormattingEnabled = true;
            this.cmbProductCode.Location = new System.Drawing.Point(63, 30);
            this.cmbProductCode.Name = "cmbProductCode";
            this.cmbProductCode.Size = new System.Drawing.Size(131, 28);
            this.cmbProductCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "通貨";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(1040, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(165, 37);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClr
            // 
            this.btnClr.BackColor = System.Drawing.Color.SkyBlue;
            this.btnClr.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClr.Location = new System.Drawing.Point(191, 266);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(165, 37);
            this.btnClr.TabIndex = 9;
            this.btnClr.Text = "消去";
            this.btnClr.UseVisualStyleBackColor = false;
            this.btnClr.Click += new System.EventHandler(this.btnClr_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPrice.Location = new System.Drawing.Point(12, 88);
            this.txtPrice.Multiline = true;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrice.Size = new System.Drawing.Size(344, 167);
            this.txtPrice.TabIndex = 8;
            this.txtPrice.Tag = "ｖ";
            // 
            // btnGetPrice
            // 
            this.btnGetPrice.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnGetPrice.Location = new System.Drawing.Point(12, 16);
            this.btnGetPrice.Name = "btnGetPrice";
            this.btnGetPrice.Size = new System.Drawing.Size(165, 37);
            this.btnGetPrice.TabIndex = 7;
            this.btnGetPrice.Text = "取引開始";
            this.btnGetPrice.UseVisualStyleBackColor = true;
            this.btnGetPrice.Click += new System.EventHandler(this.btnGetPrice_Click);
            // 
            // dgvPrice
            // 
            this.dgvPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvPrice.Location = new System.Drawing.Point(12, 331);
            this.dgvPrice.Name = "dgvPrice";
            this.dgvPrice.ReadOnly = true;
            this.dgvPrice.RowHeadersVisible = false;
            this.dgvPrice.RowTemplate.Height = 21;
            this.dgvPrice.Size = new System.Drawing.Size(1193, 234);
            this.dgvPrice.TabIndex = 14;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // dgvOrder
            // 
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvOrder.Location = new System.Drawing.Point(12, 608);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.ReadOnly = true;
            this.dgvOrder.RowHeadersVisible = false;
            this.dgvOrder.RowTemplate.Height = 21;
            this.dgvOrder.Size = new System.Drawing.Size(1193, 213);
            this.dgvOrder.TabIndex = 15;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.label11.Location = new System.Drawing.Point(12, 308);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "値動き一覧";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.label12.Location = new System.Drawing.Point(12, 585);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 20);
            this.label12.TabIndex = 17;
            this.label12.Text = "注文";
            // 
            // FrmAutoTrd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1221, 845);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgvOrder);
            this.Controls.Add(this.dgvPrice);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClr);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnGetPrice);
            this.Name = "FrmAutoTrd";
            this.Text = "うねり取りビットコイントレードシステム";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAutoTrd_FormClosing);
            this.Load += new System.EventHandler(this.frmBtcTrd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExpire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numExpire;
        private System.Windows.Forms.NumericUpDown numSize;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdoFOK;
        private System.Windows.Forms.RadioButton rdoIOC;
        private System.Windows.Forms.RadioButton rdoGTC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoSell;
        private System.Windows.Forms.RadioButton rdoBuy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoMarket;
        private System.Windows.Forms.RadioButton rdoLimit;
        private System.Windows.Forms.ComboBox cmbProductCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClr;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnGetPrice;
        private System.Windows.Forms.DataGridView dgvPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

