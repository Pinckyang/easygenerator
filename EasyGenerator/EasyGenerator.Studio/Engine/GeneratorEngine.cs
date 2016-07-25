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
using RazorEngine.Templating;
using System.CodeDom.Compiler;
using EasyGenerator.Studio.Utils;
using EasyGenerator.Studio.Model.DB;
using EasyGenerator.Studio.Model.UI;

namespace EasyGenerator.Studio.Engine
{
    public delegate void GeneratingFile(OutputFile file,bool successful,string message);
    public delegate void GeneratedFiles();
    public class GeneratorEngine
    {
        private Project project;
        private string templateDir;
        private string outputDir;
        private List<OutputFile> outputFiles = new List<OutputFile>();

        public event GeneratingFile OnGeneratingFile = null;
        public event GeneratedFiles OnGeneratedFiles = null;

        private GeneratorEngine()
        { 
        }

        public GeneratorEngine(Project project)
        {
            this.project = project;
            Razor.SetTemplateBase(typeof(EasyGeneratorTemplateBase<>));
            Razor.DefaultTemplateService.Namespaces.Add("System.Collections.Generic");
            Razor.DefaultTemplateService.Namespaces.Add("System.Text");
            Razor.DefaultTemplateService.Namespaces.Add("EasyGenerator.Studio.Utils");
            Razor.DefaultTemplateService.Namespaces.Add("EasyGenerator.Studio.Model");
            Razor.DefaultTemplateService.Namespaces.Add("EasyGenerator.Studio.Controls");
            Razor.DefaultTemplateService.Namespaces.Add("EasyGenerator.Studio.DbHelper");

        }

