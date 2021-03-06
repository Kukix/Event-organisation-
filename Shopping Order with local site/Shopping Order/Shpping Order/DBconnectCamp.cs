﻿using System;
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
    class DBconnectCamp
    {
        connection connect = new connection();

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

                return campids;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public int GetCampID(string code)
        {
            try
            {
                int camID = 0;
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from user where RFID ='" + code + "'", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (Convert.ToInt32( reader.GetString("camp_camp_id"))== 0)
                            return -1;
                        else
                            camID = Convert.ToInt32(reader.GetString("camp_camp_id"));
                    }
                }

                reader.Close();
                connection.Close();

                return camID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

    }
}
