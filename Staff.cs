using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Final.Bus;

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
                    Console.WriteLine("Connection successful!");
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.tblStaff", connection);
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

        private void Staff_Load(object sender, EventArgs e)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");
                    string query = "SELECT * FROM dbo.tblStaff";
                    SqlCommand command = new SqlCommand(query, connection);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int staffID;
            if (int.TryParse(txtSearch.Text, out staffID))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connection successful!");

                        SqlCommand command = new SqlCommand("dbo.spGetStaffData", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StaffID", staffID);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            DataRow firstRow = dataTable.Rows[0];
                            txtID.Text = firstRow["StaffID"].ToString();
                            txtNameEN.Text = firstRow["NameEN"].ToString();
                            txtNameKH.Text = firstRow["NameKH"].ToString();
                            txtCon.Text = firstRow["Contact"].ToString();
                            cbGen.Text = firstRow["Gender"].ToString();
                            txtEma.Text = firstRow["Email"].ToString();

                            // Load the image from the stored file path
                            string avatarPath = firstRow["Avatar"].ToString();
                            Console.WriteLine("Avatar path from database: " + avatarPath);

                            if (!string.IsNullOrEmpty(avatarPath))
                            {
                                try
                                {
                                    if (File.Exists(avatarPath))
                                    {
                                        using (var tempImage = Image.FromFile(avatarPath))
                                        {
                                            pbAvtar.Image = new Bitmap(tempImage);
                                        }
                                        Console.WriteLine("Image loaded successfully from: " + avatarPath);
                                    }
                                    else
                                    {
                                        pbAvtar.Image = null; // Clear the image if the path is invalid
                                        Console.WriteLine("File does not exist: " + avatarPath);
                                    }
                                }
                                catch (Exception imgEx)
                                {
                                    pbAvtar.Image = null; // Clear the image if there is an error loading it
                                    Console.WriteLine("Error loading image: " + imgEx.Message);
                                }
                            }
                            else
                            {
                                pbAvtar.Image = null; // Clear the image if the path is null or empty
                                Console.WriteLine("Avatar path is empty.");
                            }

                            cbAdd.Text = firstRow["Address"].ToString();
                            txtBir.Text = firstRow["BirthDate"].ToString();
                            cbPos.Text = firstRow["Position"].ToString();
                            txtwork.Text = firstRow["isStoppedWork"].ToString();

                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("Staff not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputFields(); // Clear UI elements if staff not found
                            pbAvtar.Image = null; // Clear the PictureBox when no staff found
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
                MessageBox.Show("Please enter a valid Staff ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearInputFields(); // Clear UI elements for invalid input
                pbAvtar.Image = null; // Clear the PictureBox for invalid input
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                txtID.Text = selectedRow.Cells["StaffID"].Value.ToString();
                txtNameEN.Text = selectedRow.Cells["NameEN"].Value.ToString();
                txtNameKH.Text = selectedRow.Cells["NameKH"].Value.ToString();
                txtCon.Text = selectedRow.Cells["Contact"].Value.ToString();
                cbGen.Text = selectedRow.Cells["Gender"].Value.ToString();
                txtEma.Text = selectedRow.Cells["Email"].Value.ToString();
                pbAvtar.Text = selectedRow.Cells["Avatar"].Value.ToString();
                cbAdd.Text = selectedRow.Cells["Address"].Value.ToString();
                txtBir.Text = selectedRow.Cells["BirthDate"].Value.ToString();
                cbPos.Text = selectedRow.Cells["Position"].Value.ToString();
                txtwork.Text = selectedRow.Cells["IsStopedWork"].Value.ToString();

            }
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
                    command.Parameters.AddWithValue("@NameEN", txtNameEN.Text);
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

                    command.Parameters.AddWithValue("@Position", cbPos.Text);
                    command.Parameters.AddWithValue("@isStopedWork", Convert.ToBoolean(txtwork.Text));

                    // Save image to disk if a file path is selected
                    string avatarPath = pbAvtar.Tag != null ? pbAvtar.Tag.ToString() : string.Empty;
                    if (!string.IsNullOrEmpty(avatarPath) && File.Exists(avatarPath))
                    {
                        // Define destination folder
                        string destinationFolder = @"D:\Transport\images\";
                        // Ensure the destination folder exists
                        if (!Directory.Exists(destinationFolder))
                        {
                            Directory.CreateDirectory(destinationFolder);
                        }

                        // Get the file name from the path
                        string fileName = Path.GetFileName(avatarPath);

                        // Construct the full path where the image will be saved
                        string destinationPath = Path.Combine(destinationFolder, fileName);

                        // Copy the image file to the destination folder
                        File.Copy(avatarPath, destinationPath, true);

                        // Update the avatarPath to the saved destinationPath
                        avatarPath = destinationPath;
                    }

                    // Insert avatarPath into the database
                    command.Parameters.AddWithValue("@Avatar", avatarPath);

                    // Execute the SQL command
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputFields(); // Helper method to clear input fields

                    PopulateDataGridView(); // Refresh DataGridView if needed
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
                        command.Parameters.AddWithValue("@NameEN", txtNameEN.Text);
                        command.Parameters.AddWithValue("@NameKH", txtNameKH.Text);
                        command.Parameters.AddWithValue("@Contact", txtCon.Text);
                        command.Parameters.AddWithValue("@Gender", (cbGen.Text));
                        command.Parameters.AddWithValue("@Email", (txtEma.Text));
                        command.Parameters.AddWithValue("@Avatar", (pbAvtar.Text));
                        command.Parameters.AddWithValue("@Address", (cbAdd.Text));
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
                        command.Parameters.AddWithValue("@Position", (cbPos.Text));
                        command.Parameters.AddWithValue("@isStopedWork", txtwork.Text);

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
                MessageBox.Show("Please enter a valid Bus ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainToOpen = new MainForm();
            mainToOpen.Show();
        }
        private void pbAvtar_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                // Load the image into the PictureBox
                pbAvtar.Image = new Bitmap(open.FileName);

                // Store the file path in the Tag property for later use
                pbAvtar.Tag = open.FileName;
            }
        }



        private void ClearInputFields()
        {
            txtID.Text = string.Empty;
            txtNameEN.Text = string.Empty;
            txtNameKH.Text = string.Empty;
            txtCon.Text = string.Empty;
            cbGen.Text = string.Empty;
            txtEma.Text = string.Empty;
            cbAdd.Text = string.Empty;
            txtBir.Text = string.Empty;
            cbPos.Text = string.Empty;
            txtwork.Text = string.Empty;
            pbAvtar.Image = null;
            pbAvtar.Tag = null;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}
