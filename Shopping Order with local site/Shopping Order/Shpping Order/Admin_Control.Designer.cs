namespace Shpping_Order
{
    partial class Admin_Control
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
            this.tbshopname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbShopDesc = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LabelRFID = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbshopname
            // 
            this.tbshopname.Location = new System.Drawing.Point(76, 23);
            this.tbshopname.Name = "tbshopname";
            this.tbshopname.Size = new System.Drawing.Size(179, 20);
            this.tbshopname.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add new shop";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Describtion";
            // 
            // rtbShopDesc
            // 
            this.rtbShopDesc.Location = new System.Drawing.Point(76, 53);
            this.rtbShopDesc.Name = "rtbShopDesc";
            this.rtbShopDesc.Size = new System.Drawing.Size(179, 96);
            this.rtbShopDesc.TabIndex = 4;
            this.rtbShopDesc.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Register RFID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Input Username";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(455, 26);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(165, 20);
            this.tbUsername.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Create Shop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LabelRFID
            // 
            this.LabelRFID.AutoSize = true;
            this.LabelRFID.Location = new System.Drawing.Point(452, 56);
            this.LabelRFID.Name = "LabelRFID";
            this.LabelRFID.Size = new System.Drawing.Size(59, 13);
            this.LabelRFID.TabIndex = 9;
            this.LabelRFID.Text = "RFID code";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(466, 109);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Assign code";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Admin_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 338);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.LabelRFID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtbShopDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbshopname);
            this.Name = "Admin_Control";
            this.Text = "Admin_Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_Control_FormClosing);
            this.Load += new System.EventHandler(this.Admin_Control_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbshopname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbShopDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LabelRFID;
        private System.Windows.Forms.Button button2;
    }
}