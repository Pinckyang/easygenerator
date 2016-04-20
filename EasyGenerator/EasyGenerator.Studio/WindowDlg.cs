using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EasyGenerator.Studio
{
    public partial class WindowDlg : Form
    {
        public WindowDlg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtName.Text = this.cmbEntity.SelectedItem.ToString();
        }
    }
}
