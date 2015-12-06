using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shpping_Order
{
    class Order
    {
       // public string OrderNr { get; set; }
        public DateTime Orderdate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Username { get; set; }
        public Shop Shop { get; set; }

        public List<OrderDetails> Orders;

        public Order(/*string orderNr. order number is an auto increasement one.*/DateTime date,Shop shop,string username)
        {
            //this.OrderNr = orderNr;
            this.Shop = shop;
            this.Orderdate = date;
            this.Username = username;
            Orders = new List<OrderDetails>();
        }

        /*public int Add1item2order(string it, int number)
        {
            foreach (Items item in Mystorage.GetAllItems())
            {
                if (item.Name == it && item.LeftStuffNumber > number)
                {
                    for (int i = 0; i < number; i++)
                    {
                        if (Mystorage.Minus1Item(it) == -1)
                        {
                            for (int j = 0; j < i; j++)
                            {
                                deleteItemFromOrder(it);
                            }
                            return -1;
                        }
                    }
                    return 1;
                }
            }

            return -1;
        }*/

        public void deleteItemFromOrder(string it,int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                foreach (Items item in Shop.GetAllItems())
                {
                    if (item.Name == it)
                    {
                        Shop.Add1item(it);
                    }
                }
            }
           
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (OrderDetails od in Orders)
            {
                total += od.GetSubTotal();
            }
            return total;
        }

        public int Add1order(Items a,int quantity)
        {
            foreach (Items i in Shop.GetAllItems())
            {
                if (i.Name == a.Name)
                {
                    if (i.LeftStuffNumber >= quantity)
                    {
                        bool exsit = false;
                        foreach (OrderDetails od in Orders)
                        {
                            if (od.ItemA.Name == i.Name)
                            {
                                od.Quantity += quantity;
                                exsit = true;
                                TotalPrice += a.Price * quantity;
                            }
                        }
                        if (!exsit)
                        {
                            OrderDetails od = new OrderDetails(i, quantity);
                            Orders.Add(od);
                            TotalPrice += od.GetSubTotal();
                        }

                        i.LeftStuffNumber -= quantity;
                        return 1;
                    }
                }
            }
            return -1;
           
        }

        public void Remove1order(Items i)
        {
           foreach (OrderDetails od in Orders)
           {
               if (od.ItemA.Name == i.Name)
                   TotalPrice -= i.Price * od.Quantity;
           }
           Orders.RemoveAll(x => x.ItemA.Name == i.Name);
        }
    }
}
