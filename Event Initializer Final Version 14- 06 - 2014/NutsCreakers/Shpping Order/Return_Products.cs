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
using System.IO;

namespace Shpping_Order
{
    public partial class Return_Products : Form
    {

        //this application is used for returning the products.
        //when the customer put their RFID tag on the scene, it should show all the products he or she has rent.
        //and you can choose which products does the customer want to return.
        //if you do not fill in the number you want to return it default return all of the choosen one.
        //if you fill in the number you want to return, it will return some amount of them as you indicate.(of course not more than the amount you borrowed.)
        //and when return successfully, update the database.

        Shop Myshop = null;

        string username;

        private RFID myRFIDReader;

        DBconnectionRental dbRental = null;
        DBconnectCutomer dbcustomer = null;

        List<Rental> rentals = null;
        List<Rental> returns = null;

        public Return_Products(string name)
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

            try
            {
                string shopName = name;
                //FileStream fs = new FileStream("../../../shop_name.txt", FileMode.Open, FileAccess.Read);
                //StreamReader sr = new StreamReader(fs);
                //shopName = sr.ReadLine();
                ////this.Connection = "server=athena01.fhict.local;Uid=dbi289315;Pwd=ZuD7UVJ5jv;Database=dbi289315;";
                //sr.Dispose();
                //fs.Dispose();

                Myshop = new Shop(shopName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dbRental = new DBconnectionRental(Myshop);
            dbcustomer = new DBconnectCutomer();

            //test part will be deleted
            //username = dbcustomer.FindUsername("hellohellohellohellohellohellohellohellohello");
            //lbname.Text = username;
            //lbBalance.Text = dbcustomer.GetBlance(username).ToString();
            //rentals = dbRental.GetAllRentals(username, Myshop.StorageName);
            //returns = new List<Rental>();
            //UpdateList();
            //

        }

        public void UpdateList()
        {
            ListofProducts.Items.Clear();
            ListofRetrunStuff.Items.Clear();
            ListofProducts.Items.Add("Username: " + username);
            if (rentals != null)
            {
                foreach (Rental r in rentals)
                {
                    ListofProducts.Items.Add(r.ToString());
                }
            }
            if (returns != null)
            {
                foreach (Rental r in returns)
                {
                    ListofRetrunStuff.Items.Add(r.ToString());
                }
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
            username = dbcustomer.FindUsername(e.Tag);
            lbname.Text = username;
            lbBalance.Text = dbcustomer.GetBlance(username).ToString();
            rentals = dbRental.GetAllRentals(username, Myshop.StorageName);
            returns = new List<Rental>();
            ListofProducts.Items.Clear();
            UpdateList();
            //lbname.Text = (e.Tag);
        }

        private void ProcessThisTagLost(object sender, TagEventArgs e)
        {
            username = "";
            lbBalance.Text = "";
            lbname.Text = "";
            rentals = null;
            returns = null;
            ListofProducts.Items.Clear();
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            //add the products you want to return to the return list.
            try 
            {
                if (tbReturnNumber.Text == "")
                {
                    returns.Add(rentals[ListofProducts.SelectedIndex - 1]);
                    rentals.RemoveAt(ListofProducts.SelectedIndex-1);
                    UpdateList();
                }
                else
                {
                    if (Convert.ToInt32(tbReturnNumber.Text) > rentals[ListofProducts.SelectedIndex-1].Quantity)
                    {
                        MessageBox.Show("Too many!");
                        return;
                    }
                    else
                    {
                        int temp = rentals[ListofProducts.SelectedIndex-1].Quantity;
                        Rental tempr = new Rental(rentals[ListofProducts.SelectedIndex - 1].Username, rentals[ListofProducts.SelectedIndex - 1].ProName, rentals[ListofProducts.SelectedIndex - 1].RentTime, rentals[ListofProducts.SelectedIndex - 1].Quantity, rentals[ListofProducts.SelectedIndex - 1].Price);
                        tempr.returnsome(tempr.Quantity - Convert.ToInt32(tbReturnNumber.Text));
                        returns.Add(tempr);
                        rentals[ListofProducts.SelectedIndex-1].returnsome(Convert.ToInt32(tbReturnNumber.Text));
                        UpdateList();
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("ops Error occurs.");
            }
        }

        private void tbReturnNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != '\b') && (e.KeyChar != '.'))
                e.KeyChar = '\0';
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            //delete the products you do not want to return from the return list.
            try
            {
                rentals.Add(returns[ListofRetrunStuff.SelectedIndex]);
                returns.RemoveAt(ListofRetrunStuff.SelectedIndex);
                UpdateList();
            }
            catch (Exception)
            {
                MessageBox.Show("Please choose a product.");
            }
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            //return the choosen product and update the database.
            if (ListofRetrunStuff.Items.Count == 0)
            {
                MessageBox.Show("ops Error!");
                return;
            }

            decimal totalPrice = 0m;
            string OutPut = "Hello: " +username +"\n";

            foreach (Rental r in returns)
            {
                r.SetPrice(dbRental.GetPriceByName(r.ProName));
                TimeSpan ts = DateTime.Now.Subtract(Convert.ToDateTime(r.RentTime));
                OutPut += r.ToString() +" Return Time: "+DateTime.Now.ToString()+ "  Price: " + r.Price * r.Quantity * Convert.ToInt32(ts.TotalDays) + "\n";
                totalPrice += r.Price * r.Quantity * Convert.ToInt32(ts.TotalDays);
            }
            OutPut += "Total Price: " + totalPrice;

            if (totalPrice > dbcustomer.GetBlance(username))
            {
                MessageBox.Show("You do not have so much money left.");
                return;
            }

            foreach (Rental r in returns)
            {
                TimeSpan ts = DateTime.Now.Subtract(Convert.ToDateTime(r.RentTime));
                dbRental.UpdateReturns(r, r.Price * r.Quantity * Convert.ToInt32(ts.TotalDays));
            }

            dbRental.UpdateBalance(totalPrice, username);
            lbBalance.Text = dbcustomer.GetBlance(username).ToString();
            
            MessageBox.Show(OutPut);
            returns = new List<Rental>();
            UpdateList();
            ListofRetrunStuff.Items.Clear();
        }

        private void Return_Products_Load(object sender, EventArgs e)
        {
            load();
        }

        private void Return_Products_FormClosing(object sender, FormClosingEventArgs e)
        {
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

    }
}
