using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EasyGenerator.Studio.DbHelper;
using EasyGenerator.Studio.DbHelper.MSSQL;
using EasyGenerator.Studio.Controls;
using System.Collections;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.AssemblyCache;
using EasyGenerator.Studio.Utils;
using EasyGenerator.Studio.Engine;
using System.Diagnostics;
using EasyGenerator.Studio.DbHelper.Info;
using EasyGenerator.Studio.Model;
using System.Xml.Serialization;
using EasyGenerator.Studio.Model.DB;
using EasyGenerator.Studio.Model.UI;


namespace EasyGenerator.Studio
{
    public partial class EasyGeneratorStudio : Form
    {

        private Project project = new Project();
        private static EasyGeneratorStudio mainForm;
        private DbTreeNode currentNode;
        private string outputDirectory = string.Empty;
        private string templateDirectory = string.Empty;

        public EasyGeneratorStudio()
        {
            InitializeComponent();
            outputDirectory=Configuration.OutputPath;
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            templateDirectory = baseDirectory + "Templates\\";
        }

        public Project CurrentProject
        {
            get { return project; }
        }

        internal static EasyGeneratorStudio MainForm
        {
            get
            {
                if (EasyGeneratorStudio.mainForm == null)
                {
                    EasyGeneratorStudio.mainForm = new EasyGeneratorStudio();
                }
                return EasyGeneratorStudio.mainForm;
            }
        }
        private void BuildUITreeFromProject()
        {
            this.tvUI.Nodes.Clear();
            // ExplorerTreeNode
            UiTreeNode uiRootNode = new UiTreeNode(this.CurrentProject);
           // uiRootNode.Name = "ProjectRoot";
            tvUI.Nodes.Add(uiRootNode);

            //DbTreeNode loginModuleNode = new DbTreeNode(this.project.Ui.LoadModule.ToString(), 1, 1, this.project.Ui.LoadModule, TreeNodeType.LoginModule);
            //loginModuleNode.Name = "LoginModule";
            //loginModuleNode.Tag = "LoginModule";

            //DbTreeNode commonModuleNode = new DbTreeNode(this.project.Ui.CommonModule.ToString(), 1, 1, this.project.Ui.CommonModule, TreeNodeType.CommonModule);
            //commonModuleNode.Name = "CommonModule";
            //commonModuleNode.Tag = "CommonModule";

            //DbTreeNode systemModuleNode = new DbTreeNode(this.project.Ui.SystemModule.ToString(), 1, 1, this.project.Ui.SystemModule, TreeNodeType.SystemModule);
            //systemModuleNode.Name = "SystemModule";
            //systemModuleNode.Tag = "SystemModule";

            //uiRootNode.Nodes.Add(loginModuleNode);
            //uiRootNode.Nodes.Add(commonModuleNode);
            //uiRootNode.Nodes.Add(systemModuleNode);
            tvUI.ExpandAll();

            tbnModuleAdd.Enabled = false;
            tbnModuleDelete.Enabled = false;
            tbnWindowAdd.Enabled = false;
            tbnWindowDelete.Enabled = false;
            tbnTableAdd.Enabled = false;
            tbnTableDelete.Enabled = false;

        }

        private void tvUI_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            UiTreeNode node = (UiTreeNode)e.Node;
            uiPGNamedObject.SelectedObject=node.ContextObject;
            uiPGNamedObject.Refresh();
            if (node.ContextObject is GUISystemModule)
            {
                tbnModuleAdd.Enabled = true;
                tbnModuleDelete.Enabled = false;
                tbnWindowAdd.Enabled = false;
                tbnWindowDelete.Enabled = false;
                tbnTableAdd.Enabled = false;
                tbnTableDelete.Enabled = false;
                return;
            }


            if (node.ContextObject is GUIModule)
            {
                tbnModuleAdd.Enabled = false;
                tbnModuleDelete.Enabled = true;
                tbnWindowAdd.Enabled = true;
                tbnWindowDelete.Enabled = false;
                tbnTableAdd.Enabled = false;
                tbnTableDelete.Enabled = false;
                return;
            }

