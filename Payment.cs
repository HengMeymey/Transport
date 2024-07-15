using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;


namespace Final
{
    public partial class Payment : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=dboTransportation;Integrated Security=True;";
        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            LoadPaymentData();
            dgvPay.SelectionChanged += DgvPay_SelectionChanged;
        }

        private void LoadPaymentData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spGetAllPayments", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvPay.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading payment data: " + ex.Message);
            }
        }

        private void DgvPay_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPay.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvPay.SelectedRows[0];
                dtpDate.Value = Convert.ToDateTime(selectedRow.Cells["Date"].Value);
                txtOrigin.Text = selectedRow.Cells["Origin"].Value.ToString();
                txtPhoneNumber.Text = selectedRow.Cells["Contact"].Value.ToString();
                txtCustomer.Text = selectedRow.Cells["CusName"].Value.ToString();
                txtDestination.Text = selectedRow.Cells["Destination"].Value.ToString();
                txtDepartureTime.Text = selectedRow.Cells["DepartureTime"].Value.ToString();
                txtStaffName.Text = selectedRow.Cells["StaffName"].Value.ToString();
                txtStaffPosition.Text = selectedRow.Cells["StaffPosition"].Value.ToString();
                txtBusNo.Text = selectedRow.Cells["BusNo"].Value.ToString();
                txtSeatNo.Text = selectedRow.Cells["SeatNumber"].Value.ToString();
                txtPrice.Text = selectedRow.Cells["TotalFare"].Value.ToString();
                checkPaid.Checked = Convert.ToBoolean(selectedRow.Cells["isPaid"].Value);
            }
        }
        //private int GetPaymentIdFromSelectedRow()
        //{
        //    if (dgvPay.SelectedRows.Count > 0)
        //    {
        //        DataGridViewRow selectedRow = dgvPay.SelectedRows[0];

        //        // Assuming the Payment Id is in the first cell of the selected row (you may need to adjust this based on your DataGridView's column order)
        //        if (selectedRow.Cells["PaymentId"].Value != null && int.TryParse(selectedRow.Cells["PaymentId"].Value.ToString(), out int paymentId))
        //        {
        //            return paymentId;
        //        }
        //    }

        //    // Return a default value or throw an exception based on your application logic
        //    return -1; // Default value if Payment Id is not found
        //}

        private int GetPaymentIdFromSelectedRow()
        {
            if (dgvPay.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvPay.SelectedRows[0];
                int rowIndex = selectedRow.Index;

                // Assuming the Payment Id starts from 2 and is in the first cell of the selected row
                int paymentId = rowIndex + 2;

                return paymentId;
            }

            // Return a default value or throw an exception based on your application logic
            return -1; // Default value if Payment Id is not found
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int paymentId = Convert.ToInt32(dgvPay.SelectedRows[0].Cells["PaymentId"].Value);

            // Validate user input (optional, add checks for empty fields or invalid formats)
            if (String.IsNullOrEmpty(txtCustomer.Text) || String.IsNullOrEmpty(txtBusNo.Text) ||
                String.IsNullOrEmpty(txtStaffName.Text) || String.IsNullOrEmpty(txtStaffPosition.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Prepare data for the stored procedure
            string cusName = txtCustomer.Text;
            string contact = txtPhoneNumber.Text;
            string busNo = txtBusNo.Text;
            string staffName = txtStaffName.Text;
            string staffPosition = txtStaffPosition.Text;
            int seatNumber = Convert.ToInt32(txtSeatNo.Text);
            string origin = txtOrigin.Text;
            string destination = txtDestination.Text;
            DateTime date = dtpDate.Value;
            DateTime? departureTime = null; // Set to null if DepartureTime is empty
            if (!String.IsNullOrEmpty(txtDepartureTime.Text))
            {
                departureTime = Convert.ToDateTime(txtDepartureTime.Text);
            }
            decimal totalFare = Convert.ToDecimal(txtPrice.Text);
            bool isPaid = checkPaid.Checked;

            // Call the stored procedure to update payment
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) // Replace with your connection string
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spUpdatePayment", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PaymentId", paymentId);
                    command.Parameters.AddWithValue("@CusName", cusName);
                    command.Parameters.AddWithValue("@Contact", contact);
                    command.Parameters.AddWithValue("@BusNo", busNo);
                    command.Parameters.AddWithValue("@StaffName", staffName);
                    command.Parameters.AddWithValue("@StaffPosition", staffPosition);
                    command.Parameters.AddWithValue("@SeatNumber", seatNumber);
                    command.Parameters.AddWithValue("@Origin", origin);
                    command.Parameters.AddWithValue("@Destination", destination);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@DepartureTime", departureTime);
                    command.Parameters.AddWithValue("@TotalFare", totalFare);
                    command.Parameters.AddWithValue("@isPaid", isPaid);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Payment updated successfully!");

                    // Refresh data grid (optional)
                    LoadPaymentData();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error updating payment: " + ex.Message);
            }
        }


        private async void button2_Click(object sender, EventArgs e)
        {
            // Ensure there's a selected row
            if (dgvPay.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to print.");
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = dgvPay.SelectedRows[0];

            // Create an object to hold the row data
            var rowData = new
            {
                PaymentID = selectedRow.Cells["PaymentID"].Value,
                CusName = selectedRow.Cells["CusName"].Value,
                Contact = selectedRow.Cells["Contact"].Value,
                BusNo = selectedRow.Cells["BusNo"].Value,
                StaffName = selectedRow.Cells["StaffName"].Value,
                StaffPosition = selectedRow.Cells["StaffPosition"].Value,
                SeatNumber = selectedRow.Cells["SeatNumber"].Value,
                Origin = selectedRow.Cells["Origin"].Value,
                Destination = selectedRow.Cells["Destination"].Value,
                Date = selectedRow.Cells["Date"].Value,
                DepartureTime = selectedRow.Cells["DepartureTime"].Value,
                TotalFare = selectedRow.Cells["TotalFare"].Value,
                IsPaid = selectedRow.Cells["isPaid"].Value
            };

            // Convert the row data to JSON
            var jsonData = JsonConvert.SerializeObject(new { data = rowData });

            // Send the JSON data to jsReport Online to generate the PDF
            var pdf = await GeneratePdfAsync(jsonData);

            // Save the PDF to a file
            if (pdf != null)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Save PDF File",
                    FileName = "Report.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, pdf);
                    MessageBox.Show("PDF saved successfully.");
                }
            }
        }

        private async Task<byte[]> GeneratePdfAsync(string jsonData)
        {
            using (var client = new HttpClient())
            {
                var url = "https://mey.jsreportonline.net/studio/templates/EMzTLUq"; // Replace with your jsReport Online server URL
                var templateName = "Transport"; // Replace with your jsReport template name or ID

                var requestContent = new StringContent(
                    JsonConvert.SerializeObject(new
                    {
                        template = new { name = templateName },
                        data = JsonConvert.DeserializeObject(jsonData)
                    }), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, requestContent);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    MessageBox.Show("An error occurred while generating the PDF: " + response.ReasonPhrase);
                    return null;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Retrieve the contact number from a textbox (assuming you have a textbox named txtContact)
            string contact = txtPhoneNumber.Text.Trim();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spSearchPaymentsByContact", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Contact", contact);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Assuming you have a DataGridView named dataGridViewPayments
                    dgvPay.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
