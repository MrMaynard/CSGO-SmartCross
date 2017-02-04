using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartCross
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!gate())
            {
                MessageBox.Show("Unable to parse template files.", "Read error");
                Application.Exit();
            }
            else
            {
                Application.Run(new GUI());
            }

            
            
        }


        private static bool gate()
        {
            MessageBox.Show("Failed to load resource files!\n" +
                "If you have moved the template files somewhere, please input their parent folder in the following dialog.",
                "Eric's Custom Crosshair Maker");

            using (var form = new Gate())
            {
                var response = form.ShowDialog();
                return (response == DialogResult.OK);
            }
            return false;
        }
    }      
}
