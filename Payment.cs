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
using static Final.Main;
using static Final.Bus;


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
        //        int rowIndex = selectedRow.Index;

        //        int paymentId = rowIndex + 2;

        //        return paymentId;
        //    }

        //    return -1; // Default value if Payment Id is not found
        //}


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



        private void btnSearch_Click(object sender, EventArgs e)
        {
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

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("This contact is not found : " + contact);
                        //dgvPay.DataSource = null; 
                    }
                    else
                    {
                        dgvPay.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formToOpen = new Login();
            formToOpen.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainToOpen = new MainForm();
            mainToOpen.Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = "";
                }
            }
            LoadPaymentData();
        }
    }
}
