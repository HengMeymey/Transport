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
                dtpPayment.Value = Convert.ToDateTime(selectedRow.Cells["Date"].Value);
                txtStaffID.Text = selectedRow.Cells["Origin"].Value.ToString();
                txtMajorID.Text = selectedRow.Cells["Contact"].Value.ToString();
                txtPaidAmount.Text = selectedRow.Cells["CusName"].Value.ToString();
                txtStaffPosition.Text = selectedRow.Cells["Destination"].Value.ToString();
                txtStuID.Text = selectedRow.Cells["DepartureTime"].Value.ToString();
                txtStaffName.Text = selectedRow.Cells["StaffName"].Value.ToString();
                textBox3.Text = selectedRow.Cells["StaffPosition"].Value.ToString();
                textBox1.Text = selectedRow.Cells["BusNo"].Value.ToString();
                textBox2.Text = selectedRow.Cells["SeatNumber"].Value.ToString();
                textBox4.Text = selectedRow.Cells["TotalFare"].Value.ToString();
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            

            // Call the stored procedure to update the payment
            //using (SqlConnection connection = new SqlConnection("YourConnectionStringHere"))
            //{
            //    using (SqlCommand command = new SqlCommand("dbo.spUpdatePayment", connection))
            //    {
            //        command.CommandType = CommandType.StoredProcedure;

            //        command.Parameters.AddWithValue("@PaymentId", paymentId);
            //        command.Parameters.AddWithValue("@CusId", cusId);
            //        command.Parameters.AddWithValue("@CusName", cusName);
            //        command.Parameters.AddWithValue("@Contact", contact);
            //        command.Parameters.AddWithValue("@BusId", busId);
            //        command.Parameters.AddWithValue("@BusNo", busNo);
            //        command.Parameters.AddWithValue("@StaffId", staffId);
            //        command.Parameters.AddWithValue("@StaffName", staffName);
            //        command.Parameters.AddWithValue("@BookingDetailsId", bookingDetailsId);
            //        command.Parameters.AddWithValue("@SeatNumber", seatNumber);
            //        command.Parameters.AddWithValue("@Origin", origin);
            //        command.Parameters.AddWithValue("@Destination", destination);
            //        command.Parameters.AddWithValue("@Date", date);
            //        command.Parameters.AddWithValue("@DepartureTime", departureTime);
            //        command.Parameters.AddWithValue("@TotalFare", totalFare);
            //        command.Parameters.AddWithValue("@CreatedDate", createdDate);
            //        command.Parameters.AddWithValue("@isPaid", isPaid);

            //        connection.Open();
            //        command.ExecuteNonQuery();
            //    }
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Retrieve values from the textboxes and controls
            int paymentId = GetPaymentIdFromSelectedRow(); // Implement this method to get the Payment Id from the selected row
            //int cusId = Convert.ToInt32(txtCusId.Text);
            string cusName = txtPaidAmount.Text;
            string contact = txtMajorID.Text;
            //int busId = Convert.ToInt32(txtBusId.Text);
            string busNo = textBox1.Text;
            //int staffId = Convert.ToInt32(txtStaffId.Text);
            string staffName = txtStaffName.Text;
            //int bookingDetailsId = Convert.ToInt32(txtBookingDetailsId.Text);
            int seatNumber = Convert.ToInt32(textBox2.Text);
            string origin = txtStaffID.Text;
            string destination = txtStaffPosition.Text;
            string date = dtpPayment.Text;
            string departureTime = txtStuID.Text;
            decimal totalFare = Convert.ToDecimal(textBox4.Text);
            DateTime createdDate = DateTime.Now; // Assuming the current date is the creation date
            bool isPaid = checkPaid.Checked ? true : false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.spUpdatePayment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PaymentId", paymentId);
                    //command.Parameters.AddWithValue("@CusId", cusId);
                    command.Parameters.AddWithValue("@CusName", cusName);
                    command.Parameters.AddWithValue("@Contact", contact);
                    //command.Parameters.AddWithValue("@BusId", busId);
                    command.Parameters.AddWithValue("@BusNo", busNo);
                    //command.Parameters.AddWithValue("@StaffId", staffId);
                    command.Parameters.AddWithValue("@StaffName", staffName);
                    //command.Parameters.AddWithValue("@BookingDetailsId", bookingDetailsId);
                    command.Parameters.AddWithValue("@SeatNumber", seatNumber);
                    command.Parameters.AddWithValue("@Origin", origin);
                    command.Parameters.AddWithValue("@Destination", destination);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@DepartureTime", departureTime);
                    command.Parameters.AddWithValue("@TotalFare", totalFare);
                    command.Parameters.AddWithValue("@CreatedDate", createdDate);
                    command.Parameters.AddWithValue("@isPaid", isPaid);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
