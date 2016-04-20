using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Threading;
using EasyGenerator.Studio.Model;
using System.IO;
using System.Text.RegularExpressions;
using RazorEngine;

namespace EasyGenerator.Studio.Engine
{
    public delegate void GeneratingFile(OutputFile file,bool successful,string message);
    public class GeneratorEngine
    {
        private Project project;
        private string templateDir;
        private string outputDir;
        private List<OutputFile> outputFiles = new List<OutputFile>();

        public event GeneratingFile OnGeneratingFile=null;

        private GeneratorEngine()
        { 
        }

        public GeneratorEngine(Project project)
        {
            this.project = project;
            Razor.SetTemplateBase(typeof(EasyGeneratorTemplateBase<>));
        }

        public void LoadTemplates(string templateDir)
        {
            this.templateDir = templateDir;
            GenerateChildTempates(templateDir, string.Empty, string.Empty, "UTF-8", false);
        }

        private void GenerateChildTempates(string tmpDir,string pattern,string matchValue,string charset,bool native)
        {
            string[] childFolders = Directory.GetDirectories(tmpDir, "*");
            List<string> folders = new List<string>(childFolders);

            List<OutputFile> files = GenerateTempleteFiles(this.project, tmpDir, matchValue,charset,native);
            this.outputFiles.AddRange(files.ConvertAll<OutputFile>(e => 
            { 
                string relativePath=Regex.Replace(e.RelativePath, pattern, matchValue, RegexOptions.IgnoreCase);
                relativePath = Regex.Replace(relativePath, "\\[CHARSET=.*?\\]", string.Empty, RegexOptions.IgnoreCase);
                relativePath = Regex.Replace(relativePath, "\\[NATIVE=.*?\\]", string.Empty, RegexOptions.IgnoreCase);
                relativePath = Regex.Replace(relativePath, pattern, matchValue, RegexOptions.IgnoreCase);
                e.RelativePath = Regex.Replace(relativePath.Replace("\\", "/"), this.templateDir.Replace("\\", "/").TrimEnd('/'), string.Empty, RegexOptions.IgnoreCase).Replace("/", "\\");
                return e; 
            }));


            foreach (string folder in folders)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folder);
                MatchCollection matchFolders = Regex.Matches(directoryInfo.Name, "\\[.*?\\]");


                foreach (Match matchFolder in matchFolders)
                {
                    if (matchFolder.Value.ToUpper().StartsWith("[CHARSET="))
                    {
                        charset = matchFolder.Value.ToUpper().Replace("[CHARSET=", string.Empty).Trim(']');
                    }
                    else if (matchFolder.Value.ToUpper().StartsWith("[NATIVE="))
                    {
                        native = bool.Parse(matchFolder.Value.ToUpper().Replace("[NATIVE=", string.Empty).Trim(']'));
                    }
                }

                if (matchFolders.Count < 1)
                {
                    GenerateChildTempates(folder, string.Empty, string.Empty, charset, native);
                    continue;
                }

