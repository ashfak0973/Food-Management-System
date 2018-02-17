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
    public partial class hdcost : Form
    {
        int  subt, ppc, pc;
        double vat = 0,total = 0,ttl=0;
        public static SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=FoodManagement;Integrated Security=True");
        SqlCommand sc = new SqlCommand();
        SqlDataReader sr;

        private List<cartitem> myit = new List<cartitem>();
        public void fill_combo()
        {
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from MN";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["ITM"].ToString());
            }
            con.Close();

        }
        public hdcost()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h = new HomePage();
            h.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from MN where ITM='" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                textBox3.Text = dr["PRC"].ToString();

            }
            con.Close();
        }

        private void hdcost_Load(object sender, EventArgs e)
        {
            sc.Connection = con;
            fill_combo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                ppc = int.Parse(textBox3.Text);
                pc = int.Parse(textBox2.Text);
                subt = ppc * pc;
                total = total + subt;
                listBox1.Items.Add(comboBox1.SelectedItem.ToString());
                listBox2.Items.Add(textBox2.Text.ToString());
                listBox3.Items.Add(subt.ToString());
                textBox1.Text = total.ToString();
                textBox5.Text = subt.ToString();


                cartitem itm = new cartitem()
                {
                    it = comboBox1.SelectedItem.ToString(),
                    pprc = textBox3.Text,
                    pc = textBox2.Text,
                    tp = textBox1.Text,
                    cst = textBox5.Text,

                };
                myit.Add(itm);

                textBox2.Clear();
                textBox3.Clear();
            }
            else
                MessageBox.Show("Fill all the fields");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            subt = 0;
            total = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox9.Clear();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Name: " + textBox8.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(10, 50));
            e.Graphics.DrawString("Mobile: " + textBox7.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(10, 70));
            e.Graphics.DrawString("Address: " + textBox6.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(10, 90));
            e.Graphics.DrawString("Date: " + DateTime.Now, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(10, 120));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(5, 175));
            e.Graphics.DrawString("Item", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 200));
            e.Graphics.DrawString("Pieces", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(450, 200));
            e.Graphics.DrawString("Per pice price(tk)", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(250, 200));
            e.Graphics.DrawString("Price(tk)", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(700, 200));

            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(5, 225));

            int y = 250;

            foreach (var i in myit)
            {
                e.Graphics.DrawString(i.it, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, y));
                e.Graphics.DrawString(i.pc, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(470, y));
                e.Graphics.DrawString(i.pprc, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(300, y));
                e.Graphics.DrawString(i.cst, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(700, y));

                y = y + 50;

            }

            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(5, y));

            e.Graphics.DrawString("Subtotal Cost = " + textBox1.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(570, y + 25));
            e.Graphics.DrawString("VAT = " + textBox9.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(645, y + 50));
            e.Graphics.DrawString("Home delivery charge = 200", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, y + 75));
            e.Graphics.DrawString("Total Cost = " + textBox4.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(600, y + 100));

        }

        private void button5_Click(object sender, EventArgs e)
        {

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (textBox8.Text != "" & textBox7.Text != "" & textBox6.Text != "")
            {
                con.Open();
                sc.CommandText = "insert into ODR (NM,MBL,ADRs) values ('" + textBox8.Text + "','" + textBox7.Text + "','" + textBox6.Text + "') ";
                sc.ExecuteNonQuery();
                MessageBox.Show("Informations saved");
                con.Close();


            }
            else
                MessageBox.Show("Fill all the fields");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            vat = total * .15;
            ttl = total + 200;
            textBox9.Text = vat.ToString();
            textBox4.Text = ttl.ToString();

            if (textBox11.Text != "" & textBox4.Text != "")
            {

                con.Open();
                sc.CommandText = "insert into SM (DT,CNM,AMNT) values ('" + textBox11.Text + "','" + textBox8.Text + "','" + textBox4.Text + "')";
                sc.ExecuteNonQuery();


                con.Close();

            }
            else
                MessageBox.Show("Fill all the fields");
        }

        
    }
}
