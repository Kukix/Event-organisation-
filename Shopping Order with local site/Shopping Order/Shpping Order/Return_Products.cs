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
        Shop Myshop = null;

        string username;

        private RFID myRFIDReader;

        DBconnectionRental dbRental = null;
        DBconnectCutomer dbcustomer = null;

        List<Rental> rentals = null;
        List<Rental> returns = null;

        public Return_Products()
        {
            InitializeComponent();

            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Attach += new AttachEventHandler(ShowWhoIsAttached);
                myRFIDReader.Detach += new DetachEventHandler(ShowWhoIsDetached);
                myRFIDReader.Tag += new TagEventHandler(ProcessThisTag);
            }
            catch (PhidgetException ex) { MessageBox.Show(ex.Message); }

            try
            {
                string shopName = "";
                FileStream fs = new FileStream("../../../shop_name.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                shopName = sr.ReadLine();
                //this.Connection = "server=athena01.fhict.local;Uid=dbi289315;Pwd=ZuD7UVJ5jv;Database=dbi289315;";
                sr.Dispose();
                fs.Dispose();

                Myshop = new Shop(shopName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dbRental = new DBconnectionRental(Myshop);
            dbcustomer = new DBconnectCutomer();

            //test part will be deleted
            username = dbcustomer.FindUsername("hellohellohellohellohellohellohellohellohello");
            lbname.Text = username;
            lbBalance.Text = dbcustomer.GetBlance(username).ToString();
            rentals = dbRental.GetAllRentals(username, Myshop.StorageName);
            returns = new List<Rental>();
            UpdateList();
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
            username = dbcustomer.FindUsername("hellohellohellohellohellohellohellohellohello");
            lbname.Text = username;
            lbBalance.Text = dbcustomer.GetBlance(username).ToString();
            rentals = dbRental.GetAllRentals(username, Myshop.StorageName);
            returns = new List<Rental>();
            ListofProducts.Items.Clear();
            UpdateList();
        }

        private void ShowWhoIsDetached(object sender, DetachEventArgs e)
        {
            MessageBox.Show("RFIDReader detached!, serial nr: " + e.Device.SerialNumber.ToString());
            username = "";
            lbBalance.Text = "";
            rentals = null;
            returns = null;
            ListofProducts.Items.Clear();
        }

        private void ProcessThisTag(object sender, TagEventArgs e)
        {
            //lbname.Text = (e.Tag);
        }

        private void btadd_Click(object sender, EventArgs e)
        {
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbReturnNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != '\b') && (e.KeyChar != '.'))
                e.KeyChar = '\0';
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
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


    }
}
