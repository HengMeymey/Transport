using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Final.Bus;
using static Final.Schedule;
using static Final.Payment;
using static Final.Report;
using static Final.Booking;

namespace Final
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formToOpen = new Login();
            formToOpen.Show();
        }
        public class Login : Form2
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formToOpen = new BusForm();
            formToOpen.Show();
        }

        public class BusForm : Bus
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formToOpen = new Schedule();
            formToOpen.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formToOpen = new Payment();
            formToOpen.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formToOpen = new Report();
            formToOpen.Show();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formToOpen = new Booking();
            formToOpen.Show();
        }
    }
}
