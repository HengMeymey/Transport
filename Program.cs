using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new Invoice());
=======
            //Application.Run(new Form2());
            Application.Run(new Schedule());
>>>>>>> 26b7659402ce50a6abf96444aa4d063bea7fb9ae
        }
    }
}
