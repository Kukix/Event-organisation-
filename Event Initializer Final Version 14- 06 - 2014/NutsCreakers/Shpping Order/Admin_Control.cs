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
    public partial class Admin_Control : Form
    {
        private RFID myRFIDReader;
        Customer Mycustomer = null;
        string filepath = "";

        DBconnectionAdmin admin = new DBconnectionAdmin();

        public Admin_Control()
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

            UpdateInformaiton();
            /////////////test part
            //Mycustomer = admin.FindCustomerByRFID("0a006f46e0");
            //if (Mycustomer != null)
            //{
            //    listBox1.Items.Clear();
            //    listBox1.Items.Add("Username: " + Mycustomer.UserName);
            //    listBox1.Items.Add("Name: " + Mycustomer.FirstName + " " + Mycustomer.LastName);
            //    listBox1.Items.Add("Balance: " + Mycustomer.Balance);
            //}
            //LabelRFID.Text = "0a006f46e0";
            //button2.Enabled = true;
            //////////end of test part.
        }

        private void UpdateInformaiton()
        {
            comboBox2.Items.Clear();
            foreach (int i in admin.GetAllCamps())
            {
                if (i == 0)
                    continue;
                comboBox2.Items.Add(i);
            }

            cbUseranme.Items.Clear();
            foreach (string s in admin.GetAllUsernames())
            {
                cbUseranme.Items.Add(s);
            }

            cbshops.Items.Clear();
            foreach (string s in admin.GetAllShopnames())
            {
                cbshops.Items.Add(s);
            }

            cbFoodName.Items.Clear();
            foreach (string s in admin.GetAllPronames())
            {
                cbFoodName.Items.Add(s);
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
            //only when the tag is in processing, you will be able to assign the RFID to a specific user.
            //otherwise you are not allowed to use the assign button.
            //lbname.Text = (e.Tag);
            Mycustomer = admin.FindCustomerByRFID(e.Tag);
            if (Mycustomer != null)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Username: " + Mycustomer.UserName);
                listBox1.Items.Add("Name: " + Mycustomer.FirstName + " " + Mycustomer.LastName);
                listBox1.Items.Add("Balance: " + Mycustomer.Balance);
            }
            LabelRFID.Text = e.Tag;
            button2.Enabled = true;
        }

        private void ProcessThisTagLost(object sender, TagEventArgs e)
        {
            Mycustomer = null;
            listBox1.Items.Clear();
            LabelRFID.Text = "RFID code";
            button2.Enabled = false;
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

        private void Admin_Control_FormClosing(object sender, FormClosingEventArgs e)
        {
            //close the RFID when you close the form.
            close();
        }

        private void Admin_Control_Load(object sender, EventArgs e)
        {
            //open the RFID when you open the form.
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create a new shop here.
            //information will be checked and the the form should give different message according to the return value of the adding shop method.

            if (tbshopname.Text == "")
            {
                MessageBox.Show("Please input shop name.");
                return;
            }
            string shopName = tbshopname.Text;
            string desc = rtbShopDesc.Text;
            if (admin.SaveShop(shopName, desc) == 1)
            {
                MessageBox.Show("Successfully added!");
                return;
            }
            if (admin.SaveShop(shopName, desc) == -1)
            {
                MessageBox.Show("Ops, Error !");
                return;
            }
            if (admin.SaveShop(shopName, desc) == 0)
            {
                MessageBox.Show("Ops Shop name exsit! ");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //it will assign the RFID code to the user
            try
            {
                if (cbUseranme.Text == "")
                {
                    MessageBox.Show("Input Username Please.");
                    return;
                }
                string user = cbUseranme.Text;
                string code = LabelRFID.Text;
                if (admin.SaveRFID(code, user) == 1)
                {
                    MessageBox.Show("Successfully. ");
                    return;
                }
                if (admin.SaveRFID(code, user) == 0)
                {
                    MessageBox.Show("Ops Username not exsit.");
                    return;
                }
                if (admin.SaveRFID(code, user) == -1)
                {
                    MessageBox.Show("Ops Error ! ");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //it will add a new product to the evet. but not assign to any shop yet.
            //it should check the information about the product you want to add.
            //and will give different message according to the information of the product you want to add.

            try
            {
                if (tbProductName.Text == "" )
                {
                    MessageBox.Show("Wrong Input Information.");
                    return;
                }

                string productName = tbProductName.Text;
                decimal price = numProductPrice.Value;
                decimal rental = 0m;
                string desc = tbdesc.Text;

                if (checkBox1.Checked)
                {
                    if (numRentPrice.Value<=0)
                    {
                        MessageBox.Show("Wrong Input Information.");
                        return;
                    }
                    rental = numRentPrice.Value;
                    Items i = null;
                    if (comboBox1.Text == "Kile")
                    {
                        i = new Items(productName, rental, unit.PerDay, 0, desc);
                    }
                    else
                    {
                        i = new Items(productName, rental, unit.PerDay, 0, desc);
                    }
                    admin.SaveProductRental(i);
                }
                else
                {
                    if (comboBox1.Text == "" || numProductPrice.Value<=0)
                    {
                        MessageBox.Show("Wrong Input Information.");
                        return;
                    }
                    Items i = null;
                    if (comboBox1.Text == "Kile")
                    {
                        i = new Items(productName, price, unit.PerKilo, 0, desc);
                    }
                    else
                    {
                        i = new Items(productName, price, unit.Perstuck, 0, desc);
                    }
                    admin.SaveProduct(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //check if the product is a rental one.
            //if it is then you will need the rental price otherwise you do not need it.
            if (checkBox1.Checked)
            {
                numProductPrice.Value = 0;
                numRentPrice.Enabled = true;
            }
            else
            {
                numProductPrice.Value = 0;
                numRentPrice.Enabled = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //it will assign the campID for the user.
            //also it will give you different message according to the camp you choose.
            try
            {
                if (cbUseranme.Text=="")
                {
                    MessageBox.Show("Input Username Please.");
                    return;
                }
                string user = cbUseranme.Text;
                int campID = Convert.ToInt32(comboBox2.Text);
                if (admin.SaveCampID(campID, user) == 1)
                {
                    MessageBox.Show("Successfully. ");
                    return;
                }
                if (admin.SaveCampID(campID, user) == 0)
                {
                    MessageBox.Show("Ops Username not exsit.");
                    return;
                }
                if (admin.SaveCampID(campID, user) == -1)
                {
                    MessageBox.Show("Ops Error ! ");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //it will assign the product to a specific shop.
            //and also information about both shop and product will be checked before assigned.

            if (cbshops.Text == "" || cbFoodName.Text == "")
                MessageBox.Show("Input Informaton please.");
            else
            {
                admin.AssignToShop(cbshops.Text,cbFoodName.Text);
            }
        }

        private void btAddEvent_Click(object sender, EventArgs e)
        {
            //add an new activity to this event.
            //and also information about this activity you want to add will be checked before.

            if (tbEventLocation.Text == "" || tbEventName.Text == "")
            {
                MessageBox.Show("Input Information Please.");
                return;
            }

            int max;
            if (!int.TryParse(tbMaxNumber.Text, out max))
            {
                MessageBox.Show("ops Error occurs.");
                return;
            }

            try
            {
                Event NewEvent = new Event(tbEventName.Text, richTextBoxEventDesc.Text, tbEventLocation.Text, dateTimePicker1.Value.ToString(),max);
                admin.AddEvent(NewEvent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btcharge_Click(object sender, EventArgs e)
        {
            //charge for someone here. and also update the logfile.
            try
            {
                if (tbcharge.Text == "")
                {
                    MessageBox.Show("pleasee input information.");
                    return;
                }
                decimal price = 0m;
                if (!decimal.TryParse(tbcharge.Text, out price))
                {
                    MessageBox.Show("input price not valid format!");
                    return;
                }

                admin.ChargeAccount(Convert.ToDecimal(tbcharge.Text), Mycustomer.UserName);
                MessageBox.Show("Successfully charged.");
                listBox1.Items.Clear();
                listBox1.Items.Add("Username: " + Mycustomer.UserName);
                listBox1.Items.Add("Name: " + Mycustomer.FirstName + " " + Mycustomer.LastName);
                listBox1.Items.Add("Balance: " + admin.GetBalance(Mycustomer.UserName));


                int countLine = 0;
                int totalDepo = 0;
                List<string> temp = new List<string>();
                FileStream fs = new FileStream("../../../logfile.txt", FileMode.Open, FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(fs);
                string s = sr.ReadLine();
                while ( s!= null)
                {
                    countLine++;
                    if (countLine == 3)
                        totalDepo = Convert.ToInt32(s);

                    temp.Add(s);
                    s = sr.ReadLine();
                }
                totalDepo++;
                countLine = 0;
                sr.Dispose();
                fs.Dispose();

                FileStream nfs = new FileStream("../../../logfile.txt", FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(nfs);
                foreach (string st in temp)
                {
                    countLine++;
                    if (countLine == 3)
                    {
                        sw.WriteLine(totalDepo + "");
                    }
                    else
                        sw.WriteLine(st);
                }
                sw.WriteLine(LabelRFID.Text + DateTime.Now.ToString("ddHHmmss") + " " + Convert.ToDecimal(tbcharge.Text));
                sw.Dispose();
                nfs.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbcharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will make you can only put numbers into this textbox.
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != '\b') && (e.KeyChar != '.'))
                e.KeyChar = '\0';
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {  //the user pushed the OK-button of openFileDialog1
                filepath = openFileDialog1.FileName;
            }
            else
            {  //the user pushed the CANCEL-button of openFileDialog1
                MessageBox.Show("You pushed the CANCEL-button.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //charge accounts according to the logfiles.
            try
            {
                if (filepath == "")
                {
                    MessageBox.Show("please choose a logfile!");
                    return;
                }

                int countLine = 0;
                List<string> temp = new List<string>();
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(fs);
                string s = sr.ReadLine();
                while (s != null)
                {
                    countLine++;
                    if (countLine >= 4)
                    {
                        temp.Add(s);
                    }
                    s = sr.ReadLine();
                }
                sr.Dispose();
                fs.Dispose();

                listBox2.Items.Clear();
                foreach (string str in temp)
                {
                    string st = str.Substring(0, 10);
                    decimal c = Convert.ToDecimal(str.Substring(18, str.Length - 18));
                    Customer tcustomer = admin.FindCustomerByRFID(st);
                    admin.ChargeAccount(c, tcustomer.UserName);
                    listBox2.Items.Add("useranme: " + tcustomer.UserName + " Name: " + tcustomer.FirstName + " " + tcustomer.LastName + "  charged  " + c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbcamplocation.Text == "" || tbMaxCamp.Text == "")
                {
                    MessageBox.Show("please input informaton!");
                    return;
                }

                int max;
                if (!int.TryParse(tbMaxCamp.Text, out max))
                {
                    MessageBox.Show("input information format wrong.");
                    return;
                }
                Camp newcamp = new Camp(tbcamplocation.Text, max);
                admin.CreateACamp(newcamp);
                MessageBox.Show("Added successfully.");
            }
            catch (Exception)
            {
                MessageBox.Show("ops Error!");
            }
        }

        private void BTResetPrice_Click(object sender, EventArgs e)
        {
            try
            {
                 if (cbFoodName.Text == "" || NPickerResetPrice.Value==0)
                {
                    MessageBox.Show("Please input correct information!");
                    return;
                 }
                int i = admin.IsRental(cbFoodName.Text);
                if (i == 0)
                {
                    MessageBox.Show("Ops Error!");
                    return;
                }
                if (i == 1)
                {
                    admin.ResetPriceRental(cbFoodName.Text, Convert.ToDecimal(NPickerResetPrice.Value));
                }
                else
                {
                    admin.ResetPrice(cbFoodName.Text, Convert.ToDecimal(NPickerResetPrice.Value));
                }
                MessageBox.Show("Successfully changed.");
            }
            catch (Exception)
            {
                MessageBox.Show("Ops Error!");
            }
        }

        private void BTaddStorge_Click(object sender, EventArgs e)
        {
            try 
            {
                if (cbFoodName.Text == "" || NumberAdded.Value == 0||cbshops.Text=="")
                {
                    MessageBox.Show("Please input correct information!");
                    return;
                }
                admin.AddAmount(cbFoodName.Text, Convert.ToInt32(NumberAdded.Value), cbshops.Text);
                MessageBox.Show("Added successfully.");
            }
            catch (Exception)
            {
                MessageBox.Show("Ops Error!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UpdateInformaiton();
        }
    }
}