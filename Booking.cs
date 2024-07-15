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
using static Final.Bus;
using static Final.Main;

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
            cbBusNo.DropDown += ComboBox_DropDown;
            cbSeatNumber.DropDown += ComboBox_DropDown;
            cbStaffName.DropDown += ComboBox_DropDown;
            cbStaffPosition.DropDown += ComboBox_DropDown;
        }
        private void dgvBooking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvBooking.Rows[e.RowIndex];
                txtID.Text = selectedRow.Cells["BookingID"].Value.ToString();
                txtCusName.Text = selectedRow.Cells["CusName"].Value.ToString();
                txtContact.Text = selectedRow.Cells["Contact"].Value.ToString();
                cbBusNo.Text = selectedRow.Cells["BusNo"].Value.ToString();
                cbSeatNumber.Text = selectedRow.Cells["SeatNumber"].Value.ToString();
                txtFare.Text = selectedRow.Cells["Fare"].Value.ToString();
                txtOrigin.Text = selectedRow.Cells["Origin"].Value.ToString();
                txtDestination.Text = selectedRow.Cells["Destination"].Value.ToString();
                dateTimePicker1.Text = selectedRow.Cells["Date"].Value.ToString();
                txtTime.Text = selectedRow.Cells["DepartureTime"].Value.ToString();
                cbStaffName.Text = selectedRow.Cells["StaffName"].Value.ToString();
                cbStaffPosition.Text = selectedRow.Cells["StaffPosition"].Value.ToString();
            }
        }


        private void LoadComboBoxData(ComboBox comboBox)
        {
            string storedProcedureName = string.Empty;
            string displayMember = string.Empty;

            switch (comboBox.Name)
            {
                case "cbBusNo":
                    storedProcedureName = "spGetBusNos";
                    displayMember = "BusNo";
                    break;
                case "cbSeatNumber":
                    storedProcedureName = "spGetSeatNumbers";
                    displayMember = "SeatNumber";
                    break;
                case "cbStaffName":
                    storedProcedureName = "spGetStaffNames";
                    displayMember = "StaffName";
                    break;
                case "cbStaffPosition":
                    storedProcedureName = "spGetStaffPositions";
                    displayMember = "StaffPosition";
                    break;
            }

            if (!string.IsNullOrEmpty(storedProcedureName))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // Add parameters if necessary (e.g., for spGetSeatNumbers)
                            if (storedProcedureName == "spGetSeatNumbers")
                            {
                                // Assuming cbBusNo.SelectedValue or cbBusNo.Text provides the BusNo
                                command.Parameters.AddWithValue("@BusNo", cbBusNo.Text.Trim());
                            }

                            if (storedProcedureName == "spGetStaffPositions")
                            {
                                command.Parameters.AddWithValue("@StaffName", cbStaffName.Text.Trim());
                            }

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                comboBox.Items.Clear();
                                while (reader.Read())
                                {
                                    comboBox.Items.Add(reader[displayMember].ToString());
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
        }



        private void ClearTextBoxes()
        {
            // Clear all textboxes for new entry
            txtCusName.Text = "";
            txtContact.Text = "";
            cbBusNo.Text = "";
            cbSeatNumber.Text = "";
            cbStaffName.Text = "";
            cbStaffPosition.Text = "";
            txtOrigin.Text = "";
            txtDestination.Text = "";
            dateTimePicker1.Text = "";
            txtTime.Text = "";
            txtFare.Text = "";
        }

        private void cbBusNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBusNo = cbBusNo.Text.Trim();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spGetSeatNumbers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BusNo", selectedBusNo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            cbSeatNumber.Items.Clear();
                            while (reader.Read())
                            {
                                cbSeatNumber.Items.Add(reader["SeatNumber"].ToString());
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

        private void cbStaffName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStaffPosition();
        }

        private void LoadStaffPosition()
        {
            string selectedStaffName = cbStaffName.Text.Trim();

            if (!string.IsNullOrEmpty(selectedStaffName))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("spGetStaffPositions", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@StaffName", selectedStaffName);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    cbStaffPosition.Text = reader["StaffPosition"].ToString();
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
        }



        private void ComboBox_DropDown(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                LoadComboBoxData(comboBox);
            }
        }

        private void LoadBookingData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
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

        private void Booking_Load(object sender, EventArgs e)
        {
            LoadBookingData();
            ClearTextBoxes();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadBookingData();
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
            if (string.IsNullOrEmpty(txtCusName.Text) || string.IsNullOrEmpty(txtContact.Text) ||
                string.IsNullOrEmpty(cbBusNo.Text) || !int.TryParse(cbSeatNumber.Text, out int seatNumber) ||
                string.IsNullOrEmpty(cbStaffName.Text) || string.IsNullOrEmpty(cbStaffPosition.Text) ||
                string.IsNullOrEmpty(txtOrigin.Text) || string.IsNullOrEmpty(txtDestination.Text) ||
                !DateTime.TryParse(dateTimePicker1.Text, out DateTime date) ||
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
                command.Parameters.AddWithValue("@BusNo", cbBusNo.Text);
                command.Parameters.AddWithValue("@SeatNumber", seatNumber);
                command.Parameters.AddWithValue("@StaffName", cbStaffName.Text);
                command.Parameters.AddWithValue("@StaffPosition", cbStaffPosition.Text);
                command.Parameters.AddWithValue("@Origin", txtOrigin.Text);
                command.Parameters.AddWithValue("@Destination", txtDestination.Text);
                command.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                command.Parameters.AddWithValue("@DepartureTime", txtTime.Text);
                command.Parameters.AddWithValue("@Fare", fare);

                // Execute the stored procedure and get the inserted BookingId
                int bookingId = (int)command.ExecuteScalar();

                if (bookingId > 0)
                {
                    MessageBox.Show("Booking inserted successfully! ");
                    LoadBookingData();
                    ClearTextBoxes();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Ensure a booking is selected before updating
            if (dgvBooking.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking to update.");
                return;
            }

            // Retrieve booking details from the selected row
            int bookingId = Convert.ToInt32(dgvBooking.SelectedRows[0].Cells["BookingId"].Value); 
            string cusName = txtCusName.Text;
            string contact = txtContact.Text;
            string busNo = cbBusNo.Text;
            int seatNumber;
            if (!int.TryParse(cbSeatNumber.Text, out seatNumber))
            {
                seatNumber = 0; 
            }
            string staffName = cbStaffName.Text;
            string staffPosition = cbStaffPosition.Text;
            string origin = txtOrigin.Text;
            string destination = txtDestination.Text;
            DateTime date = dateTimePicker1.Value;
            DateTime departureTime = DateTime.Parse(txtTime.Text); 
            decimal fare;
            if (!decimal.TryParse(txtFare.Text, out fare))
            {
                fare = 0; 
            }
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("spUpdateBooking", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@BookingId", bookingId);
                command.Parameters.AddWithValue("@CusName", cusName);
                command.Parameters.AddWithValue("@Contact", contact);
                command.Parameters.AddWithValue("@BusNo", busNo);
                command.Parameters.AddWithValue("@SeatNumber", seatNumber);
                command.Parameters.AddWithValue("@StaffName", staffName);
                command.Parameters.AddWithValue("@StaffPosition", staffPosition);
                command.Parameters.AddWithValue("@Origin", origin);
                command.Parameters.AddWithValue("@Destination", destination);
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@DepartureTime", departureTime);
                command.Parameters.AddWithValue("@Fare", fare);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Booking updated successfully!");
                    LoadBookingData(); 
                    ClearTextBoxes(); 
                }
                else
                {
                    MessageBox.Show("An error occurred while updating booking.");
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainToOpen = new MainForm();
            mainToOpen.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formToOpen = new Login();
            formToOpen.Show();
        }
    }
}
