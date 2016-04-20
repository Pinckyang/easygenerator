/*
 * Copyright ?2005-2006 Danilo Mendez <danilo.mendez@kontac.net>
 * Adolfo Socorro <ajs@esolutionspr.com>
 * www.kontac.net 
 * All rights reserved.
 * Released under both BSD license and Lesser GPL library license.
 * Whenever there is any discrepancy between the two licenses,
 * the BSD license will take precedence.
 */

using System;
using System.Collections.Generic;
using System.Text;
using EasyGenerator.Studio.DbHelper.Info;
using System.Data;
using System.Collections;
using EasyGenerator.Studio.Model;

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

            //netDataTypes.Add(SqlType.AnsiText, "System.String");
            //netDataTypes.Add(SqlType.AnsiChar, "System.String");
            //netDataTypes.Add(SqlType.AnsiVarChar, "System.String");
            //netDataTypes.Add(SqlType.AnsiVarCharMax, "System.String");
            netDataTypes.Add(SqlType.Byte, "System.Byte");
            //netDataTypes.Add(SqlType.Binary, "System.Byte[]");
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
                TableInfo tableEntity = new TableInfo();
                tableEntity.Name = table;
                ArrayList columnlist = (ArrayList)entities[table];
                ColumnInfo[] columns = (ColumnInfo[])columnlist.ToArray(typeof(ColumnInfo));

                foreach (ColumnInfo column in columns)
                {
                    //column.Owner = tableEntity;
                    if (column.SqlType == SqlType.DateTime)
                    {
                        column.DBControlType = DBControlType.DBDatePicker;
                    }else if(column.SqlType==  SqlType.NText)
                    {
                        column.DBControlType = DBControlType.DBRichEdit;
                        column.DBControl.ColSpan = 2;
                    }

                   // column.Owner = tableEntity;
                    tableEntity.Columns.Add(column.Name,column);
                }



                ArrayList keylist = (ArrayList)keyEntities[table];
                string[] keys = (string[])keylist.ToArray(typeof(string));

                foreach (string key in keys)
                {
                    tableEntity.Columns[key] = new PrimaryColumnInfo(tableEntity.Columns[key]);//.IsPrimaryKey = true;
                }

                ArrayList referencelist = (ArrayList)referenceEntities[table];
                if (referencelist != null)
                {
                    ReferenceInfo[] references = (ReferenceInfo[])referencelist.ToArray(typeof(ReferenceInfo));

                    foreach (ReferenceInfo reference in references)
                    {
                        tableEntity.Columns[reference.ColumnName].References.Add(reference.Name, reference);
                        if (reference is ForeignKeyReferenceInfo)
                        {
                            tableEntity.Columns[reference.ColumnName].IsForeignKey = true;

                            if (reference.ReferenceTableName == reference.TableName)
                            {
                                tableEntity.DBViewControlType = DBViewControlType.DBTreeView;
                                DBTreeView treeView=tableEntity.DBViewControl as DBTreeView;
                                treeView.ParentField = reference.ColumnName;
                                treeView.KeyField = reference.ReferenceColumnName;
                            }
                        }
                    }
                }

                project.Database.Tables.Add(table, tableEntity);
            }

            foreach (string view in views)
            {
                ViewInfo viewEntity = new ViewInfo();
                viewEntity.Name = view;
                ArrayList list = (ArrayList)entities[view];
                ColumnInfo[] columns= (ColumnInfo[])list.ToArray(typeof(ColumnInfo));

                foreach (ColumnInfo column in columns)
                {
                    //column.Owner = viewEntity;
                    viewEntity.Columns.Add(column.Name,column);
                }
                project.Database.Views.Add(view, viewEntity);
            }

        }
        public abstract string[] GetAllTables();
        public abstract string[] GetAllViews();
        ///// <summary>
        ///// Gets a list of all essential tables from the database.
        ///// </summary>
        ///// <returns>An array of strings containing view names.</returns>
        //public abstract string[] GetAllTables();

        ///// <summary>
        ///// Gets a list of all essential views from the database.
        ///// </summary>
        ///// <returns>An array of strings containing table names.</returns>
        //public abstract string[] GetAllViews();

        /// <summary>
        /// Gets a list of all columns from the specified table.
        /// </summary>
        /// <param name="tableName">The name of the table to extract columns information from.</param>
        /// <returns>An array of <see cref="ColumnProperties"/> objects describing all columns.</returns>
        public abstract Hashtable GetEntites();

        /// <summary>
        /// Get all constraint properties from the specified table.
        /// </summary>
        /// <param name="tableName">The name of the table to extract constraint from.</param>
        /// <returns>An array of ConstraintInfo objects describing all the constraints.</returns>
        public abstract Hashtable GetConstraints();

        /// <summary>
        /// Get all keys from the specified table.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
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
