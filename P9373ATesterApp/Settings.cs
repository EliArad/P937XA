using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P9374ATesterApp
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            txtVisaName.Text = AppSettings.Instance.Config.visaName;
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtVisaName.Text == string.Empty)
            {
                MessageBox.Show("Please set visa address");
                return;
            }
            AppSettings.Instance.Config.visaName = txtVisaName.Text;
            AppSettings.Instance.Save();
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
