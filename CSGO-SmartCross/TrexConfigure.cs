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
    public partial class TrexConfigure : Form
    {
        public TrexConfigure()
        {
            InitializeComponent();
        }

        public string[] results = { "", ""};

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void mapBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            results[0] = teamBox.SelectedText;
        }

        private void teamBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            results[1] = teamBox.SelectedText;
        }
    }
}
