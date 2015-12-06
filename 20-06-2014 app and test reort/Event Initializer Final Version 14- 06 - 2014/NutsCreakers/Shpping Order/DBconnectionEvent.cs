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
    //this class is designed for the event activities.
    //so this class will contain some methods to update extract or delete the database information.

    class DBconnectionEvent
    {
        connection connect = new connection();

        //this method will get the activity as an instance by its name.
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
                    temp = new Event(name, reader.GetString("DECRIBTION"), reader.GetString("location"), reader.GetString("time"),reader.GetInt32("user_max"));
                }
            }

            reader.Close();
            connection.Close();

            return temp;
        }

        //this method will add a customer's name to a specific event activity participants list.
        public void AddEventWithUser(User u,Event e)
        {
            int userID = 0;
            int eventID = 0;

            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();

            MySqlCommand commandu = new MySqlCommand("select user_id from user where username='"+u.UserName+"'", connection);
            userID = Convert.ToInt32(commandu.ExecuteScalar());

            MySqlCommand commande = new MySqlCommand("select event_id from event where eventname='"+e.EventName+"'", connection);
            eventID = Convert.ToInt32(commande.ExecuteScalar());

            MySqlCommand command = new MySqlCommand("insert into user_event values("+userID+","+eventID+")", connection);
            command.ExecuteNonQuery();

            connection.Close();

        }

        //this method will give all the customers' information who have joined in this activity.
        public List<Customer> LoadEvent(string name)
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

        //this method will check if this activity is at or not at capacity.
        //which means to check if you can still join in this activity.
        public bool EventAvailiable(Event e)
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();

            int eventID = 0;
            MySqlCommand commandc = new MySqlCommand("select event_id from event where eventname='" + e.EventName + "'", connection);
            eventID = Convert.ToInt32(commandc.ExecuteScalar());

            MySqlCommand commande = new MySqlCommand("select count(*) from user_event where event_event_id="+eventID, connection);
            int count = Convert.ToInt32(commande.ExecuteScalar());

            MySqlCommand command = new MySqlCommand("select user_max from event where eventname='" + e.EventName + "'", connection);
            int max = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();


            if (max > count)
                return true;
            else
                return false;
        }

    }
}
