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
    class Functions
    {
        connection connect = new connection();

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


        public int GetProductIDbyName(string Name)
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
                        proID = reader.GetInt32("product_id");
                }
            }
            reader.Close();
            connection.Close();
            return proID;
        }

        public decimal GetBlance(string username)
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();

            MySqlCommand commandb = new MySqlCommand("SELECT balance FROM user where username='" + username + "'", connection);
            decimal balance = Convert.ToDecimal(commandb.ExecuteScalar());

            connection.Close();
            return balance;
        }


        public string GetProNmaeByID(int ID)
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            string name = "";
            MySqlCommand command = new MySqlCommand("SELECT * FROM product where product_id=" + ID , connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    //add to the food list here.
                    name = reader.GetString("product_name");
                }
            }

            connection.Close();
            return name;
        }

        public decimal GetPriceByProName(string name)
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            decimal Price = 0m;
            MySqlCommand command = new MySqlCommand("SELECT * FROM product where product_name='" + name+"'", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    //add to the food list here.
                    Price = reader.GetDecimal("rental_price");
                }
            }

            connection.Close();
            return Price;
        }

    }
}
