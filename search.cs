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
    public partial class search : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=FoodManagement;Integrated Security=True");
        public search()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Name" && textBox1.Text!="")
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select * From ODR where NM like ('" + textBox1.Text + "%')", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();

                }
            }
            else if (comboBox1.Text == "Mobile" && textBox1.Text != "")
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select * From ODR where MBL like ('" + textBox1.Text + "%')", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();

                }
            }
            else
                MessageBox.Show("Wrong input");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }
    }
        }
    
