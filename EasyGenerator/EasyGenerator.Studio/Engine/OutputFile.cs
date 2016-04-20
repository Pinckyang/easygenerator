using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using EasyGenerator.Studio.Model;

namespace EasyGenerator.Studio.Engine
{
    [Serializable]
    public class OutputFile
    {
        private string fileName;
        private ContextObject contextObject;
        private string name;
        private string relativePath;
        private string outputFolder;
        private string charset;
        private bool native;
        private byte[] fileText;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public ContextObject ContextObject
        {
            get { return contextObject; }
            set { contextObject = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string RelativePath
        {
            get { return relativePath; }
            set { relativePath = value; }
        }
        public string OutputFolder
        {
            get { return outputFolder; }
            set { outputFolder = value; }
        }

        public string Charset
        {
            get { return charset; }
            set { charset = value.ToLower(); }
        }
        public bool Native
        {
            get { return native; }
            set { native = value; }
        }

        public byte[] FileText
        {
            get { return fileText; }
            set { fileText = value; }
        }
        public OutputFile()
        {
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}",outputFolder,relativePath+"\\",fileName);
        }
    }
}
