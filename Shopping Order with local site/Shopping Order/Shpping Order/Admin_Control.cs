using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;//RFID
using Phidgets.Events;//RFID

namespace Shpping_Order
{
    public partial class Admin_Control : Form
    {
        DBconnectAdmin admin = new DBconnectAdmin();
        private RFID myRFIDReader;
        public Admin_Control()
        {
            InitializeComponent();

            //for RFID PART
            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Attach += new AttachEventHandler(ShowWhoIsAttached);
                myRFIDReader.Detach += new DetachEventHandler(ShowWhoIsDetached);
                myRFIDReader.Tag += new TagEventHandler(ProcessThisTag);
            }
            catch (PhidgetException ex) { MessageBox.Show(ex.Message); }
        }

        //rfid methods
        private void ShowWhoIsAttached(object sender, AttachEventArgs e)
        {
            MessageBox.Show("RFIDReader attached!, serial nr: " + e.Device.SerialNumber.ToString());
        }

        private void ShowWhoIsDetached(object sender, DetachEventArgs e)
        {
            MessageBox.Show("RFIDReader detached!, serial nr: " + e.Device.SerialNumber.ToString());
        }

        private void ProcessThisTag(object sender, TagEventArgs e)
        {
            LabelRFID.Text = (e.Tag);
        }
        //end of rfid methods.

        private void Admin_Control_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Admin_Control_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user = tbUsername.Text;
            string code = LabelRFID.Text;
            admin.SaveRFID(code,user);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string shopName = tbshopname.Text;
            string desc = rtbShopDesc.Text;
            admin.SaveShop(shopName,desc);
        }
    }
}
