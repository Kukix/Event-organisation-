using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Shpping_Order
{
    class DBconnectionItems
    {
        public Shop NewShop { get;private set; }

        connection connect = new connection();
        int shopID = 0;

        public DBconnectionItems(Shop s)
        {
            this.NewShop = s;
        }

        public int GetIDbyName(string Name)
        {
            int proID = 0;
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from product", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    //add to the food list here.
                    if (reader.GetString("product_name") == Name)
                        proID = Convert.ToInt32(reader.GetString("product_ID"));
                }
            }
            reader.Close();
            connection.Close();
            return proID;
        }

        public void LoadFromDatabase()
        {
            try
            {
                NewShop.AllItems.Clear();
                List<int> numberleft = new List<int>();
                List<int> proID = new List<int>();
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from shop", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        //add to the food list here.
                        if (reader.GetString("SHOP_NAME") == this.NewShop.StorageName)
                            shopID = Convert.ToInt32(reader.GetString("SHOP_ID"));
                    }
                }
                reader.Close();
               
                MySqlCommand command2 = new MySqlCommand("select * from shop_product where SHOP_ID=" + shopID, connection);
                MySqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2.HasRows)
                    {
                        //add to the food list here.

                        proID.Add(reader2.GetInt32("product_id"));
                        numberleft.Add(reader2.GetInt32("numberleft"));

                    }
                }
                reader2.Close();

                int index = 0;
                foreach (int i in proID)
                {
                    MySqlCommand command3 = new MySqlCommand("select * from product where product_id=" + i, connection);
                    MySqlDataReader reader3 = command3.ExecuteReader();
                    while (reader3.Read())
                    {
                        if (reader3.HasRows)
                        {
                            if (Convert.ToDecimal(reader3.GetString("rental_price")) == 0)
                            {
                                if (reader3.GetString("unit") == "PerKilo")
                                    NewShop.AddNewItem(new Items(reader3.GetString("product_name"), Convert.ToDecimal(reader3.GetString("price")), unit.PerKilo, numberleft[index], reader3.GetString("desc")));
                                else
                                    NewShop.AddNewItem(new Items(reader3.GetString("product_name"), Convert.ToDecimal(reader3.GetString("price")), unit.Perstuck, numberleft[index], reader3.GetString("desc")));
                            }
                            index++;
                        }
                    }
                    reader3.Close();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateDatabseItems(Order order)
        {
            try
            {
                int numberleft = 0;
                //update the database here
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                foreach (OrderDetails od in order.Orders)
                {
                    int proID = GetIDbyName(od.ItemA.Name);
                    //MySqlCommand commandi = new MySqlCommand("select * from product", connection);
                    //MySqlDataReader reader = commandi.ExecuteReader();
                    //while (reader.Read())
                    //{
                    //    if (reader.HasRows)
                    //    {
                    //        //add to the food list here.
                    //        if (reader.GetString("product_name") == od.ItemA.Name)
                    //            proID = Convert.ToInt32(reader.GetString("product_ID"));
                    //    }
                    //}
                    //reader.Close();
                    MySqlCommand commandc = new MySqlCommand("select * from shop_product where product_id=" + proID, connection);
                    MySqlDataReader reader2 = commandc.ExecuteReader();
                    while (reader2.Read())
                    {
                        if (reader2.HasRows)
                        {
                            //add to the food list here.
                            numberleft = reader2.GetInt32("numberleft");
                        }
                    }
                    reader2.Close();
                    numberleft -= od.Quantity;
                    MySqlCommand command = new MySqlCommand("update shop_product set numberleft= "+numberleft+" where product_id= "+proID, connection);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddNewItem(Items i)
        {
            try
            {
                //update the database here
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand commandc = new MySqlCommand("select count(*) from product", connection);
                int count = Convert.ToInt32(commandc.ExecuteScalar());
                count++;
                MySqlCommand command = new MySqlCommand("insert into product values(" + count + ",'" + i.Name + "'," + i.Price + ",0,'" + i.Unit + "','" + i.Description + "')", connection);
                command.ExecuteNonQuery();

                MySqlCommand command2 = new MySqlCommand("insert into shop_product values(" + shopID + "," + count + ",null,0)", connection);
                command2.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddAmount(string Name,int number)
        {
           try{
                //update the database here
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                int proID = 0;
                int numberleft = 0;

                MySqlCommand command = new MySqlCommand("select * from product", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        //add to the food list here.
                        if (reader.GetString("product_name") == Name)
                            proID = Convert.ToInt32(reader.GetString("product_ID"));
                    }
                }
                reader.Close();

                MySqlCommand commandc = new MySqlCommand("select * from shop_product where product_id="+proID, connection);
                MySqlDataReader reader2 = commandc.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2.HasRows)
                    {
                        //add to the food list here.
                           numberleft = reader2.GetInt32("numberleft");
                    }
                }
                reader2.Close();

                numberleft += number;

                MySqlCommand commanda = new MySqlCommand("Update shop_product set numberleft= " + numberleft + " where product_id=" +proID, connection);
                commanda.ExecuteNonQuery();

                connection.Close();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
        }

        public void ResetPrice(string Name, decimal Price)
        {
            try
            {
                //update the database here
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("Update product set price= " + Price + " where product_name='" + Name+"'", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<string> GetAllNames()
        {
            List<string> temp = new List<string>();
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from product", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    //add to the food list here.
                    temp.Add(reader.GetString("product_name"));
                }
            }
            reader.Close();
            return temp;
        }

    }
}
