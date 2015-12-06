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
    public partial class Shop_Initializer : Form
    {
        Order_Shop no = null;
        Rental_Shop nr = null;

        public Shop_Initializer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            no = new Order_Shop();
            no.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nr = new Rental_Shop();
            nr.Visible = true;
        }
    }
}
