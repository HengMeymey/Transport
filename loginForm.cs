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
using static Final.Main;
using System.Configuration;

namespace Final
{
    public partial class Form2 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        static void Main1()
        {
           
            Console.ReadLine();
        }

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

            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please enter your phone number.", "Validation Error");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your password.", "Validation Error");
                return;
            }


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");

                    SqlCommand command = new SqlCommand("dbo.spLogin", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Contact", phoneNumber);
                    command.Parameters.AddWithValue("@Password", password);

                    int loginStatus = (int)command.ExecuteScalar();

                    if (loginStatus == 1)
                    {
                        MessageBox.Show("Welcome to our system!", "Login Successful");

                        this.Hide();
                        var mainToOpen = new main1();
                        mainToOpen.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid phone number or password.", "Login Error");
                        Console.WriteLine("No staff data found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    MessageBox.Show("An error occurred during login. Please try again.", "Login Error");
                }
            }
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

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '*';
        }
    }
}
