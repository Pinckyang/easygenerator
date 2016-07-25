using System;
using System.Collections.Generic;
using System.Text;
using EasyGenerator.Studio.DbHelper.Info;
using System.Data;
using System.Collections;
using EasyGenerator.Studio.Model;
using EasyGenerator.Studio.Model.DB;

namespace EasyGenerator.Studio.DbHelper
{
    /// <summary>
    /// An abstract class that declares a set of methods for database schema extraction.
    /// </summary>
    public abstract class OLESchemaExtractor
    {
        protected Driver driver;
        protected Hashtable netDataTypes;
        protected Project project;


        public OLESchemaExtractor(Driver driver,Project project)
        {
            this.driver = driver;
            this.project = project;

            netDataTypes = new Hashtable();

            netDataTypes.Add(SqlType.Byte, "System.Byte");
            netDataTypes.Add(SqlType.Boolean, "System.Boolean");
            netDataTypes.Add(SqlType.Char, "System.String");
            netDataTypes.Add(SqlType.DateTime, "System.DateTime");
            netDataTypes.Add(SqlType.Decimal, "System.Decimal");
            netDataTypes.Add(SqlType.Double, "System.Double");
            netDataTypes.Add(SqlType.Float, "System.Double");
            //netDataTypes.Add(SqlType.GUID, "System.Guid");
            netDataTypes.Add(SqlType.Int16, "System.Int16");
            netDataTypes.Add(SqlType.Int32, "System.Int32");
            netDataTypes.Add(SqlType.Int64, "System.Int64");
            //netDataTypes.Add(SqlType.Image, "System.Byte[]");
            netDataTypes.Add(SqlType.Money, "System.Decimal");
            netDataTypes.Add(SqlType.SmallDateTime, "System.DateTime");
            netDataTypes.Add(SqlType.SmallMoney, "System.Decimal");
            netDataTypes.Add(SqlType.Text, "System.String");
            //netDataTypes.Add(SqlType.TimeStamp, "System.DateTime");
            netDataTypes.Add(SqlType.Unknown, "System.String");
            //netDataTypes.Add(SqlType.VarBinary, "System.Byte[]");
            //netDataTypes.Add(SqlType.VarBinaryMax, "System.Byte[]");
            netDataTypes.Add(SqlType.VarChar, "System.String");
            netDataTypes.Add(SqlType.VarCharMax, "System.String");
            string [] tables=this.GetAllTables();
            string[] views = this.GetAllViews();
            Hashtable entities= this.GetEntites();
            Hashtable keyEntities = this.GetAllPrimaryKeys();
            Hashtable referenceEntities = this.GetConstraints();

            foreach (string table in tables)
            {
                TableInfo tableEntity = new TableInfo(null);
                tableEntity.Name = table;
                ArrayList columnlist = (ArrayList)entities[table];
                ColumnInfo[] columns = (ColumnInfo[])columnlist.ToArray(typeof(ColumnInfo));

                foreach (ColumnInfo column in columns)
                {
                    //TODO:
                    //if (column.SqlType == SqlType.DateTime)
                    //{
                    //    column.DBControlType = DBControlType.DBDatePicker;
                    //}else if(column.SqlType==  SqlType.NText)
                    //{
                    //    column.DBControlType = DBControlType.DBRichEdit;
                    //    column.DBControl.ColSpan = 2;
                    //}
                    //tableEntity.Columns.Add(column);
                }



                ArrayList keylist = (ArrayList)keyEntities[table];
                string[] keys = (string[])keylist.ToArray(typeof(string));

                foreach (string key in keys)
                {
                    int index = tableEntity.Columns.FindIndex(0, tableEntity.Columns.Count, e => e.Name == key);
                    ColumnInfo column=tableEntity.Columns.Find(e => e.Name == key);
                    tableEntity.Columns.RemoveAll(e=>e.Name==key);
                    tableEntity.Columns.Insert(index, new PrimaryColumnInfo(column));//.IsPrimaryKey = true;
                }

                ArrayList referencelist = (ArrayList)referenceEntities[table];
                if (referencelist != null)
                {
                    ReferenceInfo[] references = (ReferenceInfo[])referencelist.ToArray(typeof(ReferenceInfo));

                    foreach (ReferenceInfo reference in references)
                    {
                        //TODO:
                        //tableEntity.Columns.Find(e => e.Name == reference.ColumnName).Referencing.Add(reference);
                        //if (reference is ForeignKeyReferenceInfo)
                        //{
                        //    tableEntity.Columns.Find(e => e.Name == reference.ColumnName).IsForeignKey = true;

                        //    if (reference.ReferenceTableName == reference.TableName)
                        //    {
                        //        tableEntity.DBViewControlType = DBViewControlType.DBTreeView;
                        //        DBTreeView treeView=tableEntity.DBViewControl as DBTreeView;
                        //        treeView.ParentField = reference.ColumnName;
                        //        treeView.KeyField = reference.ReferenceColumnName;
                        //    }
                        //}
                    }
                }

                project.Database.Tables.Add(tableEntity);
            }

            foreach (string view in views)
            {
                ViewInfo viewEntity = new ViewInfo(null);
                viewEntity.Name = view;
                ArrayList list = (ArrayList)entities[view];
                ColumnInfo[] columns= (ColumnInfo[])list.ToArray(typeof(ColumnInfo));

                foreach (ColumnInfo column in columns)
                {
                    viewEntity.Columns.Add(column);
                }
                project.Database.Views.Add(viewEntity);
            }

        }
        public abstract string[] GetAllTables();
        public abstract string[] GetAllViews();

        public abstract Hashtable GetEntites();
        public abstract Hashtable GetConstraints();
        public abstract Hashtable GetAllPrimaryKeys();

        protected virtual IDbCommand CreateCommand()
        {
            IDbConnection connection = this.driver.CreateConnection();
            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandTimeout = 0;
            return cmd;
        }
    }
}
