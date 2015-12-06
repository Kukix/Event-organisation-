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
    public partial class Entrance_Application : Form
    {
        //this application will be used in the entrance.
        //when someone pass the gate it will give a proper message and update the database.
        //if the customer go out. it should give a message like "remember to come back username here."
        //and if the customer go in from outside. it should give a message like "welcome to come back username here".

        private RFID myRFIDReader;
        DBconnectionCustomer dbcustomer = null;
        Customer newcustomer = null;

        public Entrance_Application()
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
                int status;
                dbcustomer.CustomerCheckInOut(newcustomer, out status);              
                if (status == 0)
                    MessageBox.Show("Remember to be back " + newcustomer.UserName);
                else
                    MessageBox.Show("Welcome back " + newcustomer.UserName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcessThisTagLost(object sender, TagEventArgs e)
        {
            newcustomer = null;
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

        private void Entrance_Application_Load(object sender, EventArgs e)
        {
            load();
        }

        private void Entrance_Application_FormClosing(object sender, FormClosingEventArgs e)
        {
            close();
        }
    }
}
