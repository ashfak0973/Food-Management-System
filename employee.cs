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

namespace FoodManagement
{
    public partial class employee : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=FoodManagement;Integrated Security=True");
        SqlCommand sc = new SqlCommand();
        public employee()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" && textBox4.Text != "" & textBox5.Text != "" & textBox6.Text != "" && textBox7.Text != "")
            {
                con.Open();
                sc.CommandText = "insert into SNUP (NM,FNM,NID,DOB,MBL,ADRS,EML) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "') ";
                sc.ExecuteNonQuery();
                MessageBox.Show("Informations saved");
                con.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";

            }
            else
                MessageBox.Show("Fill all the fields");
        }

        private void employee_Load(object sender, EventArgs e)
        {
            sc.Connection = con;
        }
    }
}