            if (node.ContextObject is CommonModule || node.ContextObject is GUILoginModule)
            {
                tbnModuleAdd.Enabled = false;
                tbnModuleDelete.Enabled = false;
                tbnWindowAdd.Enabled = true;
                tbnWindowDelete.Enabled = false;
                tbnTableAdd.Enabled = false;
                tbnTableDelete.Enabled = false;
                return;
            }

            if (node.ContextObject is GUIWindow)
            {
                tbnModuleAdd.Enabled = false;
                tbnModuleDelete.Enabled = false;
                tbnWindowAdd.Enabled = false;
                tbnWindowDelete.Enabled = true;
                tbnTableAdd.Enabled = true;
                tbnTableDelete.Enabled = false;
                return;
            }

            if (node.ContextObject is EntityInfo)
            {
                tbnModuleAdd.Enabled = false;
                tbnModuleDelete.Enabled = false;
                tbnWindowAdd.Enabled = false;
                tbnWindowDelete.Enabled = false;
                tbnTableAdd.Enabled = false;
                tbnTableDelete.Enabled = true;
                return;
            }

            if (node.ContextObject  is ReferenceInfo)
            {
                tbnModuleAdd.Enabled = false;
                tbnModuleDelete.Enabled = false;
                tbnWindowAdd.Enabled = false;
                tbnWindowDelete.Enabled = false;
                tbnTableAdd.Enabled = true;
                tbnTableDelete.Enabled = false;
                return;
            }

            tbnModuleAdd.Enabled = false;
            tbnModuleDelete.Enabled = false;
            tbnWindowAdd.Enabled = false;
            tbnWindowDelete.Enabled = false;
            tbnTableAdd.Enabled = false;
            tbnTableDelete.Enabled = false;
        }

        private void BuildDatabaseTreeFromProject()
        {
            this.uiTvExplorer.Nodes.Clear();// treeView.Nodes.Clear();

            DbTreeNode databaseRootNode = new DbTreeNode(this.CurrentProject.Database);
            uiTvExplorer.Nodes.Add(databaseRootNode);
            
            // ExplorerTreeNode databaseRootNode = new ExplorerTreeNode(this.CurrentProject.Database.Connection.InitialCatalog, 0, 0,this.CurrentProject.Database, TreeNodeType.Column);
            //uiTvExplorer.Nodes.Add(databaseRootNode);

            //TreeNode tablesNode = new TreeNode("Tables", 1, 1);
            //tablesNode.Tag = "Tables";

            //TreeNode viewsNode = new TreeNode("Views", 1, 1);
            //viewsNode.Tag = "Views";

            //databaseRootNode.Nodes.Add(tablesNode);
            //databaseRootNode.Nodes.Add(viewsNode);
            //uiTvExplorer.ExpandAll();

            //foreach (EntityInfo table in this.CurrentProject.Database.Tables)
            //{
            //    ExplorerTreeNode newTableNode = new ExplorerTreeNode(table, 2, 2, table.Caption, TreeNodeType.Table);
            //    tablesNode.Nodes.Add(newTableNode);

            //    foreach (KeyValuePair<string, ColumnInfo> column in table.Caption.Columns)
            //    {
            //        ExplorerTreeNode columnNode = new ExplorerTreeNode(column.Value, column.Caption.IsPrimaryKey ? 5 : 4, column.Caption.IsPrimaryKey ? 5 : 4, column.Caption, TreeNodeType.Column);
            //        newTableNode.Nodes.Add(columnNode);

            //        foreach (KeyValuePair<string, ReferenceInfo> reference in column.Caption.References)
            //        {

            //            int imageIndex = (reference.Caption is PrimaryKeyReferenceInfo) ? 6 : 7;
            //            ExplorerTreeNode referenceNode = new ExplorerTreeNode(reference.Caption.ToString(), imageIndex, imageIndex, reference.Caption, TreeNodeType.Reference);
            //            columnNode.Nodes.Add(referenceNode);
            //        }
            //    }
            //}

            //foreach (EntityInfo view in this.CurrentProject.Database.Views)
            //{
            //    ExplorerTreeNode newViewNode = new ExplorerTreeNode(view, 3, 3, view.Caption, TreeNodeType.View);
            //    viewsNode.Nodes.Add(newViewNode);

            //    foreach (ColumnInfo column in view.Caption.Columns)
            //    {
            //        ExplorerTreeNode columnNode = new ExplorerTreeNode(column.Value, 4, 4, column.Caption, TreeNodeType.Column);
            //        newViewNode.Nodes.Add(columnNode);


            //    }
            //}
        }

