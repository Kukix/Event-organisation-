using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shpping_Order
{
    class Customer:User
    {
        //this is the class for customer inherited from the user class.
        //this class include some properties of the customer and some methods.

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phonenumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public Decimal Balance { get; set; }

        public List<Order> Myorders { get; set; }
        public List<Event> Myevents { get; set; }

        public Customer(string username,string password,string firstname,string lastname,int phonenumber,DateTime birthday,string address,decimal balance)
            :base(username,password)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Phonenumber = phonenumber;
            this.Birthday = birthday;
            this.Address = address;
            this.Balance = balance;

            Myevents = new List<Event>();
            Myorders = new List<Order>();
        }

        //add 1 activity to the customer.
        public int Add1Event(Event e)
        {
            bool ed = false;
            foreach (Event ev in Myevents)
            {
                if (ev.EventName == e.EventName)
                    ed = true;
            }
            if (ed)
                return -1;
            else
            {
                Myevents.Add(e);
                return 1;
            }
        }

        //information string1.
        public override string ToString()
        {
            string info ="Username: "+this.UserName + "\nName: " + this.FirstName + " " + this.LastName;
            // info += "\nPhoneNumber:" + this.Phonenumber.ToString();
            //info += "\nBirthday: " + this.Birthday.ToShortDateString();
            //info += "\nAddress: " + this.Address;
            //info += "\nBalance: " + this.Balance.ToString();
            if (Myevents.Count == 0)
                info += "\nNo Event Yet!";
            else
            {
                info += "\nEventJoined: \n";
                foreach (Event e in Myevents)
                {
                    info += e.EventName + "\n";
                }
            }
            return info;
        }

        //information string2.
        public string InfoString()
        {
            string info = "Username: " + this.UserName + "\nName: " + this.FirstName + " " + this.LastName;
             info += "\nPhoneNumber:" + this.Phonenumber.ToString();
            //info += "\nBirthday: " + this.Birthday.ToShortDateString();
            //info += "\nAddress: " + this.Address;
            info += "\nBalance: " + this.Balance.ToString();
            if (Myevents.Count == 0)
                info += "\nNo Event Yet!";
            else
            {
                info += "\nEventJoined: \n";
                foreach (Event e in Myevents)
                {
                    info += e.EventName + "\n";
                }
            }
            return info;
        }
    }
}
