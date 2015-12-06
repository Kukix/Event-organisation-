using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shpping_Order
{
    public partial class Specific_Admin : Form
    {
        DBconnectionSpecificAdmin dbSAdmin = null;

        public Specific_Admin()
        {
            InitializeComponent();
            dbSAdmin = new DBconnectionSpecificAdmin();

            try
            {
                comboBox1.Items.Clear();
                foreach (string s in dbSAdmin.GetAllEventNames())
                {
                    comboBox1.Items.Add(s);
                }

                comboBox2.Items.Clear();
                foreach (string s in dbSAdmin.GetAllShopNames())
                {
                    comboBox2.Items.Add(s);
                    lbShopSaleShopNames.Items.Add(s);
                }

                cbCamp.Items.Clear();
                foreach (int i in dbSAdmin.GetAllCampIDs())
                {
                    if (i == 0)
                        continue;
                    cbCamp.Items.Add(i.ToString());
                }

                cbUsernameEx.Items.Clear();
                foreach (string s in dbSAdmin.GetAllUsernames())
                {
                    if (dbSAdmin.GetRFIDByUsername(s) == "")
                        continue;
                    cbusername.Items.Add(s);
                    cbUsernameEx.Items.Add(s);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Event temp = dbSAdmin.GeteventByName(comboBox1.Text);
                lbEventParticipants.Items.Clear();
                string[] splits = temp.ToString().Split('\n');
                foreach (string s in splits)
                {
                    lbEventParticipants.Items.Add(s);
                }
                lbEventParticipants.Items.Add("Number of Participants is: " + dbSAdmin.CountEventParticipants(comboBox1.Text) + "\n");
                lbEventParticipants.Items.Add("Info of participants: \n");
                foreach (Customer c in dbSAdmin.GetEventParticipants(comboBox1.Text))
                {
                    lbEventParticipants.Items.Add("Username: " + c.UserName + " Name: " + c.FirstName + " " + c.LastName + "\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {

                //if (!int.TryParse(tbCamp.Text, out campID))
                //{
                //    MessageBox.Show("ops Error occurs.");
                //    return;
                //}
                //if (dbSAdmin.FindCampInfoById(campID) == "")
                //{
                //    MessageBox.Show("CampID do not exsit.");
                //    return;
                //}
                if (cbCamp.Text == "")
                {
                    MessageBox.Show("please choose one camp site.");
                    return;
                }

                int campID = Convert.ToInt32(cbCamp.Text);
                lbCampAvailablity.Items.Clear();

                string[] splits = dbSAdmin.FindCampInfoById(campID).Split('\n');
                foreach (string s in splits)
                {
                    lbCampAvailablity.Items.Add(s);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbShopProfit.Items.Clear();
                lbShopProfit.Items.Add("Shopname: " + comboBox2.Text);
                lbShopProfit.Items.Add("Total Receiving: " + (dbSAdmin.GetTotalReceiveForOneShop(comboBox2.Text) + dbSAdmin.GetTotalReceiveForOneShopRental(comboBox2.Text)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btFindByusername_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbusername.Text == "")
                {
                    MessageBox.Show("please choose one username.");
                    return;
                }
                //if (!dbSAdmin.UsernameExsit(textBox1.Text))
                //{
                //    MessageBox.Show("Ops Username do not exsit.");
                //    return;
                //}

                lbUserInfo.Items.Clear();
                Customer c = dbSAdmin.FindCustomerByUsername(cbusername.Text);
                if (dbSAdmin.UserInOrOut(cbusername.Text) == 1)
                    lbUserInfo.Items.Add("Status: InSide Of This Event.");
                else
                    lbUserInfo.Items.Add("Status: OutSide Of This Event.");
                string[] splits = c.InfoString().Split('\n');
                foreach (string  s in splits)
                {
                    lbUserInfo.Items.Add(s);
                }
                //lbUserInfo.Items.Add("Username: " + c.UserName);
                //lbUserInfo.Items.Add("Name: " + c.FirstName + c.LastName);
                //lbUserInfo.Items.Add("Phone: " + c.Phonenumber);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!dbSAdmin.UsernameExsit(textBox3.Text))
                //{
                //    MessageBox.Show("Ops Username do not exsit.");
                //    return;
                //}
                if (cbUsernameEx.Text=="")
                {
                    MessageBox.Show("please choose one username.");
                    return;
                }

                lbPersonalExpense.Items.Clear();
                lbPersonalExpense.Items.Add("Personal Expense for shopping: " + dbSAdmin.GetTotalReceiveForOneUser(cbUsernameEx.Text));
                lbPersonalExpense.Items.Add("Personal Expense for Renting: " + dbSAdmin.GetTotalReceiveForOneUserRental(cbUsernameEx.Text));
                lbPersonalExpense.Items.Add("Personal Expense Total: " + (dbSAdmin.GetTotalReceiveForOneUser(cbUsernameEx.Text) + dbSAdmin.GetTotalReceiveForOneUserRental(cbUsernameEx.Text)));

            }
            catch (Exception)
            {
                MessageBox.Show("ops Error!");
            }
        }

        private void btByname_Click(object sender, EventArgs e)
        {
            try
            {
                lbUserInfo.Items.Clear();
                foreach (string s in dbSAdmin.FindCustomerByName(textBox1.Text))
                {
                    Customer c = dbSAdmin.FindUserByRFID(s);
                    if (dbSAdmin.UserInOrOut(textBox1.Text) == 1)
                        lbUserInfo.Items.Add("Status: InSide Of This Event.");
                    else
                        lbUserInfo.Items.Add("Status: OutSide Of This Event.");
                    string[] splits = c.InfoString().Split('\n');
                    foreach (string st in splits)
                    {
                        lbUserInfo.Items.Add(st);
                    }
                }
                
                //lbUserInfo.Items.Add("Username: " + c.UserName);
                //lbUserInfo.Items.Add("Name: " + c.FirstName + c.LastName);
                //lbUserInfo.Items.Add("Phone: " + c.Phonenumber);
                if (lbUserInfo.Items.Count == 0)
                    MessageBox.Show("Name do not exsit.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"\nWrong input, please input the name with space between firstname and lastname.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                lbShopSaleShopPros.Items.Clear();
                List<string> pros = dbSAdmin.GetProductsFromOneShop(lbShopSaleShopNames.SelectedItem.ToString());
                if(pros.Count==0)
                {
                    lbShopSaleShopPros.Items.Add("No products.");
                    return;
                }
                foreach (string s in pros)
                {
                    lbShopSaleShopPros.Items.Add(s);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please select an Item.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string shopname = lbShopSaleShopNames.SelectedItem.ToString();
                string proname = lbShopSaleShopPros.SelectedItem.ToString();
                if (proname == "No products.")
                {
                    return;
                }
                lbShopSaleProDetails.Items.Clear();
                int NumberSold = dbSAdmin.GetProductsNumberSold(proname, shopname);
                lbShopSaleProDetails.Items.Add(NumberSold + " of them are sold.");
                lbShopSaleProDetails.Items.Add("the price of this product is: " + dbSAdmin.GetPriceOfOneProduct(proname));
                lbShopSaleProDetails.Items.Add(dbSAdmin.GetLeftNumberOfOneProduct(proname, shopname) + " of them still in the shop.");
                lbShopSaleProDetails.Items.Add("total receiving is: " + (dbSAdmin.GetPriceOfOneProduct(proname) * NumberSold));
            }
            catch (Exception)
            {
                MessageBox.Show("ops Error occurs.");
            }
        }
    }
}
