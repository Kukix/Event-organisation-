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
    public partial class Event_Status : Form
    {
        private RFID myRFIDReader;

        Event NewEvent = null;
        Customer NewCustomer = null;

        DBconnectionCustomer dbcustomer = new DBconnectionCustomer();
        DBconnectionEvent dbEvent = new DBconnectionEvent();

        public Event_Status()
        {
            InitializeComponent();

            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Attach += new AttachEventHandler(ShowWhoIsAttached);
                myRFIDReader.Detach += new DetachEventHandler(ShowWhoIsDetached);
                myRFIDReader.Tag += new TagEventHandler(ProcessThisTag);
                myRFIDReader.TagLost += new TagEventHandler(ProcessThisTagLost);
            }
            catch (PhidgetException ex) { MessageBox.Show(ex.Message); }

            //lateron this part will be deleted. this is only for test without RFID.
            NewEvent = dbEvent.GeteventByName("playing3");
            NewCustomer = dbcustomer.FindCustomerByRFID("hellohellohellohellohellohellohellohellohello");
            LoadPersonInfo();
            if (NewCustomer.Add1Event(NewEvent) == -1)
            {
                MessageBox.Show("You have already joined in this event, you are not allowed to join in again.");
                return;
            }
            else
            {
                dbEvent.AddEventWithUser(NewCustomer, NewEvent);
                lbEventParciticipenter.Items.Add("Username: " + NewCustomer.UserName + " Name: " + NewCustomer.FirstName + " " + NewCustomer.LastName);
            }
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
            //lbname.Text = (e.Tag);
            NewCustomer = dbcustomer.FindCustomerByRFID(e.Tag);
            LoadPersonInfo();
            if (NewCustomer.Add1Event(NewEvent) == -1)
            {
                MessageBox.Show("You have already joined in this event, you are not allowed to join in again.");
                return;
            }
            else
            {
                dbEvent.AddEventWithUser(NewCustomer, NewEvent);
                lbEventParciticipenter.Items.Add("Username: " + NewCustomer.UserName + " Name: " + NewCustomer.FirstName + " " + NewCustomer.LastName);
            }
        }

        private void ProcessThisTagLost(object sender, TagEventArgs e)
        {
            NewCustomer = null;
            lbPersonInfo.Items.Clear();
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


        public void LoadPersonInfo()
        {
            string[] splits = NewCustomer.ToString().Split('\n');
            foreach (string s in splits)
            {
                lbPersonInfo.Items.Add(s);
            }
        }


        private void BTaddEvent_Click(object sender, EventArgs e)
        {
            NewEvent = dbEvent.GeteventByName(textBox1.Text);
            if (NewEvent == null)
                MessageBox.Show("Wrong name! Event not exsit");
            else
            {
                lbEventParciticipenter.Items.Clear();
                foreach (Customer c in dbEvent.LoadEvent(textBox1.Text))
                {
                    lbEventParciticipenter.Items.Add("Username: " + c.UserName + " Name: " + c.FirstName + " " + c.LastName);
                }
                MessageBox.Show("Event: " + NewEvent.EventName + " has started!");
                textBox1.Text = NewEvent.EventName;
            }
        }


        private void btclear_Click(object sender, EventArgs e)
        {
            lbEventParciticipenter.Items.Clear();
            lbPersonInfo.Items.Clear();
            textBox1.Text = "";
        }

        private void Event_Status_Load(object sender, EventArgs e)
        {
            load();
        }

        private void Event_Status_FormClosing(object sender, FormClosingEventArgs e)
        {
            close();
        }
    }
}
