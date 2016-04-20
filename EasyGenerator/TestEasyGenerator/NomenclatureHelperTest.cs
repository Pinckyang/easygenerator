using EasyGenerator.Studio.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestEasyGenerator
{
    
    
    /// <summary>
    ///这是 NomenclatureHelperTest 的测试类，旨在
    ///包含所有 NomenclatureHelperTest 单元测试
    ///</summary>
    [TestClass()]
    public class NomenclatureHelperTest
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
        ///ConvertToPascalCase 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToPascalCaseTest()
        {
            string srcCase1 = "test_in_case"; 
            string actual1 = NomenclatureHelper.ConvertToPascalCase(srcCase1);
            Assert.AreEqual("TestInCase", actual1);

            string srcCase2 = "TestInCase";
            string actual2 = NomenclatureHelper.ConvertToPascalCase(srcCase2);
            Assert.AreEqual("TestInCase", actual2);

        }

        /// <summary>
        ///ConvertToCamelCase 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToCamelCaseTest()
        {
            string srcCase1 = "test_in_case";
            string actual1 = NomenclatureHelper.ConvertToCamelCase(srcCase1);
            Assert.AreEqual("testInCase", actual1);

            string srcCase2 = "TestInCase";
            string actual2 = NomenclatureHelper.ConvertToCamelCase(srcCase2);
            Assert.AreEqual("testInCase", actual2);

        }

        /// <summary>
        ///ConvertToTitleCase 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToTitleCaseTest()
        {
            //string item = string.Empty; // TODO: 初始化为适当的值
            //string expected = string.Empty; // TODO: 初始化为适当的值
            //string actual;
            //actual = NomenclatureHelper.ConvertToTitleCase(item);
            //Assert.AreEqual(expected, actual);

        }
    }
}
