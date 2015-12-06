using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shpping_Order
{
    class OrderDetails
    {
        //this is the class for the orderdetails.
        //there will be some necessary properties and some simple methods.

        public Items ItemA { get; set; }
        private int quantity;
        public int Quantity
        {
            set
            {
                if (value < 1)
                    quantity = 1;
                else quantity = value;
            }
            get { return quantity; }
        }

        public OrderDetails(Items a,int number)
        {
            this.ItemA = a;
            this.Quantity = number;
        }

        public decimal GetSubTotal()
        {
            decimal sub = 0;
            sub = quantity * ItemA.Price;
            return sub;
        }

    }
}
