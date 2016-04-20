using System;
using System.Collections.Generic;
using System.Text;

namespace EasyGenerator.Studio.Engine
{
    public class TemplateDir
    {
        private string templateOriginalDir;

        public string TemplateOriginalDir
        {
            get { return templateOriginalDir; }
            set { templateOriginalDir = value; }
        }
        private string templateNewDir;

        public string TemplateNewDir
        {
            get { return templateNewDir; }
            set { templateNewDir = value; }
        }
        private bool readOnly;

        public bool ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; }
        }
        //private 
    }
}
