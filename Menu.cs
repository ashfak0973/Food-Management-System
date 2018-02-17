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
    public partial class Menu : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=FoodManagement;Integrated Security=True");
        SqlCommand sc=new SqlCommand();
        SqlDataReader sr;

        public Menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" & textBox2.Text!="")
            {
                con.Open();
                sc.CommandText = "delete from MN where ITM='"+textBox1.Text+"' and PRC='"+textBox2.Text+"'";
                sc.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Item deleted");
                loadlist();
                textBox1.Text = "";
                textBox2.Text = "";

            }
            else
                MessageBox.Show("Fill all the fields");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox1.Text!="" & textBox2.Text!="")
            {
                
                con.Open();
                sc.CommandText = "insert into MN (ITM,PRC) values ('" + textBox1.Text + "','" + textBox2.Text + "')";
                sc.ExecuteNonQuery();
               
                MessageBox.Show("Item added");
                con.Close();
                 textBox1.Text = "";
                 textBox2.Text = "";

                 loadlist();
            }
            else
                MessageBox.Show("Fill all the fields");
        }


        private void loadlist()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            con.Open();
            sc.CommandText = "select * from MN";
            sr = sc.ExecuteReader();
            if(sr.HasRows)
            {
                while(sr.Read())
                {
                    listBox1.Items.Add(sr[0].ToString());
                    listBox2.Items.Add(sr[1].ToString());

                }

            }
            con.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            sc.Connection = con;
            loadlist();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox l = sender as ListBox;
            if (l.SelectedIndex != -1)
            {
                listBox1.SelectedIndex = l.SelectedIndex;
                listBox2.SelectedIndex = l.SelectedIndex;
                textBox1.Text = listBox1.SelectedItem.ToString();
                textBox2.Text = listBox2.SelectedItem.ToString();


            }
        }

        private void listBox1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" & textBox2.Text != "" & listBox2.SelectedIndex!=-1)
            {
                con.Open();
                sc.CommandText = "update MN set ITM='" + textBox1.Text + "' , PRC='" + textBox2.Text + "' where ITM='"+listBox1.SelectedItem.ToString()+"' and  PRC='"+listBox2.SelectedItem.ToString()+"'";
                sc.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Item updated");
                loadlist();
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
                MessageBox.Show("Fill all the fields");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h = new HomePage();
            h.Show();
        }



    }
}
