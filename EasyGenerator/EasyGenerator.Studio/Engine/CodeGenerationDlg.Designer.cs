/*
 * Copyright ?2005-2006 Danilo Mendez <danilo.mendez@kontac.net>
 * Adolfo Socorro <ajs@esolutionspr.com>
 * www.kontac.net 
 * All rights reserved.
 * Released under both BSD license and Lesser GPL library license.
 * Whenever there is any discrepancy between the two licenses,
 * the BSD license will take precedence.
 */

namespace EasyGenerator.Studio.Engine
{
    partial class CodeGenerationDlg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeGenerationDlg));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lvResume = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.pbProgressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.831418F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96.16858F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lvResume, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.pbProgressBar, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(543, 322);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lvResume
            // 
            this.lvResume.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4});
            this.lvResume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResume.FullRowSelect = true;
            this.lvResume.GridLines = true;
            this.lvResume.Location = new System.Drawing.Point(23, 58);
            this.lvResume.MultiSelect = false;
            this.lvResume.Name = "lvResume";
            this.lvResume.Size = new System.Drawing.Size(496, 216);
            this.lvResume.SmallImageList = this.imageList;
            this.lvResume.TabIndex = 0;
            this.lvResume.UseCompatibleStateImageBehavior = false;
            this.lvResume.View = System.Windows.Forms.View.Details;
           // this.lvResume.DoubleClick += new System.EventHandler(this.UILiResume_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 25;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 128;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "提示消息";
            this.columnHeader2.Width = 166;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "路径";
            this.columnHeader4.Width = 239;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ok.png");
            this.imageList.Images.SetKeyName(1, "error2.png");
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(444, 297);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 22);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbProgressBar
            // 
            this.pbProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProgressBar.Location = new System.Drawing.Point(23, 21);
            this.pbProgressBar.Name = "pbProgressBar";
            this.pbProgressBar.Size = new System.Drawing.Size(496, 17);
            this.pbProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbProgressBar.TabIndex = 2;
            // 
            // CodeGenerationDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(543, 322);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CodeGenerationDlg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generating";
            this.Load += new System.EventHandler(this.CodeGenerationDlg_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView lvResume;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ProgressBar pbProgressBar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader columnHeader4;

    }
}