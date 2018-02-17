using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodManagement
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 s = new Form1();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu s = new Menu();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cost c = new Cost();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CoustomerList s = new CoustomerList();
            s.Show();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
          hdcost hdc = new hdcost();
            hdc.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeDelivery hd = new HomeDelivery();
            hd.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            search sr = new search();
            sr.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            employee em = new employee();
            em.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            searchEmployee se = new searchEmployee();
            se.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesReport sr = new salesReport();
            sr.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewMenu vm = new viewMenu();
            vm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            employeeList el = new employeeList();
            el.Show();
        }
    }
}
