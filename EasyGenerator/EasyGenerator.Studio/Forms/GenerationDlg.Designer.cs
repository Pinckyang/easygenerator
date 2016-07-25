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
    partial class GenerationDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerationDlg));
            this.uiClose = new System.Windows.Forms.Button();
            this.uiGenerate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearchFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvTemplates = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiClose
            // 
            this.uiClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiClose.Location = new System.Drawing.Point(150, 10);
            this.uiClose.Name = "uiClose";
            this.uiClose.Size = new System.Drawing.Size(75, 21);
            this.uiClose.TabIndex = 7;
            this.uiClose.Text = "&Close";
            this.uiClose.UseVisualStyleBackColor = true;
            // 
            // uiGenerate
            // 
            this.uiGenerate.Location = new System.Drawing.Point(68, 10);
            this.uiGenerate.Name = "uiGenerate";
            this.uiGenerate.Size = new System.Drawing.Size(75, 21);
            this.uiGenerate.TabIndex = 6;
            this.uiGenerate.Text = "&Generate";
            this.uiGenerate.UseVisualStyleBackColor = true;
            this.uiGenerate.Click += new System.EventHandler(this.uiGenerate_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 55);
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "在下列列表中选择模板，点击模板可查看模板使用说明";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "请根据需求选择模板生成代码";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSearchFolder);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtOutputFolder);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 462);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(658, 40);
            this.panel2.TabIndex = 10;
            // 
            // btnSearchFolder
            // 
            this.btnSearchFolder.Location = new System.Drawing.Point(369, 8);
            this.btnSearchFolder.Name = "btnSearchFolder";
            this.btnSearchFolder.Size = new System.Drawing.Size(34, 23);
            this.btnSearchFolder.TabIndex = 3;
            this.btnSearchFolder.Text = "...";
            this.btnSearchFolder.UseVisualStyleBackColor = true;
            this.btnSearchFolder.Click += new System.EventHandler(this.btnSearchFolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "输出目录：";
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtOutputFolder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtOutputFolder.Location = new System.Drawing.Point(74, 10);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(298, 21);
            this.txtOutputFolder.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.uiClose);
            this.panel3.Controls.Add(this.uiGenerate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(425, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(233, 40);
            this.panel3.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "BringToFrontHS.png");
            this.imageList1.Images.SetKeyName(1, "BringForwardHS.png");
            this.imageList1.Images.SetKeyName(2, "open116x16 24-bit.png");
            this.imageList1.Images.SetKeyName(3, "TableHS.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 55);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvTemplates);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbDescription);
            this.splitContainer1.Size = new System.Drawing.Size(658, 407);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 11;
            // 
            // lvTemplates
            // 
            this.lvTemplates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTemplates.FullRowSelect = true;
            this.lvTemplates.GridLines = true;
            this.lvTemplates.Location = new System.Drawing.Point(0, 0);
            this.lvTemplates.MultiSelect = false;
            this.lvTemplates.Name = "lvTemplates";
            this.lvTemplates.Size = new System.Drawing.Size(658, 250);
            this.lvTemplates.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvTemplates.StateImageList = this.imageList1;
            this.lvTemplates.TabIndex = 12;
            this.lvTemplates.UseCompatibleStateImageBehavior = false;
            this.lvTemplates.View = System.Windows.Forms.View.Details;
            this.lvTemplates.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvTemplates_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "模板名称";
            this.columnHeader1.Width = 250;
            // 
            // rtbDescription
            // 
            this.rtbDescription.AutoWordSelection = true;
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDescription.Location = new System.Drawing.Point(0, 0);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ReadOnly = true;
            this.rtbDescription.Size = new System.Drawing.Size(658, 153);
            this.rtbDescription.TabIndex = 0;
            this.rtbDescription.Text = "";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.SelectedPath = "C:\\";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "说明内容";
            this.columnHeader2.Width = 295;
            // 
            // GenerationDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 502);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GenerationDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择模板";
            this.Load += new System.EventHandler(this.GenerationDlg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uiClose;
        private System.Windows.Forms.Button uiGenerate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvTemplates;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnSearchFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        public System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}