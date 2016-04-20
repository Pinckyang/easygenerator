using System;
using System.Collections.Generic;
using System.Text;
//using EasyGenerator.Studio.Templates;

namespace EasyGenerator.Studio.Engine
{
    public interface ICodeOutput
    {
        void WriteToOutput();
        void ShowOutputFolder();
    }
}
