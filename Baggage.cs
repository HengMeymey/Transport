using System;
using System.Data;
using System.Data.SqlClient;
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
            staffNameComboBox.Text = string.Empty;
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
            var mainToOpen = new Staff();
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

                    SqlCommand command = new SqlCommand("spInsertBaggage", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CusName", txtCus.Text);
                    command.Parameters.AddWithValue("@Contact", txtCon.Text);
                    string selectedStaffName = staffNameComboBox.Text;
                    int selectedStaffID = GetStaffIDByName(selectedStaffName); 

                    if (selectedStaffID == -1)
                    {
                        MessageBox.Show("Please select a valid staff member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string selectedStaffPosition = cbStaffp.Text;
                    int selectedStaffIPosition = GetStaffIDByPosition(selectedStaffPosition); 

                    if (selectedStaffIPosition == -1)
                    {
                        MessageBox.Show("Please select a valid staff member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    command.Parameters.AddWithValue("@StaffID", selectedStaffID);
                    command.Parameters.AddWithValue("@StaffName", selectedStaffName);
                    command.Parameters.AddWithValue("@StaffPosition", selectedStaffPosition);
                    command.Parameters.AddWithValue("@ReceiverPhone", txtReciver.Text);
                    command.Parameters.AddWithValue("@Origin", txtOrigin.Text);
                    command.Parameters.AddWithValue("@Destination", txtDes.Text);
                    command.Parameters.AddWithValue("@BaggageType", txtBagType.Text);
                    command.Parameters.AddWithValue("@Qty", int.Parse(txtQty.Text));
                    command.Parameters.AddWithValue("@Scale", txtScale.Text);
                    command.Parameters.AddWithValue("@Fare", decimal.Parse(txtFare.Text));

                    command.ExecuteNonQuery();

                    MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtCus.Clear();
                    txtCon.Clear();
                    staffNameComboBox.SelectedIndex = -1;
                    cbStaffp.SelectedIndex = -1;
                    txtReciver.Clear();
                    txtOrigin.SelectedIndex = -1;
                    txtDes.SelectedIndex = -1;
                    txtBagType.SelectedIndex = -1;
                    txtQty.Clear();
                    txtScale.Clear();
                    txtFare.Clear();

                    PopulateDataGridView(); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    MessageBox.Show("Error occurred while inserting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int GetStaffIDByName(string staffName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT StaffID FROM tblStaff WHERE Name = @Name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", staffName);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                return -1;
            }
        }

        private int GetStaffIDByPosition(string staffPosition)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT StaffID FROM tblStaff WHERE StaffPosition = @StaffPosition";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StaffPosition", staffPosition);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                return -1;
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
                        command.Parameters.AddWithValue("@StaffName", staffNameComboBox.Text);
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
                            staffNameComboBox.Text = firstRow["StaffName"].ToString();
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
                staffNameComboBox.Text = selectedRow.Cells["StaffName"].Value.ToString();
                cbStaffp.Text = selectedRow.Cells["StaffPosition"].Value.ToString();
                txtReciver.Text = selectedRow.Cells["ReceiverPhone"].Value.ToString();
                txtOrigin.Text = selectedRow.Cells["Origin"].Value.ToString();
                txtDes.Text = selectedRow.Cells["Destination"].Value.ToString();
                txtBagType.Text = selectedRow.Cells["BaggageType"].Value.ToString();
                txtQty.Text = selectedRow.Cells["Qty"].Value.ToString();
                txtScale.Text = selectedRow.Cells["Scale"].Value.ToString();
                txtFare.Text = selectedRow.Cells["Fare"].Value.ToString();


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
                    txtOrigin.DropDownStyle = ComboBoxStyle.DropDownList;
                    txtDes.DropDownStyle = ComboBoxStyle.DropDownList;
                    txtBagType.DropDownStyle = ComboBoxStyle.DropDownList;
                    PopulateStaffNameComboBox();
                    PopulateStaffPositionComboBox();

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
                        staffNameComboBox.Text = string.Empty;
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

        private void PopulateStaffNameComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetStaffNameDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                staffNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                staffNameComboBox.DataSource = dt;
                staffNameComboBox.DisplayMember = "Name";

            }
        }

        private void PopulateStaffPositionComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetStaffPositionDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbStaffp.DropDownStyle = ComboBoxStyle.DropDownList;
                cbStaffp.DataSource = dt;
                cbStaffp.DisplayMember = "StaffPosition"; 
            }
        }

        private void staffNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (staffNameComboBox.SelectedIndex != -1)
            {
                string selectedStaffName = staffNameComboBox.Text;
                string staffPosition = GetStaffPositionByName(selectedStaffName);
                cbStaffp.Enabled = false;
                if (!string.IsNullOrEmpty(staffPosition))
                {
                    int staffPositionIndex = cbStaffp.FindStringExact(staffPosition);

                    if (staffPositionIndex != -1)
                    {
                        cbStaffp.SelectedIndex = staffPositionIndex;
                    }
                    else
                    {
                        Console.WriteLine($"StaffPosition '{staffPosition}' not found in cbStaffp.");
                    }
                }
                else
                {
                    Console.WriteLine($"No staff position found for NameKH: {selectedStaffName}");
                }
            }
        }

        private string GetStaffPositionByName(string staffName)
        {
            string procedureName = "GetStaffPositionByStaffNameEN";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", staffName);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        Console.WriteLine($"No staff position found for NameKH: {staffName}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching staff position: {ex.Message}");
                    throw; 
                }
            }
            return string.Empty; 
        }

    }
}