                foreach (Match matchFolder in matchFolders)
                {
                    if (matchFolder.Value.ToUpper() == "[TABLES]")
                    {
                        foreach (EntityInfo entity in project.Database.Tables.Values)
                        {
                            GenerateChildTempates(folder, "\\[TABLES\\]", entity.Name, charset, native);
                        }
                    }
                    else if (matchFolder.Value.ToUpper() == "[VIEWS]")
                    {
                        foreach (EntityInfo entity in project.Database.Views.Values)
                        {
                            GenerateChildTempates(folder, "\\[VIEWS\\]", entity.Name, charset, native);
                        }
                    }
                    else if (matchFolder.Value.ToUpper() == "[ENTITIES]")
                    {
                        foreach (EntityInfo entity in project.Database.Tables.Values)
                        {
                            GenerateChildTempates(folder, "\\[ENTITIES\\]", entity.Name, charset, native);
                        }
                        foreach (EntityInfo entity in project.Database.Views.Values)
                        {
                            GenerateChildTempates(folder, "\\[ENTITIES\\]", entity.Name, charset, native);
                        }
                    }
                    else if (matchFolder.Value.ToUpper() == "[MODULES]")
                    {
                        foreach (Model.Module module in project.Ui.SystemModule.Modules.Values)
                        {
                            GenerateChildTempates(folder, "\\[MODULES\\]", module.Name, charset, native);
                        }
 
                    }
                    else if(matchFolder.Value.ToUpper() == "[WINDOWS]")
                    {
                        if (pattern == "\\[MODULES\\]" && matchValue != string.Empty)
                        {
                            Model.Module module = null;
                            project.Ui.SystemModule.Modules.TryGetValue(matchValue, out module);

                            if (module != null)
                            {
                                foreach (Window window in module.Windows.Values)
                                {
                                    GenerateChildTempates(folder, "\\[WINDOWS\\]", window.Name, charset, native);
                                }
                            }

                        }
                        else
                        {
                            foreach (Model.Module module in project.Ui.SystemModule.Modules.Values)
                            {
                                foreach (Window window in module.Windows.Values)
                                {
                                    GenerateChildTempates(folder, "\\[WINDOWS\\]", window.Name, charset, native);
                                }
                            }
                        }
                    }
                    else if (matchFolder.Value.ToUpper() == "[DIALOGS]")
                    {
                        foreach (Dialog dialog in project.Ui.CommonModule.Dialogs.Values)
                        {
                            GenerateChildTempates(folder, "\\[DIALOGS\\]", dialog.Name, charset, native);
                        }
                    }
                    else if (matchFolder.Value.ToUpper() == "[TABLE]")
                    {
                        GenerateChildTempates(folder, "\\[TABLE\\]", matchValue, charset, native);
                    }
                    else if (matchFolder.Value.ToUpper() == "[VIEW]")
                    {
                        GenerateChildTempates(folder, "\\[TABLE\\]", matchValue, charset, native);
                    }
                    else if (matchFolder.Value.ToUpper() == "[ENTITY]")
                    {
                        GenerateChildTempates(folder, "\\[TABLE\\]", matchValue, charset, native);
                    }
                    else if(matchFolder.Value.ToUpper() == "[MODULE]")
                    {
                        GenerateChildTempates(folder, "\\[MODULE\\]", matchValue, charset, native);
                    }
                    else if(matchFolder.Value.ToUpper() == "[WINDOW]")
                    {
                        GenerateChildTempates(folder, "\\[WINDOW\\]", matchValue, charset, native);
                    }
                    else if (matchFolder.Value.ToUpper() == "[DIALOG]")
                    {
                        GenerateChildTempates(folder, "\\[DIALOG\\]", matchValue, charset, native);
                    }
                    else
                    {
                        if (!matchFolder.Value.ToUpper().StartsWith("[CHARSET=") && !matchFolder.Value.ToUpper().StartsWith("[NATIVE="))
                        {
                            GenerateChildTempates(folder, string.Empty, string.Empty, charset, native);
                        }
                    }

                }


            }
        }

        private static List<OutputFile> GenerateTempleteFiles(Project pro, string directory, string matchValue, string charset, bool native)
        {
            List<OutputFile> outputFileList = new List<OutputFile>();

            if (pro == null)
            {
                return outputFileList;
            }

            if (!Directory.Exists(directory))
            {
                return outputFileList;
            }

            string[] files = Directory.GetFiles(directory);



            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                string fileName = Regex.Replace(fileInfo.Name, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);

                MatchCollection matchs = Regex.Matches(fileName, "\\[.*?\\]");

                foreach (Match match in matchs)
                {
                    if (match.Value.ToUpper().StartsWith("[CHARSET="))
                    {
                        charset = match.Value.ToUpper().Replace("[CHARSET=", string.Empty).Trim(']');
                    }
                    else if (match.Value.ToUpper().StartsWith("[NATIVE="))
                    {
                        native = bool.Parse(match.Value.ToUpper().Replace("[NATIVE=", string.Empty).Trim(']'));
                    }
                }

                if (matchs.Count < 1)
                {
                    OutputFile outputFile = new OutputFile();
                    outputFile.FileName = fileName;
                    outputFile.ContextObject = pro;
                    outputFile.Charset = charset;
                    outputFile.Native = native;
                    outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                    outputFile.FileText = File.ReadAllBytes(file);
                    outputFileList.Add(outputFile);
                }


                foreach (Match match in matchs)
                {
                    if (match.Value.ToUpper() == "[TABLES]")
                    {
                        foreach (EntityInfo entity in pro.Database.Tables.Values)
                        {
                            OutputFile outputFile = new OutputFile();
                            outputFile.FileName = Regex.Replace(fileName, "\\[TABLES\\]", entity.Name, RegexOptions.IgnoreCase);
                            outputFile.ContextObject = entity;
                            outputFile.Charset = charset;
                            outputFile.Native = native;
                            outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                            outputFile.FileText = File.ReadAllBytes(file);
                            outputFileList.Add(outputFile);
                        }

                    }
                    else if (match.Value.ToUpper() == "[VIEWS]")
                    {
                        foreach (EntityInfo entity in pro.Database.Views.Values)
                        {
                            OutputFile outputFile = new OutputFile();
                            outputFile.FileName = Regex.Replace(fileName, "\\[VIEWS\\]", entity.Name, RegexOptions.IgnoreCase);
                            outputFile.ContextObject = entity;
                            outputFile.Charset = charset;
                            outputFile.Native = native;
                            outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                            outputFile.FileText = File.ReadAllBytes(file);
                            outputFileList.Add(outputFile);
                        }
                    }
                    else if (match.Value.ToUpper() == "[ENTITIES]")
                    {
                        foreach (EntityInfo entity in pro.Database.Tables.Values)
                        {
                            OutputFile outputFile = new OutputFile();
                            outputFile.FileName = Regex.Replace(fileName, "\\[ENTITIES\\]", entity.Name, RegexOptions.IgnoreCase);
                            outputFile.ContextObject = entity;
                            outputFile.Charset = charset;
                            outputFile.Native = native;
                            outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                            outputFile.FileText = File.ReadAllBytes(file);
                            outputFileList.Add(outputFile);
                        }

                        foreach (EntityInfo entity in pro.Database.Views.Values)
                        {
                            OutputFile outputFile = new OutputFile();
                            outputFile.FileName = Regex.Replace(fileName, "\\[ENTITIES\\]", entity.Name, RegexOptions.IgnoreCase);
                            outputFile.ContextObject = entity;
                            outputFile.Charset = charset;
                            outputFile.Native = native;
                            outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                            outputFile.FileText = File.ReadAllBytes(file);
                            outputFileList.Add(outputFile);
                        }
                    }
                    else if (match.Value.ToUpper() == "[MODULES]")
                    {
                        foreach (Model.Module module in pro.Ui.SystemModule.Modules.Values)
                        {
                            OutputFile outputFile = new OutputFile();
                            outputFile.FileName = Regex.Replace(fileName, "\\[MODULES\\]", module.Name, RegexOptions.IgnoreCase);
                            outputFile.ContextObject = module;
                            outputFile.Charset = charset;
                            outputFile.Native = native;
                            outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                            outputFile.FileText = File.ReadAllBytes(file);
                            outputFileList.Add(outputFile);
                        }
                    }
                    else if (match.Value.ToUpper() == "[WINDOWS]")
                    {
                        if (matchValue != string.Empty)
                        {
                            Model.Module module = null;
                            pro.Ui.SystemModule.Modules.TryGetValue(matchValue, out module);

                            if (module != null)
                            {
                                foreach (Window window in module.Windows.Values)
                                {
                                    OutputFile outputFile = new OutputFile();
                                    outputFile.FileName = Regex.Replace(fileName, "\\[WINDOWS\\]", window.Name, RegexOptions.IgnoreCase);
                                    outputFile.ContextObject = window;
                                    outputFile.Charset = charset;
                                    outputFile.Native = native;
                                    outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                                    outputFile.FileText = File.ReadAllBytes(file);
                                    outputFileList.Add(outputFile);
                                }
                            }

                        }
                        else
                        {
                            foreach (Model.Module module in pro.Ui.SystemModule.Modules.Values)
                            {
                                foreach (Window window in module.Windows.Values)
                                {
                                    OutputFile outputFile = new OutputFile();
                                    outputFile.FileName = Regex.Replace(fileName, "\\[WINDOWS\\]", window.Name, RegexOptions.IgnoreCase);
                                    outputFile.ContextObject = window;
                                    outputFile.Charset = charset;
                                    outputFile.Native = native;
                                    outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                                    outputFile.FileText = File.ReadAllBytes(file);
                                    outputFileList.Add(outputFile);
                                }
                            }
                        }
                    }
                    else if (match.Value.ToUpper() == "[DIALOGS]")
                    {
                        foreach (Dialog dialog in pro.Ui.CommonModule.Dialogs.Values)
                        {
                            OutputFile outputFile = new OutputFile();
                            outputFile.FileName = Regex.Replace(fileName, "\\[DIALOGS\\]", dialog.Name, RegexOptions.IgnoreCase);
                            outputFile.ContextObject = dialog;
                            outputFile.Charset = charset;
                            outputFile.Native = native;
                            outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                            outputFile.FileText = File.ReadAllBytes(file);
                            outputFileList.Add(outputFile);
                        }
                    }
                    else if (match.Value.ToUpper() == "[TABLE]")
                    {
                        EntityInfo entityInfo=null;
                        pro.Database.Tables.TryGetValue(matchValue,out entityInfo);

                        OutputFile outputFile = new OutputFile();
                        outputFile.FileName = Regex.Replace(fileName, "\\[TABLE\\]", matchValue, RegexOptions.IgnoreCase);
                        outputFile.ContextObject = (entityInfo == null) ? (ContextObject)pro : (ContextObject)entityInfo;
                        outputFile.Charset = charset;
                        outputFile.Native = native;
                        outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                        outputFile.FileText = File.ReadAllBytes(file);
                        outputFileList.Add(outputFile);
                    }
                    else if (match.Value.ToUpper() == "[VIEW]")
                    {
                        EntityInfo entityInfo = null;
                        pro.Database.Views.TryGetValue(matchValue, out entityInfo);

                        OutputFile outputFile = new OutputFile();
                        outputFile.FileName = Regex.Replace(fileName, "\\[VIEW\\]", matchValue, RegexOptions.IgnoreCase);
                        outputFile.ContextObject = (entityInfo == null) ? (ContextObject)pro : (ContextObject)entityInfo;
                        outputFile.Charset = charset;
                        outputFile.Native = native;
                        outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                        outputFile.FileText = File.ReadAllBytes(file);
                        outputFileList.Add(outputFile);
                    }
                    else if (match.Value.ToUpper() == "[ENTITY]")
                    {
                        EntityInfo entityInfo = null;
                        pro.Database.Tables.TryGetValue(matchValue, out entityInfo);
                        if (entityInfo == null)
                        {
                            pro.Database.Views.TryGetValue(matchValue, out entityInfo);
                        }

                        OutputFile outputFile = new OutputFile();
                        outputFile.FileName = Regex.Replace(fileName, "\\[ENTITY\\]", matchValue, RegexOptions.IgnoreCase);
                        outputFile.ContextObject = (entityInfo == null) ? (ContextObject)pro : (ContextObject)entityInfo;
                        outputFile.Charset = charset;
                        outputFile.Native = native;
                        outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                        outputFile.FileText = File.ReadAllBytes(file);
                        outputFileList.Add(outputFile);
                    }
                    else if (match.Value.ToUpper() == "[MODULE]")
                    {
                        Model.Module module = null;
                        pro.Ui.SystemModule.Modules.TryGetValue(matchValue, out module);

                        OutputFile outputFile = new OutputFile();
                        outputFile.FileName = Regex.Replace(fileName, "\\[MODULE\\]", matchValue, RegexOptions.IgnoreCase);
                        outputFile.ContextObject = (module == null) ? (ContextObject)pro : (ContextObject)module;
                        outputFile.Charset = charset;
                        outputFile.Native = native;
                        outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                        outputFile.FileText = File.ReadAllBytes(file);
                        outputFileList.Add(outputFile);
                    }
                    else if (match.Value.ToUpper() == "[WINDOW]")
                    {
                        Window window = null;
                        foreach (Model.Module module in pro.Ui.SystemModule.Modules.Values)
                        {
                            module.Windows.TryGetValue(matchValue, out window);
                            if (window != null)
                            {
                                break;
                            }
                        }

                        OutputFile outputFile = new OutputFile();
                        outputFile.FileName = Regex.Replace(fileName, "\\[WINDOW\\]", matchValue, RegexOptions.IgnoreCase);
                        outputFile.ContextObject = (window == null) ? (ContextObject)pro : (ContextObject)window;
                        outputFile.Charset = charset;
                        outputFile.Native = native;
                        outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                        outputFile.FileText = File.ReadAllBytes(file);
                        outputFileList.Add(outputFile);
                    }
                    else if (match.Value.ToUpper() == "[DIALOG]")
                    {

                        Dialog dialog = null;
                        pro.Ui.CommonModule.Dialogs.TryGetValue(matchValue, out dialog);

                        OutputFile outputFile = new OutputFile();
                        outputFile.FileName = Regex.Replace(fileName, "\\[DIALOG\\]", matchValue, RegexOptions.IgnoreCase);
                        outputFile.ContextObject = (window == null) ? (ContextObject)pro : (ContextObject)window;
                        outputFile.Charset = charset;
                        outputFile.Native = native;
                        outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                        outputFile.FileText = File.ReadAllBytes(file);
                        outputFileList.Add(outputFile);
                    }
                    else 
                    {
                        if (!match.Value.ToUpper().StartsWith("[CHARSET=") && !match.Value.ToUpper().StartsWith("[NATIVE="))
                        {
                            OutputFile outputFile = new OutputFile();
                            outputFile.FileName = fileName;
                            outputFile.EntityName = matchValue;
                            outputFile.Charset = charset;
                            outputFile.Native = native;
                            outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                            outputFile.FileText = File.ReadAllBytes(file);
                            outputFileList.Add(outputFile);
                        }
                    }
                }
            }
            return outputFileList;
        }

        public void GenorateFiles(string outputDir)
        {
            this.outputDir = outputDir;
            foreach (OutputFile file in outputFiles)
            {
                string message = string.Empty;
                bool successful = true;

                file.OutputFolder = this.outputDir.TrimEnd('\\');

                if (File.Exists(file.ToString()))
                {
                    File.Delete(file.ToString());
                    message = "删除重复文件！";
                    successful = true;
                }
                else
                {
                    string path = Path.GetDirectoryName(file.ToString());
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        message = "创建文件夹！";
                        successful = true;
                    }
                }

                try
                {
                    if (!file.Native)
                    {
                        string text = Encoding.GetEncoding(file.Charset).GetString(file.FileText);
                        Razor.Compile(text, file.FileName);
                        string result = Razor.Parse(text, file);
                        File.WriteAllText(file.ToString(), result);
                    }
                    else
                    {
                        File.WriteAllBytes(file.ToString(), file.FileText);
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    successful = false;
                }

                if (this.OnGeneratingFile != null)
                {
                    OnGeneratingFile(file,successful,message);
                }
            }
        }

        ///// Method for ThreadStart delegate
        ///// </summary>
        //public void RunProcess()
        //{
        //    Thread.CurrentThread.IsBackground = true;
        //    this.RunCodeEngine();
        //}


       /* public void RunCodeEngine()
        {
            //OutputInfo outputInfo = new OutputInfo();
            try
            {
               // foreach (KeyValuePair<string, LibraryInfo> pair in project.Libraries)
                //{
                //    LibraryInfo library = pair.Caption;
                //    foreach (OutputFile template in library.Templates)
                //    {
                //        if (!template.IsProjectTemplate)
                //        {
                //            for (int i = 0; i < template.AssignedObjects.Count; i++)
                //            {
                //                try
                //                {
                //                    if (template.AssignedObjects[i] is NamedObject)
                //                    {
                //                        outputInfo = EasyGeneratorEngine.GenerateCode(template, library.AssemblyQualifiedName, this.project.Domain, template.AssignedObjects[i]);
                //                        this.sender.BeginInvoke(this.senderDelegate, new object[] { new GenerationArgs(template, outputInfo, "Success", true, false) });

                //                    }
                //                }
                //                catch (Exception ex)
                //                {
                //                    this.sender.BeginInvoke(this.senderDelegate, new object[] { new GenerationArgs(template, outputInfo, ex.Message, false, false) });
                //                }
                //            }
                //        }
                //        else if (template.Run)
                //        {
                //            try
                //            {

                //                outputInfo = EasyGeneratorEngine.GenerateCode(template, library.AssemblyQualifiedName, this.project.Domain, null);
                //                this.sender.BeginInvoke(this.senderDelegate, new object[] { new GenerationArgs(template, outputInfo, "Success", true, false) });
                //            }
                //            catch (Exception ex)
                //            {
                //                this.sender.BeginInvoke(this.senderDelegate, new object[] { new GenerationArgs(template, outputInfo, ex.Message, false, false) });
                //            }
                //        }
                //    }
                //}

            }
            finally
            {
                //Process.Start("Explorer", this.folderBrowserDialog.SelectedPath);
                //The end
              //  this.sender.BeginInvoke(this.senderDelegate, new object[] { new GenerationArgs(null, outputInfo, "Success", true, true) });
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="assemblyName"></param>
        /// <param name="domain"></param>
        /// <param name="namedObject"></param>
        /// <returns></returns>
        //private static OutputInfo GenerateCode(OutputFile template, string assemblyName, Domain domain, NamedObject namedObject)
        //{
        //    try
        //    {
        //        OutputInfo outputInfo = new OutputInfo();
        //        Assembly assembly = Assembly.Load(assemblyName);
        //        foreach (Type type in assembly.GetTypes())
        //        {
        //            if (type.IsClass && (type.Name == template.ClassName))
        //            {
        //                object handle = Activator.CreateInstance(type);
        //                object obj = type.InvokeMember("Run", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, handle, new object[] { domain, namedObject});
        //                ArrayList returnValues = (ArrayList)obj;
        //                outputInfo.Code = returnValues[0].ToString();
        //                outputInfo.FileName = returnValues[1].ToString();
        //                outputInfo.Folder = returnValues[2].ToString();
        //                outputInfo.CreateFile = returnValues[3].ToString() == "True";
        //            }
        //        }
        //        return outputInfo;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(exception.ToString());
        //    }
        //}*/
    }
}
