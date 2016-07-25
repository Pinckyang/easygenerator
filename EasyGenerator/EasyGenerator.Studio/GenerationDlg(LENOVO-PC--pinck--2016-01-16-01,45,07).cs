using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EasyGenerator.Studio
{
    public partial class GenerationDlg : Form
    {
        private string projectName;

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }

        public GenerationDlg()
        {
            InitializeComponent();
        }

        private void uiGenerate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void GenerationDlg_Load(object sender, EventArgs e)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string baseTemplateDirectory = baseDirectory + "Templates\\";
            string [] templateDirs= Directory.GetDirectories(baseTemplateDirectory);

            foreach(string dir in templateDirs)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                ListViewItem item = lvTemplates.Items.Add(directoryInfo.Name);
                item.StateImageIndex =0;
                string readmeText=File.ReadAllText(dir+"\\readme.rtf");
                item.SubItems.Add(readmeText);
            }

            if (txtOutputFolder.Text==string.Empty)
            txtOutputFolder.Text = folderBrowserDialog.SelectedPath+this.projectName;

        }

        private void lvTemplates_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
           rtbDescription.Text= e.Item.SubItems[1].Text;
        }

        private void btnSearchFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputFolder.Text = folderBrowserDialog.SelectedPath +"\\"+ this.projectName;
            }
        }

    }
}