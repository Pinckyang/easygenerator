/*
 * Copyright ?2005-2006 Danilo Mendez <danilo.mendez@kontac.net>
 * Adolfo Socorro <ajs@esolutionspr.com>
 * www.kontac.net 
 * All rights reserved.
 * Released under both BSD license and Lesser GPL library license.
 * Whenever there is any discrepancy between the two licenses,
 * the BSD license will take precedence.
 */

namespace EasyGenerator.Studio
{
    partial class DriverDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiDriverType = new System.Windows.Forms.ComboBox();
            this.uiLocation = new System.Windows.Forms.RichTextBox();
            this.uiOK = new System.Windows.Forms.Button();
            this.uiCancel = new System.Windows.Forms.Button();
            this.uiDomainName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiTest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiDriverType
            // 
            this.uiDriverType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uiDriverType.FormattingEnabled = true;
            this.uiDriverType.Items.AddRange(new object[] {
            "<Select>",
            "SQL Server 2000 (Windows Authentication)",
            "SQL Server 2000 (SQL Server Authentication)",
            "SQL Server 2005 (Windows Authentication)",
            "SQL Server 2005 (SQL Server Authentication)",
            "SQL Server 2008 (Windows Authentication)",
            "SQL Server 2008 (SQL Server Authentication)",
            "SQL Server 2012 (Windows Authentication)",
            "SQL Server 2012 (SQL Server Authentication)",
            "Open connection to Access database",
            "Open connection to password protected Access database"});
            this.uiDriverType.Location = new System.Drawing.Point(15, 60);
            this.uiDriverType.Name = "uiDriverType";
            this.uiDriverType.Size = new System.Drawing.Size(308, 20);
            this.uiDriverType.TabIndex = 0;
            this.uiDriverType.SelectedIndexChanged += new System.EventHandler(this.uiDriverType_SelectedIndexChanged);
            // 
            // uiLocation
            // 
            this.uiLocation.Location = new System.Drawing.Point(15, 102);
            this.uiLocation.Name = "uiLocation";
            this.uiLocation.Size = new System.Drawing.Size(308, 55);
            this.uiLocation.TabIndex = 1;
            this.uiLocation.Text = "[[user[:password]@]host[:port]]/database";
            // 
            // uiOK
            // 
            this.uiOK.Location = new System.Drawing.Point(169, 210);
            this.uiOK.Name = "uiOK";
            this.uiOK.Size = new System.Drawing.Size(75, 21);
            this.uiOK.TabIndex = 2;
            this.uiOK.Text = "确认(&O)";
            this.uiOK.UseVisualStyleBackColor = true;
            this.uiOK.Click += new System.EventHandler(this.uiOK_Click);
            // 
            // uiCancel
            // 
            this.uiCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiCancel.Location = new System.Drawing.Point(251, 210);
            this.uiCancel.Name = "uiCancel";
            this.uiCancel.Size = new System.Drawing.Size(75, 21);
            this.uiCancel.TabIndex = 3;
            this.uiCancel.Text = "取消(&C)";
            this.uiCancel.UseVisualStyleBackColor = true;
            // 
            // uiDomainName
            // 
            this.uiDomainName.Location = new System.Drawing.Point(15, 24);
            this.uiDomainName.Name = "uiDomainName";
            this.uiDomainName.Size = new System.Drawing.Size(308, 21);
            this.uiDomainName.TabIndex = 4;
            this.uiDomainName.Text = "(local)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "服务器:";
            // 
            // uiTest
            // 
            this.uiTest.Location = new System.Drawing.Point(251, 172);
            this.uiTest.Name = "uiTest";
            this.uiTest.Size = new System.Drawing.Size(75, 21);
            this.uiTest.TabIndex = 6;
            this.uiTest.Text = "测试连接(&T)";
            this.uiTest.UseVisualStyleBackColor = true;
            this.uiTest.Click += new System.EventHandler(this.uiTest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "驱动:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "连接串:";
            // 
            // DriverDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uiCancel;
            this.ClientSize = new System.Drawing.Size(339, 245);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiDomainName);
            this.Controls.Add(this.uiCancel);
            this.Controls.Add(this.uiOK);
            this.Controls.Add(this.uiLocation);
            this.Controls.Add(this.uiDriverType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriverDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据库驱动设置";
            this.Load += new System.EventHandler(this.DriverDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox uiDriverType;
        private System.Windows.Forms.RichTextBox uiLocation;
        private System.Windows.Forms.Button uiOK;
        private System.Windows.Forms.Button uiCancel;
        private System.Windows.Forms.TextBox uiDomainName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uiTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}