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
                //txtPaidAmount.Text = selectedRow.Cells["TotalFare"].Value.ToString();
                dtpPayment.Value = Convert.ToDateTime(selectedRow.Cells["CreatedDate"].Value);
                txtStaffID.Text = selectedRow.Cells["StaffID"].Value.ToString();
                //txtStaffPosition.Text = selectedRow.Cells["StaffPosition"].Value.ToString();
                txtStaffName.Text = selectedRow.Cells["StaffName"].Value.ToString();
                textBox1.Text = selectedRow.Cells["BusNo"].Value.ToString();
                textBox2.Text = selectedRow.Cells["SeatNumber"].Value.ToString();
                textBox4.Text = selectedRow.Cells["TotalFare"].Value.ToString();
                checkPaid.Checked = Convert.ToBoolean(selectedRow.Cells["isPaid"].Value);
            }
        }
    }
}
