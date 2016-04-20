using EasyGenerator.Studio.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EasyGenerator.Studio.Utils;
using System.Xml.Serialization;
using System.IO;

namespace TestEasyGenerator
{
    
    
    /// <summary>
    ///这是 DatabaseTest 的测试类，旨在
    ///包含所有 DatabaseTest 单元测试
    ///</summary>
    [TestClass()]
    public class DatabaseTest
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
        ///Connection 的测试
        ///</summary>
        [TestMethod()]
        public void ConnectionTest()
        {
            Database target = new Database();
            target.DatabaseType = DatabaseType.SQLServer2000;
            
            Connection expected = new Connection();
            target.Connection = expected;
            expected.DataSource = "(local)";
            expected.InitialCatalog = "dbo";
            expected.IntegratedSecurity = false;
            expected.Password = "111";
            expected.UserID = "sa";

            
            TableInfo tableInfo=new TableInfo() { Caption="Table1",Name="Table1", Schema="dbo"};
            ColumnInfo columnInfo = new PrimaryColumnInfo();
            columnInfo.Name = "column1";
            columnInfo.IsPrimaryKey = true;
            columnInfo.IsIdentity = true;
            columnInfo.IsRequire = true;
            columnInfo.Length = 8;
            columnInfo.Precision = 0;
            columnInfo.SqlType = SqlType.Int;
            columnInfo.Visible = true;
            columnInfo.DBControlType = DBControlType.DBText;
            tableInfo.Columns.Add("column1", columnInfo);
            target.Tables.Add("Table1",tableInfo );

            XmlSerializer xmlSerializer = new XmlSerializer(target.GetType());
            StringWriter writer = new StringWriter();
            xmlSerializer.Serialize(writer, target);

            StringReader reader=new StringReader(writer.ToString());
            
            Database actual=(Database)xmlSerializer.Deserialize(reader);
            Assert.AreEqual(actual.DatabaseType,DatabaseType.SQLServer2000);
            Assert.AreEqual(actual.Connection.DataSource, "(local)");
            Assert.AreEqual(actual.Connection.InitialCatalog, "dbo");
            Assert.AreEqual(actual.Connection.IntegratedSecurity, false);
            Assert.AreEqual(actual.Connection.Password, "111");
            Assert.AreEqual(actual.Connection.UserID,"sa");
        }



        /// <summary>
        ///DatabaseType 的测试
        ///</summary>
        [TestMethod()]
        public void DatabaseTypeTest()
        {
            Database target = new Database(); 
            DatabaseType expected = new DatabaseType(); 
            DatabaseType actual;
            target.DatabaseType = expected;
            actual = target.DatabaseType;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Tables 的测试
        ///</summary>
        [TestMethod()]
        public void TablesTest()
        {
            Database target = new Database(); 
            ContextObjectDictionary<string, TableInfo> expected = null; 
            ContextObjectDictionary<string, TableInfo> actual;
            target.Tables = expected;
            actual = target.Tables;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Views 的测试
        ///</summary>
        [TestMethod()]
        public void ViewsTest()
        {
            Database target = new Database();
            ContextObjectDictionary<string, ViewInfo> expected = null; 
            ContextObjectDictionary<string, ViewInfo> actual;
            target.Views = expected;
            actual = target.Views;
            Assert.AreEqual(expected, actual);
        }
    }
}
