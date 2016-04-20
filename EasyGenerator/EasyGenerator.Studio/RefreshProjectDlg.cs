using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using EasyGenerator.Studio.Utils;
using EasyGenerator.Studio.Controls.UserControls.XPListView;
using EasyGenerator.Studio.Builder;

namespace EasyGenerator.Studio
{
    public partial class RefreshProjectDlg : Form
    {
        enum ObjectType
        {
            Table,
            View,
            Column,
        }

        private Domain projectDomain;
        private Domain dbDomain;


        //Mirror Treeview?
 
        public RefreshProjectDlg()
        {
            InitializeComponent();
        }

        public RefreshProjectDlg(Domain projectDomain, Domain dbDomain)
            :this()
        {
            this.projectDomain = projectDomain;
            this.dbDomain = dbDomain;
            this.uiLVResults.ShowInGroups = true;
        }

        private void RefreshProjectDlg_Load(object sender, EventArgs e)
        {
            Analize();
        }

        private void Analize()
        {
            /*foreach (Table dbTable in dbDomain.ConnectionInfo.Tables)
            {
                Table projectTable = projectDomain.ConnectionInfo.FindTable(dbTable.Name);
                if (projectTable == null)
                {
                    XPListViewItem li = new XPListViewItem(new string[] { "Table", dbTable.Name, "-", "Add" });
                    li.Tag = dbTable;
                    this.uiLVResults.Items.Add(li);
                }
                else
                {
                    foreach (Column dbColumn in dbTable.AllColumns())
                    {
                        Column projColumn = projectTable.FindColumn(dbColumn.Name);
                        //Exist??
                        if (projColumn == null)
                        {
                            XPListViewItem li = new XPListViewItem(new string[] { "Column", dbTable.Name, dbColumn.Name, "Add" });
                            li.Tag = dbColumn;
                            this.uiLVResults.Items.Add(li);
                        }
                        else if (projColumn.DefaultValue != dbColumn.DefaultValue ||
                            projColumn.IsIdentity != dbColumn.IsIdentity ||
                            projColumn.IsPrimaryKey != dbColumn.IsPrimaryKey ||
                            projColumn.IsRequired != dbColumn.IsRequired ||
                            projColumn.NetDataType != dbColumn.NetDataType ||
                            projColumn.SqlType != dbColumn.SqlType ||
                            projColumn.Scale != dbColumn.Scale )
                        {
                            XPListViewItem li = new XPListViewItem(new string[] { "Column", dbTable.Name, dbColumn.Name, "Update" });
                            li.Tag = dbColumn;
                            this.uiLVResults.Items.Add(li);
                        }
                    }
                }
            }
            this.uiLVResults.AutoGroupByColumn(1);*/

        }

        private void uiOK_Click(object sender, EventArgs e)
        {
            UpdateProject();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void UpdateProject()
        {
            //foreach (XPListViewItem li in this.uiLVResults.CheckedItems)
            //{
            //    Table table = li.Tag as Table;
            //    if (table != null && li.SubItems[3].Text == "Add")
            //    {
            //        //Add table to Domain
            //        Table newtable = table.Clone() as Table;
            //        newtable.Domain = this.projectDomain;
            //        this.projectDomain.ConnectionInfo.Tables.Add(newtable);
            //        continue;
            //    }

            //    Column dbColumn = li.Tag as Column;
            //    if (dbColumn != null && li.SubItems[3].Text == "Add")
            //    {
            //        Table projectTable = projectDomain.ConnectionInfo.FindTable(li.SubItems[1].Text);
            //        if (projectTable != null)
            //        {
            //            Column newColumn = (Column)dbColumn.Clone();
            //            newColumn.Table = projectTable;
            //            projectTable.Columns.Add(newColumn.Name, newColumn);
            //        }
            //    }
            //    else if (dbColumn != null && li.SubItems[3].Text == "Update")
            //    {
            //        Table projectTable = projectDomain.ConnectionInfo.FindTable(li.SubItems[1].Text);
            //        if (projectTable != null)
            //        {
            //            Column projectColumn = projectTable.FindColumn(dbColumn.Name);
            //            if (projectColumn != null)
            //            {
            //                projectColumn.DefaultValue = dbColumn.DefaultValue;
            //                projectColumn.IsIdentity = dbColumn.IsIdentity ;
            //                projectColumn.IsPrimaryKey = dbColumn.IsPrimaryKey;
            //                projectColumn.IsRequired = dbColumn.IsRequired ;
            //                projectColumn.NetDataType = dbColumn.NetDataType;
            //                projectColumn.SqlType = dbColumn.SqlType ;
            //                projectColumn.Scale = dbColumn.Scale;
            //            }

            //        }
            //    }
           // }
        }
  
    }
}