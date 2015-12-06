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
                comboBox1.Items.Add(i);
            }

        }

        private void ShowWhoIsAttached(object sender, AttachEventArgs e)
        {
            MessageBox.Show("RFIDReader attached!, serial nr: " + e.Device.SerialNumber.ToString());
            if ((Int32)comboBox1.SelectedValue == dbCamp.GetCampID(e.Device.SerialNumber.ToString()))
                MessageBox.Show("Welcome!");
            else
                MessageBox.Show("Sorry you are not allowed to go in.");
        }

        private void ShowWhoIsDetached(object sender, DetachEventArgs e)
        {
            MessageBox.Show("RFIDReader detached!, serial nr: " + e.Device.SerialNumber.ToString());
           
        }

        private void ProcessThisTag(object sender, TagEventArgs e)
        {
            //lbname.Text = (e.Tag);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Attach += new AttachEventHandler(ShowWhoIsAttached);
                myRFIDReader.Detach += new DetachEventHandler(ShowWhoIsDetached);
                myRFIDReader.Tag += new TagEventHandler(ProcessThisTag);

                //test part
                if ((Int32)comboBox1.SelectedItem == dbCamp.GetCampID("hellohellohellohellohellohellohellohellohello"))
                    MessageBox.Show("Welcome!");
                else
                    MessageBox.Show("Sorry you are not allowed to go in.");
                //
            }
            catch (PhidgetException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
