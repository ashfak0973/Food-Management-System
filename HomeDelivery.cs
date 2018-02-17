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
    public partial class HomeDelivery : Form
    {
        public HomeDelivery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String city = textBox1.Text;
            String sate = textBox2.Text;
            String country = textBox3.Text;

            StringBuilder ad = new StringBuilder("http://www.maps.google.com/maps?q=");

            ad.Append(city);
            ad.Append(" ");
            ad.Append(sate);
            ad.Append(" ");
            ad.Append(country);

            webBrowser1.Navigate(ad.ToString());

        }

        private void HomeDelivery_Load(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }
    }
}
