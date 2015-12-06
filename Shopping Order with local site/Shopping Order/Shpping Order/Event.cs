using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shpping_Order
{
    class Event
    {
        public string EventName { get; set; }
        public string Describtion { get; set; }
        public string Location { get; set; }
        private List<Customer> Participants;
        public string Date;

        public Event(string name, string describtion, string location, string date)
        {
            this.EventName = name;
            this.Describtion = describtion;
            this.Location = location;
            this.Date = date;
            Participants = new List<Customer>();
        }

        public void AddPlayer(Customer a)
        {
            Participants.Add(a);
        }

    }
}
