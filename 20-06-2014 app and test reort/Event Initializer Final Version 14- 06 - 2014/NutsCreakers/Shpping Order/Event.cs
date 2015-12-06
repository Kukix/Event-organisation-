using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shpping_Order
{
    class Event
    {
        //this class is for some properties of the activities.

        public string EventName { get; set; }
        public string Describtion { get; set; }
        public string Location { get; set; }
        private List<Customer> Participants;
        public string Date { get; set; }
        public int Max { get; set; }

        public Event(string name, string describtion, string location, string date,int max)
        {
            this.EventName = name;
            this.Describtion = describtion;
            this.Location = location;
            this.Date = date;
            this.Max = max;
            Participants = new List<Customer>();
        }

        public void AddPlayer(Customer a)
        {
            Participants.Add(a);
        }

        public override string ToString()
        {
            string info = "Event Name: " + this.EventName + "\n";
            info += "Describtion: " + this.Describtion + "\n";
            info += "Location: " + this.Location + "\n";
            info += "Date: " + this.Date + "\n";
            info += "Maximun Number: " + this.Max + "\n";
            return info;
        }
    }
}
