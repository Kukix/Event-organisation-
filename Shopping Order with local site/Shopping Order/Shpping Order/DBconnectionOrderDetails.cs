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
    class DBconnectionOrderDetails
    {
        public Order Myorder { get; private set; }
        connection connect = new connection();

        public DBconnectionOrderDetails(Order order)
        {
            this.Myorder = order;
        }

        public int GetProIDbyName(string Name)
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

        public void AddOrderDetails(int orderid)
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            foreach (OrderDetails od in Myorder.Orders)
            {
                int proID = GetProIDbyName(od.ItemA.Name);
                MySqlCommand command = new MySqlCommand("INSERT INTO `order_datails` values("+proID+","+orderid+","+od.Quantity+",null)", connection);
                command.ExecuteNonQuery();
            }

        }
    }
}
