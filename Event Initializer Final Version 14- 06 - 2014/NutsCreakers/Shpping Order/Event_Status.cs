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
        //this application is for the activities.
        //first you need to type the activity name and then you can initialize the application for that activity.
        //then every time a customer join in this activity, you should get some message and update the databse.

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
            catch (PhidgetException) { MessageBox.Show("ops Error!"); }
           
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
            //every time a customer join in this activity, update the databse.
            //lbname.Text = (e.Tag);
            try
            {
                NewCustomer = dbcustomer.FindCustomerByRFID(e.Tag);
                LoadPersonInfo();
                if (!dbEvent.EventAvailiable(NewEvent))
                {
                    MessageBox.Show("ops this event is at capacity now.");
                    return;
                }
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
            catch (Exception)
            {
                MessageBox.Show("ops Error! Event not started yet!");
            }
        }

        private void ProcessThisTagLost(object sender, TagEventArgs e)
        {
            try
            {
                NewCustomer = null;
                lbPersonInfo.Items.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            catch (PhidgetException) { MessageBox.Show("ops Error!"); }
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
            //start this application for a specific activity.
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
            //clear the information.
            lbEventParciticipenter.Items.Clear();
            lbPersonInfo.Items.Clear();
            textBox1.Text = "";
        }

        private void Event_Status_Load(object sender, EventArgs e)
        {
            //start the RFID.
            load();
        }

        private void Event_Status_FormClosing(object sender, FormClosingEventArgs e)
        {
            //close the RFID.
            close();
        }
    }
}
