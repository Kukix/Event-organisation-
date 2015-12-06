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
    class DBconnectCutomer
    {
        //this class will connect to the related database and will be able to do some changes with the database that is used in this application.
        public String Username { get; private set; }

        connection connect = new connection();

        public string FindUsername(string code)
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
                        this.Username = reader.GetString("username");
                    }
                }

                reader.Close();
                connection.Close();

                return this.Username;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
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

    }
}
