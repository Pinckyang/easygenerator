using EasyGenerator.Studio.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EasyGenerator.Studio.Model;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace TestEasyGenerator
{
    
    
    /// <summary>
    ///这是 GeneratorEngineTest 的测试类，旨在
    ///包含所有 GeneratorEngineTest 单元测试
    ///</summary>
    [TestClass()]
    public class GeneratorEngineTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///LoadTemplates 的测试
        ///</summary>
        [TestMethod()]
        public void LoadTemplatesTest()
        {
            Project project = new Project(); // TODO: 初始化为适当的值
            project.Name = "TEST";
            TableInfo tableInfo1 = new TableInfo();
            tableInfo1.Name = "table1";
            tableInfo1.Columns.Add("column1", new ColumnInfo() { Caption = "Column1", Name = "column1", SqlType = SqlType.Varchar });
            tableInfo1.Columns.Add("column2", new ColumnInfo() { Caption = "Column2", Name = "column2", SqlType = SqlType.Varchar });
            TableInfo tableInfo2 = new TableInfo();
            tableInfo2.Name = "table2";
            tableInfo2.Columns.Add("column1", new ColumnInfo() { Caption = "Column1", Name = "column1", SqlType = SqlType.Varchar });
            tableInfo2.Columns.Add("column2", new ColumnInfo() { Caption = "Column2", Name = "column2", SqlType = SqlType.Varchar });
            ViewInfo viewInfo1 = new ViewInfo();
            viewInfo1.Name = "view1";
            ViewInfo viewInfo2 = new ViewInfo();
            viewInfo2.Name = "view2";
            project.Database.Tables.Add("table1", tableInfo1);
            project.Database.Tables.Add("table2", tableInfo2);
            project.Database.Views.Add("view1", viewInfo1);
            project.Database.Views.Add("view2", viewInfo2);
            GeneratorEngine target = new GeneratorEngine(project); // TODO: 初始化为适当的值
            string test = Environment.CurrentDirectory;
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string str = Assembly.GetExecutingAssembly().CodeBase;
            string baseTemplateDirectory = baseDirectory + "\\Templates\\csharp_dotnet_sql2000_mvc3_utf8";

            target.LoadTemplates(baseTemplateDirectory);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///GenorateFiles 的测试
        ///</summary>
        [TestMethod()]
        public void GenorateFilesTest()
        {
            Project project = new Project(); // TODO: 初始化为适当的值
            project.Name = "TEST";
            TableInfo tableInfo1 = new TableInfo();
            tableInfo1.Name = "table1";
            tableInfo1.Columns.Add("column1", new ColumnInfo() { Caption = "Column1", Name = "column1", SqlType = SqlType.Varchar });
            tableInfo1.Columns.Add("column2", new ColumnInfo() { Caption = "Column2", Name = "column2", SqlType = SqlType.Varchar });
            TableInfo tableInfo2 = new TableInfo();
            tableInfo2.Name = "table2";
            tableInfo2.Columns.Add("column1", new ColumnInfo() { Caption = "Column1", Name = "column1", SqlType = SqlType.Varchar });
            tableInfo2.Columns.Add("column2", new ColumnInfo() { Caption = "Column2", Name = "column2", SqlType = SqlType.Varchar });
            ViewInfo viewInfo1 = new ViewInfo();
            viewInfo1.Name = "view1";
            ViewInfo viewInfo2 = new ViewInfo();
            viewInfo2.Name = "view2";
            project.Database.Tables.Add("table1", tableInfo1);
            project.Database.Tables.Add("table2", tableInfo2);
            project.Database.Views.Add("view1", viewInfo1);
            project.Database.Views.Add("view2", viewInfo2);
            GeneratorEngine target = new GeneratorEngine(project); // TODO: 初始化为适当的值
            string test = Environment.CurrentDirectory;
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string str = Assembly.GetExecutingAssembly().CodeBase;
            string baseTemplateDirectory = baseDirectory + "\\Templates\\csharp_dotnet_sql2000_mvc3_utf8";

            target.LoadTemplates(baseTemplateDirectory);
            string outputPath = baseDirectory + "\\GenerateCode";
            Directory.CreateDirectory(outputPath);
            target.OnGeneratingFile += new GeneratingFile(target_OnGeneratingFile);
            target.GenorateFiles(baseDirectory + "\\GenerateCode");

        }

        void target_OnGeneratingFile(OutputFile file, bool successful, string message)
        {
            Debug.WriteLine((successful?"成功！":"失败！")+"=>"+message);
        }
    }
}
