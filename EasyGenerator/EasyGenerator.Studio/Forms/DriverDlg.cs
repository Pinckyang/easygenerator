using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EasyGenerator.Studio.DbHelper;
using EasyGenerator.Studio.DbHelper.MSSQL;
using EasyGenerator.Studio.Model;
//using EasyGenerator.Studio.DbHelper.Access;

namespace EasyGenerator.Studio
{
    public partial class DriverDlg : Form
    {
        private string connection;

        public string Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public DriverDlg()
        {
            InitializeComponent();

        }

        private void uiOK_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                try
                {
                    this.Connection = this.uiLocation.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "´íÎó", MessageBoxButtons.OK);
                }
            }
        }

        private bool IsValid()
        {
            return true;
        }

        public string DomainName
        {
            get { return this.uiDomainName.Text ; }
        }

        private void uiDriverType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //provider/[[user[:password]@]host[:port]]/database
            switch (this.uiDriverType.SelectedIndex)
            {
                case 0:
                    this.uiLocation.Text = @"provider/[[user[:password]@]host[:port]]/database";
                    break;
                case 1:
                    this.uiLocation.Text = @"mssql/(local)/Northwind";
                    break;
                case 2:
                    this.uiLocation.Text = @"mssql/sa:000@(local)/Northwind";
                    break;
                case 3:
                    this.uiLocation.Text = @"mssql2005/(local)/Northwind";
                    break;
                case 4:
                    this.uiLocation.Text = @"mssql2005/user:password@(local)/Northwind";
                    break;
                case 5:
                    this.uiLocation.Text = @"mssql2008/(local)/Northwind";
                    break;
                case 6:
                    this.uiLocation.Text = @"mssql2008/user:password@(local)/Northwind";
                    break;
                case 7:
                    this.uiLocation.Text = @"mssql2012/(local)/Northwind";
                    break;
                case 8:
                    this.uiLocation.Text = @"mssql2012/user:password@(local)/Northwind";
                    break;
                case 9:
                    this.uiLocation.Text = @"msaccess/(local)/C:\\SampleDB.mdb";
                    break;
                case 10:
                    this.uiLocation.Text = @"msaccess/admin:password@(local)/C:\\SampleDB.mdb";
                    break;
                default:
                    break;
            }
        }

        private void uiTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The method or operation is not implemented. Please click on OK to Create the Domain", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void DriverDlg_Load(object sender, EventArgs e)
        {
            uiDriverType.Text = "SQL Server 2000 (SQL Server Authentication)";
        }

  
    }
}