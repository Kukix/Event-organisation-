using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Shpping_Order
{
    public partial class Event_Initializer : Form
    {
        Shop_Initializer nn = null;

        public Event_Initializer()
        {
            InitializeComponent();
            //start the logfile with the bank account numebr and the start time.
            try
            {
                FileStream nfs = new FileStream("../../../logfile.txt", FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(nfs);
                sw.WriteLine("0613062093");
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine("0");
                sw.Dispose();
                nfs.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //make a new instance of that new form
            //and make that new form visible and at the meantime make the current one invisible
            //and also add an method to the form closing event to let the current show up again after closing that new form.
            //so it will be like when you open a new form, the current form will be invisible
            //and when you close that form, you will see the previous form again.
            try
            {
            nn = new Shop_Initializer();
            nn.Visible = true;
            this.Visible = false;
            nn.FormClosed += nn_FormClosed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void nn_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //make a new instance of that new form
            //and make that new form visible and at the meantime make the current one invisible
            //and also add an method to the form closing event to let the current show up again after closing that new form.
            //so it will be like when you open a new form, the current form will be invisible
            //and when you close that form, you will see the previous form again.
            try
            {
                Checking_Information nck = new Checking_Information();
                nck.Visible = true;
                this.Visible = false;
                nck.FormClosed += nck_FormClosed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void nck_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //make a new instance of that new form
            //and make that new form visible and at the meantime make the current one invisible
            //and also add an method to the form closing event to let the current show up again after closing that new form.
            //so it will be like when you open a new form, the current form will be invisible
            //and when you close that form, you will see the previous form again.
            try
            {
                Event_Status ne = new Event_Status();
                ne.Visible = true;
                this.Visible = false;
                ne.FormClosed += ne2_FormClosed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ne2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //make a new instance of that new form
            //and make that new form visible and at the meantime make the current one invisible
            //and also add an method to the form closing event to let the current show up again after closing that new form.
            //so it will be like when you open a new form, the current form will be invisible
            //and when you close that form, you will see the previous form again.
            try{
            Camp_site nc = new Camp_site();
            nc.Visible = true;
            this.Visible = false;
            nc.FormClosed += nc_FormClosed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void nc_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //make a new instance of that new form
            //and make that new form visible and at the meantime make the current one invisible
            //and also add an method to the form closing event to let the current show up again after closing that new form.
            //so it will be like when you open a new form, the current form will be invisible
            //and when you close that form, you will see the previous form again.
            try
            {
                Admin_Control na = new Admin_Control();
                na.Visible = true;
                this.Visible = false;
                na.FormClosed += na_FormClosed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void na_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //make a new instance of that new form
            //and make that new form visible and at the meantime make the current one invisible
            //and also add an method to the form closing event to let the current show up again after closing that new form.
            //so it will be like when you open a new form, the current form will be invisible
            //and when you close that form, you will see the previous form again.
            try{
            ShopIniRental nr = new ShopIniRental();
            nr.Visible = true;
            this.Visible = false;
            nr.FormClosed += nr_FormClosed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void nr_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //make a new instance of that new form
            //and make that new form visible and at the meantime make the current one invisible
            //and also add an method to the form closing event to let the current show up again after closing that new form.
            //so it will be like when you open a new form, the current form will be invisible
            //and when you close that form, you will see the previous form again.
            try{
            General_admin ng = new General_admin();
            ng.Visible = true;
            this.Visible = false;
            ng.FormClosed += ng_FormClosed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ng_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //make a new instance of that new form
            //and make that new form visible and at the meantime make the current one invisible
            //and also add an method to the form closing event to let the current show up again after closing that new form.
            //so it will be like when you open a new form, the current form will be invisible
            //and when you close that form, you will see the previous form again.
            try
            {
                Specific_Admin ns = new Specific_Admin();
                ns.Visible = true;
                this.Visible = false;
                ns.FormClosed += ns_FormClosed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ns_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //make a new instance of that new form
            //and make that new form visible and at the meantime make the current one invisible
            //and also add an method to the form closing event to let the current show up again after closing that new form.
            //so it will be like when you open a new form, the current form will be invisible
            //and when you close that form, you will see the previous form again.
            try
            {
            Entrance_Application ne = new Entrance_Application();
            ne.Visible = true;
            this.Visible = false;
            ne.FormClosed += ne_FormClosed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ne_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }

        private void Event_Initializer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //end the logfile with the end time.
            List<string> temp = new List<string>();
            int countLine = 0;
            FileStream fs = new FileStream("../../../logfile.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadLine();
            while (s != null)
            {
                temp.Add(s);
                s = sr.ReadLine();
            }
            sr.Dispose();
            fs.Dispose();

            FileStream nfs = new FileStream("../../../logfile.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(nfs);
            foreach (string st in temp)
            {

                countLine++;
                if (countLine == 3)
                {
                    sw.WriteLine(DateTime.Now.ToString());
                    sw.WriteLine(st);
                }
                else
                    sw.WriteLine(st);
            }
            sw.Dispose();
            nfs.Dispose();
        }
    }
}
