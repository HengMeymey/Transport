using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Final
{
    public partial class Report : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=dboTransportation;Integrated Security=True;";
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            LoadAllPayments();
        }

        private void LoadAllPayments()
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

                        dgvReport.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading payment data: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime beginDate;
            DateTime endDate;

            // Validate date values
            if (!DateTime.TryParse(dtpBeginDate.Text, out beginDate) || !DateTime.TryParse(dateTimePicker1.Text, out endDate))
            {
                MessageBox.Show("Please select valid begin and end dates.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (beginDate > endDate)
            {
                MessageBox.Show("Begin date cannot be later than end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spGetPaymentsByDateRange", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@StartDate", beginDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvReport.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while filtering payment data: " + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Create a new DataTable
                DataTable dt = dgvReport.DataSource as DataTable;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export.", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create a new workbook and worksheet
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Report");

                    // Insert DataTable content into worksheet
                    worksheet.Cell(1, 1).InsertTable(dt);

                    // Save the workbook
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                        saveFileDialog.Title = "Save Excel File";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Data exported successfully.", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while exporting data to Excel: " + ex.Message);
            }
        }

        private void dtpBeginDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
