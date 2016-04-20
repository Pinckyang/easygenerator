using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EasyGenerator.Studio.Model;

namespace EasyGenerator.Studio
{
    public partial class LoginWindowDlg : Form
    {
        private Project project;

        public Project Project
        {
            get { return project; }
            set { project = value; }
        }

        public LoginWindowDlg()
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

            TableInfo entity=null;
            this.project.Database.Tables.TryGetValue(this.txtName.Text, out entity);

            if(entity==null)
            {
                return;
            }

            this.cmbAccountField.Items.Clear();
            this.cmbPasswordField.Items.Clear();
            foreach (KeyValuePair<string, ColumnInfo> kv in entity.Columns)
            {
                this.cmbAccountField.Items.Add(kv.Key);
                this.cmbPasswordField.Items.Add(kv.Key);
            }

            this.cmbAccountField.SelectedIndex = 0;
            this.cmbPasswordField.SelectedIndex = 0;
        }


    }
}
