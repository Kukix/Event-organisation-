using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shpping_Order
{
    class Items:IComparable<Items>
    {
        //this is the class for the products.
        //there will be some necessary properties and some simple methods.

        public decimal Price { get; set; }
        public unit Unit { get; set; }
        public string Name { get; set; }
        public int LeftStuffNumber { get; set; }
        public string Description { get; set; }

        public Items(string name,decimal price,unit unit,int numberofleft,string desc)
        {
            this.Name = name;
            this.Price = price;
            this.Unit = unit;
            this.LeftStuffNumber = numberofleft;
            this.Description = desc;
        }

        public void ResetTheprice(decimal price,unit unit)
        {
            this.Price = price;
            this.Unit = unit;
        }

        public void ResetName(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            string info = this.Name;
            info += " Price: " + this.Price.ToString() + " " + this.Unit.ToString() + " NrLeft:" + this.LeftStuffNumber.ToString() + " desc: " + this.Description;
            return info;
        }

        public int CompareTo(Items i)
        {
            if (this.Price > i.Price)
                return 1;
            else
            {
                if (this.Price < i.Price)
                    return -1;
                else
                    return 0;
            }
        }
    }
}
