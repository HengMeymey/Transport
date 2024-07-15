using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Final
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
            txtID.ReadOnly = true;
            dataGridView1.CellClick += dataGridView1_CellContentClick;

        }
        string connectionString = "Data Source=NOENG\\SQLEXPRESS01;Initial Catalog=Test;Integrated Security=True;";

        public class MainForm : Main
        {

        }
        private void PopulateDataGridView()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "GetStaffDetails";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    if (dataGridView1.Columns.Contains("Avatar"))
                    {
                        dataGridView1.Columns["Avatar"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    MessageBox.Show("Error occurred while fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");
                    string query = "GetStaffDetails";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    cbGen.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbAdd.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbPos.DropDownStyle = ComboBoxStyle.DropDownList;
                    txtwork.DropDownStyle = ComboBoxStyle.DropDownList;

                    dataGridView1.DataSource = dataTable;

                    if (dataGridView1.Columns.Contains("Avatar"))
                    {
                        dataGridView1.Columns["Avatar"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    MessageBox.Show("Error occurred while fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                txtID.Text = selectedRow.Cells["StaffID"].Value.ToString();
                txtNameEN.Text = selectedRow.Cells["Name"].Value.ToString();
                txtNameKH.Text = selectedRow.Cells["NameKH"].Value.ToString();
                txtCon.Text = selectedRow.Cells["Contact"].Value.ToString();
                cbGen.Text = selectedRow.Cells["Gender"].Value.ToString();
                txtEma.Text = selectedRow.Cells["Email"].Value.ToString();
                cbAdd.Text = selectedRow.Cells["Address"].Value.ToString();

                if (selectedRow.Cells["BirthDate"].Value != DBNull.Value)
                {
                    txtBir.Text = Convert.ToDateTime(selectedRow.Cells["BirthDate"].Value).ToString("MM/dd/yyyy");
                }
                else
                {
                    txtBir.Text = string.Empty;
                }

                cbPos.Text = selectedRow.Cells["StaffPosition"].Value.ToString();
                txtwork.Text = selectedRow.Cells["IsStoppedWork"].Value.ToString();

                if (dataGridView1.Columns.Contains("Avatar"))
                {
                    if (selectedRow.Cells["Avatar"].Value != DBNull.Value)
                    {
                        byte[] avatarData = (byte[])selectedRow.Cells["Avatar"].Value;
                        using (MemoryStream ms = new MemoryStream(avatarData))
                        {
                            pbAvtar.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pbAvtar.Image = null;
                    }
                }
                else
                {
                    pbAvtar.Image = null;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string staffName = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(staffName))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connection successful!");

                        SqlCommand command = new SqlCommand("dbo.spSearchStaffByName", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Name", staffName);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            DataRow firstRow = dataTable.Rows[0];

                            txtID.Text = firstRow["StaffID"].ToString();
                            txtNameEN.Text = firstRow["Name"].ToString();
                            txtNameKH.Text = firstRow["NameKH"].ToString();
                            txtCon.Text = firstRow["Contact"].ToString();
                            cbGen.Text = firstRow["Gender"].ToString();
                            txtEma.Text = firstRow["Email"].ToString();
                            cbAdd.Text = firstRow["Address"].ToString();
                            txtBir.Text = firstRow["BirthDate"] != DBNull.Value ? Convert.ToDateTime(firstRow["BirthDate"]).ToString("MM/dd/yyyy") : string.Empty;
                            cbPos.Text = firstRow["StaffPosition"].ToString();
                            txtwork.Text = firstRow["IsStoppedWork"].ToString();
                            if (firstRow["Avatar"] != DBNull.Value)
                            {
                                byte[] avatarData = (byte[])firstRow["Avatar"];
                                using (MemoryStream ms = new MemoryStream(avatarData))
                                {
                                    pbAvtar.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                pbAvtar.Image = null;
                            }
                            dataGridView1.DataSource = dataTable;
                              
                        }
                        else
                        {
                            MessageBox.Show("Staff not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputFields();
                            pbAvtar.Image = null;
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
                ClearInputFields();
                pbAvtar.Image = null;
            }
        }

        private void ClearInputFields()
        {
            txtNameEN.Clear();
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("dbo.spInsertStaff", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", txtNameEN.Text);
                    command.Parameters.AddWithValue("@NameKH", txtNameKH.Text);
                    command.Parameters.AddWithValue("@Contact", txtCon.Text);
                    command.Parameters.AddWithValue("@Gender", cbGen.Text);
                    command.Parameters.AddWithValue("@Email", txtEma.Text);
                    command.Parameters.AddWithValue("@Address", cbAdd.Text);

                    DateTime birthDate;
                    if (DateTime.TryParseExact(txtBir.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                    {
                        command.Parameters.AddWithValue("@BirthDate", birthDate);
                    }
                    else
                    {
                        MessageBox.Show("Invalid BirthDate format! Please enter the date in MM/dd/yyyy format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    command.Parameters.AddWithValue("@StaffPosition", cbPos.Text);
                    command.Parameters.AddWithValue("@IsStoppedWork", Convert.ToBoolean(txtwork.Text));

                    byte[] avatarData = null;
                    if (pbAvtar.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pbAvtar.Image.Save(ms, pbAvtar.Image.RawFormat);
                            avatarData = ms.ToArray();
                        }
                    }

                    command.Parameters.AddWithValue("@Avatar", (object)avatarData ?? DBNull.Value);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputFields();
                    PopulateDataGridView();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    MessageBox.Show("Error occurred while inserting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            int staffID;
            if (int.TryParse(txtID.Text, out staffID))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connection successful!");

                        SqlCommand command = new SqlCommand("dbo.spUpdateStaff", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StaffID", staffID);
                        command.Parameters.AddWithValue("@Name", txtNameEN.Text);
                        command.Parameters.AddWithValue("@NameKH", txtNameKH.Text);
                        command.Parameters.AddWithValue("@Contact", txtCon.Text);
                        command.Parameters.AddWithValue("@Gender", cbGen.Text);
                        command.Parameters.AddWithValue("@Email", txtEma.Text);
                        command.Parameters.AddWithValue("@Address", cbAdd.Text);

                        DateTime birthDate;
                        if (DateTime.TryParseExact(txtBir.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                        {
                            command.Parameters.AddWithValue("@BirthDate", birthDate);
                        }
                        else
                        {
                            MessageBox.Show("Invalid BirthDate format! Please enter the date in MM/dd/yyyy format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        command.Parameters.AddWithValue("@StaffPosition", cbPos.Text);
                        command.Parameters.AddWithValue("@IsStoppedWork", Convert.ToBoolean(txtwork.Text));

                        byte[] avatarData = null;
                        if (pbAvtar.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                pbAvtar.Image.Save(ms, pbAvtar.Image.RawFormat);
                                avatarData = ms.ToArray();
                            }
                        }

                        command.Parameters.AddWithValue("@Avatar", (object)avatarData ?? DBNull.Value);

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
                MessageBox.Show("Please enter a valid Staff ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            cbAdd.Text = string.Empty;
            txtBir.Text = string.Empty;
            txtCon.Text = string.Empty;
            txtEma.Text = string.Empty;
            txtNameEN.Text = string.Empty;
            txtNameKH.Text = string.Empty;
            cbPos.Text = string.Empty;
            txtwork.Text = string.Empty;
            cbGen.Text = string.Empty;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            int staffID;
            if (int.TryParse(txtID.Text, out staffID))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connection successful!");

                        SqlCommand command = new SqlCommand("dbo.spDeleteStaff", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StaffID", staffID);

                        command.ExecuteNonQuery();
                        PopulateDataGridView();
                     
                        txtID.Text = string.Empty;
                        cbAdd.Text = string.Empty;
                        txtBir.Text = string.Empty;
                        txtCon.Text = string.Empty;
                        txtEma.Text = string.Empty;
                        txtNameEN.Text = string.Empty;
                        txtNameKH.Text = string.Empty;
                        cbPos.Text = string.Empty;
                        txtwork.Text = string.Empty;
                        cbGen.Text = string.Empty;
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
                MessageBox.Show("Please enter a valid Staff ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainToOpen = new Main();
            mainToOpen.Show();
        }

        private byte[] imageData = null;

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                pbAvtar.Image = new Bitmap(open.FileName);
                pbAvtar.Tag = open.FileName;
                imageData = File.ReadAllBytes(open.FileName);
            }
        }

    }
}
