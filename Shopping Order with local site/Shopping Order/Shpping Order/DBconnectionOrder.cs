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
    class DBconnectionOrder
    {
        public Order Myorder { get; private set; }
        connection connect = new connection();

        public DBconnectionOrder(Order order)
        {
            this.Myorder = order;
        }

        public int GetUserIDbyName(string Name)
        {
            int proID = 0;
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from user", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    //add to the food list here.
                    if (reader.GetString("username") == Name)
                        proID = reader.GetInt32("user_id");
                }
            }
            reader.Close();
            connection.Close();
            return proID;
        }

        public int GetShopIDbyName(string Name)
        {
            int proID = 0;
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
                    if (reader.GetString("shop_name") == Name)
                        proID = Convert.ToInt32(reader.GetString("shop_ID"));
                }
            }
            reader.Close();
            connection.Close();
            return proID;
        }

        public int AddOrder(string username)
        {
            //add the order to the customer with this username.
            try
            {
                int userID = GetUserIDbyName(Myorder.Username);
                int shopID = GetShopIDbyName(Myorder.Shop.StorageName);
                //update the database here

                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                MySqlCommand commandc = new MySqlCommand("SELECT count(*) FROM `order`", connection);
                int count = Convert.ToInt32(commandc.ExecuteScalar());
                count++;

                MySqlCommand command = new MySqlCommand("INSERT INTO `order` values(" + count + "," + userID + "," + shopID + ",'" + Myorder.TotalPrice + "','" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString() + "')", connection);
                command.ExecuteNonQuery();
                //insert into order values("+count+",'"+DateTime.Now.ToLongTimeString()+"',"+userID+","+shopID+",'"+Myorder.TotalPrice.ToString()+"')

                MySqlCommand commandb = new MySqlCommand("SELECT balance FROM user where username='" + username + "'", connection);
                decimal balance = Convert.ToDecimal(commandb.ExecuteScalar());

                if (balance < Myorder.TotalPrice)
                    return -1;
                else
                    balance -= Myorder.TotalPrice;

                MySqlCommand commandm = new MySqlCommand("update user set balance = " + balance + " where username ='" + username + "'", connection);
                commandm.ExecuteNonQuery();

                connection.Close();
                return count++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }


    }
}
