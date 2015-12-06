using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shpping_Order
{
    public partial class Event_Initializer : Form
    {
        Normal_Shop nn = null;

        public Event_Initializer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nn = new Normal_Shop();
            nn.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Checking_Information nc = new Checking_Information();
            nc.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Event_Status ne = new Event_Status();
            ne.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Camp_site nc = new Camp_site();
            nc.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Admin_Control na = new Admin_Control();
            na.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Return_Products nr = new Return_Products();
            nr.Visible = true;
        }
    }
}
