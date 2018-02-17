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
    public partial class employeeList : Form
    {
       SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=FoodManagement;Integrated Security=True");
        SqlCommand sc=new SqlCommand();
        
        public employeeList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * From SNUP", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" )
            {
                con.Open();
                sc.CommandText = "delete from SNUP where NM='" + textBox1.Text + "'";
                sc.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Item deleted");
                
                textBox1.Text = "";
                

            }
            else
                MessageBox.Show("Fill all the fields");
        }

        private void employeeList_Load(object sender, EventArgs e)
        {
            sc.Connection = con;
        }
    }
}
