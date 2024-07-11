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
    public partial class Baggage : Form
    {
        public Baggage()
        {
            InitializeComponent();
            txtID.ReadOnly = true;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            //this.Load += new System.EventHandler(this.Form1_Load);
        }
        string connectionString = "Data Source=NOENG\\SQLEXPRESS01;Initial Catalog=Test;Integrated Security=True;";

        private void txtNameEN_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtCus.Text = string.Empty;
            txtCon.Text = string.Empty;
            txtStaffn.Text = string.Empty;
            cbStaffp.Text = string.Empty;
            txtReciver.Text = string.Empty;
            txtOrigin.Text = string.Empty;
            txtDes.Text = string.Empty;
            txtBagType.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtScale.Text = string.Empty;
            txtFare.Text = string.Empty;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainToOpen = new Main();
            mainToOpen.Show();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        { 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");

                    SqlCommand command = new SqlCommand("dbo.spInsertBaggage", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CusName", txtCus.Text);
                    command.Parameters.AddWithValue("@Contact", txtCon.Text);
                    command.Parameters.AddWithValue("@StaffName", txtStaffn.Text);
                    command.Parameters.AddWithValue("@StaffPosition", (cbStaffp.Text));
                    command.Parameters.AddWithValue("@ReceiverPhone", (txtReciver.Text));
                    command.Parameters.AddWithValue("@Origin", (txtOrigin.Text));
                    command.Parameters.AddWithValue("@Destination",(txtDes.Text));
                    command.Parameters.AddWithValue("@BaggageType", (txtBagType.Text));
                    command.Parameters.AddWithValue("@Qty", decimal.Parse(txtQty.Text));
                    command.Parameters.AddWithValue("@Scale", (txtScale.Text));
                    command.Parameters.AddWithValue("@Fare", decimal.Parse(txtFare.Text));

                    command.ExecuteNonQuery();

                    MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Text = string.Empty;
                    txtCus.Text = string.Empty;
                    txtCon.Text = string.Empty;
                    txtStaffn.Text = string.Empty;
                    cbStaffp.Text = string.Empty;
                    txtReciver.Text = string.Empty;
                    txtOrigin.Text = string.Empty;
                    txtDes.Text = string.Empty;
                    txtBagType.Text = string.Empty;
                    txtQty.Text = string.Empty;
                    txtScale.Text = string.Empty;
                    txtFare.Text = string.Empty;
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
            int baggageID;
            if (int.TryParse(txtID.Text, out baggageID))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connection successful!");

                        SqlCommand command = new SqlCommand("dbo.spUpdateBaggage", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BaggageID", baggageID);
                        command.Parameters.AddWithValue("@CusName", txtCus.Text);
                        command.Parameters.AddWithValue("@Contact", txtCon.Text);
                        command.Parameters.AddWithValue("@StaffName", txtStaffn.Text);
                        command.Parameters.AddWithValue("@StaffPosition", (cbStaffp.Text));
                        command.Parameters.AddWithValue("@ReceiverPhone", (txtReciver.Text));
                        command.Parameters.AddWithValue("@Origin", (txtOrigin.Text));
                        command.Parameters.AddWithValue("@Destination", (txtDes.Text));
                        command.Parameters.AddWithValue("@BaggageType", (txtBagType.Text));
                        command.Parameters.AddWithValue("@Qty", decimal.Parse(txtQty.Text));
                        command.Parameters.AddWithValue("@Scale", (txtScale.Text));
                        command.Parameters.AddWithValue("@Fare", decimal.Parse(txtFare.Text));


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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string contact = txtsearch.Text;

            if (!string.IsNullOrWhiteSpace(contact))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connection successful!");

                        SqlCommand command = new SqlCommand("dbo.spSearchBaggageByContact", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Contact", contact);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            DataRow firstRow = dataTable.Rows[0];

                            txtID.Text = firstRow["BaggageID"].ToString();
                            txtCus.Text = firstRow["CusName"].ToString();
                            txtCon.Text = firstRow["Contact"].ToString();
                            txtStaffn.Text = firstRow["StaffName"].ToString();
                            cbStaffp.Text = firstRow["StaffPosition"].ToString();
                            txtReciver.Text = firstRow["ReceiverPhone"].ToString();
                            txtOrigin.Text = firstRow["Origin"].ToString();
                            txtDes.Text = firstRow["Destination"].ToString();
                            txtBagType.Text = firstRow["BaggageType"].ToString();
                            txtQty.Text = firstRow["Qty"].ToString();
                            txtScale.Text = firstRow["Scale"].ToString();
                            txtFare.Text = firstRow["Fare"].ToString();
                            dataGridView1.DataSource = dataTable;

                            if (dataGridView1.Columns["Contact"] != null)
                            {
                                dataGridView1.Columns["Contact"].Visible = false;
                            }
                            if (dataGridView1.Columns["StaffName"] != null)
                            {
                                dataGridView1.Columns["StaffName"].Visible = false;
                            }
                            if (dataGridView1.Columns["StaffPosition"] != null)
                            {
                                dataGridView1.Columns["StaffPosition"].Visible = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Baggage not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        reader.Close();
                    }
                    catch (SqlException sqlEx)
                    {
                        Console.WriteLine("SQL Error: " + sqlEx.Message);
                        MessageBox.Show("Error occurred while querying data: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        MessageBox.Show("Unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Contact.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];


                txtID.Text = selectedRow.Cells["BaggageID"].Value.ToString();
                txtCus.Text = selectedRow.Cells["CusName"].Value.ToString();
                txtCon.Text = selectedRow.Cells["Contact"].Value.ToString();
                txtStaffn.Text = selectedRow.Cells["StaffName"].Value.ToString();
                cbStaffp.Text = selectedRow.Cells["StaffPosition"].Value.ToString();
                txtReciver.Text = selectedRow.Cells["ReceiverPhone"].Value.ToString();
                txtOrigin.Text = selectedRow.Cells["Origin"].Value.ToString();
                txtDes.Text = selectedRow.Cells["Destination"].Value.ToString();
                txtBagType.Text = selectedRow.Cells["BaggageType"].Value.ToString();
                txtQty.Text = selectedRow.Cells["Qty"].Value.ToString();
                txtScale.Text = selectedRow.Cells["Scale"].Value.ToString();
                txtFare.Text = selectedRow.Cells["Fare"].Value.ToString();

                //string baggageID = selectedRow.Cells["BaggageID"].Value.ToString();
                //var additionalData = GetAdditionalDataFromDatabase(baggageID);

                //txtCon.Text = additionalData.contact;
                //txtStaffn.Text = additionalData.staffName;
                //cbStaffp.Text = additionalData.staffPosition;
                // Hide the columns
                
                
                dataGridView1.Columns["Contact"].Visible = false;
                dataGridView1.Columns["StaffName"].Visible = false;
                dataGridView1.Columns["StaffPosition"].Visible = false;

            }
        }

        private void Baggage_Load(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");
                    string storedProcedureName = "GetBaggageDetails";
                    SqlCommand command = new SqlCommand(storedProcedureName, connection);
                    command.CommandType = CommandType.StoredProcedure;
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

        private void PopulateDataGridView()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.tblBaggage", connection);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int baggageID;
            if (int.TryParse(txtID.Text, out baggageID))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connection successful!");

                        SqlCommand command = new SqlCommand("dbo.spDeleteBaggage", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BaggageID", baggageID);

                        command.ExecuteNonQuery();
                        PopulateDataGridView();
                        txtID.Text = string.Empty;
                        txtCus.Text = string.Empty;
                        txtCon.Text = string.Empty;
                        txtStaffn.Text = string.Empty;
                        cbStaffp.Text = string.Empty;
                        txtReciver.Text = string.Empty;
                        txtOrigin.Text = string.Empty;
                        txtDes.Text = string.Empty;
                        txtBagType.Text = string.Empty;
                        txtQty.Text = string.Empty;
                        txtScale.Text = string.Empty;
                        txtFare.Text = string.Empty;
                        MessageBox.Show("Data deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        MessageBox.Show("Error occurred while deleting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Bus ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

    }
}
