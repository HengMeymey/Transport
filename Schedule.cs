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
    public partial class Schedule : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=dboTransportation;Integrated Security=True;");
        BindingSource ShceduleBindingSource = new BindingSource();

        SqlDataAdapter ShceduleAdapter = new SqlDataAdapter();
        DataSet dataSet = new DataSet();
        DataSet datasetbackup = new DataSet();

        private string VIEW_SHCEDULE_INFO = "tbSchedule";
        private string INSERT_SChedule = "InsertSchedule ";
        private string DELETE_SCHEDULE = "DeleteSchedule";
        private string UPDATE_SCHEDULE = "UpdateSchedule";
        private string SEARCH_SCHEDULE = "GetSchedule";

        public Schedule()
        {
            InitializeComponent();
            SetUpCommand();
            BindingControl();
        }

        private void SetUpCommand()
        {
            ShceduleAdapter.SelectCommand = new SqlCommand($"select *from {VIEW_SHCEDULE_INFO}", connection);
            ShceduleAdapter.Fill(dataSet, VIEW_SHCEDULE_INFO);
            ShceduleBindingSource.DataSource = dataSet;
            ShceduleBindingSource.DataMember = VIEW_SHCEDULE_INFO;
            dgvSC.DataSource = ShceduleBindingSource;
            //============[INSERT]=========================
            ShceduleAdapter.InsertCommand = new SqlCommand()
            {
                CommandText = INSERT_SChedule
                ,
                CommandType = CommandType.StoredProcedure,
                Connection = this.connection
            };
            ShceduleAdapter.InsertCommand.Parameters.Add("@BusID", SqlDbType.Int, 0, "BusID");
            ShceduleAdapter.InsertCommand.Parameters.Add("@BusDate", SqlDbType.Date, 0, "BusDate");
            ShceduleAdapter.InsertCommand.Parameters.Add("@DepartureTime", SqlDbType.DateTime, 0, "DepartureTime");
            ShceduleAdapter.InsertCommand.Parameters.Add("@Fare", SqlDbType.Decimal, 0, "Fare");
            ShceduleAdapter.InsertCommand.Parameters.Add("@Origin", SqlDbType.VarChar, 50, "Origin");
            ShceduleAdapter.InsertCommand.Parameters.Add("@Destination", SqlDbType.VarChar, 50, "Destination");

            //========================[DELETE]======================
            ShceduleAdapter.DeleteCommand = new SqlCommand()
            {
                CommandText = DELETE_SCHEDULE,
                CommandType = CommandType.StoredProcedure,
                Connection = this.connection
            };
            ShceduleAdapter.DeleteCommand.Parameters.Add("@ScheduleID", SqlDbType.Int, 0, "ScheduleID");
            //===================[Update]=========================
            ShceduleAdapter.UpdateCommand = new SqlCommand()
            {
                CommandText = UPDATE_SCHEDULE,
                CommandType = CommandType.StoredProcedure,
                Connection = this.connection
            };
            ShceduleAdapter.UpdateCommand.Parameters.Add("ScheduleID", SqlDbType.Int, 0, "ScheduleID");
            ShceduleAdapter.UpdateCommand.Parameters.Add("@BusID", SqlDbType.Int, 0, "BusID");
            ShceduleAdapter.UpdateCommand.Parameters.Add("@BusDate", SqlDbType.Date, 0, "BusDate");
            ShceduleAdapter.UpdateCommand.Parameters.Add("@DepartureTime", SqlDbType.DateTime, 0, "DepartureTime");
            ShceduleAdapter.UpdateCommand.Parameters.Add("@Fare", SqlDbType.Decimal, 0, "Fare");
            ShceduleAdapter.UpdateCommand.Parameters.Add("@Origin", SqlDbType.VarChar, 50, "Origin");
            ShceduleAdapter.UpdateCommand.Parameters.Add("@Destination", SqlDbType.VarChar, 50, "Destination");
        }
        private void BindingControl()
        {
            txtBusID.DataBindings.Add(new Binding("Text", ShceduleBindingSource, "BusID"));
            txtScheduleID.DataBindings.Add(new Binding("Text", ShceduleBindingSource, "ScheduleID"));
            txtDepartureTime.DataBindings.Add(new Binding("Text", ShceduleBindingSource, "DepartureTime"));
            txtDestination.DataBindings.Add(new Binding("Text", ShceduleBindingSource, "Destination"));
            txtFare.DataBindings.Add(new Binding("Text", ShceduleBindingSource, "Fare"));
            txtOrigin.DataBindings.Add(new Binding("Text", ShceduleBindingSource, "Origin"));
            txtBusDate.DataBindings.Add(new Binding("Text", ShceduleBindingSource, "BusDate"));
        }
        private void Shcedule_Load(object sender, EventArgs e)
        {
            datasetbackup = dataSet.Copy();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.ShceduleBindingSource.AddNew();
            txtScheduleID.Text = "Auto increament";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtScheduleID.Text) ||
                string.IsNullOrEmpty(txtBusID.Text) ||
                string.IsNullOrEmpty(txtDepartureTime.Text) ||
                string.IsNullOrEmpty(txtDestination.Text) ||
                string.IsNullOrEmpty(txtFare.Text) ||
                string.IsNullOrEmpty(txtOrigin.Text))
            {
                MessageBox.Show("Please fill all TextBox Before Save!!");
                return;
            }
            else
            {
                this.ShceduleBindingSource.EndEdit();
                ShceduleAdapter.Update(dataSet, VIEW_SHCEDULE_INFO);
            }
        }
        private void txtDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ShceduleBindingSource.RemoveCurrent();
                ShceduleAdapter.Update(dataSet, VIEW_SHCEDULE_INFO);
                datasetbackup.Merge(dataSet);
            }
            catch
            {
                MessageBox.Show("Date Empty Can't Delete");
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataSet.Tables[VIEW_SHCEDULE_INFO].Clear();
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                ShceduleAdapter.SelectCommand = new SqlCommand()
                {
                    CommandText = SEARCH_SCHEDULE,
                    CommandType = CommandType.StoredProcedure,
                    Connection = this.connection
                };
                ShceduleAdapter.SelectCommand.Parameters.Add("@Search", SqlDbType.VarChar, 50);
                ShceduleAdapter.SelectCommand.Parameters["@Search"].Value = txtSearch.Text;
                ShceduleAdapter.Fill(dataSet, VIEW_SHCEDULE_INFO);
            }
            else
            {

                dataSet.Merge(datasetbackup);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShceduleBindingSource.CancelEdit();
            dataSet.RejectChanges();
        }
    }
}