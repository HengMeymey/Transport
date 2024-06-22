using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Final.Main;

namespace Final
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            string phoneNumber = phone_number.Text;
            string password = txtpassword.Text;

            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both phone number and password.", "Validation Error");
                return;
            }


            this.Hide();

            var mainToOpen = new main1();
            mainToOpen.Show();

        }
        public class main1 : Main
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            phone_number.Text = string.Empty;
            txtpassword.Text = string.Empty;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
