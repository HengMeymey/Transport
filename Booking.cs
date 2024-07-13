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

namespace Final
{
    public partial class Booking : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=dboTransportation;Integrated Security=True;";
        public Booking()
        {
            InitializeComponent();
            txtID.ReadOnly = true;
            dgvBooking.CellClick += dgvBooking_CellContentClick;
        }
        private void dgvBooking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvBooking.Rows[e.RowIndex];
                txtID.Text = selectedRow.Cells["BookingID"].Value.ToString();
                txtCusName.Text = selectedRow.Cells["CusName"].Value.ToString();
                txtContact.Text = selectedRow.Cells["Contact"].Value.ToString();
                txtBusNo.Text = selectedRow.Cells["BusNo"].Value.ToString();
                txtSeatNumber.Text = selectedRow.Cells["SeatNumber"].Value.ToString();
                txtFare.Text = selectedRow.Cells["Fare"].Value.ToString();
                txtOrigin.Text = selectedRow.Cells["Origin"].Value.ToString();
                txtDestination.Text = selectedRow.Cells["Destination"].Value.ToString();
                dateTimePicker1.Text = selectedRow.Cells["Date"].Value.ToString();
                txtTime.Text = selectedRow.Cells["DepartureTime"].Value.ToString();
                txtStaffName.Text = selectedRow.Cells["StaffName"].Value.ToString();
                txtStaffPosition.Text = selectedRow.Cells["StaffPosition"].Value.ToString();
            }
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand to execute the stored procedure
                    using (SqlCommand command = new SqlCommand("spGetAllBookings", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        DataTable dataTable = new DataTable();

                        adapter.Fill(dataTable);

                        dgvBooking.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that might have occurred
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string contact = txtSearch.Text.Trim();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spSearchBookingByContact", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Contact", contact);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvBooking.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Validate user input (optional)
            if (string.IsNullOrEmpty(txtCusName.Text) || string.IsNullOrEmpty(txtContact.Text) ||
                string.IsNullOrEmpty(txtBusNo.Text) || !int.TryParse(txtSeatNumber.Text, out int seatNumber) ||
                string.IsNullOrEmpty(txtStaffName.Text) || string.IsNullOrEmpty(txtStaffPosition.Text) ||
                string.IsNullOrEmpty(txtOrigin.Text) || string.IsNullOrEmpty(txtDestination.Text) ||
                !DateTime.TryParse(dateTimePicker1.Text, out DateTime date) ||
                !DateTime.TryParse(txtTime.Text, out DateTime departureTime) ||
                !decimal.TryParse(txtFare.Text, out decimal fare))
            {
                MessageBox.Show("Please fill in all fields with valid data.");
                return;
            }
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                // Create a SqlCommand object for the stored procedure
                SqlCommand command = new SqlCommand("spInsertBooking", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters to the SqlCommand object
                command.Parameters.AddWithValue("@CusName", txtCusName.Text);
                command.Parameters.AddWithValue("@Contact", txtContact.Text);
                command.Parameters.AddWithValue("@BusNo", txtBusNo.Text);
                command.Parameters.AddWithValue("@SeatNumber", seatNumber);
                command.Parameters.AddWithValue("@StaffName", txtStaffName.Text);
                command.Parameters.AddWithValue("@StaffPosition", txtStaffPosition.Text);
                command.Parameters.AddWithValue("@Origin", txtOrigin.Text);
                command.Parameters.AddWithValue("@Destination", txtDestination.Text);
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@DepartureTime", departureTime);
                command.Parameters.AddWithValue("@Fare", fare);

                // Execute the stored procedure and get the inserted BookingId
                int bookingId = (int)command.ExecuteScalar();

                if (bookingId > 0)
                {
                    MessageBox.Show("Booking inserted successfully! Booking ID: " + bookingId.ToString());
                    // Clear textboxes for new entry (optional)
                    txtCusName.Text = "";
                    txtContact.Text = "";
                    txtBusNo.Text = "";
                    txtSeatNumber.Text = "";
                    txtStaffName.Text = "";
                    txtStaffPosition.Text = "";
                    txtOrigin.Text = "";
                    txtDestination.Text = "";
                    dateTimePicker1.Text = "";
                    txtTime.Text = "";
                    txtFare.Text = "";
                }
                else
                {
                    MessageBox.Show("An error occurred while inserting booking.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }
}
