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
        //this application is pretty simple.
        //it will get all the shop names from the database.
        //so you can choose your shop and start the shop application with the choosen shop name.
        //and this is the initializer for shops that sell or rent products.

        Functions func = new Functions();

        public Shop_Initializer()
        {
            InitializeComponent();

            foreach (string s in func.GetAllNamesOfShop())
            {
                comboBox1.Items.Add(s);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //shop appliction will be lunched here.
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please choose one shop.");
                return;
            }

            Normal_Shop nn = new Normal_Shop(comboBox1.Text);
            nn.Visible = true;
            this.Visible = false;
            nn.FormClosed += nn_FormClosed;
        }

        void nn_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }
    }
}
