using System;
using System.Collections.Generic;
using System.Text;

namespace EasyGenerator.Studio.Engine
{
    public class TemplateFile
    {
        private string fileName;
        private string outputFolder;
        private string charset;
        private bool readOnly;
        private byte[] fileText;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public string OutputFolder
        {
            get { return outputFolder; }
            set { outputFolder = value; }
        }

        public string Charset
        {
            get { return charset; }
            set { charset = value; }
        }
        public bool ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; }
        }

        public byte[] FileText
        {
            get { return fileText; }
            set { fileText = value; }
        }
    }
}
