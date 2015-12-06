using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shpping_Order
{
    class Rental
    {
        public string Username { get;private set; }
        public string ProName { get;private set; }
        public string RentTime { get;private set; }
        public int Quantity { get;private set; }
        public decimal Price { get; set; }

        public Rental(string username, string proname, string rentTime, int quantity, decimal price)
        {
            this.Username = username;
            this.ProName = proname;
            this.RentTime = rentTime;
            this.Quantity = quantity;
            this.Price = price;
        }

        public override string ToString()
        {
            string info = "Product Name:" + this.ProName;
            info += "   Quantity:" + this.Quantity;
            info += "   RentTime:" + this.RentTime;
            return info;
        }

        public void returnsome(int i)
        {
            this.Quantity -= i;
        }

        public void SetPrice(decimal d)
        {
            this.Price = d;
        }

    }
}
