using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Shpping_Order
{
    //this class is designed for the administer
    //so this class will contain some methods to update extract or delete the database information.

    class DBconnectionSpecificAdmin
    {
        connection connect = new connection();
        Functions func = new Functions();
        DBconnectionCustomer dbcustomer = new DBconnectionCustomer();

        public List<string> GetAllEventNames()
        {
            return func.GetAllEventNames();
        }

        //this method will get the activity ID by its name.
        public Event GeteventByName(string name)
        {
            Event temp = null;

            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from event where eventname ='" + name + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    temp = new Event(name, reader.GetString("DECRIBTION"), reader.GetString("location"), reader.GetString("time"), reader.GetInt32("user_max"));
                }
            }

            reader.Close();
            connection.Close();

            return temp;
        }

        //this method will count the total number of participants for one specific activity.
        public int CountEventParticipants(string name)
        {
            int eventID = func.GetEventIdByName(name);

            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT count(*) FROM user_event where event_event_id = "+eventID, connection);
            int count = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();
            return count;
        }

        //this method will get all the customers of one specific activity.
        public List<Customer> GetEventParticipants(string name)
        {
            return func.GetEventParticipants(name);
        }

        //this method will find the camp name by its ID.
        public string FindCampInfoById(int campID)
        {
            string info = "";

            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from camp ", connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    if (reader.GetInt32("camp_id") == campID)
                    {
                        info = "CampID: " + campID + "\n";
                        info += "Location: " + reader.GetString("Location") + "\n";
                        info += "User Now: " + reader.GetInt32("user_number") + "\n";
                        info += "User Maximun: " + reader.GetInt32("user_max") + "\n";
                    }
                }
            }

            reader.Close();
            connection.Close();

            return info;
        }

        //this method will get all shopnames from the database.
        public List<string> GetAllShopNames()
        {
            return func.GetAllNamesOfShop();
            //List<string> shops = new List<string>();
            //string Connect = connect.Connection;
            //MySqlConnection connection = new MySqlConnection(Connect);
            //connection.Open();
            //MySqlCommand command = new MySqlCommand("select * from shop ", connection);
            //MySqlDataReader reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    if (reader.HasRows)
            //    {
            //        shops.Add(reader.GetString("shop_name"));
            //    }
            //}

            //reader.Close();
            //connection.Close();

            //return shops;
        }

        //this method will get the total receiving for one specific shop.(for selling products.)
        public decimal GetTotalReceiveForOneShop(string name)
        {
            try
            {
                int shopID = func.GetShopIDbyName(name);

                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select sum( `TOTALPRICE`) from `order` where `SHOP_SHOP_ID`=" + shopID, connection);
                decimal total = Convert.ToDecimal(command.ExecuteScalar());

                connection.Close();

                return total;

            } 
            catch (Exception)
            {
                return 0;
            }
        }

        //this method will get the total receiving for one specific shop.(for rental products.)
        public decimal GetTotalReceiveForOneShopRental(string name)
        {
            try
            {
                int shopID = func.GetShopIDbyName(name);

                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                MySqlCommand commandr = new MySqlCommand("select sum(`total_price`) from `rent_record` where `shop_shop_id`=" + shopID, connection);
                decimal total = Convert.ToDecimal(commandr.ExecuteScalar());

                connection.Close();
                return total;

            }
            catch (Exception)
            {
                return 0;
            }
        }

        //this method will check if the username exsit.
        public bool UsernameExsit(string username)
        {
            return func.UsernameExsit(username);
        }

        //this method will get the total expense of one specific user.(selling products)
        public decimal GetTotalReceiveForOneUser(string name)
        {
            try
            {
            int userID = func.GetUserIDbyName(name);

            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select sum( `TOTALPRICE`) from `order` where `user_user_id`=" + userID, connection);
            decimal total = Convert.ToDecimal(command.ExecuteScalar());

            connection.Close();

            return total;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //this method will get the total expense of one specific user.(rental products)
        public decimal GetTotalReceiveForOneUserRental(string name)
        {
            try
            {
                int userID = func.GetUserIDbyName(name);

                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select sum( `TOTAL_PRICE`) from `rent_record` where `user_user_id`=" + userID, connection);
                decimal total = Convert.ToDecimal(command.ExecuteScalar());

                connection.Close();

                return total;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //this method will get the customer by his or her username.
        public Customer FindCustomerByUsername(string name)
        {
            string rfid = "";
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select rfid from user where username ='" + name + "'", connection);
            rfid = command.ExecuteScalar().ToString();
            connection.Close();

            return dbcustomer.FindCustomerInfoByRfid(rfid);
        }

        //this method will check whether the customer is inside this event or outside of this event.
        public int UserInOrOut(string username)
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select in_out from user where username ='" + username + "'", connection);
            int inout = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return inout;
        }

        //this method will get all product names from one specific shop.
        public List<string> GetProductsFromOneShop(string name)
        {
            int shopID = func.GetShopIDbyName(name);
            List<string> products = new List<string>();
            List<int> proIDs = new List<int>();

            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from shop_product ", connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    if (reader.GetInt32("shop_id") == shopID)
                        proIDs.Add(reader.GetInt32("product_id"));
                }
            }

            reader.Close();

            foreach (int i in proIDs)
            {
                MySqlCommand commandp = new MySqlCommand("select * from product where product_id="+i, connection);
                MySqlDataReader reader2 = commandp.ExecuteReader();

                while (reader2.Read())
                {
                    if (reader2.HasRows)
                    {
                        if (reader2.GetDecimal("price")!=0)
                            products.Add(reader2.GetString("product_name"));
                    }
                }

                reader2.Close();
            }
            connection.Close();

            return products;
        }

        //this method will get the total number of sold for one product.
        public int GetProductsNumberSold(string proname,string shopname)
        {
            int shopID = func.GetShopIDbyName(shopname);
            int proID = func.GetProductIDbyName(proname);
            int total = 0;

            List<int> OrderIDs = new List<int>();
          
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();

            MySqlCommand command = new MySqlCommand("select * from `order` ", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    if (reader.GetInt32("shop_shop_id") == shopID)
                        OrderIDs.Add(reader.GetInt32("order_id"));
                }
            }
            reader.Close();

            foreach (int i in OrderIDs)
            {
                MySqlCommand command2 = new MySqlCommand("select * from `order_datails`  ", connection);
                MySqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2.HasRows)
                    {
                        if (reader2.GetInt32("product_product_id") == proID && reader2.GetInt32("order_order_id")==i)
                            total += reader2.GetInt32("quantity");
                    }
                }
                reader2.Close();
            }

            connection.Close();
            return total;
        }

        //this method will let you get the price of one product.
        public decimal GetPriceOfOneProduct(string name)
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            decimal Price = 0m;
            MySqlCommand command = new MySqlCommand("SELECT * FROM product where product_name='" + name + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    Price = reader.GetDecimal("price");
                }
            }
            reader.Close();
            connection.Close();
            return Price;
        }

        //this method will let you get the left number of one specific product in one specific shop.
        public int GetLeftNumberOfOneProduct(string proname, string shopname)
        {
            int shopID = func.GetShopIDbyName(shopname);
            int proID = func.GetProductIDbyName(proname);
            int total = 0;

            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("select numberleft from `shop_product` where shop_id= " + shopID + " and product_id = " + proID, connection);
            total = Convert.ToInt32(command2.ExecuteScalar());

            connection.Close();
            return total;
        }

        //this method will get the customers with a given name.
        //there may be someone whose names are same so it will return a list.
        public List<string> FindCustomerByName(string name)
        {
            string[] splits = name.Split(' ');
            string firstname = splits[0];
            string lastname = splits[1];
            List<string> RFIDS = new List<string>();
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from user", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    if (reader.GetString("user_first_name") == firstname && reader.GetString("user_last_name") == lastname)
                        RFIDS.Add(reader.GetString("rfid"));
                }
            }
            reader.Close();
            connection.Close();

            return RFIDS;
        }

        //this method will find the customer by his or her RFID code.
        public Customer FindUserByRFID(string code)
        {
            return dbcustomer.FindCustomerInfoByRfid(code);
        }

        public List<int> GetAllCampIDs()
        {
            return func.GetAllCampIDs();
        }

        public List<string> GetAllUsernames()
        {
            return func.GetAllUserNames();
        }

        public string GetRFIDByUsername(string username)
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("select rfid from `user` where username= '" + username + "'", connection);
            string temp = Convert.ToString(command2.ExecuteScalar());

            connection.Close();
            return temp;
        }
    }
}
