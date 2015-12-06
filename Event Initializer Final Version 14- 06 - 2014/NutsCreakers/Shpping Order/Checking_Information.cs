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

        //this application will check users' personal information
        //when they put their RFID on the scaner they should get their personal information.

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
                myRFIDReader.TagLost += new TagEventHandler(ProcessThisTagLost);
            }
            catch (PhidgetException ex) { MessageBox.Show(ex.Message); }

        }

        private void ShowWhoIsAttached(object sender, AttachEventArgs e)
        {
            MessageBox.Show("RFIDReader attached!, serial nr: " + e.Device.SerialNumber.ToString());
            //newcustomer = dbcustomer.FindCustomerInfoByRfid(e.Device.SerialNumber.ToString());
            //string[] splits = newcustomer.InfoString().Split('\n');
            //foreach (string s in splits)
            //{
            //    listBox1.Items.Add(s);
            //}
        }

        private void ShowWhoIsDetached(object sender, DetachEventArgs e)
        {
            MessageBox.Show("RFIDReader detached!, serial nr: " + e.Device.SerialNumber.ToString());
        }

        private void ProcessThisTag(object sender, TagEventArgs e)
        {
            try
            {
                newcustomer = dbcustomer.FindCustomerInfoByRfid(e.Tag);
                string[] splits = newcustomer.InfoString().Split('\n');
                foreach (string s in splits)
                {
                    listBox1.Items.Add(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcessThisTagLost(object sender, TagEventArgs e)
        {
            listBox1.Items.Clear();
            newcustomer = null;
        }

        private void Checking_Information_Load(object sender, EventArgs e)
        {
            //open the RFID when open this application.
            load();
        }

        public void load()
        {
            try
            {
                if (!myRFIDReader.Attached)
                {
                    myRFIDReader.open();
                    myRFIDReader.waitForAttachment(3000);
                    myRFIDReader.Antenna = true;
                    myRFIDReader.LED = true;
                }
            }
            catch (PhidgetException ex) { MessageBox.Show(ex.Message); }
        }

        public void close()
        {
            try
            {
                if (myRFIDReader.Attached)
                {
                    myRFIDReader.LED = false;
                    myRFIDReader.Antenna = false;
                    myRFIDReader.close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Checking_Information_FormClosing(object sender, FormClosingEventArgs e)
        {
            //close the RFID when you close this application.
            close();
        }
    }
}
