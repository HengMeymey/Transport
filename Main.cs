using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public class StaffForm : Staff
        {

        }
        public class BaggageForm : Baggage
        {

        }
        
        private void btnStaff_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formToOpen = new StaffForm();
            formToOpen.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formToOpen = new BaggageForm();
            formToOpen.Show();
        }
    }
}
