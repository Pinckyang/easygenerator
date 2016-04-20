using EasyGenerator.Studio.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EasyGenerator.Studio.Model;
using System.Reflection;

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
            EntityInfo tableInfo1 = new TableInfo();
            tableInfo1.Name = "table1";
            EntityInfo tableInfo2 = new TableInfo();
            tableInfo2.Name = "table2";
            EntityInfo viewInfo1 = new ViewInfo();
            viewInfo1.Name = "view1";
            EntityInfo viewInfo2 = new ViewInfo();
            viewInfo2.Name = "view2";
            project.Database.Tables.Add("table1", tableInfo1);
            project.Database.Tables.Add("table2", tableInfo2);
            project.Database.Views.Add("view1", viewInfo1);
            project.Database.Views.Add("view2", viewInfo2);
            GeneratorEngine target = new GeneratorEngine(project); // TODO: 初始化为适当的值
          //  string test = Environment.CurrentDirectory;
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
           // string str = Assembly.GetExecutingAssembly().CodeBase;
            string baseTemplateDirectory = baseDirectory + "\\Templates\\csharp_mvc2_utf8";
            // string[] templateDirs = Directory.GetDirectories(baseTemplateDirectory);

            target.LoadTemplates(baseTemplateDirectory);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///GenorateFiles 的测试
        ///</summary>
        [TestMethod()]
        public void GenorateFilesTest()
        {
            //GeneratorEngine target = new GeneratorEngine(); // TODO: 初始化为适当的值
            //string outputDir = string.Empty; // TODO: 初始化为适当的值
            //target.GenorateFiles(outputDir);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }
    }
}
