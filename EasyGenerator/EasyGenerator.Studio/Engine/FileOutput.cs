using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EasyGenerator.Studio.Utils;
using System.Diagnostics;

namespace EasyGenerator.Studio.Engine
{
    public class FileOutput : ICodeOutput
    {

        public FileOutput()
        {

        }


        public void WriteToOutput()
        {
            //string rootPath = this.selectedPath + @"\" + template.RelativePath;
            //if (template.CreateFile)
            //{
            //    new FileInfo(rootPath + @"\" + ouputInfo.FileName);
            //    Common.CreateAndWriteToFile(rootPath, ouputInfo.FileName, ouputInfo.Code);
            //}
        }


        public void ShowOutputFolder()
        {
            //Process.Start("Explorer", selectedPath);
        }


    }
}
