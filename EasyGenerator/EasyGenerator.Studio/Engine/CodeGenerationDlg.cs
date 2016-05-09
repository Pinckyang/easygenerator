using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using EasyGenerator.Studio.Model;

namespace EasyGenerator.Studio.Engine
{
    public partial class CodeGenerationDlg : Form
    {
      //  delegate void CodeGenerationDelegate(GenerationArgs args);

        private GeneratorEngine codeEngine = null;
        private Project project = null;
        private string templateDir = string.Empty;
        private string outputDir = string.Empty;
       // private ICodeOutput codeOutput;

        private  CodeGenerationDlg()
        {
            this.InitializeComponent();
        }

        public CodeGenerationDlg(Project project,string templateDir,string outputDir)
            : this()
        {
            this.project=project;
            this.templateDir = templateDir;
            this.outputDir = outputDir;
            this.codeEngine = new GeneratorEngine(project);
            this.codeEngine.OnGeneratedFiles += new GeneratedFiles(codeEngine_OnGeneratedFiles);
            this.codeEngine.OnGeneratingFile += new GeneratingFile(codeEngine_OnGeneratingFile);
           // this.ConfigureProgressBar();
         //   CodeGenerationDelegate showProgress = new CodeGenerationDelegate(EngineProgress);
         //   codeEngine = new EasyGeneratorEngine(this, showProgress, EasyGeneratorStudio.MainForm.CurrentProject);
        }

        void codeEngine_OnGeneratingFile(OutputFile file, bool successful, string message)
        {
            AddMessageToListView(successful, message, file.FileName);
            //this.codeEngine.
        }

        void codeEngine_OnGeneratedFiles()
        {
            this.DialogResult= DialogResult.OK;
            this.Close();
        }

        private void CodeGenerationDlg_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(RunProcess));
            t.IsBackground = true;
            t.Start();
        }

        private void RunProcess()
        {
            this.codeEngine.LoadTemplates(this.templateDir);
            this.codeEngine.GenerateFiles(this.outputDir);
        }


        public void AddMessageToListView(bool success, string message, string fullFileName)
        {
            ListViewItem li;
            if (success)
            {
                li = new ListViewItem(new string[] { string.Empty, fullFileName, message }, 0);
                li.ImageIndex = 0;
            }
            else
            {
                li = new ListViewItem(new string[] { string.Empty, message, fullFileName }, 1);
                li.ImageIndex = 1;
            }
            this.lvResume.Items.Insert(0,li);
           
        }
    
        private void uiLiResume_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem li = ((ListView)sender).SelectedItems[0];
                MessageBox.Show(li.Text.ToString() + "\n" + li.SubItems[1].Text.ToString() + "\n" + li.SubItems[2].Text.ToString(), "Code Generation Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
            }
        }



        //internal void ConfigureProgressBar()
        //{
        //    int total = 0;
        //    //foreach (KeyValuePair<string, LibraryInfo> pair in EasyGenerator.Studio.SmartStudio.MainForm.CurrentProject.Libraries)
        //    //{
        //    //    foreach (OutputFile template in pair.Caption.Templates)
        //    //    {
        //    //        total += template.AssignedObjects.Count;
        //    //        if (template.Run)
        //    //        {
        //    //            total++;
        //    //        }
        //    //    }
        //    //}
        //    this.pbProgressBar.Value = 0;
        //    this.pbProgressBar.Minimum = 0;
        //    this.pbProgressBar.Maximum = total;
        //    this.pbProgressBar.Step = 1;
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}