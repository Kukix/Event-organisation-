using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Shpping_Order
{
    class DBconnectAdmin
    {
        connection connect = new connection();
        public void SaveRFID(string code, string name)
        {
            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                string sql = "UPDATE User SET [RFID] = @RFID WHERE [Username] = @Username";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@RFID", code);
                command.Parameters.AddWithValue("@Username", name);
                command.ExecuteNonQuery();
                MessageBox.Show("Success!");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveShop(string name, string describtion) 
        {
            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                string sql = "UPDATE User SET [RFID] = @RFID WHERE [Username] = @Username";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@RFID", name);
                command.Parameters.AddWithValue("@Username", name);
                command.ExecuteNonQuery();
                MessageBox.Show("Success!");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
