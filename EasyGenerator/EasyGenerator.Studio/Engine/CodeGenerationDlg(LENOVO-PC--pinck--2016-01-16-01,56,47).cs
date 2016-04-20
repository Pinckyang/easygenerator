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
       // private ICodeOutput codeOutput;

        private  CodeGenerationDlg()
        {
            this.InitializeComponent();
        }

        public CodeGenerationDlg(Project project,string templateDir)
            : this()
        {

            //this.codeOutput = codeOutput;
            this.ConfigureProgressBar();
         //   CodeGenerationDelegate showProgress = new CodeGenerationDelegate(EngineProgress);
         //   codeEngine = new EasyGeneratorEngine(this, showProgress, EasyGeneratorStudio.MainForm.CurrentProject);
        }

        private void CodeGenerationDlg_Load(object sender, EventArgs e)
        {
            //Thread t = new Thread(new ThreadStart(codeEngine.RunProcess));
            //t.IsBackground = true;
            //t.Start();
        }

        //private void EngineProgress(GenerationArgs args)
        //{
        //    if (args.StatusDone)
        //    {
        //        MessageBox.Show("The Code engine was successful executed", "Message", MessageBoxButtons.OK);
        //    }
        //    else
        //    {
        //        codeOutput.WriteToOutput(args.Output, args.Template );
        //        UpdateInfo(args.Output, args.Message, args.Template, args.Success );
        //    }
        //}
 

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
            this.lvResume.Items.Add(li);
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

        //public void UpdateInfo(OutputInfo output, string message, OutputFile template, bool success)
        //{
        //    this.uiProgressBar.PerformStep();
        //    if (success)
        //    {
        //        if (output.CreateFile)
        //        {
        //            this.AddMessageToListView(true, "Created successfully ", output.Folder + @"\" + output.FileName);
        //        }
        //        else
        //        {
        //            this.AddMessageToListView(true, "Template successfully executed", template.Name);
        //        }
        //    }
        //    else
        //    {
        //        this.AddMessageToListView(false, "Error in Template '" + template.Name, message);
        //    }
        //}

        internal void ConfigureProgressBar()
        {
            int total = 0;
            //foreach (KeyValuePair<string, LibraryInfo> pair in EasyGenerator.Studio.SmartStudio.MainForm.CurrentProject.Libraries)
            //{
            //    foreach (OutputFile template in pair.Caption.Templates)
            //    {
            //        total += template.AssignedObjects.Count;
            //        if (template.Run)
            //        {
            //            total++;
            //        }
            //    }
            //}
            this.pbProgressBar.Value = 0;
            this.pbProgressBar.Minimum = 0;
            this.pbProgressBar.Maximum = total;
            this.pbProgressBar.Step = 1;
        }

    }
}