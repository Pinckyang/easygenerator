using EasyGenerator.Studio.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace TestEasyGenerator
{
    
    
    /// <summary>
    ///这是 ProfileHelperTest 的测试类，旨在
    ///包含所有 ProfileHelperTest 单元测试
    ///</summary>
    [TestClass()]
    public class ProfileHelperTest
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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            //string file = GetProfilePathName();

            ////写入/更新键值
            //ProfileHelper.WriteValue(file, "Desktop", "Color", "Red");
            //ProfileHelper.WriteValue(file, "Desktop", "Width", "3270");

            //ProfileHelper.WriteValue(file, "Toolbar", "Items", "Save,Delete,Open");
            //ProfileHelper.WriteValue(file, "Toolbar", "Dock", "True");

            //写入一批键值
            //ProfileHelper.WriteItems(file, "Menu", "File=文件\0View=视图\0Edit=编辑");

            ////获取文件中所有的节点
            //string[] sections = ProfileHelper.GetAllSectionNames(file);

            ////获取指定节点中的所有项
            //string[] items = ProfileHelper.GetAllItems(file, "Menu");

            ////获取指定节点中所有的键
            //string[] keys = ProfileHelper.GetAllItemKeys(file, "Menu");

            ////获取指定KEY的值
            //string value = ProfileHelper.GetStringValue(file, "Desktop", "color", null);

            ////删除指定的KEY
            //ProfileHelper.DeleteKey(file, "desktop", "color");

            ////删除指定的节点
            //ProfileHelper.DeleteSection(file, "desktop");

            ////清空指定的节点
            //ProfileHelper.EmptySection(file, "toolbar");
        }

        private static string GetProfilePathName()
        {
            string test = Environment.CurrentDirectory;
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string str = Assembly.GetExecutingAssembly().CodeBase;
            string file = baseDirectory + "\\TestIni.ini";
            return file;
        }
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///WriteValue 的测试
        ///</summary>
        [TestMethod()]
        public void WriteValueTest()
        {
            string file = GetProfilePathName();

            //写入/更新键值
            bool actual1=ProfileHelper.WriteValue(file, "Desktop", "Color", "Red");
            Assert.AreEqual(true, actual1);

            bool actual2 = ProfileHelper.WriteValue(file, "Desktop", "Width", "3270");
            Assert.AreEqual(true, actual2);

            bool actual3=ProfileHelper.WriteValue(file, "Toolbar", "Items", "Save,Delete,Open");
            Assert.AreEqual(true, actual3);

            bool actual4 = ProfileHelper.WriteValue(file, "Toolbar", "Dock", "True");
            Assert.AreEqual(true, actual4);

        }

        /// <summary>
        ///WriteKey 的测试
        ///</summary>
        [TestMethod()]
        public void WriteKeysTest()
        {
            string file = GetProfilePathName();
            string section = "window"; 
            string key = "size"; 
            string value = "100";

            ProfileHelper.WriteKey(section, key, value, file);
            string actual=ProfileHelper.ReadKey(section,key,file);
            Assert.AreEqual("100", actual);

        }

        /// <summary>
        ///WriteItems 的测试
        ///</summary>
        [TestMethod()]
        public void WriteItemsTest()
        {
            string file = GetProfilePathName();
            bool actual=ProfileHelper.WriteItems(file, "Menu", "File=文件\0View=视图\0Edit=编辑");
            Assert.AreEqual(true, actual);

            string actualFile = ProfileHelper.ReadKey("Menu", "File", file);
            Assert.AreEqual("文件", actualFile);
            string actualView = ProfileHelper.ReadKey("Menu", "View", file);
            Assert.AreEqual("视图", actualView);
            string actualEdit = ProfileHelper.ReadKey("Menu", "Edit", file);
            Assert.AreEqual("编辑", actualEdit);
            
        }

        /// <summary>
        ///ReadKey 的测试
        ///</summary>
        [TestMethod()]
        public void ReadKeyTest()
        {
            //string section = string.Empty; // TODO: 初始化为适当的值
            //string keys = string.Empty; // TODO: 初始化为适当的值
            //string filePath = string.Empty; // TODO: 初始化为适当的值
            //string expected = string.Empty; // TODO: 初始化为适当的值
            //string actual;
            //actual = ProfileHelper.ReadKey(section, keys, filePath);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ReadAllKeys 的测试
        ///</summary>
        [TestMethod()]
        public void ReadAllKeysTest()
        {
            //string section = string.Empty; // TODO: 初始化为适当的值
            //string filePath = string.Empty; // TODO: 初始化为适当的值
            //string[] expected = null; // TODO: 初始化为适当的值
            //string[] actual;
            //actual = ProfileHelper.ReadAllKeys(section, filePath);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetStringValue 的测试
        ///</summary>
        [TestMethod()]
        public void GetStringValueTest()
        {
            //string iniFile = string.Empty; // TODO: 初始化为适当的值
            //string section = string.Empty; // TODO: 初始化为适当的值
            //string key = string.Empty; // TODO: 初始化为适当的值
            //string defaultValue = string.Empty; // TODO: 初始化为适当的值
            //string expected = string.Empty; // TODO: 初始化为适当的值
            //string actual;
            //actual = ProfileHelper.GetStringValue(iniFile, section, key, defaultValue);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAllSectionNames 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllSectionNamesTest()
        {
        //    string iniFile = string.Empty; // TODO: 初始化为适当的值
        //    string[] expected = null; // TODO: 初始化为适当的值
        //    string[] actual;
        //    actual = ProfileHelper.GetAllSectionNames(iniFile);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAllItems 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllItemsTest()
        {
            //string iniFile = string.Empty; // TODO: 初始化为适当的值
            //string section = string.Empty; // TODO: 初始化为适当的值
            //string[] expected = null; // TODO: 初始化为适当的值
            //string[] actual;
            //actual = ProfileHelper.GetAllItems(iniFile, section);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAllItemKeys 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllItemKeysTest()
        {
            //string iniFile = string.Empty; // TODO: 初始化为适当的值
            //string section = string.Empty; // TODO: 初始化为适当的值
            //string[] expected = null; // TODO: 初始化为适当的值
            //string[] actual;
            //actual = ProfileHelper.GetAllItemKeys(iniFile, section);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///EmptySection 的测试
        ///</summary>
        [TestMethod()]
        public void EmptySectionTest()
        {
            //string iniFile = string.Empty; // TODO: 初始化为适当的值
            //string section = string.Empty; // TODO: 初始化为适当的值
            //bool expected = false; // TODO: 初始化为适当的值
            //bool actual;
            //actual = ProfileHelper.EmptySection(iniFile, section);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteSection 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteSectionTest()
        {
            //string iniFile = string.Empty; // TODO: 初始化为适当的值
            //string section = string.Empty; // TODO: 初始化为适当的值
            //bool expected = false; // TODO: 初始化为适当的值
            //bool actual;
            //actual = ProfileHelper.DeleteSection(iniFile, section);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteKey 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteKeyTest()
        {
            //string iniFile = string.Empty; // TODO: 初始化为适当的值
            //string section = string.Empty; // TODO: 初始化为适当的值
            //string key = string.Empty; // TODO: 初始化为适当的值
            //bool expected = false; // TODO: 初始化为适当的值
            //bool actual;
            //actual = ProfileHelper.DeleteKey(iniFile, section, key);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
