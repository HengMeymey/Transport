using DocumentFormat.OpenXml.Wordprocessing;
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
using static Final.Main;
using static Final.Bus;

namespace Final
{
   
    public partial class Schedule : Form
    {
        public class ComboItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }
        string connectionString = "Data Source=localhost;Initial Catalog=dboTransportation;Integrated Security=True;";
        public Schedule()
        {
            InitializeComponent();
            txtScheduleID.ReadOnly = true;
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            LoadScheduleData();
            cbBusNo.Text = "";  // Set initial text to empty
            FillBusNoComboBox();  // Moved after setting Text
            cbBusNo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBusNo.SelectedIndex = -1; 
            dgvSch.SelectionChanged += DgvSch_SelectionChanged;
        }

        private void LoadScheduleData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spGetSchedule", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvSch.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading payment data: " + ex.Message);
            }
        }
        private void FillBusNoComboBox()
        {
            List<ComboItem> busItems = new List<ComboItem>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spGetBusNumbersForSchedule", conn))  // New stored procedure
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int busID = reader.GetInt32(0);  // Assuming busID is the first column (index 0)
                                string busNo = reader.GetString(1);  // Assuming BusNo is the second column (index 1)
                                busItems.Add(new ComboItem { Text = busNo, Value = busID });
                            }
                        }
                    }
                }
                cbBusNo.DataSource = busItems;
                cbBusNo.DisplayMember = "Text";
                cbBusNo.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading bus numbers: " + ex.Message);
            }
        }


        private void cbBusNo_DropDown(object sender, EventArgs e)
        {
            if (cbBusNo.Items.Count == 0)  // Check if not already populated
            {
                FillBusNoComboBox();
            }
        }

        private List<string> GetBusNumbers()
        {
            List<string> busNumbers = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spGetBusNumbers", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                busNumbers.Add(reader.GetString(0));  // Assuming BusNo is the first column (index 0)
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading bus numbers: " + ex.Message);
            }
            return busNumbers;
        }

        private void DgvSch_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSch.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvSch.SelectedRows[0];
                txtScheduleID.Text = selectedRow.Cells["ScheduleID"].Value.ToString();
                dtpDate.Value = Convert.ToDateTime(selectedRow.Cells["BusDate"].Value);
                txtOrigin.Text = selectedRow.Cells["Origin"].Value.ToString();
                txtDestination.Text = selectedRow.Cells["Destination"].Value.ToString();
                txtTime.Text = selectedRow.Cells["DepartureTime"].Value.ToString();
                cbBusNo.Text = selectedRow.Cells["BusNo"].Value.ToString();
                txtFare.Text = selectedRow.Cells["Fare"].Value.ToString();
            }
        }
         private void btnInsert_Click_1(object sender, EventArgs e)
        {
            if (cbBusNo.SelectedIndex == -1)  // Check if no item is selected
            {
                MessageBox.Show("Please select a Bus ID.");
                return;
            }

            try
            {

                int selectedBusID = ((ComboItem)cbBusNo.SelectedItem).Value;  // Access bus ID from ComboItem
                if (!int.TryParse(cbBusNo.SelectedValue.ToString(), out selectedBusID))
                {
                    MessageBox.Show("Please select a valid Bus ID.");
                    return;
                }

                DateTime busDate = dtpDate.Value;

                string departureTime = txtTime.Text;
                if (string.IsNullOrWhiteSpace(departureTime))
                {
                    MessageBox.Show("Please enter a valid Departure Time.");
                    return;
                }

                decimal fare;
                if (!decimal.TryParse(txtFare.Text, out fare))
                {
                    MessageBox.Show("Please enter a valid Fare amount.");
                    return;
                }

                string origin = txtOrigin.Text;
                string destination = txtDestination.Text;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("spInsertSchedule", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BusID", selectedBusID);
                    cmd.Parameters.AddWithValue("@BusDate", busDate);
                    cmd.Parameters.AddWithValue("@DepartureTime", departureTime);
                    cmd.Parameters.AddWithValue("@Fare", fare);
                    cmd.Parameters.AddWithValue("@Origin", origin);
                    cmd.Parameters.AddWithValue("@Destination", destination);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Schedule inserted successfully.");
                        ClearForm();
                        LoadScheduleData(); // Refresh the data grid  
                    }
                    else
                    {
                        MessageBox.Show("Schedule insertion failed. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while inserting schedule: " + ex.Message);
            }
        }
        private void ClearForm()
        {
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = "";
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1; 
                }
                else if (control is DateTimePicker)
                {
                    ((DateTimePicker)control).Value = DateTime.Now;  
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtScheduleID.Text))
            {
                MessageBox.Show("Please select a schedule to update.");
                return;
            }

            int scheduleID = int.Parse(txtScheduleID.Text);
            int selectedBusID = ((ComboItem)cbBusNo.SelectedItem).Value;
            DateTime busDate = dtpDate.Value;
            string departureTime = txtTime.Text;
            decimal fare;
            if (!decimal.TryParse(txtFare.Text, out fare))
            {
                MessageBox.Show("Please enter a valid Fare amount.");
                return;
            }
            string origin = txtOrigin.Text;
            string destination = txtDestination.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spUpdateSchedule", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ScheduleID", scheduleID);
                        cmd.Parameters.AddWithValue("@BusID", selectedBusID);
                        cmd.Parameters.AddWithValue("@BusDate", busDate);
                        cmd.Parameters.AddWithValue("@DepartureTime", departureTime);
                        cmd.Parameters.AddWithValue("@Fare", fare);
                        cmd.Parameters.AddWithValue("@Origin", origin);
                        cmd.Parameters.AddWithValue("@Destination", destination);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Schedule updated successfully.");
                            ClearForm();
                            LoadScheduleData(); // Refresh the data grid
                        }
                        else
                        {
                            MessageBox.Show("Schedule update failed. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating schedule: " + ex.Message);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadScheduleData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainToOpen = new MainForm();
            mainToOpen.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formToOpen = new Login();
            formToOpen.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBusNoSearch.Text))
            {
                MessageBox.Show("Please enter a Bus Number to search.");
                return;
            }

            string busNo = txtBusNoSearch.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spSearchSchedule", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BusNo", busNo);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvSch.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No schedules found for Bus Number containing: " + busNo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching schedules: " + ex.Message);
            }
        }

    }
}
