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
    public partial class General_admin : Form
    {
        //this application will show you some general information about this event.
        //when you open this application information will be shown.
        //and some of them you need to do some simple operations others will be shown dierctly.
        //and all the information is readonly.

        DBconnectionGernalAdmin dbGadmim = null;

        public General_admin()
        {
            InitializeComponent();
            dbGadmim = new DBconnectionGernalAdmin();
            try
            {
                UpdateData();
            }
            catch (Exception)
            {
                MessageBox.Show("ops Error!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbNumberOfPlayersEvent.Text = dbGadmim.ParticipaterInEvent(comboBox1.Text) + "";
            tbEventLeftNumbersOfPlayers.Text = (dbGadmim.GetMaxNumberOfAnEvent(comboBox1.Text) - dbGadmim.ParticipaterInEvent(comboBox1.Text)) + "";
        }

        private void UpdateData()
        {
            tbTotalRegisters.Text = dbGadmim.GetNumberOfUsers().ToString();
            tbTotalParticipants.Text = dbGadmim.GetNumberOfComers().ToString();
            tbTotalAbsence.Text = (dbGadmim.GetNumberOfUsers() - dbGadmim.GetNumberOfComers()) + "";
            tbTotalNumberIn.Text = dbGadmim.GetNumberOfComersIn().ToString();
            tbTotalNumberOut.Text = (dbGadmim.GetNumberOfComers() - dbGadmim.GetNumberOfComersIn()) + "";

            tbTotalEvent.Text = dbGadmim.CountEventNumber().ToString();
            comboBox1.Items.Clear();
            foreach (string s in dbGadmim.AlleventNames())
            {
                comboBox1.Items.Add(s);
            }

            tbTotalCamps.Text = dbGadmim.CountCampsNumber().ToString();

            tbTotalReceive.Text = dbGadmim.TotalReceiving().ToString();

            tbAmountOfShops.Text = dbGadmim.CountShopsNumber().ToString();

            listBox1.Items.Clear();
            foreach (string s in dbGadmim.AllProductsNamesWithQuantity())
            {
                listBox1.Items.Add(s);
            }

            int count = 0;
            for (int i = 0; i < Convert.ToInt32(tbTotalCamps.Text); i++)
            {
                if (dbGadmim.CampAvailiable(i))
                    count++;
            }
            tbTotalAvilisbaleCamps.Text = count + "";
            tbTotalUnavailiabelCamps.Text = Convert.ToInt32(tbTotalCamps.Text) - count + "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateData();
            }
            catch (Exception)
            {
                MessageBox.Show("ops Error!");
            }
        }
    }
}
