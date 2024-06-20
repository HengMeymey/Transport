using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDataFromDatabase();
            btnRefresh.Click += BtnRefresh_Click;
        }
        string connectionString = "Data Source=localhost;Initial Catalog=dboTransportation;Integrated Security=True;";
        private void LoadDataFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spGetAllCustomers", connection);
                command.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);
                connection.Close();

                dgvCus.DataSource = dataTable;
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spGetAllCustomers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    connection.Open();
                    adapter.Fill(dataTable);
                    connection.Close();

                    dgvCus.DataSource = dataTable;
                }
            }
        }
    }
}