using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shpping_Order
{
    class Shop
    {
        public string StorageName { get; set; }
        public List<Items> AllItems { get;private set; }

        public Shop(string name)
        {
            this.StorageName = name;
            AllItems = new List<Items>();
        }

        public void AddNewItem(Items i)
        {
            AllItems.Add(i);
        }

        public void RemoveNewItem(Items i)
        {
            AllItems.Remove(i);
        }

        public void Add1item(string name)
        {
            foreach (Items s in AllItems)
            {
                if (s.Name == name)
                    s.LeftStuffNumber++;
            }
        }

        public int Minus1Item(string name)
        {
            foreach (Items s in AllItems)
            {
                if (s.Name == name)
                {
                    if (s.LeftStuffNumber == 0)
                        return -1;
                    else
                        s.LeftStuffNumber--;
                }
            }
            return 1;   
        }

        public List<Items> GetAllItems()
        {
            return this.AllItems;
        }
    }
}