        public void LoadTemplates(string templateDir)
        {
            this.templateDir = templateDir;
            string [] items= ProfileHelper.ReadAllKeys("TypeMapping", string.Format("{0}\\setting.ini",this.templateDir));
            foreach (string item in items)
            {
                string [] keys=item.Split('=');
                SqlType type=(SqlType)Enum.Parse(typeof(SqlType),keys[0],true);
                if (!PageModel.TypeMapping.ContainsKey(type))
                {
                    PageModel.TypeMapping.Add(type, keys[1]);
                }
            }
            string charset=ProfileHelper.GetStringValue(string.Format("{0}\\setting.ini", this.templateDir), "Option", "Charset", "UTF-8");
            GenerateChildTempates(templateDir, string.Empty, string.Empty, charset, false);
            this.outputFiles.RemoveAll(e => { return e.FileName.Equals("setting.ini", StringComparison.CurrentCultureIgnoreCase) || e.FileName.Equals("readme.rtf", StringComparison.CurrentCultureIgnoreCase); });
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
                string tempCharset = charset;
                bool tempNative = native;

                DirectoryInfo directoryInfo = new DirectoryInfo(folder);
                MatchCollection matchFolders = Regex.Matches(directoryInfo.Name, "\\[.*?\\]");

                

                foreach (Match matchFolder in matchFolders)
                {
                    if (matchFolder.Value.ToUpper().StartsWith("[CHARSET="))
                    {
                        tempCharset = matchFolder.Value.ToUpper().Replace("[CHARSET=", string.Empty).Trim(']');
                    }
                    else if (matchFolder.Value.ToUpper().StartsWith("[NATIVE="))
                    {
                        tempNative = bool.Parse(matchFolder.Value.ToUpper().Replace("[NATIVE=", string.Empty).Trim(']'));
                    }
                }

                if (matchFolders.Count < 1)
                {
                    GenerateChildTempates(folder, string.Empty, string.Empty, tempCharset, tempNative);
                    continue;
                }

                foreach (Match matchFolder in matchFolders)
                {
                    if (matchFolder.Value.ToUpper() == "[TABLES]")
                    {
                        foreach (EntityInfo entity in project.Database.Tables)
                        {
                            GenerateChildTempates(folder, "\\[TABLES\\]", entity.Name, charset, tempNative);
                        }
                    }
                    else if (matchFolder.Value.ToUpper() == "[VIEWS]")
                    {
                        foreach (EntityInfo entity in project.Database.Views)
                        {
                            GenerateChildTempates(folder, "\\[VIEWS\\]", entity.Name, tempCharset, tempNative);
                        }
                    }
                    else if (matchFolder.Value.ToUpper() == "[ENTITIES]")
                    {
                        foreach (EntityInfo entity in project.Database.Tables)
                        {
                            GenerateChildTempates(folder, "\\[ENTITIES\\]", entity.Name, tempCharset, tempNative);
                        }
                        foreach (EntityInfo entity in project.Database.Views)
                        {
                            GenerateChildTempates(folder, "\\[ENTITIES\\]", entity.Name, tempCharset, tempNative);
                        }
                    }
                    else if (matchFolder.Value.ToUpper() == "[MODULES]")
                    {
                        foreach (var module in project.Ui.SystemModule.Modules)
                        {
                            GenerateChildTempates(folder, "\\[MODULES\\]", module.Name, tempCharset, tempNative);
                        }
 
                    }
                    else if(matchFolder.Value.ToUpper() == "[WINDOWS]")
                    {
                        if (pattern == "\\[MODULES\\]" && matchValue != string.Empty)
                        {

                            var  module = project.Ui.SystemModule.Modules.Find(e=>e.Name==matchValue);

                            if (module != null)
                            {
                                foreach (GUIWindow window in module.Windows)
                                {
                                    GenerateChildTempates(folder, "\\[WINDOWS\\]", window.Name, tempCharset, tempNative);
                                }
                            }

                        }
                        else
                        {
                            foreach (var module in project.Ui.SystemModule.Modules)
                            {
                                foreach (GUIWindow window in module.Windows)
                                {
                                    GenerateChildTempates(folder, "\\[WINDOWS\\]", window.Name, tempCharset, tempNative);
                                }
                            }
                        }
                    }
                    else if (matchFolder.Value.ToUpper() == "[DIALOGS]")
                    {
                        foreach (GUIDialog dialog in project.Ui.CommonModule.Dialogs)
                        {
                            GenerateChildTempates(folder, "\\[DIALOGS\\]", dialog.Name, tempCharset, tempNative);
                        }
                    }
                    else if (matchFolder.Value.ToUpper() == "[TABLE]")
                    {
                        GenerateChildTempates(folder, "\\[TABLE\\]", matchValue, tempCharset, tempNative);
                    }
                    else if (matchFolder.Value.ToUpper() == "[VIEW]")
                    {
                        GenerateChildTempates(folder, "\\[TABLE\\]", matchValue, tempCharset, tempNative);
                    }
                    else if (matchFolder.Value.ToUpper() == "[ENTITY]")
                    {
                        GenerateChildTempates(folder, "\\[TABLE\\]", matchValue, tempCharset, tempNative);
                    }
                    else if(matchFolder.Value.ToUpper() == "[MODULE]")
                    {
                        GenerateChildTempates(folder, "\\[MODULE\\]", matchValue, tempCharset, tempNative);
                    }
                    else if(matchFolder.Value.ToUpper() == "[WINDOW]")
                    {
                        GenerateChildTempates(folder, "\\[WINDOW\\]", matchValue, tempCharset, tempNative);
                    }
                    else if (matchFolder.Value.ToUpper() == "[DIALOG]")
                    {
                        GenerateChildTempates(folder, "\\[DIALOG\\]", matchValue, tempCharset, tempNative);
                    }
                    else
                    {
                        if (!matchFolder.Value.ToUpper().StartsWith("[CHARSET=") && !matchFolder.Value.ToUpper().StartsWith("[NATIVE="))
                        {
                            GenerateChildTempates(folder, string.Empty, string.Empty, tempCharset, tempNative);
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
                string tempCharset = charset;
                bool tempNative = native;

                FileInfo fileInfo = new FileInfo(file);

                string fileName = Regex.Replace(fileInfo.Name, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);

                MatchCollection matchs = Regex.Matches(fileName, "\\[.*?\\]");

                foreach (Match match in matchs)
                {
                    if (match.Value.ToUpper().StartsWith("[CHARSET="))
                    {
                        tempCharset = match.Value.ToUpper().Replace("[CHARSET=", string.Empty).Trim(']');
                    }
                    else if (match.Value.ToUpper().StartsWith("[NATIVE="))
                    {
                        tempNative = bool.Parse(match.Value.ToUpper().Replace("[NATIVE=", string.Empty).Trim(']'));
                    }
                }

                if (matchs.Count < 1)
                {
                    OutputFile outputFile = new PageModel();
                    outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(fileName);
                    outputFile.ContextObject = pro;
                    outputFile.Name = string.Empty;
                    outputFile.Charset = tempCharset;
                    outputFile.Native = tempNative;
                    outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                    outputFile.FileText = File.ReadAllBytes(file);
                    outputFileList.Add(outputFile);
                }


                foreach (Match match in matchs)
                {
                    if (match.Value.ToUpper() == "[TABLES]")
                    {
                        foreach (EntityInfo entity in pro.Database.Tables)
                        {
                            OutputFile outputFile = new PageModel();
                            outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(Regex.Replace(fileName, "\\[TABLES\\]", entity.Name, RegexOptions.IgnoreCase));
                            outputFile.ContextObject = entity;
                            outputFile.Name = entity.Name;
                            outputFile.Charset = tempCharset;
                            outputFile.Native = tempNative;
                            outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                            outputFile.FileText = File.ReadAllBytes(file);
                            outputFileList.Add(outputFile);
                        }

                    }
                    else if (match.Value.ToUpper() == "[VIEWS]")
                    {
                        foreach (EntityInfo entity in pro.Database.Views)
                        {
                            OutputFile outputFile = new PageModel();
                            outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(Regex.Replace(fileName, "\\[VIEWS\\]", entity.Name, RegexOptions.IgnoreCase));
                            outputFile.ContextObject = entity;
                            outputFile.Name = entity.Name;
                            outputFile.Charset = tempCharset;
                            outputFile.Native = tempNative;
                            outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                            outputFile.FileText = File.ReadAllBytes(file);
                            outputFileList.Add(outputFile);
                        }
                    }
                    else if (match.Value.ToUpper() == "[ENTITIES]")
                    {
                        foreach (EntityInfo entity in pro.Database.Tables)
                        {
                            OutputFile outputFile = new PageModel();
                            outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(Regex.Replace(fileName, "\\[ENTITIES\\]", entity.Name, RegexOptions.IgnoreCase));
                            outputFile.ContextObject = entity;
                            outputFile.Name = entity.Name;
                            outputFile.Charset = tempCharset;
                            outputFile.Native = tempNative;
                            outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                            outputFile.FileText = File.ReadAllBytes(file);
                            outputFileList.Add(outputFile);
                        }

                        foreach (EntityInfo entity in pro.Database.Views)
                        {
                            OutputFile outputFile = new PageModel();
                            outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(Regex.Replace(fileName, "\\[ENTITIES\\]", entity.Name, RegexOptions.IgnoreCase));
                            outputFile.ContextObject = entity;
                            outputFile.Name = entity.Name;
                            outputFile.Charset = tempCharset;
                            outputFile.Native = tempNative;
                            outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                            outputFile.FileText = File.ReadAllBytes(file);
                            outputFileList.Add(outputFile);
                        }
                    }
                    else if (match.Value.ToUpper() == "[MODULES]")
                    {
                        foreach (var module in pro.Ui.SystemModule.Modules)
                        {
                            OutputFile outputFile = new PageModel();
                            outputFile.FileName =NomenclatureHelper.ConvertToPascalCase( Regex.Replace(fileName, "\\[MODULES\\]", module.Name, RegexOptions.IgnoreCase));
                            outputFile.ContextObject = module;
                            outputFile.Name = module.Name;
                            outputFile.Charset = tempCharset;
                            outputFile.Native = tempNative;
                            outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                            outputFile.FileText = File.ReadAllBytes(file);
                            outputFileList.Add(outputFile);
                        }
                    }
                    else if (match.Value.ToUpper() == "[WINDOWS]")
                    {
                        if (matchValue != string.Empty)
                        {

                            var module = pro.Ui.SystemModule.Modules.Find(e=>e.Name==matchValue);

                            if (module != null)
                            {
                                foreach (GUIWindow window in module.Windows)
                                {
                                    OutputFile outputFile = new PageModel();
                                    outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(Regex.Replace(fileName, "\\[WINDOWS\\]", window.Name, RegexOptions.IgnoreCase));
                                    outputFile.ContextObject = window;
                                    outputFile.Name = window.Name;
                                    outputFile.Charset = tempCharset;
                                    outputFile.Native = tempNative;
                                    outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                                    outputFile.FileText = File.ReadAllBytes(file);
                                    outputFileList.Add(outputFile);
                                }
                            }

                        }
                        else
                        {
                            foreach (var module in pro.Ui.SystemModule.Modules)
                            {
                                foreach (GUIWindow window in module.Windows)
                                {
                                    OutputFile outputFile = new PageModel();
                                    outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(Regex.Replace(fileName, "\\[WINDOWS\\]", window.Name, RegexOptions.IgnoreCase));
                                    outputFile.ContextObject = window;
                                    outputFile.Name = window.Name;
                                    outputFile.Charset = tempCharset;
                                    outputFile.Native = tempNative;
                                    outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                                    outputFile.FileText = File.ReadAllBytes(file);
                                    outputFileList.Add(outputFile);
                                }
                            }
                        }
                    }
                    else if (match.Value.ToUpper() == "[DIALOGS]")
                    {
                        foreach (GUIDialog dialog in pro.Ui.CommonModule.Dialogs)
                        {
                            OutputFile outputFile = new PageModel();
                            outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(Regex.Replace(fileName, "\\[DIALOGS\\]", dialog.Name, RegexOptions.IgnoreCase));
                            outputFile.Name = dialog.Name;
                            outputFile.ContextObject = dialog;
                            outputFile.Charset = tempCharset;
                            outputFile.Native = tempNative;
                            outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                            outputFile.FileText = File.ReadAllBytes(file);
                            outputFileList.Add(outputFile);
                        }
                    }
                    else if (match.Value.ToUpper() == "[TABLE]")
                    {

                        TableInfo entityInfo = pro.Database.Tables.Find(e=>e.Name==matchValue);

                        OutputFile outputFile = new PageModel();
                        outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(Regex.Replace(fileName, "\\[TABLE\\]", matchValue, RegexOptions.IgnoreCase));
                        outputFile.ContextObject = (entityInfo == null) ? (ContextObject)pro : (ContextObject)entityInfo;
                        outputFile.Name = matchValue;
                        outputFile.Charset = tempCharset;
                        outputFile.Native = tempNative;
                        outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                        outputFile.FileText = File.ReadAllBytes(file);
                        outputFileList.Add(outputFile);
                    }
                    else if (match.Value.ToUpper() == "[VIEW]")
                    {

                        ViewInfo entityInfo = pro.Database.Views.Find(e=>e.Name==matchValue);

                        OutputFile outputFile = new PageModel();
                        outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(Regex.Replace(fileName, "\\[VIEW\\]", matchValue, RegexOptions.IgnoreCase));
                        outputFile.ContextObject = (entityInfo == null) ? (ContextObject)pro : (ContextObject)entityInfo;
                        outputFile.Name = matchValue;
                        outputFile.Charset = tempCharset;
                        outputFile.Native = tempNative;
                        outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                        outputFile.FileText = File.ReadAllBytes(file);
                        outputFileList.Add(outputFile);
                    }
                    else if (match.Value.ToUpper() == "[ENTITY]")
                    {
                        EntityInfo entityInfo = null;
                        
                        ViewInfo viewInfo = null;
                        TableInfo tableInfo = pro.Database.Tables.Find(e=>e.Name==matchValue);
                        entityInfo = tableInfo;

                        if (entityInfo == null)
                        {
                            viewInfo = pro.Database.Views.Find(e=>e.Name==matchValue);
                            entityInfo = viewInfo;
                        }

                        OutputFile outputFile = new PageModel();
                        outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(Regex.Replace(fileName, "\\[ENTITY\\]", matchValue, RegexOptions.IgnoreCase));
                        outputFile.ContextObject = (entityInfo == null) ? (ContextObject)pro : (ContextObject)entityInfo;
                        outputFile.Name = matchValue;
                        outputFile.Charset = tempCharset;
                        outputFile.Native = tempNative;
                        outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                        outputFile.FileText = File.ReadAllBytes(file);
                        outputFileList.Add(outputFile);
                    }
                    else if (match.Value.ToUpper() == "[MODULE]")
                    {

                        var module = pro.Ui.SystemModule.Modules.Find(e=>e.Name==matchValue);

                        OutputFile outputFile = new PageModel();
                        outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(Regex.Replace(fileName, "\\[MODULE\\]", matchValue, RegexOptions.IgnoreCase));
                        outputFile.ContextObject = (module == null) ? (ContextObject)pro : (ContextObject)module;
                        outputFile.Name = matchValue;
                        outputFile.Charset = tempCharset;
                        outputFile.Native = tempNative;
                        outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                        outputFile.FileText = File.ReadAllBytes(file);
                        outputFileList.Add(outputFile);
                    }
                    else if (match.Value.ToUpper() == "[WINDOW]")
                    {
                        GUIWindow window = null;
                        foreach (var module in pro.Ui.SystemModule.Modules)
                        {
                            window = module.Windows.Find(e=>e.Name==matchValue);
                            if (window != null)
                            {
                                break;
                            }
                        }

                        OutputFile outputFile = new PageModel();
                        outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(Regex.Replace(fileName, "\\[WINDOW\\]", matchValue, RegexOptions.IgnoreCase));
                        outputFile.ContextObject = (window == null) ? (ContextObject)pro : (ContextObject)window;
                        outputFile.Name = matchValue;
                        outputFile.Charset = tempCharset;
                        outputFile.Native = tempNative;
                        outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                        outputFile.FileText = File.ReadAllBytes(file);
                        outputFileList.Add(outputFile);
                    }
                    else if (match.Value.ToUpper() == "[DIALOG]")
                    {

                        GUIDialog dialog = pro.Ui.CommonModule.Dialogs.Find(e=>e.Name==matchValue);

                        OutputFile outputFile = new PageModel();
                        outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(Regex.Replace(fileName, "\\[DIALOG\\]", matchValue, RegexOptions.IgnoreCase));
                        outputFile.ContextObject = (dialog == null) ? (ContextObject)pro : (ContextObject)dialog;
                        outputFile.Name = matchValue;
                        outputFile.Charset = tempCharset;
                        outputFile.Native = tempNative;
                        outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                        outputFile.FileText = File.ReadAllBytes(file);
                        outputFileList.Add(outputFile);
                    }
                    else 
                    {
                        if (!match.Value.ToUpper().StartsWith("[CHARSET=") && !match.Value.ToUpper().StartsWith("[NATIVE="))
                        {
                            OutputFile outputFile = new PageModel();
                            outputFile.FileName = NomenclatureHelper.ConvertToPascalCase(fileName);
                            outputFile.ContextObject = pro;
                            outputFile.Name = string.Empty;
                            outputFile.Charset = tempCharset;
                            outputFile.Native = tempNative;
                            outputFile.RelativePath = Regex.Replace(fileInfo.DirectoryName, "\\[PROJECTNAME\\]", pro.Name, RegexOptions.IgnoreCase);
                            outputFile.FileText = File.ReadAllBytes(file);
                            outputFileList.Add(outputFile);
                        }
                    }
                }
            }
            return outputFileList;
        }

        public void GenerateFiles(string outputDir)
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
                        //Razor.Compile(text, file.FileName);
                        string result = Razor.Parse(text, file);
                        File.WriteAllText(file.ToString(), result);
                    }
                    else
                    {
                        File.WriteAllBytes(file.ToString(), file.FileText);
                    }
                }
                catch (TemplateCompilationException ex)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach(CompilerError err in ex.Errors)
                    {
                        sb.AppendLine(string.Format("行{0}列{1}:{2}",err.Column,err.Line,err.ToString()));
                    }
                    message = sb.ToString();
                    successful = false;
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
            if (this.OnGeneratedFiles != null)
            {
                OnGeneratedFiles();
            }
        }
    }
}
