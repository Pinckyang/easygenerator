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
    partial class EasyGeneratorStudio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EasyGeneratorStudio));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.librariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLibrariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.uiBtnNew = new System.Windows.Forms.ToolStripButton();
            this.uiBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.uiBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.uiBtnGenerate = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.uiPnlExplorer = new System.Windows.Forms.Panel();
            this.uiTvExplorer = new System.Windows.Forms.TreeView();
            this.uiDBImages = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.uiTBDeleteObject = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tvUI = new System.Windows.Forms.TreeView();
            this.uiProjectImages = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tbnModuleAdd = new System.Windows.Forms.ToolStripButton();
            this.tbnModuleDelete = new System.Windows.Forms.ToolStripButton();
            this.tbnWindowAdd = new System.Windows.Forms.ToolStripButton();
            this.tbnWindowDelete = new System.Windows.Forms.ToolStripButton();
            this.tbnTableAdd = new System.Windows.Forms.ToolStripButton();
            this.tbnTableDelete = new System.Windows.Forms.ToolStripButton();
            this.uiPnlMain = new System.Windows.Forms.Panel();
            this.uiPGNamedObject = new System.Windows.Forms.PropertyGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.uiPnlExplorer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.uiPnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.librariesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1049, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator4,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.fileToolStripMenuItem.Text = "文件(&F)";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newToolStripMenuItem.Text = "新建项目(&N)";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewProject_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openToolStripMenuItem.Text = "打开项目(&O)...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenProject_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(148, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveToolStripMenuItem.Text = "保存(&S)";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveProject_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveAsToolStripMenuItem.Text = "另存为(&A)...";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(148, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.closeToolStripMenuItem.Text = "退出(&E)";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseProject_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshProjectToolStripMenuItem,
            this.addControlToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.projectToolStripMenuItem.Text = "工程(&P)";
            // 
            // refreshProjectToolStripMenuItem
            // 
            this.refreshProjectToolStripMenuItem.Enabled = false;
            this.refreshProjectToolStripMenuItem.Name = "refreshProjectToolStripMenuItem";
            this.refreshProjectToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.refreshProjectToolStripMenuItem.Text = "刷新(&R)";
            this.refreshProjectToolStripMenuItem.Click += new System.EventHandler(this.refreshProjectToolStripMenuItem_Click);
            // 
            // addControlToolStripMenuItem
            // 
            this.addControlToolStripMenuItem.Enabled = false;
            this.addControlToolStripMenuItem.Name = "addControlToolStripMenuItem";
            this.addControlToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addControlToolStripMenuItem.Text = "添加控件(&A)...";
            this.addControlToolStripMenuItem.Click += new System.EventHandler(this.addControlToolStripMenuItem_Click);
            // 
            // librariesToolStripMenuItem
            // 
            this.librariesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadLibraryToolStripMenuItem,
            this.viewLibrariesToolStripMenuItem,
            this.toolStripSeparator5,
            this.generateToolStripMenuItem});
            this.librariesToolStripMenuItem.Name = "librariesToolStripMenuItem";
            this.librariesToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.librariesToolStripMenuItem.Text = "生成(&G)";
            // 
            // loadLibraryToolStripMenuItem
            // 
            this.loadLibraryToolStripMenuItem.Enabled = false;
            this.loadLibraryToolStripMenuItem.Name = "loadLibraryToolStripMenuItem";
            this.loadLibraryToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.loadLibraryToolStripMenuItem.Text = "&Add Library";
            this.loadLibraryToolStripMenuItem.Click += new System.EventHandler(this.LoadLibrary_Click);
            // 
            // viewLibrariesToolStripMenuItem
            // 
            this.viewLibrariesToolStripMenuItem.Enabled = false;
            this.viewLibrariesToolStripMenuItem.Name = "viewLibrariesToolStripMenuItem";
            this.viewLibrariesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.viewLibrariesToolStripMenuItem.Text = "&View Libraries";
            this.viewLibrariesToolStripMenuItem.Click += new System.EventHandler(this.ViewLibraries_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(154, 6);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Enabled = false;
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.generateToolStripMenuItem.Text = "生成(&n)";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.Generate_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.helpToolStripMenuItem.Text = "帮助(&H)";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.helpToolStripMenuItem1.Text = "H&elp";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "关于(&A)";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiBtnNew,
            this.uiBtnOpen,
            this.uiBtnSave,
            this.toolStripSeparator1,
            this.uiBtnGenerate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1049, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // uiBtnNew
            // 
            this.uiBtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uiBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiBtnNew.Name = "uiBtnNew";
            this.uiBtnNew.Size = new System.Drawing.Size(38, 22);
            this.uiBtnNew.Text = "New";
            this.uiBtnNew.Click += new System.EventHandler(this.NewProject_Click);
            // 
            // uiBtnOpen
            // 
            this.uiBtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uiBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiBtnOpen.Name = "uiBtnOpen";
            this.uiBtnOpen.Size = new System.Drawing.Size(44, 22);
            this.uiBtnOpen.Text = "Open";
            this.uiBtnOpen.Click += new System.EventHandler(this.OpenProject_Click);
            // 
            // uiBtnSave
            // 
            this.uiBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uiBtnSave.Enabled = false;
            this.uiBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("uiBtnSave.Image")));
            this.uiBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiBtnSave.Name = "uiBtnSave";
            this.uiBtnSave.Size = new System.Drawing.Size(39, 22);
            this.uiBtnSave.Text = "Save";
            this.uiBtnSave.Click += new System.EventHandler(this.SaveProject_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // uiBtnGenerate
            // 
            this.uiBtnGenerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uiBtnGenerate.Enabled = false;
            this.uiBtnGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiBtnGenerate.Name = "uiBtnGenerate";
            this.uiBtnGenerate.Size = new System.Drawing.Size(65, 22);
            this.uiBtnGenerate.Text = "Generate";
            this.uiBtnGenerate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 542);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1049, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uiPnlMain);
            this.splitContainer1.Size = new System.Drawing.Size(1049, 492);
            this.splitContainer1.SplitterDistance = 444;
            this.splitContainer1.SplitterIncrement = 2;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(442, 490);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uiPnlExplorer);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(434, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据库";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uiPnlExplorer
            // 
            this.uiPnlExplorer.Controls.Add(this.uiTvExplorer);
            this.uiPnlExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPnlExplorer.Location = new System.Drawing.Point(3, 26);
            this.uiPnlExplorer.Name = "uiPnlExplorer";
            this.uiPnlExplorer.Size = new System.Drawing.Size(428, 435);
            this.uiPnlExplorer.TabIndex = 3;
            // 
            // uiTvExplorer
            // 
            this.uiTvExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTvExplorer.FullRowSelect = true;
            this.uiTvExplorer.HideSelection = false;
            this.uiTvExplorer.ImageIndex = 0;
            this.uiTvExplorer.ImageList = this.uiDBImages;
            this.uiTvExplorer.Location = new System.Drawing.Point(0, 0);
            this.uiTvExplorer.Name = "uiTvExplorer";
            this.uiTvExplorer.SelectedImageIndex = 0;
            this.uiTvExplorer.Size = new System.Drawing.Size(428, 435);
            this.uiTvExplorer.TabIndex = 0;
            this.uiTvExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.uiTvExplorer_AfterSelect);
            // 
            // uiDBImages
            // 
            this.uiDBImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("uiDBImages.ImageStream")));
            this.uiDBImages.TransparentColor = System.Drawing.Color.Transparent;
            this.uiDBImages.Images.SetKeyName(0, "database.png");
            this.uiDBImages.Images.SetKeyName(1, "entity.png");
            this.uiDBImages.Images.SetKeyName(2, "table.png");
            this.uiDBImages.Images.SetKeyName(3, "view.png");
            this.uiDBImages.Images.SetKeyName(4, "columns.png");
            this.uiDBImages.Images.SetKeyName(5, "primaryKey.png");
            this.uiDBImages.Images.SetKeyName(6, "primaryReference.png");
            this.uiDBImages.Images.SetKeyName(7, "foreignReference.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 23);
            this.panel1.TabIndex = 2;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.uiTBDeleteObject});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(428, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton2.Text = "Add";
            // 
            // uiTBDeleteObject
            // 
            this.uiTBDeleteObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uiTBDeleteObject.Enabled = false;
            this.uiTBDeleteObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTBDeleteObject.Name = "uiTBDeleteObject";
            this.uiTBDeleteObject.Size = new System.Drawing.Size(59, 22);
            this.uiTBDeleteObject.Text = "Remove";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tvUI);
            this.tabPage2.Controls.Add(this.toolStrip3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(434, 464);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "项目";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tvUI
            // 
            this.tvUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUI.ImageIndex = 0;
            this.tvUI.ImageList = this.uiProjectImages;
            this.tvUI.Location = new System.Drawing.Point(3, 28);
            this.tvUI.Name = "tvUI";
            this.tvUI.SelectedImageIndex = 0;
            this.tvUI.Size = new System.Drawing.Size(428, 433);
            this.tvUI.TabIndex = 0;
            this.tvUI.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvUI_NodeMouseClick);
            // 
            // uiProjectImages
            // 
            this.uiProjectImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("uiProjectImages.ImageStream")));
            this.uiProjectImages.TransparentColor = System.Drawing.Color.Transparent;
            this.uiProjectImages.Images.SetKeyName(0, "project.png");
            this.uiProjectImages.Images.SetKeyName(1, "folder_open_16_h.gif");
            this.uiProjectImages.Images.SetKeyName(2, "modules.png");
            this.uiProjectImages.Images.SetKeyName(3, "module.png");
            this.uiProjectImages.Images.SetKeyName(4, "window.png");
            this.uiProjectImages.Images.SetKeyName(5, "table.png");
            this.uiProjectImages.Images.SetKeyName(6, "view.png");
            this.uiProjectImages.Images.SetKeyName(7, "primaryKey.png");
            this.uiProjectImages.Images.SetKeyName(8, "primaryReference.png");
            this.uiProjectImages.Images.SetKeyName(9, "foreignReference.png");
            this.uiProjectImages.Images.SetKeyName(10, "columns.png");
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbnModuleAdd,
            this.tbnModuleDelete,
            this.tbnWindowAdd,
            this.tbnWindowDelete,
            this.tbnTableAdd,
            this.tbnTableDelete});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(428, 25);
            this.toolStrip3.TabIndex = 1;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tbnModuleAdd
            // 
            this.tbnModuleAdd.Image = ((System.Drawing.Image)(resources.GetObject("tbnModuleAdd.Image")));
            this.tbnModuleAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnModuleAdd.Name = "tbnModuleAdd";
            this.tbnModuleAdd.Size = new System.Drawing.Size(76, 22);
            this.tbnModuleAdd.Text = "添加模块";
            this.tbnModuleAdd.Click += new System.EventHandler(this.tbnModuleAdd_Click);
            // 
            // tbnModuleDelete
            // 
            this.tbnModuleDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbnModuleDelete.Image")));
            this.tbnModuleDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnModuleDelete.Name = "tbnModuleDelete";
            this.tbnModuleDelete.Size = new System.Drawing.Size(76, 22);
            this.tbnModuleDelete.Text = "删除模块";
            this.tbnModuleDelete.Click += new System.EventHandler(this.tbnModuleDelete_Click);
            // 
            // tbnWindowAdd
            // 
            this.tbnWindowAdd.Image = ((System.Drawing.Image)(resources.GetObject("tbnWindowAdd.Image")));
            this.tbnWindowAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnWindowAdd.Name = "tbnWindowAdd";
            this.tbnWindowAdd.Size = new System.Drawing.Size(76, 22);
            this.tbnWindowAdd.Text = "添加窗口";
            this.tbnWindowAdd.Click += new System.EventHandler(this.tbnWindowAdd_Click);
            // 
            // tbnWindowDelete
            // 
            this.tbnWindowDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbnWindowDelete.Image")));
            this.tbnWindowDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnWindowDelete.Name = "tbnWindowDelete";
            this.tbnWindowDelete.Size = new System.Drawing.Size(76, 22);
            this.tbnWindowDelete.Text = "删除窗口";
            this.tbnWindowDelete.Click += new System.EventHandler(this.tbnWindowDelete_Click);
            // 
            // tbnTableAdd
            // 
            this.tbnTableAdd.Image = ((System.Drawing.Image)(resources.GetObject("tbnTableAdd.Image")));
            this.tbnTableAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnTableAdd.Name = "tbnTableAdd";
            this.tbnTableAdd.Size = new System.Drawing.Size(64, 22);
            this.tbnTableAdd.Text = "添加表";
            this.tbnTableAdd.Click += new System.EventHandler(this.tbnTableAdd_Click);
            // 
            // tbnTableDelete
            // 
            this.tbnTableDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbnTableDelete.Image")));
            this.tbnTableDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnTableDelete.Name = "tbnTableDelete";
            this.tbnTableDelete.Size = new System.Drawing.Size(64, 21);
            this.tbnTableDelete.Text = "删除表";
            // 
            // uiPnlMain
            // 
            this.uiPnlMain.Controls.Add(this.uiPGNamedObject);
            this.uiPnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPnlMain.Location = new System.Drawing.Point(0, 0);
            this.uiPnlMain.Name = "uiPnlMain";
            this.uiPnlMain.Size = new System.Drawing.Size(595, 490);
            this.uiPnlMain.TabIndex = 1;
            // 
            // uiPGNamedObject
            // 
            this.uiPGNamedObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPGNamedObject.Location = new System.Drawing.Point(0, 0);
            this.uiPGNamedObject.Name = "uiPGNamedObject";
            this.uiPGNamedObject.Size = new System.Drawing.Size(595, 490);
            this.uiPGNamedObject.TabIndex = 1;
            this.uiPGNamedObject.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.uiPGNamedObject_PropertyValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "egpro";
            this.openFileDialog.Filter = "All files(*.egpro)|*.egpro";
            this.openFileDialog.Title = "Open Project As...";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "egpro";
            this.saveFileDialog.Filter = "All files(*.egpro)|*.egpro";
            this.saveFileDialog.Title = "Save Project As...";
            // 
            // EasyGeneratorStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 564);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EasyGeneratorStudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Easy Generator";
            this.Load += new System.EventHandler(this.SmartStudio_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.uiPnlExplorer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.uiPnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton uiBtnNew;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel uiPnlMain;
        private System.Windows.Forms.PropertyGrid uiPGNamedObject;
        private System.Windows.Forms.ImageList uiDBImages;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton uiBtnOpen;
        private System.Windows.Forms.ToolStripButton uiBtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton uiBtnGenerate;
        private System.Windows.Forms.ImageList uiProjectImages;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem librariesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLibrariesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addControlToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel uiPnlExplorer;
        private System.Windows.Forms.TreeView uiTvExplorer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton uiTBDeleteObject;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TreeView tvUI;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tbnModuleAdd;
        private System.Windows.Forms.ToolStripButton tbnWindowAdd;
        private System.Windows.Forms.ToolStripButton tbnWindowDelete;
        private System.Windows.Forms.ToolStripButton tbnTableAdd;
        private System.Windows.Forms.ToolStripButton tbnTableDelete;
        private System.Windows.Forms.ToolStripButton tbnModuleDelete;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

