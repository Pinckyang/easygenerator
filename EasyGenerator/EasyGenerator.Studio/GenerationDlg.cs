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
        private string templateDirectory;

        public string TemplateDirectory
        {
            get { return templateDirectory; }
            set { templateDirectory = value; }
        }

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
            if (lvTemplates.SelectedItems.Count < 1)
            {
                MessageBox.Show("ÇëÑ¡ÔñÄ£°å£¡");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void GenerationDlg_Load(object sender, EventArgs e)
        {
            string[] templateDirs = Directory.GetDirectories(this.TemplateDirectory);

            foreach(string dir in templateDirs)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                ListViewItem item = lvTemplates.Items.Add(directoryInfo.Name);
                item.StateImageIndex =0;
                byte[] text=File.ReadAllBytes(dir + "\\readme.rtf");
                string readmeText = Encoding.GetEncoding("gbk").GetString(text);
                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();

                RichTextBox rtBox = new RichTextBox();
                rtBox.Rtf = readmeText;
                string plainText = rtBox.Text;
                subItem.Text = plainText;
                subItem.Tag = readmeText;
                item.SubItems.Add(subItem);
                rtBox.Dispose();
            }

            if (txtOutputFolder.Text == string.Empty)
            {
                txtOutputFolder.Text = folderBrowserDialog.SelectedPath + this.projectName;
            }

            if (lvTemplates.Items.Count > 0)
            {
                lvTemplates.Focus();
                lvTemplates.Items[0].Selected = true;
                lvTemplates.Items[0].Focused = true;
            }

        }

        private void lvTemplates_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
           rtbDescription.Rtf=e.Item.SubItems[1].Tag.ToString();
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