namespace Shpping_Order
{
    partial class Return_Products
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
            this.ListofProducts = new System.Windows.Forms.ListBox();
            this.btReturn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbReturnNumber = new System.Windows.Forms.TextBox();
            this.ListofRetrunStuff = new System.Windows.Forms.ListBox();
            this.btadd = new System.Windows.Forms.Button();
            this.btdelete = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbname = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ListofProducts
            // 
            this.ListofProducts.FormattingEnabled = true;
            this.ListofProducts.ItemHeight = 12;
            this.ListofProducts.Location = new System.Drawing.Point(12, 23);
            this.ListofProducts.Name = "ListofProducts";
            this.ListofProducts.Size = new System.Drawing.Size(414, 232);
            this.ListofProducts.TabIndex = 2;
            // 
            // btReturn
            // 
            this.btReturn.Location = new System.Drawing.Point(434, 219);
            this.btReturn.Name = "btReturn";
            this.btReturn.Size = new System.Drawing.Size(199, 23);
            this.btReturn.TabIndex = 3;
            this.btReturn.Text = "Return";
            this.btReturn.UseVisualStyleBackColor = true;
            this.btReturn.Click += new System.EventHandler(this.btReturn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(432, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Return Number:";
            // 
            // tbReturnNumber
            // 
            this.tbReturnNumber.Location = new System.Drawing.Point(527, 125);
            this.tbReturnNumber.Name = "tbReturnNumber";
            this.tbReturnNumber.Size = new System.Drawing.Size(106, 21);
            this.tbReturnNumber.TabIndex = 5;
            this.tbReturnNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReturnNumber_KeyPress);
            // 
            // ListofRetrunStuff
            // 
            this.ListofRetrunStuff.FormattingEnabled = true;
            this.ListofRetrunStuff.ItemHeight = 12;
            this.ListofRetrunStuff.Location = new System.Drawing.Point(663, 23);
            this.ListofRetrunStuff.Name = "ListofRetrunStuff";
            this.ListofRetrunStuff.Size = new System.Drawing.Size(430, 232);
            this.ListofRetrunStuff.TabIndex = 6;
            // 
            // btadd
            // 
            this.btadd.Location = new System.Drawing.Point(434, 161);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(199, 23);
            this.btadd.TabIndex = 7;
            this.btadd.Text = ">>";
            this.btadd.UseVisualStyleBackColor = true;
            this.btadd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // btdelete
            // 
            this.btdelete.Location = new System.Drawing.Point(434, 190);
            this.btdelete.Name = "btdelete";
            this.btdelete.Size = new System.Drawing.Size(199, 23);
            this.btdelete.TabIndex = 8;
            this.btdelete.Text = "<<";
            this.btdelete.UseVisualStyleBackColor = true;
            this.btdelete.Click += new System.EventHandler(this.btdelete_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(432, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "Welcome:";
            // 
            // lbname
            // 
            this.lbname.AutoSize = true;
            this.lbname.Location = new System.Drawing.Point(506, 58);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(41, 12);
            this.lbname.TabIndex = 15;
            this.lbname.Text = "lbName";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(432, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "Balance:";
            // 
            // lbBalance
            // 
            this.lbBalance.AutoSize = true;
            this.lbBalance.Location = new System.Drawing.Point(506, 85);
            this.lbBalance.Name = "lbBalance";
            this.lbBalance.Size = new System.Drawing.Size(47, 12);
            this.lbBalance.TabIndex = 23;
            this.lbBalance.Text = "Balance";
            // 
            // Return_Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 290);
            this.Controls.Add(this.lbBalance);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbname);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btdelete);
            this.Controls.Add(this.btadd);
            this.Controls.Add(this.ListofRetrunStuff);
            this.Controls.Add(this.tbReturnNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btReturn);
            this.Controls.Add(this.ListofProducts);
            this.Name = "Return_Products";
            this.Text = "Return_Products";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListofProducts;
        private System.Windows.Forms.Button btReturn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbReturnNumber;
        private System.Windows.Forms.ListBox ListofRetrunStuff;
        private System.Windows.Forms.Button btadd;
        private System.Windows.Forms.Button btdelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbBalance;
    }
}