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
    public partial class Normal_Shop : Form
    {
        //this is the application for the shops to sell or rent some products.
        //if you want to show the selling products, then clciking the get sell products button.
        //and for the rental products clicking the get all rental products button.
        //and you are only allowed to add rental products when you choose the rental products button.
        //aldo you are only allowed to add selling products when you choose the selling products button.
        //and the customer will take the order by this application.
        //also if they want to rent some thing they need to user this application. of course the operater will be our staff. not the customer themselves.
        //and the shop manager may be able to add some new products to his or her own shop(of course with the permission of this event organizer.)
        //and also shop manager will be able to change some properties of his or her own shop's products.

        private RFID myRFIDReader;

        DBconnectionItems dbitems;
        DBconnectCutomer dbcustomer;
        DBconnectionOrder dborder;
        DBconnectionOrderDetails dborderdetails;
        DBconnectionRental dbRental;

        bool IsNormalFood = true;

        Order NewOrder = null;
        Shop Myshop = null;

        string username = "";

        public Normal_Shop(string shopname)
        {
            InitializeComponent();
            timer1.Enabled = true;

            try
            {
                string shopName = shopname;
                //FileStream fs = new FileStream("../../../shop_name.txt", FileMode.Open, FileAccess.Read);
                //StreamReader sr = new StreamReader(fs);
                //shopName = sr.ReadLine();
                //sr.Dispose();
                //fs.Dispose();

                Myshop = new Shop(shopName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*for (int i = 0; i < 10; i++)
            {
                Items it = new Items("omg" + i.ToString(), 66.66m, unit.PerKilo, 10, " ");
                Listoffood.Items.Add(it.ToString());
                Myshop.AddNewItem(it);
            }
            Items it2 = new Items("omg", 65.66m, unit.PerKilo, 10, " ");
            Listoffood.Items.Add(it2.ToString());
            Myshop.AddNewItem(it2);
            Items it3 = new Items("om", 64.66m, unit.PerKilo, 10, " ");
            Listoffood.Items.Add(it3.ToString());
            Myshop.AddNewItem(it3);
            this part was for the test. 
            */

            dbitems = new DBconnectionItems(Myshop);
            dbRental = new DBconnectionRental(Myshop);
            dbitems.LoadFromDatabase();

            dbcustomer = new DBconnectCutomer();
            //test part will be deleted

            //
            updateListOfFood();

            //for RFID PART
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

        //rfid methods
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
            BTadd.Enabled = true;
            Btdelete.Enabled = true;
            BTtakeorder.Enabled = true;
            lbname.Text = ( e.Tag);
            username = dbcustomer.FindUsername(e.Tag);
            lbname.Text = username;
            lbBalance.Text = dbcustomer.GetBlance(username).ToString();
        }


        private void ProcessThisTagLost(object sender, TagEventArgs e)
        {
            BTadd.Enabled = false;
            Btdelete.Enabled = false;
            BTtakeorder.Enabled = false;
            username = "";
            lbBalance.Text = "";
            lbname.Text = "";
        }
        //end of rfid methods.

        public void updateListOfFood()
        {
            Listoffood.Items.Clear();
            foreach (Items i in Myshop.GetAllItems())
            {
                Listoffood.Items.Add(i.ToString());
            }
        }

        private void BTtakeorder_Click(object sender, EventArgs e)
        {
            //take the order and update the database.
            try
            {
                string temporder = "Hello: " + username + "\n";
                decimal balance = 0m;
                if (ListofOrder.Items.Count == 0)
                {
                    MessageBox.Show("ops Error.");
                    return;
                }
                //once this button is clicked, the select food will be added to the right list.


                if (IsNormalFood)
                {
                    dborder = new DBconnectionOrder(NewOrder);
                    int orederid = dborder.AddOrder(username);
                    if (orederid == -1)
                    {
                        MessageBox.Show("sorry, you do not have so mych money left.");
                        return;
                    }
                    if (orederid == 0)
                    {
                        MessageBox.Show("ops Error.");
                        return;
                    }
                    dborderdetails = new DBconnectionOrderDetails(NewOrder);
                    dborderdetails.AddOrderDetails(orederid);
                    dbitems.UpdateDatabseItems(NewOrder);
                    balance = dbcustomer.GetBlance(username);

                    dbitems.LoadFromDatabase();
                    updateListOfFood();

                    foreach (string s in ListofOrder.Items)
                    {
                        temporder += s;
                        temporder += "\n";
                    }
                    temporder += "Totoal Price: " + NewOrder.TotalPrice + "\n";
                    temporder += "Balance: " + balance;

                }
                else
                {

                    dbRental.UpdateRentalRecord(NewOrder);
                    dbitems.UpdateDatabseItems(NewOrder);
                    balance = dbcustomer.GetBlance(username);

                    foreach (string s in ListofOrder.Items)
                    {
                        temporder += s;
                        temporder += "\n";
                    }
                    temporder += "Totoal Price: " + NewOrder.TotalPrice + "PerDay\n";
                    temporder += "Balance: " + balance;
                }


               
                MessageBox.Show(temporder);
                ListofOrder.Items.Clear();
                LBtotalPrice.Text = "0";
                // clear the order.
                NewOrder = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void UpdateListOfOrders()
        {
            ListofOrder.Items.Clear();
            foreach (OrderDetails od in NewOrder.Orders)
            {
                ListofOrder.Items.Add(od.ItemA.Name + "*" + od.Quantity + "*Price: " + od.ItemA.Price * od.Quantity);
            }
        }

        private void BTadd_Click(object sender, EventArgs e)
        {
            //add 1 order detail to the order.
            try
            {
                if (OrderTakenNumber.Value <= 0)
                {
                    MessageBox.Show("Wrong Input for with the taken Number");
                    return;
                }
                if (NewOrder == null)
                    NewOrder = new Order(DateTime.Now, Myshop,username);

                string[] temp = Listoffood.SelectedItem.ToString().Split(' ');

                //foreach (Items i in Myshop.GetAllItems())
                //{
                //    if (temp[0] == i.Name)
                //    {
                //        if (NewOrder.Add1order(i, (Int32)OrderTakenNumber.Value) == -1)
                //            MessageBox.Show("Insufficient Stuff Left.");
                //        else
                //        {
                //            decimal tempPrice = 0m;
                //            foreach (OrderDetails od in NewOrder.Orders)
                //            {
                //                if (od.ItemA.Name == i.Name)
                //                    tempPrice += od.ItemA.Price * od.Quantity;
                //            }

                //            int oldone = 0;
                //            int count = 0;
                //            bool repeat = false;

                //            List<string> tempstring = new List<string>();

                //            foreach (string ts in ListofOrder.Items)
                //            {
                //                tempstring.Add(ts);
                //            }

                //            foreach (string os in ListofOrder.Items)
                //            {

                //                if (os.Split('*')[0] == temp[0])
                //                {
                //                    oldone = Convert.ToInt32(os.Split('*')[1]);
                //                    repeat = true;
                //                    break;
                //                }
                //                count++;
                //            }

                //            if (repeat)
                //                tempstring[count] = temp[0] + "*" + (OrderTakenNumber.Value + oldone).ToString() +"*Price: "+ tempPrice;
                //            else
                //                tempstring.Add(temp[0] + "*" + (OrderTakenNumber.Value + oldone).ToString() + "*Price: " + tempPrice);

                //            ListofOrder.Items.Clear();
                //            foreach (string s in tempstring)
                //            {
                //                ListofOrder.Items.Add(s);
                //            }

                //            LBtotalPrice.Text = NewOrder.TotalPrice.ToString();
                //        }
                //    }
                //}

                foreach (Items i in Myshop.GetAllItems())
                {
                    if (temp[0] == i.Name)
                    {
                        if (NewOrder.Add1order(i, (Int32)OrderTakenNumber.Value) == -1)
                        {
                            MessageBox.Show("Insufficient Stuff Left.");
                            return;
                        }
                    }
                }

                UpdateListOfOrders();
                updateListOfFood();
                LBtotalPrice.Text = NewOrder.TotalPrice.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please choose one of the food.");
            }
        }

        private void Btdelete_Click(object sender, EventArgs e)
        {
            //delete one order detail from order.
            try
            {
                string tempstring = ListofOrder.SelectedItem.ToString();
                string[] splits = tempstring.Split('*');

                    foreach (OrderDetails od in NewOrder.Orders)
                    {
                        if (splits[0] == od.ItemA.Name)
                        {
                            Items t=null;
                            NewOrder.deleteItemFromOrder(splits[0], Convert.ToInt32(splits[1]));
                            foreach (Items it in Myshop.GetAllItems())
                            {
                                if (it.Name == splits[0])
                                    t = it;
                            }
                            NewOrder.Remove1order(t);
                            break;
                        }
                    }
                    List<string> temp = new List<string>();
                    foreach (string item in ListofOrder.Items)
                    {
                        temp.Add(item);
                    }
                    temp.RemoveAt(ListofOrder.SelectedIndex);
                    updateListOfFood();
                    ListofOrder.Items.Clear();
                    foreach (string s in temp)
                    {
                        ListofOrder.Items.Add(s);
                    }

                    LBtotalPrice.Text = NewOrder.TotalPrice.ToString();

                   /* List<OrderDetails> temp = new List<OrderDetails>();

                    bool repeat = false;

                    foreach (OrderDetails od in NewOrder.Orders)
                    {
                        int index = 0;
                        foreach (OrderDetails ot in temp)
                        {

                            if (od.ItemA.Name == ot.ItemA.Name)
                            {
                                repeat = true;
                                temp[index].Quantity += od.Quantity;
                            }
                            else
                            {
                                repeat = false; temp.Add(od);
                            }

                        }
                        if (repeat)
                        {
                            temp[index].Quantity += od.Quantity;
                        }
                        else
                        {
                            temp.Add(od);
                        }
                        for (int i = 0; i < temp.Count; i++)
                        {
                            if (od.ItemA.Name == temp[i].ItemA.Name)
                            {
                                repeat = true;
                                index = i;
                            }
                            else
                            {
                                repeat = false;
                            }
                        }

                    }

                    updateListOfFood();
                    ListofOrder.Items.Clear();
                    foreach (OrderDetails od in temp)
                    {
                        ListofOrder.Items.Add(od.ItemA.Name + "*" + od.Quantity.ToString());
                    }
                */
            }
            catch (Exception)
            {
                MessageBox.Show("Please choose the order you want to delete.");
            }
        }

        private void btsearch_Click(object sender, EventArgs e)
        {
            //this button will find the food you are looking for.
            try
            {
                if (tbsearch.Text == "")
                    MessageBox.Show("Input Information Please.");
                else
                {
                    int index = 0;
                    bool check = false;
                    foreach (string s in Listoffood.Items)
                    {
                        index++;
                        foreach (string st in s.Split(' '))
                        {
                            if (st == tbsearch.Text)
                            {
                                Listoffood.SelectedIndex = index - 1;
                                check = true;
                            }
                        }
                        if (check)
                            break;
                    }
                    if (!check)
                        MessageBox.Show("No such Items.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BTaddNewSpeecics_Click(object sender, EventArgs e)
        {
            //add new product to the shop and update the database.
            try
            {
                bool exsit = false;
                if (TBFoodName.Text == "" || TBprice.Text == "" || comboBox1.Text == "")
                    MessageBox.Show("Input Information needed please");
                else
                {
                    decimal price = 0m;
                    if (!decimal.TryParse(TBprice.Text, out price))
                    {
                        MessageBox.Show("input price not valid format!");
                        return;
                    }
                    foreach (string i in dbitems.GetAllNames())
                    {
                        if (i == TBFoodName.Text)
                            exsit = true;
                    }
                    if (!exsit)
                    {
                        if (comboBox1.Text == "Day"&&!IsNormalFood)
                        {
                            Items i = new Items(TBFoodName.Text, Convert.ToDecimal(TBprice.Text), unit.PerKilo, 0, tbDesc.Text);
                            dbRental.AddNewItem(i);
                            dbRental.LoadFromDatabase();
                        }
                        else
                        {
                            if (comboBox1.Text == "Kilo"&&IsNormalFood)
                            {
                                Items i = new Items(TBFoodName.Text, Convert.ToDecimal(TBprice.Text), unit.PerKilo, 0, tbDesc.Text);
                                dbitems.AddNewItem(i);
                                dbitems.LoadFromDatabase();
                            }
                            else
                            {
                                if (comboBox1.Text == "Stuck" && IsNormalFood)
                                {
                                    Items i = new Items(TBFoodName.Text, Convert.ToDecimal(TBprice.Text), unit.Perstuck, 0, tbDesc.Text);
                                    // update databse.
                                    dbitems.AddNewItem(i);
                                    dbitems.LoadFromDatabase();
                                }
                                else
                                {
                                    MessageBox.Show("ops Error.");
                                }
                            }
                        }
                        updateListOfFood();
                    }
                    else
                        MessageBox.Show("Product Exsit.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void BTaddStorge_Click(object sender, EventArgs e)
        {
            //add the left amount of a choosen product.
            try
            {
                if (StorageNumberAdded.Value <= 0)
                {
                    MessageBox.Show("Wrong Input for with the added Number");
                    return;
                }
                bool namefound = false;
                if (TBFoodName.Text == "" || StorageNumberAdded.Value == 0m)
                    MessageBox.Show("Input the Information please.");
                else
                {
                    foreach (Items i in Myshop.GetAllItems())
                    {
                        if (i.Name == TBFoodName.Text)
                        {
                            namefound = true;
                            //update database.
                        }
                    }
                    if (namefound)
                    {
                        if (!IsNormalFood)
                        {
                            dbitems.AddAmount(TBFoodName.Text, Convert.ToInt32(StorageNumberAdded.Value));
                            dbRental.LoadFromDatabase();
                            updateListOfFood();
                        }
                        else
                        {
                            dbitems.AddAmount(TBFoodName.Text, Convert.ToInt32(StorageNumberAdded.Value));
                            dbitems.LoadFromDatabase();
                            updateListOfFood();
                        }
                        MessageBox.Show("Added Successfully.");
                    }
                    else
                        MessageBox.Show("Food Name not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

       


        private void BTResetPrice_Click(object sender, EventArgs e)
        {
            //reset the product price and update the database.
            try
            {
                bool nameexsit = false;
                if (TBprice.Text == ""||TBFoodName.Text=="")
                    MessageBox.Show("Input the price please.");
                else
                {
                    decimal price = 0m;
                    if (!decimal.TryParse(TBprice.Text, out price))
                    {
                        MessageBox.Show("input price not valid format!");
                        return;
                    }
                    foreach (Items i in Myshop.GetAllItems())
                    {
                        if (i.Name == TBFoodName.Text)
                        {
                            //i.Price = Convert.ToDecimal(TBprice.Text);
                            nameexsit = true;
                        }
                    }

                    if (nameexsit)
                    {
                        if (!IsNormalFood)
                        {
                            dbRental.ResetPrice(TBFoodName.Text, Convert.ToDecimal(TBprice.Text));
                            dbRental.LoadFromDatabase();
                            updateListOfFood();
                        }
                        else
                        {
                            dbitems.ResetPrice(TBFoodName.Text, Convert.ToDecimal(TBprice.Text));
                            dbitems.LoadFromDatabase();
                            updateListOfFood();
                        }
                    }
                    else
                        MessageBox.Show("name do not exsit");
                }
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
            catch (PhidgetException ex) { MessageBox.Show(ex.Message); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            close();
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

        private void btRFIDS_Click(object sender, EventArgs e)
        {
            //start the RFID.
            load();
        }

        private void btRFIDC_Click(object sender, EventArgs e)
        {
            //close the RFID.
            close();
        }

        private void btDsort_Click(object sender, EventArgs e)
        {
            //sort the products list by left amount.
            Myshop.GetAllItems().Sort(new Comparison<Items>(SortByLeftnumber));
            updateListOfFood();
        }

        private int SortByLeftnumber(Items a, Items b)
        {
            return a.LeftStuffNumber.CompareTo(b.LeftStuffNumber);
        }

        private void btSortPrice_Click(object sender, EventArgs e)
        {
            //sort the products list by price.
            Myshop.GetAllItems().Sort();
            updateListOfFood();
        }

        private int SortByName(Items a, Items b)
        {
            return a.Name.CompareTo(b.Name);
        }

        private void btSortName_Click(object sender, EventArgs e)
        {
            //sort the products list by product name.
            Myshop.GetAllItems().Sort(new Comparison<Items>(SortByName));
            updateListOfFood();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //this button will let you access the selling products.
            IsNormalFood = true;
            NewOrder = null;
            LBtotalPrice.Text = "";
            ListofOrder.Items.Clear();
            dbitems.LoadFromDatabase();
            updateListOfFood();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this button will let you access the rental products.
            IsNormalFood = false;
            NewOrder = null;
            LBtotalPrice.Text = "";
            ListofOrder.Items.Clear();
            dbRental.LoadFromDatabase();
            updateListOfFood();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsNormalFood)
                dbitems.LoadFromDatabase();
            else
                dbRental.LoadFromDatabase();
            updateListOfFood();
        }

        private void Normal_Shop_Click(object sender, EventArgs e)
        {

        }

        private void Normal_Shop_MouseMove(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            timer1.Enabled = true;
        }
       
    }
}