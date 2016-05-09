using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
//using EasyGenerator.Studio.Templates;

namespace EasyGenerator.Studio.AssemblyCache
{
    public partial class GACDlg : Form
    {
        bool canClose = false;
        public GACDlg()
        {
            InitializeComponent();
            LoadGACListView();
        }

        private void uiOK_Click(object sender, EventArgs e)
        {
            if (canClose)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        internal ArrayList GetSelectedLibraries()
        {
            ArrayList results = new ArrayList();
            foreach (ListViewItem li in this.uiLvGAC.SelectedItems)
            {
                //results.Add(li.Tag  as LibraryInfo);
            }
            return results;
        }

        private void LoadGACListView()
        {
            CacheAssemblies assemblies = new CacheAssemblies();
            ArrayList list = new ArrayList();
            assemblies.GetGACCache(list);
            //foreach (object libraryInfo in list)
            //{
            //    if (libraryInfo != null && libraryInfo is LibraryInfo)
            //    {
            //        ListViewItem li = new ContextObjectListViewItem(((LibraryInfo)libraryInfo).AssemblyName);
            //        li.Tag = libraryInfo;
            //        this.uiLvGAC.Items.Add(li);
            //    }
            //}
            if (this.uiLvGAC.Items.Count > 0)
            {
                this.uiLvGAC.Enabled = true;
                this.uiLvGAC.Items[0].Selected = true;
            }
            else
            {
                this.uiLvGAC.Enabled = false;
            }
        }

        private void _lvGAC_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.canClose = this.uiLvGAC.SelectedItems.Count > 0;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.codeproject.com/csharp/usedllgac.asp");
        }
    }
}