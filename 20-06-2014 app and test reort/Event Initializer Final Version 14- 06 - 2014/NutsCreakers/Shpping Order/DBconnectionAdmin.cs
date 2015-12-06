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

    class DBconnectionAdmin
    {
        connection connect = new connection();
        Functions func = new Functions();

        //this method will assign the RFID code to a specific user.
        public int SaveRFID(string code, string name)
        {
            try
            {
                if (!func.UsernameExsit(name))
                {
                    return 0;
                }

                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                string sql = "UPDATE user SET RFID = '" + code + "' WHERE Username = '" + name + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);
                //command.Parameters.AddWithValue("@RFID", code);
                //command.Parameters.AddWithValue("@Username", name);
                command.ExecuteNonQuery();
                connection.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //this method will let you add a new shop for this event.
        public int SaveShop(string name, string describtion)
        {
            try
            {
                foreach (string  s in func.GetAllNamesOfShop())
                {
                    if (s == name)
                        return 0;
                }

               //int shopID = func.CountShopNumbers();
               // shopID++;
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                string sql = "INSERT INTO shop VALUES (" + "null" + ",'" + @name + "', '" + @describtion + "')";
                MySqlCommand command = new MySqlCommand(sql, connection);
                //string sql = "INSERT INTO shop VALUES (" + shopID + " @name ,@describtion)";
                //command.Parameters.AddWithValue("@name", "'" + name + "'");
                //command.Parameters.Add("@name", MySqlDbType.String );
                //command.Parameters["@name"].Value = "'" + name + "'";
                //command.Parameters.AddWithValue("@describtion", "'" + describtion + "'");
                command.ExecuteNonQuery();
                connection.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //this method will let you add a new product for this event.
        //and this is for the product which are used to sell but not rent.
        public void SaveProduct(Items i)
        {
            try
            {
                //string Connect = connect.Connection;
                //MySqlConnection connection = new MySqlConnection(Connect);
                //connection.Open();
                //string sql = "INSERT INTO product (product_name, price,rental_price) VALUES (@name, @price,@rental)";
                //MySqlCommand command = new MySqlCommand(sql, connection);
                //command.Parameters.AddWithValue("@name", name);
                //command.Parameters.AddWithValue("@price", price);
                //command.Parameters.AddWithValue("@rental", rental);
                //if (rental == 0)
                //{
                //    command.Parameters.AddWithValue("@rental", null);
                //}
                //command.ExecuteNonQuery();
                //MessageBox.Show("Success!");
                //connection.Close();
                //update the database here
                foreach (string s in func.GetAllNames())
                {
                    if (s == i.Name)
                    {
                        MessageBox.Show("Food name exsit!");
                        return;
                    }
                }

                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
               // MySqlCommand commandc = new MySqlCommand("select count(*) from product", connection);
               // int count = Convert.ToInt32(commandc.ExecuteScalar());
               // count++;
                MySqlCommand command = new MySqlCommand("insert into product values(" + "null" + ",'" + i.Name + "'," + i.Price + ",0,'" + i.Unit + "','" + i.Description + "')", connection);
                command.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Successfully added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        //this method will let you add a new product for this event.
        //and this is for the product which are used to rent but not sell.
        public void SaveProductRental(Items i)
        {
            try
            {
                foreach (string s in func.GetAllNames())
                {
                    if (s == i.Name)
                    {
                        MessageBox.Show("Food name exsit!");
                        return;
                    }
                }

                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                //MySqlCommand commandc = new MySqlCommand("select count(*) from product", connection);
               // int count = Convert.ToInt32(commandc.ExecuteScalar());
               // count++;
                MySqlCommand command = new MySqlCommand("insert into product values(" + "null" + ",'" + i.Name + "'," + 0 + ","+i.Price+",'" + i.Unit + "','" + i.Description + "')", connection);
                command.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Successfully added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        //this method will return all the camp IDs.
        public List<int> GetAllCamps()
        {
            return func.GetAllCampIDs();
        }

        //this method will let you add a new camp site.
        //if the user is alreay assigned to a camp, then the user can be able to choose a new camp.
        //the old one will be removed and a new one will be added.
        public int SaveCampID(int CampID, string name)
        {
            try
            {
                if (!func.UsernameExsit(name))
                {
                    return 0;
                }

                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                int campIDt = 0;
                string sql3 = "select camp_camp_id from user where username = '" + name+"'";
                MySqlCommand command4 = new MySqlCommand(sql3, connection);
                campIDt = Convert.ToInt32(command4.ExecuteScalar());

                string sql = "UPDATE user SET camp_camp_id = " + CampID + " WHERE Username = '" + name + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);
                //command.Parameters.AddWithValue("@RFID", code);
                //command.Parameters.AddWithValue("@Username", name);
                command.ExecuteNonQuery();

                int usersIn = 0;
                string sql2 = "select user_number from camp where camp_id = "+CampID;
                MySqlCommand command2 = new MySqlCommand(sql2, connection);
                usersIn = Convert.ToInt32(command2.ExecuteScalar());
                usersIn++;
                MySqlCommand command3 = new MySqlCommand("update camp set user_number = " + usersIn + " where camp_id = " + CampID, connection);
                command3.ExecuteNonQuery();

                if (campIDt != 0)
                {
                    int temp = 0;
                    MySqlCommand command6 = new MySqlCommand("select user_number from camp where camp_id = "+campIDt, connection);
                    temp = Convert.ToInt32(command6.ExecuteScalar());
                    temp--;
                    MySqlCommand command5 = new MySqlCommand("update camp set user_number = " + temp + " where camp_id = " + campIDt, connection);
                    command5.ExecuteNonQuery();
                }
                connection.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //this method will allow you to assign a new product to a specific shop.
        public void AssignToShop(string shopname,string proname)
        {
            bool shopExsit = false;
            bool foodExsit = false;
            foreach (string s in func.GetAllNamesOfShop())
            {
                if (s == shopname)
                    shopExsit = true;
            }

            foreach (string  s in func.GetAllNames())
            {
                if (s == proname)
                    foodExsit = true;
            }
            if (!shopExsit||!foodExsit)
            {
                MessageBox.Show("Shop name or food name do not exsit.");
                return;
            }


            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                int proID = func.GetProductIDbyName(proname);
                int shopID = func.GetShopIDbyName(shopname);


                //MySqlCommand command3 = new MySqlCommand("select count(*) from shop_product", connection);
                //int count = Convert.ToInt32( command3.ExecuteScalar());
                //int[,] check = new int[count,2];
                bool rowExsit = false;

                MySqlCommand command = new MySqlCommand("select * from shop_product ", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (reader.GetInt32("shop_id") == shopID && reader.GetInt32("product_id") == proID)
                            rowExsit = true;
                    }
                }

                reader.Close();

                if (rowExsit)
                {
                    MessageBox.Show("this shopID and productID combination exsit");
                    return;
                }

                MySqlCommand command2 = new MySqlCommand("insert into shop_product values(" + shopID + "," + proID + ",null,0)", connection);
                command2.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Successfully added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //this method will let you add a new activity for this event.
        public void AddEvent(Event e)
        {
            foreach (string  s in func.GetAllEventNames())
            {
                if (e.EventName == s)
                {
                    MessageBox.Show("Error Event already Exsit.");
                    return;
                }
            }

            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();

            int EventID = func.CountEventsNumber() + 1;

            MySqlCommand command2 = new MySqlCommand("insert into event values("+EventID+",'"+e.Describtion+"','"+e.EventName+"','"+e.Location+"','"+e.Date+"',"+e.Max+")", connection);
            command2.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Successfully added.");

        }


        //this method will let you find the username by a given RFID code.
        public Customer FindCustomerByRFID(string code)
        {
            try
            {
                Customer Newcustomer = null;
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from user where RFID ='" + code + "'", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Newcustomer = new Customer(reader.GetString("username"), "", reader.GetString("user_first_name"), reader.GetString("user_last_name"), 0, DateTime.Now, "", reader.GetDecimal("balance"));
                    }
                }

                reader.Close();
                connection.Close();
                return Newcustomer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void ChargeAccount(decimal d,string username)
        {
            decimal oldBalance = func.GetBlance(username);
            decimal newBalance = oldBalance + d;
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("update user set balance = " + newBalance + " where username = '" + username + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public decimal GetBalance(string username)
        {
            return func.GetBlance(username);
        }

        public void CreateACamp(Camp camp)
        {
            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();
            MySqlCommand command = new MySqlCommand("insert into camp values(null,'"+camp.Location+"',0,"+camp.Max+")", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<string> GetAllUsernames()
        {
            return func.GetAllUserNames();
        }

        public List<string> GetAllShopnames()
        {
            return func.GetAllNamesOfShop();
        }

        public List<string> GetAllPronames()
        {
            return func.GetAllNames();
        }

        public void ResetPriceRental(string Name, decimal Price)
        {
            try
            {
                //update the database here
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("Update product set rental_price= " + Price + " where product_name='" + Name + "'", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ResetPrice(string Name, decimal Price)
        {
            try
            {
                //update the database here
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("Update product set price= " + Price + " where product_name='" + Name + "'", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddAmount(string Name, int number,string shopname)
        {
            try
            {
                //update the database here
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                int proID = 0;
                int numberleft = 0;
                int shopID = func.GetShopIDbyName(shopname);

                MySqlCommand command = new MySqlCommand("select * from product", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        //add to the food list here.
                        if (reader.GetString("product_name") == Name)
                            proID = Convert.ToInt32(reader.GetString("product_ID"));
                    }
                }
                reader.Close();

                MySqlCommand commandc = new MySqlCommand("select * from shop_product where product_id=" + proID+ " and shop_id = "+ shopID, connection);
                MySqlDataReader reader2 = commandc.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2.HasRows)
                    {
                        //add to the food list here.
                        numberleft = reader2.GetInt32("numberleft");
                    }
                }
                reader2.Close();

                numberleft += number;

                MySqlCommand commanda = new MySqlCommand("Update shop_product set numberleft= " + numberleft + " where product_id=" + proID + " and shop_id = " + shopID, connection);
                commanda.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int IsRental(string Name)
        {
            try
            {
                //update the database here
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select price from product where product_name = '" +Name +"'", connection);
                decimal temp = Convert.ToDecimal(command.ExecuteScalar());
                connection.Close();
                if (temp == 0)
                    return 1;
                else
                    return -1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
