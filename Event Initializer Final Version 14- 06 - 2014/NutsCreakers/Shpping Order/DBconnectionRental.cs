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
    class DBconnectionRental
    {
        //this class is designed for the rental products.
        //so this class will contain some methods to update extract or delete the database information.

        public Shop NewShop { get;private set; }
        Functions func = new Functions();

        connection connect = new connection();
        int shopID = 0;

        public DBconnectionRental(Shop s)
        {
            this.NewShop = s;
        }

        //this method will get every rental products from the database for one spevific shop.
        public void LoadFromDatabase()
        {
            try
            {
                NewShop.AllItems.Clear();
                List<int> numberleft = new List<int>();
                List<int> proID = new List<int>();
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
                        if (reader.GetString("SHOP_NAME") == this.NewShop.StorageName)
                            shopID = Convert.ToInt32(reader.GetString("SHOP_ID"));
                    }
                }
                reader.Close();

                MySqlCommand command2 = new MySqlCommand("select * from shop_product where SHOP_ID=" + shopID, connection);
                MySqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2.HasRows)
                    {
                        //add to the food list here.

                        proID.Add(reader2.GetInt32("product_id"));
                        numberleft.Add(reader2.GetInt32("numberleft"));

                    }
                }
                reader2.Close();

                int index = 0;
                foreach (int i in proID)
                {
                    MySqlCommand command3 = new MySqlCommand("select * from product where product_id=" + i, connection);
                    MySqlDataReader reader3 = command3.ExecuteReader();
                    while (reader3.Read())
                    {
                        if (reader3.HasRows)
                        {
                            if (Convert.ToDecimal(reader3.GetString("rental_price")) != 0)
                            {
                                NewShop.AddNewItem(new Items(reader3.GetString("product_name"), Convert.ToDecimal(reader3.GetString("rental_price")), unit.PerDay, numberleft[index], reader3.GetString("desc")));
                            }
                            index++;
                        }
                    }
                    reader3.Close();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //this method will allow you to reset the price of one specific product.
        public void ResetPrice(string Name, decimal Price)
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

        //this method will allow you to add a new rental product to this event.
        public void AddNewItem(Items i)
        {
            try
            {
                //update the database here
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                //MySqlCommand commandc = new MySqlCommand("select count(*) from product", connection);
                //int count = Convert.ToInt32(commandc.ExecuteScalar());
                //count++;
                MySqlCommand command = new MySqlCommand("insert into product values(" + "null" + ",'" + i.Name + "'," + "0" + ","+i.Price+",'" + i.Unit + "','" + i.Description + "')", connection);
                command.ExecuteNonQuery();

                int proID = func.GetProductIDbyName(i.Name);

                MySqlCommand command2 = new MySqlCommand("insert into shop_product values(" + shopID + "," + proID + ",null,0)", connection);
                command2.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //this method will update the rental record in the database, it is like when you take an order.
        public void UpdateRentalRecord(Order order)
        {
            try
            {
                int userID = func.GetUserIDbyName(order.Username);
                int shopID = func.GetShopIDbyName(NewShop.StorageName);
                //update the database here
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                foreach (OrderDetails od in order.Orders)
                {
                    int proID = func.GetProductIDbyName(od.ItemA.Name);
                    MySqlCommand command = new MySqlCommand("insert into rent_record values(null,"+shopID+","+userID+","+proID+",'"+DateTime.Now.ToString()+"','',"+od.Quantity+",0)", connection);
                    command.ExecuteNonQuery();
                }

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //this method will get all the rentals for someone in one specific shop.
        public List<Rental> GetAllRentals(string username, string shopname)
        {
            int userID = func.GetUserIDbyName(username);
            int shopID = func.GetShopIDbyName(shopname);
            string name = "";

            List<Rental> rentals = new List<Rental>();

            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from rent_record where shop_shop_id = "+shopID+" and user_user_id = "+userID, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        //add to the food list here.
                        if (reader.GetInt32("quantity") != 0)
                        {
                            name = func.GetProNmaeByID(Convert.ToInt32(reader.GetString("product_product_id")));
                            rentals.Add(new Rental(username, name, reader.GetString("rent_time"), reader.GetInt32("quantity"), 0m));
                        }
                    }
                }
                reader.Close();
                connection.Close();
                return rentals;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //get the product's rental price by its name.
        public decimal GetPriceByName(string name)
        {
            return func.GetPriceByProName(name);
        }

        //update the databse when the customer return the products.
        public void UpdateReturns(Rental r,decimal Price)
        {

            int userID = func.GetUserIDbyName(r.Username);
            int proID = func.GetProductIDbyName(r.ProName);

            string Connect = connect.Connection;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT quantity FROM rent_record where user_user_id = "+userID+" and rent_time='"+r.RentTime+"'  and product_product_id= "+proID, connection);
            int quantity = Convert.ToInt32(command.ExecuteScalar());

            quantity -= r.Quantity;

            MySqlCommand commandn = new MySqlCommand("UPDATE `rent_record` SET `BACK_TIME`='" + DateTime.Now.ToString() + "',`QUANTITY`=" + quantity + ",`TOTAL_PRICE`=" + Price + " where user_user_id = " + userID + " and rent_time='" + r.RentTime + "' and product_product_id= "+proID, connection);
            //"UPDATE `rent_record` SET back_time = '" + DateTime.Now.ToString() + "', quantity =" + quantity + ",total_price=" + Price.ToString() +"where user_user_id = "+1+" and rent_time='"+r.RentTime+"' "
            commandn.ExecuteNonQuery();

            connection.Close();
        }

        //update the customer's balance when he or she does some money expense. here it will be when they return the products.
        public void UpdateBalance(decimal d,string username)
        {
            decimal b = func.GetBlance(username);
            b -= d;
            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();
                MySqlCommand command = new MySqlCommand("update user set balance="+b+"where username='"+username+"'", connection);
                command.ExecuteNonQuery();
              
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
