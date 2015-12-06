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
    class DBconnectionCustomer
    {
        connection connect = new connection();
        public Customer Newcustomer { get;private set; }

        public Customer FindCustomerByRFID(string code)
        {
            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from user where RFID ='" + code + "'", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Newcustomer = new Customer(reader.GetString("username"), "", reader.GetString("user_first_name"), reader.GetString("user_last_name"), 0, DateTime.Now, "", 0m);
                    }
                }

                reader.Close();

                int userID = 0;
                List<int> eventID = new List<int>();

                MySqlCommand commandu = new MySqlCommand("select * from user", connection);
                MySqlDataReader readeru = commandu.ExecuteReader();
                while (readeru.Read())
                {
                    if (readeru.HasRows)
                    {
                        if (readeru.GetString("username") == Newcustomer.UserName)
                            userID = Convert.ToInt32(readeru.GetString("USER_ID"));
                    }
                }
                readeru.Close();

                MySqlCommand commande = new MySqlCommand("select * from user_event", connection);
                MySqlDataReader readere = commande.ExecuteReader();
                while (readere.Read())
                {
                    if (readere.HasRows)
                    {
                        if (readere.GetInt32("user_user_id") == userID)
                            eventID.Add(readere.GetInt32("event_event_id"));
                    }
                }
                readere.Close();

                foreach (int i in eventID)
                {
                    MySqlCommand commandn = new MySqlCommand("select * from event", connection);
                    MySqlDataReader readern = commandn.ExecuteReader();
                    while (readern.Read())
                    {
                        if (readern.HasRows)
                        {
                            if (readern.GetInt32("event_id") == i)
                                Newcustomer.Add1Event(new Event(readern.GetString("eventname"), readern.GetString("DECRIBTION"), readern.GetString("location"), readern.GetString("time")));
                        }
                    }
                    readern.Close();
                }

                connection.Close();

                return Newcustomer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public Customer FindCustomerInfoByRfid(string code)
        {
            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from user where RFID ='" + code + "'", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Newcustomer = new Customer(reader.GetString("username"), "", reader.GetString("user_first_name"), reader.GetString("user_last_name"), reader.GetInt32("PHONE"), DateTime.Now, "", Convert.ToDecimal(reader.GetString("BALANCE")));
                    }
                }

                reader.Close();

                int userID = 0;
                List<int> eventID = new List<int>();

                MySqlCommand commandu = new MySqlCommand("select * from user", connection);
                MySqlDataReader readeru = commandu.ExecuteReader();
                while (readeru.Read())
                {
                    if (readeru.HasRows)
                    {
                        if (readeru.GetString("username") == Newcustomer.UserName)
                            userID = Convert.ToInt32(readeru.GetString("USER_ID"));
                    }
                }
                readeru.Close();

                MySqlCommand commande = new MySqlCommand("select * from user_event", connection);
                MySqlDataReader readere = commande.ExecuteReader();
                while (readere.Read())
                {
                    if (readere.HasRows)
                    {
                        if (readere.GetInt32("user_user_id") == userID)
                            eventID.Add(readere.GetInt32("event_event_id"));
                    }
                }
                readere.Close();

                foreach (int i in eventID)
                {
                    MySqlCommand commandn = new MySqlCommand("select * from event", connection);
                    MySqlDataReader readern = commandn.ExecuteReader();
                    while (readern.Read())
                    {
                        if (readern.HasRows)
                        {
                            if (readern.GetInt32("event_id") == i)
                                Newcustomer.Add1Event(new Event(readern.GetString("eventname"), readern.GetString("DECRIBTION"), readern.GetString("location"), readern.GetString("time")));
                        }
                    }
                    readern.Close();
                }

                connection.Close();

                return Newcustomer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            
        }


    }
}
