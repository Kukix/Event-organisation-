namespace Shpping_Order
{
    partial class Normal_Shop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BTtakeorder = new System.Windows.Forms.Button();
            this.Listoffood = new System.Windows.Forms.ListBox();
            this.ListofOrder = new System.Windows.Forms.ListBox();
            this.OrderTakenNumber = new System.Windows.Forms.NumericUpDown();
            this.Amount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LBtotalPrice = new System.Windows.Forms.Label();
            this.BTadd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BTResetPrice = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBprice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StorageNumberAdded = new System.Windows.Forms.NumericUpDown();
            this.TBFoodName = new System.Windows.Forms.TextBox();
            this.BTaddNewSpeecics = new System.Windows.Forms.Button();
            this.BTaddStorge = new System.Windows.Forms.Button();
            this.Btdelete = new System.Windows.Forms.Button();
            this.tbsearch = new System.Windows.Forms.TextBox();
            this.btsearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbname = new System.Windows.Forms.Label();
            this.btRFIDS = new System.Windows.Forms.Button();
            this.btRFIDC = new System.Windows.Forms.Button();
            this.btDsort = new System.Windows.Forms.Button();
            this.btSortPrice = new System.Windows.Forms.Button();
            this.btSortName = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lbBalance = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OrderTakenNumber)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StorageNumberAdded)).BeginInit();
            this.SuspendLayout();
            // 
            // BTtakeorder
            // 
            this.BTtakeorder.Enabled = false;
            this.BTtakeorder.Location = new System.Drawing.Point(542, 181);
            this.BTtakeorder.Name = "BTtakeorder";
            this.BTtakeorder.Size = new System.Drawing.Size(155, 23);
            this.BTtakeorder.TabIndex = 0;
            this.BTtakeorder.Text = "Take Order";
            this.BTtakeorder.UseVisualStyleBackColor = true;
            this.BTtakeorder.Click += new System.EventHandler(this.BTtakeorder_Click);
            // 
            // Listoffood
            // 
            this.Listoffood.FormattingEnabled = true;
            this.Listoffood.ItemHeight = 12;
            this.Listoffood.Location = new System.Drawing.Point(134, 9);
            this.Listoffood.Name = "Listoffood";
            this.Listoffood.Size = new System.Drawing.Size(380, 232);
            this.Listoffood.TabIndex = 1;
            // 
            // ListofOrder
            // 
            this.ListofOrder.FormattingEnabled = true;
            this.ListofOrder.ItemHeight = 12;
            this.ListofOrder.Location = new System.Drawing.Point(732, 9);
            this.ListofOrder.Name = "ListofOrder";
            this.ListofOrder.Size = new System.Drawing.Size(210, 232);
            this.ListofOrder.TabIndex = 2;
            // 
            // OrderTakenNumber
            // 
            this.OrderTakenNumber.Location = new System.Drawing.Point(604, 86);
            this.OrderTakenNumber.Name = "OrderTakenNumber";
            this.OrderTakenNumber.Size = new System.Drawing.Size(93, 21);
            this.OrderTakenNumber.TabIndex = 3;
            this.OrderTakenNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Amount
            // 
            this.Amount.AutoSize = true;
            this.Amount.Location = new System.Drawing.Point(540, 88);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(47, 12);
            this.Amount.TabIndex = 4;
            this.Amount.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(558, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Total:";
            // 
            // LBtotalPrice
            // 
            this.LBtotalPrice.AutoSize = true;
            this.LBtotalPrice.Location = new System.Drawing.Point(614, 229);
            this.LBtotalPrice.Name = "LBtotalPrice";
            this.LBtotalPrice.Size = new System.Drawing.Size(65, 12);
            this.LBtotalPrice.TabIndex = 6;
            this.LBtotalPrice.Text = "TotalPrice";
            // 
            // BTadd
            // 
            this.BTadd.Enabled = false;
            this.BTadd.Location = new System.Drawing.Point(542, 113);
            this.BTadd.Name = "BTadd";
            this.BTadd.Size = new System.Drawing.Size(155, 23);
            this.BTadd.TabIndex = 7;
            this.BTadd.Text = "Add";
            this.BTadd.UseVisualStyleBackColor = true;
            this.BTadd.Click += new System.EventHandler(this.BTadd_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.tbDesc);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.BTResetPrice);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TBprice);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.StorageNumberAdded);
            this.panel1.Controls.Add(this.TBFoodName);
            this.panel1.Controls.Add(this.BTaddNewSpeecics);
            this.panel1.Controls.Add(this.BTaddStorge);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(68, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 100);
            this.panel1.TabIndex = 8;
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(109, 34);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(175, 21);
            this.tbDesc.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "Descripton";
            // 
            // BTResetPrice
            // 
            this.BTResetPrice.Location = new System.Drawing.Point(323, 26);
            this.BTResetPrice.Name = "BTResetPrice";
            this.BTResetPrice.Size = new System.Drawing.Size(174, 23);
            this.BTResetPrice.TabIndex = 19;
            this.BTResetPrice.Text = "ResetPrice";
            this.BTResetPrice.UseVisualStyleBackColor = true;
            this.BTResetPrice.Click += new System.EventHandler(this.BTResetPrice_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Kilo",
            "Stuck",
            "Day"});
            this.comboBox1.Location = new System.Drawing.Point(199, 62);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(85, 20);
            this.comboBox1.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "Per";
            // 
            // TBprice
            // 
            this.TBprice.Location = new System.Drawing.Point(109, 62);
            this.TBprice.Name = "TBprice";
            this.TBprice.Size = new System.Drawing.Size(58, 21);
            this.TBprice.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "Food Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(538, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "Amount";
            // 
            // StorageNumberAdded
            // 
            this.StorageNumberAdded.Location = new System.Drawing.Point(602, 28);
            this.StorageNumberAdded.Name = "StorageNumberAdded";
            this.StorageNumberAdded.Size = new System.Drawing.Size(93, 21);
            this.StorageNumberAdded.TabIndex = 11;
            // 
            // TBFoodName
            // 
            this.TBFoodName.Location = new System.Drawing.Point(109, 7);
            this.TBFoodName.Name = "TBFoodName";
            this.TBFoodName.Size = new System.Drawing.Size(175, 21);
            this.TBFoodName.TabIndex = 10;
            // 
            // BTaddNewSpeecics
            // 
            this.BTaddNewSpeecics.Location = new System.Drawing.Point(323, 54);
            this.BTaddNewSpeecics.Name = "BTaddNewSpeecics";
            this.BTaddNewSpeecics.Size = new System.Drawing.Size(174, 23);
            this.BTaddNewSpeecics.TabIndex = 9;
            this.BTaddNewSpeecics.Text = "Add New Item";
            this.BTaddNewSpeecics.UseVisualStyleBackColor = true;
            this.BTaddNewSpeecics.Click += new System.EventHandler(this.BTaddNewSpeecics_Click);
            // 
            // BTaddStorge
            // 
            this.BTaddStorge.Location = new System.Drawing.Point(540, 54);
            this.BTaddStorge.Name = "BTaddStorge";
            this.BTaddStorge.Size = new System.Drawing.Size(155, 23);
            this.BTaddStorge.TabIndex = 8;
            this.BTaddStorge.Text = "Add To Storage";
            this.BTaddStorge.UseVisualStyleBackColor = true;
            this.BTaddStorge.Click += new System.EventHandler(this.BTaddStorge_Click);
            // 
            // Btdelete
            // 
            this.Btdelete.Enabled = false;
            this.Btdelete.Location = new System.Drawing.Point(542, 142);
            this.Btdelete.Name = "Btdelete";
            this.Btdelete.Size = new System.Drawing.Size(155, 23);
            this.Btdelete.TabIndex = 9;
            this.Btdelete.Text = "Delete";
            this.Btdelete.UseVisualStyleBackColor = true;
            this.Btdelete.Click += new System.EventHandler(this.Btdelete_Click);
            // 
            // tbsearch
            // 
            this.tbsearch.Location = new System.Drawing.Point(542, 46);
            this.tbsearch.Name = "tbsearch";
            this.tbsearch.Size = new System.Drawing.Size(98, 21);
            this.tbsearch.TabIndex = 11;
            // 
            // btsearch
            // 
            this.btsearch.Location = new System.Drawing.Point(646, 44);
            this.btsearch.Name = "btsearch";
            this.btsearch.Size = new System.Drawing.Size(51, 23);
            this.btsearch.TabIndex = 12;
            this.btsearch.Text = "Search";
            this.btsearch.UseVisualStyleBackColor = true;
            this.btsearch.Click += new System.EventHandler(this.btsearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(546, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "Welcome:";
            // 
            // lbname
            // 
            this.lbname.AutoSize = true;
            this.lbname.Location = new System.Drawing.Point(614, 9);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(41, 12);
            this.lbname.TabIndex = 14;
            this.lbname.Text = "lbName";
            // 
            // btRFIDS
            // 
            this.btRFIDS.Location = new System.Drawing.Point(820, 275);
            this.btRFIDS.Name = "btRFIDS";
            this.btRFIDS.Size = new System.Drawing.Size(48, 74);
            this.btRFIDS.TabIndex = 15;
            this.btRFIDS.Text = "Start RFID";
            this.btRFIDS.UseVisualStyleBackColor = true;
            this.btRFIDS.Click += new System.EventHandler(this.btRFIDS_Click);
            // 
            // btRFIDC
            // 
            this.btRFIDC.Location = new System.Drawing.Point(883, 274);
            this.btRFIDC.Name = "btRFIDC";
            this.btRFIDC.Size = new System.Drawing.Size(48, 74);
            this.btRFIDC.TabIndex = 17;
            this.btRFIDC.Text = "Close RFID";
            this.btRFIDC.UseVisualStyleBackColor = true;
            this.btRFIDC.Click += new System.EventHandler(this.btRFIDC_Click);
            // 
            // btDsort
            // 
            this.btDsort.Location = new System.Drawing.Point(25, 73);
            this.btDsort.Name = "btDsort";
            this.btDsort.Size = new System.Drawing.Size(100, 34);
            this.btDsort.TabIndex = 18;
            this.btDsort.Text = "Sort By LeftNumber";
            this.btDsort.UseVisualStyleBackColor = true;
            this.btDsort.Click += new System.EventHandler(this.btDsort_Click);
            // 
            // btSortPrice
            // 
            this.btSortPrice.Location = new System.Drawing.Point(25, 26);
            this.btSortPrice.Name = "btSortPrice";
            this.btSortPrice.Size = new System.Drawing.Size(100, 41);
            this.btSortPrice.TabIndex = 19;
            this.btSortPrice.Text = "Sort By Price";
            this.btSortPrice.UseVisualStyleBackColor = true;
            this.btSortPrice.Click += new System.EventHandler(this.btSortPrice_Click);
            // 
            // btSortName
            // 
            this.btSortName.Location = new System.Drawing.Point(25, 113);
            this.btSortName.Name = "btSortName";
            this.btSortName.Size = new System.Drawing.Size(100, 34);
            this.btSortName.TabIndex = 20;
            this.btSortName.Text = "Sort By Name";
            this.btSortName.UseVisualStyleBackColor = true;
            this.btSortName.Click += new System.EventHandler(this.btSortName_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(546, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "Balance:";
            // 
            // lbBalance
            // 
            this.lbBalance.AutoSize = true;
            this.lbBalance.Location = new System.Drawing.Point(614, 29);
            this.lbBalance.Name = "lbBalance";
            this.lbBalance.Size = new System.Drawing.Size(47, 12);
            this.lbBalance.TabIndex = 22;
            this.lbBalance.Text = "Balance";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 23;
            this.button1.Text = "Get Sale Products";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 35);
            this.button2.TabIndex = 24;
            this.button2.Text = "Get Rental Products";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Normal_Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 380);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbBalance);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btSortName);
            this.Controls.Add(this.btSortPrice);
            this.Controls.Add(this.btDsort);
            this.Controls.Add(this.btRFIDC);
            this.Controls.Add(this.btRFIDS);
            this.Controls.Add(this.lbname);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btsearch);
            this.Controls.Add(this.tbsearch);
            this.Controls.Add(this.Btdelete);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTadd);
            this.Controls.Add(this.LBtotalPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.OrderTakenNumber);
            this.Controls.Add(this.ListofOrder);
            this.Controls.Add(this.Listoffood);
            this.Controls.Add(this.BTtakeorder);
            this.Name = "Normal_Shop";
            this.Text = "Order Taker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Normal_Shop_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Normal_Shop_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.OrderTakenNumber)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StorageNumberAdded)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTtakeorder;
        private System.Windows.Forms.ListBox Listoffood;
        private System.Windows.Forms.ListBox ListofOrder;
        private System.Windows.Forms.NumericUpDown OrderTakenNumber;
        private System.Windows.Forms.Label Amount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LBtotalPrice;
        private System.Windows.Forms.Button BTadd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown StorageNumberAdded;
        private System.Windows.Forms.TextBox TBFoodName;
        private System.Windows.Forms.Button BTaddNewSpeecics;
        private System.Windows.Forms.Button BTaddStorge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBprice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTResetPrice;
        private System.Windows.Forms.Button Btdelete;
        private System.Windows.Forms.TextBox tbsearch;
        private System.Windows.Forms.Button btsearch;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbname;
        private System.Windows.Forms.Button btRFIDS;
        private System.Windows.Forms.Button btRFIDC;
        private System.Windows.Forms.Button btDsort;
        private System.Windows.Forms.Button btSortPrice;
        private System.Windows.Forms.Button btSortName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbBalance;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
    }
}

