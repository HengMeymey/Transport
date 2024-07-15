using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Final.Form2;
using static Final.Main;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final
{
    public partial class Bus : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=dboTransportation;Integrated Security=True;";
        public Bus()
        {
            InitializeComponent();
            txtID.ReadOnly = true;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            txtsearch.KeyDown += txtsearch_KeyDown;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainToOpen = new MainForm();
            mainToOpen.Show();
        }
        public class MainForm : Main
        {

        }
        
        private void btnInsert_Click(object sender, EventArgs e)
        {
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");

                    SqlCommand command = new SqlCommand("dbo.spInsertBus", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BusType", txtBusType.Text);
                    command.Parameters.AddWithValue("@BusNo", txtBusNO.Text);
                    command.Parameters.AddWithValue("@BusModel", txtBusModel.Text);
                    command.Parameters.AddWithValue("@TotalSeat", int.Parse(txtTotalSeats.Text));
                    command.Parameters.AddWithValue("@DefaultFare", decimal.Parse(txtDefaultFarr.Text));

                    command.ExecuteNonQuery();
                    
                    MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Text = string.Empty;
                    txtBusType.Text = string.Empty;
                    txtBusNO.Text = string.Empty;
                    txtDefaultFarr.Text = string.Empty;
                    txtTotalSeats.Text = string.Empty;
                    txtBusModel.Text = string.Empty;
                    PopulateDataGridView();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    MessageBox.Show("Error occurred while inserting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int busID;
            if (int.TryParse(txtID.Text, out busID))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connection successful!");

                        SqlCommand command = new SqlCommand("dbo.spUpdateBus", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BusID", busID);
                        command.Parameters.AddWithValue("@BusType", txtBusType.Text);
                        command.Parameters.AddWithValue("@BusNo", txtBusNO.Text);
                        command.Parameters.AddWithValue("@BusModel", txtBusModel.Text);
                        command.Parameters.AddWithValue("@TotalSeat", int.Parse(txtTotalSeats.Text));
                        command.Parameters.AddWithValue("@DefaultFare", decimal.Parse(txtDefaultFarr.Text));

                        command.ExecuteNonQuery();
                        PopulateDataGridView();
                        MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        MessageBox.Show("Error occurred while updating data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Bus ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                txtID.Text = selectedRow.Cells["BusID"].Value.ToString();
                txtBusType.Text = selectedRow.Cells["BusType"].Value.ToString();
                txtBusNO.Text = selectedRow.Cells["BusNo"].Value.ToString();
                txtBusModel.Text = selectedRow.Cells["BusModel"].Value.ToString();
                txtTotalSeats.Text = selectedRow.Cells["TotalSeat"].Value.ToString();
                txtDefaultFarr.Text = selectedRow.Cells["DefaultFare"].Value.ToString();
            }
        }
        private void PopulateDataGridView()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");
                    SqlCommand command = new SqlCommand("dbo.spGetBusDatas", connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    MessageBox.Show("Error occurred while fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Bus_Load(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");
                    SqlCommand command = new SqlCommand("dbo.spGetBusDatas", connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    MessageBox.Show("Error occurred while fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SearchBusByBusNo(string busNo)
        {
            if (string.IsNullOrEmpty(busNo))
            {
                MessageBox.Show("Please enter a bus number.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.spSearchBusByBusNo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BusNo", busNo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);
                                dataGridView1.DataSource = dataTable;
                            }
                            else
                            {
                                MessageBox.Show("No records found.");
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL error occurred: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string busNo = txtsearch.Text.Trim();
            SearchBusByBusNo(busNo);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string busNo = txtsearch.Text.Trim();
            SearchBusByBusNo(busNo);
        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string busNo = txtsearch.Text.Trim();
                SearchBusByBusNo(busNo);
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevents the beep sound on Enter key press
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtBusType.Text = string.Empty;
            txtBusNO.Text = string.Empty;
            txtDefaultFarr.Text = string.Empty;
            txtTotalSeats.Text = string.Empty;
            txtBusModel.Text = string.Empty;
            txtsearch.Text = string.Empty;
            PopulateDataGridView();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formToOpen = new Login();
            formToOpen.Show();
        }
    }
}
