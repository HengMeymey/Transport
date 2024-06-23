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

namespace Final
{
    public partial class Form2 : Form
    {

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

            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both phone number and password.", "Validation Error");
                return;
            }


            string connectionString = "Data Source=DESKTOP-C18EFJB\\DBSERVER;Initial Catalog=Transportation;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");

                    SqlCommand command = new SqlCommand("dbo.GetStaffData", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.AddWithValue("@phonenumber", phoneNumber);
                    command.Parameters.AddWithValue("@password", password);

                    // Execute the stored procedure
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        this.Hide();
                        var mainToOpen = new main1();
                        mainToOpen.Show();

                    }
                    else
                    {
                        MessageBox.Show("Invalid phone number or password.", "Login Error");
                        Console.WriteLine("No staff data found.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
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
