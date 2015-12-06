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

    class DBconnectionGernalAdmin
    {
        connection connect = new connection();
        Functions func = new Functions();

        //this method will count the total number of customers we have.
        public int GetNumberOfUsers()
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select count(*) from user", connection);
            int count = Convert.ToInt32(command.ExecuteScalar());
            
            connection.Close();

            return count;
        }

        //this method will get the total number of customers who come to our event.
        public int GetNumberOfComers()
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select count(*) from user where RFID is not null", connection);
            int count = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            return count;
        }

        //this method will get the total number of the customers who are in this event area now.
        public int GetNumberOfComersIn()
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select count(*) from user where RFID is not null and in_out = 1", connection);
            int count = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            return count;
        }

        //this method will return the total number of the events we have now.
        public int CountEventNumber()
        {
            return func.CountEventsNumber();
        }

        //this method will return a list of names of all the events.
        public List<string> AlleventNames()
        {
            return func.GetAllEventNames();
        }

        //this method will get the partipants number we have till now for one specific event activity.
        public int ParticipaterInEvent(string name)
        {
            int eventID = func.GetEventIdByName(name);

            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select count(*) from user_event where event_event_id ="+eventID, connection);
            int count = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return count;
        }

        //this method will get the maxium number of one specific event activity.
        public int GetMaxNumberOfAnEvent(string name)
        {
            return func.GetMaxNumberOfAnEvent(name);
        }

        //this method will return the total camps number we have.
        public int CountCampsNumber()
        {
            return func.CountCampsNumber();
        }

        //this method will return the total receiving we have so far.(selling and renting)
        public decimal TotalReceiving()
        {
            decimal total = 0m;

            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT sum(totalprice) FROM `order`", connection);
                total = Convert.ToDecimal(command.ExecuteScalar());
            }
            catch (Exception)
            {
                total = total + 0;
            }
            try
            {
                MySqlCommand commandr = new MySqlCommand("SELECT sum(total_price) FROM `rent_record`", connection);
                total += Convert.ToDecimal(commandr.ExecuteScalar());
            }
            catch (Exception)
            {
                total = total + 0;
            }
            connection.Close();

            return total;
        }

        //this method will return the total number of shops.
        public int CountShopsNumber()
        {
            return func.CountShopNumbers();
        }

        //this method will return all products names and with their corresponding left quantity.
        public List<string> AllProductsNamesWithQuantity()
        {
            List<string> Temp = new List<string>();
            foreach (string s in func.GetAllNames())
            {
                string temp = s;
                temp += "  And the LeftNumber is: ";
                temp += GetCountByProName(s);
                Temp.Add(temp);
            }

            return Temp;
        }

        //this method will get the total number of one specific product.(total number in all shops)
        public int GetCountByProName(string name)
        {
            int proID = func.GetProductIDbyName(name);

            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();

            try
            {
                MySqlCommand command = new MySqlCommand("SELECT sum(numberleft) FROM shop_product where product_id = " + proID, connection);
                int total = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return total;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //this method will check if the camp is atill availiable.
        //which means check if that camp is at capacity or not.
        public bool CampAvailiable(int campID)
        {
            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM camp where camp_id = " + campID, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (reader.GetInt32("user_number") == reader.GetInt32("user_max"))
                            return false;
                    }
                }

                reader.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
