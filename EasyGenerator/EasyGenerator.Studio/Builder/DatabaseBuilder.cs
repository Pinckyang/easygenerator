using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using EasyGenerator.Studio.DbHelper;
using EasyGenerator.Studio.DbHelper.Info;
using EasyGenerator.Studio.Model;

namespace EasyGenerator.Studio.Builder
{
    [Serializable]
    public class DatabaseBuilder
    {
        private Project project;
        private Domain domain;
        private Driver driver;
       // private IDictionary<string, LibraryInfo> libraries;

        #region Properties
        public Project Project
        {
            get { return project; }
            set { project = value; }
        }

        public Domain Domain
        {
            get { return domain; }
            set { domain = value; }
        }
        public Driver Driver
        {
            get { return driver; }
            set { driver = value; }
        }
        //public IDictionary<string, LibraryInfo> Libraries
        //{
        //    get { return libraries; }
        //}

        #endregion

        //public ProjectBuilder()
        //{
        //    this.libraries = new Dictionary<string, LibraryInfo>();
        //}

        public DatabaseBuilder(Driver driver)
        {
            this.domain =new Domain(driver.ConnectionInfo);
            this.driver = driver;
           // this.BuildTables();
            //this.BuildViews();
        }

        //public Project(Domain domain)
        //{
        //    this.domain = domain;
        //    this.libraries = new Dictionary<string, LibraryInfo>();

        //}

        //public ProjectBuilder(SerializationInfo Info, StreamingContext ctxt)
        //{
        //    this.fileName = (string)Info.GetValue("fileName", typeof(string));
        //    this.domain = (Domain)Info.GetValue("domain", typeof(Domain));
        //    this.libraries = (IDictionary<string, LibraryInfo>)Info.GetValue("libraries", typeof(IDictionary<string, LibraryInfo>));
        //}

        ///// <summary>
        ///// 导出视图
        ///// </summary>
        //private void BuildViews()
        //{
        //    string [] views = this.driver.Extractor.GetAllViews();
        //    for (int j = 0; j < views.Length; j++)
        //    {
        //        BuildEntityInfo(views[j], false);
        //    }
        //}

        ///// <summary>
        ///// 导出数据库表
        ///// </summary>
        //private void BuildTables()
        //{
        //    string [] tables = this.driver.Extractor.GetAllTables();
            
        //    for (int i = 0; i < tables.Length; i++)
        //    {
        //        string tableName = tables[i];
        //        BuildEntityInfo(tableName, true);
        //        BuildConstraints(tableName);
        //    }
        //}

        ///// <summary>
        ///// 导出关联
        ///// </summary>
        //private void BuildConstraints(string tableName)
        //{
        //    Table childTable = this.domain.ConnectionInfo.FindTable(tableName);
        //    if (childTable != null)
        //    {
        //        OLESchemaExtractor extractor = this.driver.Extractor;

        //        ConstraintInfo[] constraintsInfo = extractor.GetConstraints(tableName);
        //        foreach (ConstraintInfo constraint in constraintsInfo)
        //        {
        //            Table parentTable = this.domain.ConnectionInfo.FindTable(constraint.PrimaryKeyTable);
        //            if (parentTable != null)
        //            {
        //                // ConstraintInfo.PrimaryKeyTableColumns and ConstraintInfo.Columns are RelatedImageListAttribute 1-1
        //                EasyGenerator.Model.Reference reference = new EasyGenerator.Model.Reference(constraint.Name, parentTable, childTable);
        //                reference.OnDeleteCascade = constraint.OnDeleteCascade;
        //                reference.OnUpdateCascade = constraint.OnUpdateCascade;

        //                for (int i = 0; i < constraint.PrimaryKeyTableColumns.Length; i++)
        //                {
        //                    Column parentColumn = parentTable.FindColumn(constraint.PrimaryKeyTableColumns[i]);
        //                    Column childColumn = childTable.FindColumn(constraint.Columns[i]);
        //                    reference.AddNewJoin(parentColumn, childColumn);
        //                }
        //                parentTable.AddOutReference(reference);
        //                childTable.AddInReference(reference);
        //            }
        //        }
        //    }

        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="tableName"></param>
        ///// <param name="isTable"></param>
        //private void BuildEntityInfo(string tableName, bool isTable)
        //{
        //    try
        //    {
        //        Table table = new Table(this.domain, tableName);
        //        table.IsTable = isTable;

        //        xColumnInfo[] columnsInfo = this.driver.Extractor.GetColumns(tableName);
        //        foreach (xColumnInfo columnInfo in columnsInfo)
        //        {
        //            Column column = new Column(columnInfo.Name, table);
        //            column.SqlType = columnInfo.SqlType;

        //            column.NetDataType = columnInfo.NetDataType;
        //            column.Length = columnInfo.Size;
        //            column.OriginalSQLType = columnInfo.OriginalSQLType;
        //            column.IsIdentity = columnInfo.AutoIncrement;
        //            column.IsRequired = !columnInfo.AllowNull;
        //            column.Scale = columnInfo.Scale;
        //            table.AddColumn(column);
        //        }

        //        this.domain.ConnectionInfo.AddTable(table);

        //        KeyInfo[] keysInfo = this.driver.Extractor.GetKeys(tableName);
        //        foreach (KeyInfo keyInfo in keysInfo)
        //        {
        //            //Bug Fix
        //            if (keyInfo.TableName == table.Name)
        //            {
        //                Column keyColumn = table.FindColumn(keyInfo.ColumnName);
        //                if (keyColumn != null)
        //                {
        //                    keyColumn.IsPrimaryKey = true;
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #region ISerializable Members

        public void GetObjectData(SerializationInfo Info, StreamingContext context)
        {
            //Info.AddValue("fileName", this.fileName);
            //Info.AddValue("domain", this.domain);
            //Info.AddValue("libraries", this.libraries);
        }

        #endregion

        //public void AddLibrary(LibraryInfo library)
        //{
        //    this.libraries.Add(library.AssemblyQualifiedName, library);
        //}

        //public bool RemoveLibrary(LibraryInfo library)
        //{
        //    return this.libraries.Remove(library.AssemblyQualifiedName);
        //}


       






    }
}
