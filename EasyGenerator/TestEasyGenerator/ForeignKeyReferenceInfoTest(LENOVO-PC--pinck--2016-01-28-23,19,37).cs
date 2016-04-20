using EasyGenerator.Studio.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Serialization;
using System.IO;

namespace TestEasyGenerator
{
    
    
    /// <summary>
    ///这是 ForeignKeyReferenceInfoTest 的测试类，旨在
    ///包含所有 ForeignKeyReferenceInfoTest 单元测试
    ///</summary>
    [TestClass()]
    public class ForeignKeyReferenceInfoTest
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
        ///ForeignKeyReferenceInfo 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ForeignKeyReferenceInfoConstructorTest()
        {
            ForeignKeyReferenceInfo target = new ForeignKeyReferenceInfo();
            target.ColumnName = "column1";
            target.Name = "Reference1";
            target.ReferenceColumnName = "ReferenceColumn1";
            target.ReferenceTableName = "ReferenceTable1";

            XmlSerializer xmlSerializer = new XmlSerializer(target.GetType());
            StringWriter writer = new StringWriter();
            xmlSerializer.Serialize(writer, target);

            StringReader reader = new StringReader(writer.ToString());

            ForeignKeyReferenceInfo actual = (ForeignKeyReferenceInfo)xmlSerializer.Deserialize(reader);
            Assert.AreEqual("column1",actual.ColumnName);

        }
    }
}
