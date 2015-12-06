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
    public partial class Checking_Information : Form
    {
        private RFID myRFIDReader;
        DBconnectionCustomer dbcustomer = null;
        Customer newcustomer = null;

        public Checking_Information()
        {
            InitializeComponent();
            dbcustomer = new DBconnectionCustomer();

            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Attach += new AttachEventHandler(ShowWhoIsAttached);
                myRFIDReader.Detach += new DetachEventHandler(ShowWhoIsDetached);
                myRFIDReader.Tag += new TagEventHandler(ProcessThisTag);
            }
            catch (PhidgetException ex) { MessageBox.Show(ex.Message); }

            //test part:
            newcustomer = dbcustomer.FindCustomerInfoByRfid("hellohellohellohellohellohellohellohellohello");
            string[] splits = newcustomer.InfoString().Split('\n');
            foreach (string s in splits)
            {
                listBox1.Items.Add(s);
            }
            //

        }

        private void ShowWhoIsAttached(object sender, AttachEventArgs e)
        {
            MessageBox.Show("RFIDReader attached!, serial nr: " + e.Device.SerialNumber.ToString());
            newcustomer = dbcustomer.FindCustomerInfoByRfid(e.Device.SerialNumber.ToString());
            string[] splits = newcustomer.InfoString().Split('\n');
            foreach (string s in splits)
            {
                listBox1.Items.Add(s);
            }
        }

        private void ShowWhoIsDetached(object sender, DetachEventArgs e)
        {
            MessageBox.Show("RFIDReader detached!, serial nr: " + e.Device.SerialNumber.ToString());
            listBox1.Items.Clear();
            newcustomer = null;
        }

        private void ProcessThisTag(object sender, TagEventArgs e)
        {
            //lbname.Text = (e.Tag);
        }

        private void Checking_Information_Load(object sender, EventArgs e)
        {

        }
    }
}
