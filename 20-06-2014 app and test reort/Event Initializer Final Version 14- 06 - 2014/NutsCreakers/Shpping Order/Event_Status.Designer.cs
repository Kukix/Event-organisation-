namespace Shpping_Order
{
    partial class Event_Status
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
            this.btclear = new System.Windows.Forms.Button();
            this.BTaddEvent = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPersonInfo = new System.Windows.Forms.ListBox();
            this.lbEventParciticipenter = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btclear
            // 
            this.btclear.Location = new System.Drawing.Point(301, 253);
            this.btclear.Name = "btclear";
            this.btclear.Size = new System.Drawing.Size(213, 23);
            this.btclear.TabIndex = 7;
            this.btclear.Text = "Clear Information";
            this.btclear.UseVisualStyleBackColor = true;
            this.btclear.Click += new System.EventHandler(this.btclear_Click);
            // 
            // BTaddEvent
            // 
            this.BTaddEvent.Location = new System.Drawing.Point(301, 224);
            this.BTaddEvent.Name = "BTaddEvent";
            this.BTaddEvent.Size = new System.Drawing.Size(213, 23);
            this.BTaddEvent.TabIndex = 8;
            this.BTaddEvent.Text = "Start this event";
            this.BTaddEvent.UseVisualStyleBackColor = true;
            this.BTaddEvent.Click += new System.EventHandler(this.BTaddEvent_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(382, 197);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 21);
            this.textBox1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Event Name:";
            // 
            // lbPersonInfo
            // 
            this.lbPersonInfo.FormattingEnabled = true;
            this.lbPersonInfo.ItemHeight = 12;
            this.lbPersonInfo.Location = new System.Drawing.Point(301, 7);
            this.lbPersonInfo.Name = "lbPersonInfo";
            this.lbPersonInfo.Size = new System.Drawing.Size(216, 184);
            this.lbPersonInfo.TabIndex = 11;
            // 
            // lbEventParciticipenter
            // 
            this.lbEventParciticipenter.FormattingEnabled = true;
            this.lbEventParciticipenter.ItemHeight = 12;
            this.lbEventParciticipenter.Location = new System.Drawing.Point(32, 7);
            this.lbEventParciticipenter.Name = "lbEventParciticipenter";
            this.lbEventParciticipenter.Size = new System.Drawing.Size(248, 292);
            this.lbEventParciticipenter.TabIndex = 12;
            // 
            // Event_Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 319);
            this.Controls.Add(this.lbEventParciticipenter);
            this.Controls.Add(this.lbPersonInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BTaddEvent);
            this.Controls.Add(this.btclear);
            this.Name = "Event_Status";
            this.Text = "Event_Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Event_Status_FormClosing);
            this.Load += new System.EventHandler(this.Event_Status_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btclear;
        private System.Windows.Forms.Button BTaddEvent;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbPersonInfo;
        private System.Windows.Forms.ListBox lbEventParciticipenter;
    }
}