        /// <summary>
        /// Create a new Project
        /// </summary>
        private void CreateNewProject()
        {
            DriverDlg dlg = new DriverDlg();

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Driver driver = DriverFactory.GetDriver(dlg.Connection, this.CurrentProject);
                OLESchemaExtractor extractor = new MSSQL2000SchemaExtractor(driver, this.CurrentProject);

                DisplayProperties(null);

                BuildUITreeFromProject();
                BuildDatabaseTreeFromProject();

                SetControls(true);
            }
            dlg.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled"></param>
        private void SetControls(bool enabled)
        {
            this.saveAsToolStripMenuItem.Enabled = enabled;
            this.saveToolStripMenuItem.Enabled = enabled;
            this.loadLibraryToolStripMenuItem.Enabled = enabled;
            this.viewLibrariesToolStripMenuItem.Enabled = enabled;
            this.generateToolStripMenuItem.Enabled = enabled;
            this.uiBtnSave.Enabled = enabled;
           // this.uiBtnSaveAs.Enabled = enabled;
        //    this.uiBtnAddLibraries.Enabled = enabled;
       //     this.uiBtnLibrarySetting.Enabled = enabled;
            this.uiBtnGenerate.Enabled = enabled;
            this.refreshProjectToolStripMenuItem.Enabled = enabled;
            this.addControlToolStripMenuItem.Enabled = enabled;
        }

        ///// <summary>
        ///// Return all tables defined into domain
        ///// </summary>
        ///// <returns></returns>
        //internal ArrayList GetAllTables()
        //{
        //    return this.project.Domain.ConnectionInfo.GetAllTables();
        //}

        ///// <summary>
        ///// Return all views defined into domain
        ///// </summary>
        ///// <returns></returns>
        //internal ArrayList GetAllViews()
        //{
        //    return this.project.Domain.ConnectionInfo.GetAllViews();
        //}

        private void SetSelectedPropertyObject(object p)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        private void uiTvExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
           // this.uiTxtCaption.Text = string.Empty;
            this.currentNode = ((TreeView)sender).SelectedNode as DbTreeNode;
            this.CleanPanel();
            if (currentNode == null)
            {
                return;
            }

