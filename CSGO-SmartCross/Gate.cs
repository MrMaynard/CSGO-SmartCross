using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartCross
{
    public partial class Gate : Form
    {

        Coder coder;

        public Gate()
        {
            coder = new Coder();
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (loadBox.Text == coder.decrypt("k j34r38kk"))
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.No;

            this.Close();
        }

        private void loadBox_TextChanged(object sender, EventArgs e)
        {
            ;
        }
    }
}
