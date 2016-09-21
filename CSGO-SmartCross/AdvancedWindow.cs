using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSGO_SmartCross
{
    public partial class AdvancedWindow : Form
    {
        public AdvancedWindow()
        {
            results = new String[12];
            InitializeComponent();
            
            //crude default values:
            textBox1.Text = "1080";
            textBox2.Text = "1920";
            textBox3.Text = "20";
            textBox4.Text = "20";
            textBox5.Text = "20";
            textBox6.Text = "20";
            textBox7.Text = "20";
            textBox8.Text = "20";
            textBox9.Text = "20";
            textBox10.Text = "20";
            textBox11.Text = "20";
            textBox12.Text = "20";

        }

        public String[] results;

        private void doneButton_Click(object sender, EventArgs e)
        {

            results[0] = textBox1.Text;
            results[1] = textBox2.Text;
            results[2] = textBox3.Text;
            results[3] = textBox4.Text;
            results[4] = textBox5.Text;
            results[5] = textBox6.Text;
            results[6] = textBox7.Text;
            results[7] = textBox8.Text;
            results[8] = textBox9.Text;
            results[9] = textBox10.Text;
            results[10] = textBox11.Text;
            results[11] = textBox12.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