            //this.SetContextMenu(selectedNode);
            this.DisplayProperties(this.currentNode);
            this.SetMainPanel(this.currentNode);
            SetExplorerToolBar(this.currentNode);
        }

        private void SetExplorerToolBar(TreeNode tn)
        {
            //bool enabled = false;

            //enabled |= tn.Tag is Column;
            //enabled |= tn.Tag is Reference;
            //enabled |= tn.Tag is ReferenceJoin;
            //enabled |= tn.Tag is Table;

            //uiTBDeleteObject.Enabled = enabled;
        }

        /// <summary>
        /// Set the main panel
        /// </summary>
        /// <param name="node"></param>
        internal void DisplayProperties(DbTreeNode node)
        {
            if (node == null)
            {
                this.SetSelectedPropertyObject(null);
                //this.uiTxtCaption.Text = string.Empty;
            }
            else
            {
                //this.uiPGNamedObject.SelectedObject = node.PropertyWrapper;
                //this.uiPGNamedObject.Refresh();
                //this.uiTxtCaption.Text = node.Text;
            }

        }


        private void SetMainPanel(DbTreeNode node)
        {
            if (node is DbTreeNode)
            {
                this.uiPGNamedObject.Dock = DockStyle.Fill;
               // this.uiPGNamedObject.Visible = true;
            }
        }

        private void CleanPanel()
        {
            //foreach (Control ctl in this.uiPnlMain.Controls)
            //{
            //    ctl.Visible = false;
            //}
        }

        private void SmartStudio_Load(object sender, EventArgs e)
        {


            CheckForIllegalCrossThreadCalls = false;
            this.CleanPanel();
            Splash splash = new Splash();
            splash.ShowDialog(this);
            splash.Dispose();
        }


        private void LoadFilename(string fileName)
        {
            FileStream stream = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                stream = File.Open(fileName, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                this.project = (Project)formatter.Deserialize(stream);
                //this.project.FileName = fileName;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                this.Cursor = Cursors.Default;
            }

        }
      
        private void GenerateCode(string templateDir,string outputDir)
        {
            using (CodeGenerationDlg codeGenerationDlg = new CodeGenerationDlg(this.project, templateDir, outputDir))
            {
                if (codeGenerationDlg.ShowDialog(this)== DialogResult.OK)
                {
                    MessageBox.Show("代码生成完成，请浏览目标文件夹！");
                    Process.Start("explorer.exe",this.outputDirectory);
                }
            }
        }


        private void NewProject_Click(object sender, EventArgs e)
        {
            CreateNewProject();
        }

        private void OpenProject_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.project = XmlHelper.FromXml<Project>(openFileDialog.FileName);

            }
        }

        private void SaveProject_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlHelper.ToXml<Project>(saveFileDialog.FileName, this.project);
            }
        }



        private void CloseProject_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadLibrary_Click(object sender, EventArgs e)
        {
            //LoadLibrariesFromGAC();
        }

        private void ViewLibraries_Click(object sender, EventArgs e)
        {
            //LibrariesDlg dlg = new LibrariesDlg();
            //dlg.ShowDialog(this);
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            GenerationDlg dlg = new GenerationDlg();
            dlg.txtOutputFolder.Text = outputDirectory;
            dlg.ProjectName = this.project.Name;
            dlg.TemplateDirectory = this.templateDirectory;
            

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                this.GenerateCode(dlg.TemplateDirectory, dlg.txtOutputFolder.Text.Trim());
            }
            outputDirectory = dlg.txtOutputFolder.Text;
            Configuration.OutputPath = outputDirectory;

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDlg dlg = new AboutDlg();
            dlg.ShowDialog(this);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The method or operation is not implemented.");
        }


        private void OnDeleteObject_Click(object sender, EventArgs e)
        {
           /* if (this.currentNode != null)
            {
                uiTBDeleteObject.Enabled = false;

                Column column = this.currentNode.Tag as Column;
                if (column != null)
                {
                    Table table = this.currentNode.Parent.Tag as Table;
                    if (table.RemoveColumn(column))
                    {
                        return;
                    }
                }

                Reference reference = this.currentNode.Tag as Reference;
                if (reference != null)
                {
                    Table table = this.currentNode.Parent.Tag as Table;
                    if (table.RemoveOutReference(reference))
                    {
                        return;
                    }
                }
                ReferenceJoin join = this.currentNode.Tag as ReferenceJoin;
                if (join != null)
                {
                    Reference refe = this.currentNode.Parent.Tag as Reference;
                    if (refe.RemoveJoin(join))
                    {
                        return;
                    }
                }

                //Table selectedTable = this.currentNode.Tag as Table;
                //if (selectedTable != null)
                //{
                //    if (this.CurrentProject.Domain.RemoveTable(selectedTable))
                //    {
                //        return;
                //    }
                //}
            }*/
        }

        private void RefreshExplorer()
        {
            this.uiTvExplorer.Nodes.Clear();
            this.CleanPanel();
            DisplayProperties(null);
            // Common.BuildTreeFromDomain(this.uiTvExplorer, this.project.Domain, true);
            SetControls(true);
        }

        private void AddControl()
        {
            //ControlsDlg dlg = new ControlsDlg();
            //if (dlg.ShowDialog(this) == DialogResult.OK)
            //{
            //    //TreeNode controlsNode = this.uiTvExplorer.Nodes[0].Nodes[2];
            //    //ExplorerTreeNode controlNode = new ExplorerTreeNode(dlg.control.Name, 7, 7, dlg.control, controlsNode);
            //    //controlsNode.Nodes.Add(controlNode);
            //}
        }

        private void refreshProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Driver tempDriver = DriverFactory.GetDriver(this.project.Domain.ConnectionInfo.Location);

            //EntitiesDlg entitiesDlg = new EntitiesDlg(tempDriver);
            //if (entitiesDlg.ShowDialog(this) == DialogResult.OK)
            //{
            //    string[] selectedTables = entitiesDlg.GetSelectedTables();
            //    string[] selectedViews = entitiesDlg.GetSelectedViews();

            //    BuildDomainDlg dlg = new BuildDomainDlg(tempDriver, selectedTables, selectedViews);
            //    if (dlg.ShowDialog(this) == DialogResult.OK)
            //    {
            //        RefreshProjectDlg refreshDlg = new RefreshProjectDlg(CurrentProject.Domain, dlg.GetDomain());
            //        if (refreshDlg.ShowDialog(this) == DialogResult.OK )
            //        {
            //            RefreshExplorer();
            //        }
            //    }
            //}


        }

        private void addControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AddControl();
        }

        private void tbnModuleAdd_Click(object sender, EventArgs e)
        {
            UiTreeNode node = tvUI.SelectedNode as UiTreeNode;
            if (node == null || !(node.ContextObject is GUISystemModule))
            {
                MessageBox.Show("请选择结点");
                return;
            }

            ModuleDlg dlg = new ModuleDlg();
            dlg.Text = "添加模块信息";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                GUISystemModule systemModule = node.ContextObject as GUISystemModule;
                if (systemModule == null)
                {
                    return;
                }

                GUIModule module = new GUIModule(systemModule);
                module.Caption = dlg.txtCaption.Text.Trim();
                module.Name = dlg.txtName.Text.Trim();
                module.Description = dlg.txtDescription.Text.Trim();
                systemModule.Modules.Add(module);

                UiTreeNode moduleNode = new UiTreeNode(module);
                node.Nodes.Add(moduleNode);
            }
        }

        private void tbnModuleDelete_Click(object sender, EventArgs e)
        {

            UiTreeNode node = tvUI.SelectedNode as UiTreeNode;
            if (node == null || !(node.ContextObject is GUIModule))
            {
                MessageBox.Show("请选择结点");
                return;
            }
            GUIModule module = node.ContextObject as GUIModule;

            UiTreeNode systemModuleNode = node.Parent as UiTreeNode;

            GUISystemModule systemModule = systemModuleNode.ContextObject as GUISystemModule;
            if (systemModule == null || !(node.ContextObject is GUISystemModule))
            {
                return;
            }

            systemModule.Modules.RemoveAll(o=>o.Name==module.Name);
            systemModuleNode.Nodes.Remove(node);



        }

        private void tbnWindowAdd_Click(object sender, EventArgs e)
        {
            UiTreeNode node = tvUI.SelectedNode as UiTreeNode;
            //if (node == null || !(node.ContextObject is Module))
            //{
            //    MessageBox.Show("请选择结点");
            //    return;
            //}
            if(node==null)
            {
                return;
            }
            if (node.ContextObject is GUIModule)
            {
                CreateModuleWindow(node);
                return;
            }

            if (node.ContextObject is CommonModule)
            {
                CreateCommonModuleDialog(node);
                return;
            }

            if(node.ContextObject is GUILoginModule)
            {
                CreateLoginModuleDialog(node);
                return;
            }
        }
        private void CreateLoginModuleDialog(UiTreeNode node)
        {
            if (node == null || !(node.ContextObject is GUILoginModule))
            {
                MessageBox.Show("请选择结点");
                return;
            }

            LoginWindowDlg dlg = new LoginWindowDlg();
            dlg.Project = this.project;
            dlg.Text = "添加登录窗口";
            foreach (TableInfo entity in this.project.Database.Tables)
            {
                dlg.cmbEntity.Items.Add(entity);
            }

            dlg.cmbEntity.SelectedIndex = 0;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                GUILoginModule module = node.ContextObject as GUILoginModule;
                if (module == null)
                {
                    return;
                }


                TableInfo entityInfo = this.project.Database.Tables.Find(e=>e.Name==dlg.cmbEntity.SelectedItem.ToString());

                if (entityInfo == null)
                {
                    return;
                }

                module.TableName = ((TableInfo)entityInfo).Name;
                module.AccountField = dlg.cmbAccountField.SelectedItem.ToString();
                module.PasswordField = dlg.cmbPasswordField.SelectedItem.ToString();
            }
        }


        private void CreateCommonModuleDialog(UiTreeNode node)
        {
            if (node == null || !(node.ContextObject is CommonModule))
            {
                MessageBox.Show("请选择结点");
                return;
            }

            WindowDlg dlg = new WindowDlg();
            dlg.Text = "添加窗口信息";
            foreach (TableInfo table in this.project.Database.Tables)
            {
                dlg.cmbEntity.Items.Add(table);
            }
            foreach (ViewInfo view in this.project.Database.Views)
            {
                dlg.cmbEntity.Items.Add(view);
            }

            dlg.cmbEntity.SelectedIndex = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CommonModule module = node.ContextObject as CommonModule;
                if (module == null)
                {
                    return;
                }

                GUIDialog window = new GUIDialog(module);
                window.Caption = dlg.txtCaption.Text.Trim();
                window.Name = dlg.txtName.Text.Trim();
                window.Description = dlg.txtDescription.Text.Trim();
                module.Dialogs.Add(window);

                EntityInfo entityInfo = null;
                TableInfo tableInfo = null;
                ViewInfo viewInfo = null;
                tableInfo= this.project.Database.Tables.Find(e=>e.Name==dlg.cmbEntity.SelectedItem.ToString());
                entityInfo = tableInfo;

                if (entityInfo != null)
                {
                    entityInfo = (EntityInfo)((TableInfo)entityInfo).Clone();
                }
                else
                {
                    viewInfo = this.project.Database.Views.Find(e=>e.Name == dlg.cmbEntity.SelectedItem.ToString());
                    entityInfo = viewInfo;
                    entityInfo = (EntityInfo)((ViewInfo)entityInfo).Clone();
                }
                
                window.Entities.Add(entityInfo);
                window.ResultTableName = entityInfo.Name;

                BuildEntities(entityInfo);
                UiTreeNode windowNode = new UiTreeNode(window);
                node.Nodes.Add(windowNode);
            }
        }

        private void CreateModuleWindow(UiTreeNode node)
        {

            if (node == null || !(node.ContextObject is GUIModule))
            {
                MessageBox.Show("请选择结点");
                return;
            }
            WindowDlg dlg = new WindowDlg();
            dlg.Text = "添加窗口信息";
            foreach (TableInfo item in this.project.Database.Tables)
            {
                dlg.cmbEntity.Items.Add(item);
            }
            foreach (ViewInfo item in this.project.Database.Views)
            {
                dlg.cmbEntity.Items.Add(item);
            }

            dlg.cmbEntity.SelectedIndex = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                GUIModule module = node.ContextObject as GUIModule;
                if (module == null)
                {
                    return;
                }

                GUIWindow window = new GUIWindow(module);
                window.Caption = dlg.txtCaption.Text.Trim();
                window.Name = dlg.txtName.Text.Trim();
                window.Description = dlg.txtDescription.Text.Trim();
                module.Windows.Add(window);

                EntityInfo entityInfo = null;
                TableInfo tableInfo = null;
                ViewInfo viewInfo = null;
                tableInfo=this.project.Database.Tables.Find(e=>e.Name==dlg.cmbEntity.SelectedItem.ToString());
                entityInfo = tableInfo;

                if (entityInfo != null)
                {
                    entityInfo = (EntityInfo)((TableInfo)entityInfo).Clone();
                    //todo:window.MasterViews.Add(entityInfo);
                }
                else
                {
                    viewInfo=this.project.Database.Views.Find(e=>e.Name==dlg.cmbEntity.SelectedItem.ToString());
                    entityInfo = viewInfo;
                    entityInfo = (EntityInfo)((ViewInfo)entityInfo).Clone();
                    //todo:window.Entities.Add(entityInfo);
                }

                BuildEntities(entityInfo);
                UiTreeNode windowNode = new UiTreeNode(window);
                node.Nodes.Add(windowNode);
            }
        }

        
        private void BuildEntities(EntityInfo entityInfo)
        {
            foreach ( ColumnInfo column in entityInfo.Columns)
            {
                //foreach (ReferenceInfo reference in column.ReferencedReferences)
                //{
                //    if (reference is PrimaryKeyReferenceInfo)
                //    {
                //        TableInfo referTable = null;
                //        referTable=this.CurrentProject.Database.Tables.Find(e=>e.Name==reference.ReferenceTableName );
                //        if (referTable != null && referTable is TableInfo)
                //        {
                //            reference.ReferenceTable = (TableInfo)((TableInfo)referTable).Clone();
                //            if (reference.TableName != reference.ReferenceTableName)
                //            {
                //                BuildEntities(reference.ReferenceTable);
                //            }
                //        }
                //    }
                //    else if (reference is ForeignKeyReferenceInfo)
                //    {
                //        TableInfo referTable = null;
                //        referTable=this.CurrentProject.Database.Tables.Find(e=>e.Name==reference.ReferenceTableName);
                //        if (referTable != null && referTable is TableInfo)
                //        {
                //            reference.ReferenceTable = (TableInfo)((TableInfo)referTable).Clone();

                //            column.DBControlType = DBControlType.DBLookupListBox;
                //            DBLookupListBox lookupGridBox = column.DBControl as DBLookupListBox;
                //            if (lookupGridBox != null)
                //            {
                //                lookupGridBox.LookupTable = reference.ReferenceTableName;
                //                lookupGridBox.LookupKeyField = reference.ReferenceColumnName;
                //            }
                //        }
                //    }
                //}
            }
        }

        private void tbnWindowDelete_Click(object sender, EventArgs e)
        {
            UiTreeNode node = tvUI.SelectedNode as UiTreeNode;
            if (node == null || !(node.ContextObject is GUIWindow))
            {
                MessageBox.Show("请选择窗口");
                return;
            }

            GUIWindow window = node.ContextObject as GUIWindow;

            UiTreeNode moduleNode = node.Parent as UiTreeNode;

            GUIModule module = moduleNode.ContextObject as Module;
            if (module == null || node.ContextObject is Module)
            {
                return;
            }

            module.Windows.RemoveAll(o=>o.Name==window.Name);
            moduleNode.Nodes.Remove(node);
        }

        private void tbnTableAdd_Click(object sender, EventArgs e)
        {
            UiTreeNode node = tvUI.SelectedNode as UiTreeNode;
            if (node == null || !(node.ContextObject is Window))
            {
                MessageBox.Show("请选择结点");
                return;
            }

            TableDlg dlg = new TableDlg();
            dlg.Text = "添加表/视图信息";
            foreach (TableInfo item in this.project.Database.Tables)
            {
                dlg.cmbEntity.Items.Add(item);
            }
            foreach (ViewInfo item in this.project.Database.Views)
            {
                dlg.cmbEntity.Items.Add(item);
            }

            dlg.cmbEntity.SelectedIndex = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Window window = node.ContextObject as Window;
                if (window == null)
                {
                    return;
                }

                TableInfo entityInfo = null;
                entityInfo = this.project.Database.Tables.Find(o=>o.Name==dlg.cmbEntity.SelectedItem.ToString() );

                if (entityInfo != null)
                {
                    window.Entities.Add((EntityInfo)((TableInfo)entityInfo).Clone());
                }
                else
                {
                    ViewInfo viewInfo = null;
                    viewInfo=this.project.Database.Views.Find(o=>o.Name==dlg.cmbEntity.SelectedItem.ToString());

                    window.Entities.Add((EntityInfo)((ViewInfo)viewInfo).Clone());
                }

                BuildEntities(entityInfo);

                UiTreeNode moduleNode = new UiTreeNode(entityInfo);
                node.Nodes.Add(moduleNode);
            }
        }

        private void uiPGNamedObject_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            uiPGNamedObject.Refresh();
        }
    }
}