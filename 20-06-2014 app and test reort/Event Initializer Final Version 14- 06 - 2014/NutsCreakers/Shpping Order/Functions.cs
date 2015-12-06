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
        //this is the class which will provide some commen methods.
        //so usually the methods here will be used in many other classes.

        connection connect = new connection();

        //this method will get the user ID by his or her name.
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

        //this method will get the shop ID by its name.
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

        //this method will get the product ID by its name.
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

        //this method will get the balance by the given username.
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

        //this method will get the product name by its ID.
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

        //this method will get the product price by its name.
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

        //this method will return the total number of the shops.
        public int CountShopNumbers()
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT count(*) FROM shop", connection);
            int count = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();
            return count;
        }

        //this method will return all the names of the shops.
        public List<string> GetAllNamesOfShop()
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            List<string> shops = new List<string>();
            MySqlCommand command = new MySqlCommand("SELECT shop_name FROM shop", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    //add to the food list here.
                    shops.Add(reader.GetString("shop_name"));
                }
            }

            shops.Sort();
            connection.Close();
            return shops;
        }

        //this method will check if the username already exsit in the database.
        public bool UsernameExsit(string name)
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            List<string> shops = new List<string>();
            MySqlCommand command = new MySqlCommand("SELECT * FROM user", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    //add to the food list here.
                    if (reader.GetString("username") == name)
                        return true;
                }
            }

            connection.Close();
            return false;
        }

        //this method will get all the capm IDs.
        public List<int> GetAllCampIDs()
        {
            List<int> campids = new List<int>();

            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from camp ", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        campids.Add(reader.GetInt32("camp_id"));
                    }
                }

                reader.Close();
                connection.Close();
                campids.Sort();

                return campids;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //this method will get all the names of the products.
        public List<string> GetAllNames()
        {
            List<string> campids = new List<string>();

            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from product ", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        campids.Add(reader.GetString("product_name"));
                    }
                }

                reader.Close();
                connection.Close();

                campids.Sort();
                return campids;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<string> GetAllUserNames()
        {
            List<string> campids = new List<string>();

            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from user ", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        campids.Add(reader.GetString("username"));
                    }
                }

                reader.Close();
                connection.Close();
                campids.Sort();

                return campids;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //this method will get all the names of the events.
        public List<string> GetAllEventNames()
        {
            List<string> Events = new List<string>();

            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from event ", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Events.Add(reader.GetString("eventname"));
                    }
                }

                reader.Close();
                connection.Close();
                Events.Sort();
                return Events;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //this method will return the total number of the activities.
        public int CountEventsNumber()
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT count(*) FROM event", connection);
            int count = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();
            return count;
        }

        //this method will get the event ID by its name.
        public int GetEventIdByName(string name)
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            int eventID = 0;
            MySqlCommand commandc = new MySqlCommand("select event_id from event where eventname='" + name + "'", connection);
            eventID = Convert.ToInt32(commandc.ExecuteScalar());
            connection.Close();
            return eventID;
        }

        //this method will get the maximun number of one specific event.
        public int GetMaxNumberOfAnEvent(string name)
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select user_max from event where eventname='" + name + "'", connection);
            int max = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return max;
        }

        //this method will get the number of how many camps do we have.
        public int CountCampsNumber()
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT count(*) FROM camp", connection);
            int count = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();
            return count;
        }

        //this method will get all the customers who join in a specific activity.
        public List<Customer> GetEventParticipants(string name)
        {
            List<Customer> users = new List<Customer>();
            List<int> userIDs = new List<int>();
            int eventID = 0;

            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();

            MySqlCommand commande = new MySqlCommand("select event_id from event where eventname='" + name + "'", connection);
            eventID = Convert.ToInt32(commande.ExecuteScalar());

            MySqlCommand command = new MySqlCommand("select user_user_id from user_event where event_event_id =" + eventID, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    userIDs.Add(reader.GetInt32("user_user_id"));
                }
            }
            reader.Close();

            foreach (int i in userIDs)
            {
                MySqlCommand commandu = new MySqlCommand("select * from user where user_id=" + i, connection);
                MySqlDataReader readeru = commandu.ExecuteReader();

                while (readeru.Read())
                {
                    if (readeru.HasRows)
                    {
                        users.Add(new Customer(readeru.GetString("username"), "", readeru.GetString("user_first_name"), readeru.GetString("user_last_name"), 0, DateTime.Now, "", 0m));
                    }
                }
                readeru.Close();
            }

            connection.Close();

            return users;
        }

    }
}