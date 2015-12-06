using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shpping_Order
{
    class Camp
    {
        public string  Location { get;private set; }
        public int Max { get; set; }

        public Camp(string locaton,int max)
        {
            this.Location = locaton;
            this.Max = max;
        }
    }
}
