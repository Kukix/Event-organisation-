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
    public partial class Camp_site : Form
    {
        private RFID myRFIDReader;
        DBconnectCamp dbCamp = null;


        public Camp_site()
        {
            InitializeComponent();
            dbCamp = new DBconnectCamp();

           foreach (int  i in dbCamp.GetAllCampIDs())
            {
                if (i == 0)
                    continue;
                comboBox1.Items.Add(i);
            }

           try
           {

               myRFIDReader = new RFID();
               myRFIDReader.Attach += new AttachEventHandler(ShowWhoIsAttached);
               myRFIDReader.Detach += new DetachEventHandler(ShowWhoIsDetached);
               myRFIDReader.Tag += new TagEventHandler(ProcessThisTag);

           }
           catch (PhidgetException)
           {
               MessageBox.Show("ops Error!");
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
            //it will check if you are allowed to go in this camp or not.
            //and it should show you a proper message to indicate that.
            try
            {
                if ((Int32)comboBox1.SelectedItem == dbCamp.GetCampID(e.Tag))
                    MessageBox.Show("Welcome!");
                else
                    MessageBox.Show("Sorry you are not allowed to go in.");
            }
            catch (Exception)
            {
                MessageBox.Show("ops Error!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this button will strat the application for a specific camp site
            //after starting it only the users who belong to this camp site will be allowed to go in.
            //others will be blocked out.

            if (comboBox1.Text == "")
            {
                MessageBox.Show("please choose a camp site.");
                return;
            }
            try
            {
                button2.Enabled = true;
                button1.Enabled = false;
                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Camp_site_Load(object sender, EventArgs e)
        {
            //load();
        }

        private void Camp_site_FormClosing(object sender, FormClosingEventArgs e)
        {
            //close the RFID when you close this application.

            close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            //if you want to use this application for another camp site you need to close it for the current one first
            //and then you can open it for another one.
            try
            {
                close();
                comboBox1.Text = "";
                button2.Enabled = false;
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
