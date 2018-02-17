using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace FoodManagement
{
    public partial class Order : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=FoodManagement;Integrated Security=True");
        SqlCommand sc = new SqlCommand();

        public Order()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "")
            {
                con.Open();
                sc.CommandText = "insert into ODR (NM,MBL,ADRs) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "') ";
                sc.ExecuteNonQuery();
                MessageBox.Show("Informations saved");
                con.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

                this.Hide();
                Cost c = new Cost();
                c.Show();
                

            }
        }

        private void Order_Load(object sender, EventArgs e)
        {
            sc.Connection = con;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h = new HomePage();
            h.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cost c = new Cost();
            c.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

