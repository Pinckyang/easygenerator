//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Collections;
//using System.Data;
//using System.Data.OleDb;
//using EasyGenerator.Studio.DbHelper.Info;
//using EasyGenerator.Model;
//using System.Collections.Specialized;

//namespace EasyGenerator.Studio.DbHelper.Access
//{
//    internal class AccessSchemaExtractor : OLESchemaExtractor
//    {
//        HybridDictionary sqlTypes;
//        IDbConnection connection ;
//        public AccessSchemaExtractor(Driver driver)
//            :base(driver)
//        {
//            sqlTypes = new HybridDictionary();
//            sqlTypes.Add(typeof(System.Boolean), SqlType.Boolean);
//            sqlTypes.Add(typeof(System.Byte), SqlType.Byte);
//            sqlTypes.Add(typeof(System.DateTime), SqlType.DateTime);
//            sqlTypes.Add(typeof(System.Decimal), SqlType.Decimal);
//            sqlTypes.Add(typeof(System.Double), SqlType.Double);
//            sqlTypes.Add(typeof(System.Guid), SqlType.GUID);
//            sqlTypes.Add(typeof(System.Int16), SqlType.Int16);
//            sqlTypes.Add(typeof(System.Int32), SqlType.Int32);
//            sqlTypes.Add(typeof(System.String), SqlType.VarChar);
//            sqlTypes.Add(typeof(System.Byte[]), SqlType.VarBinary);

//            sqlTypes.Add(OleDbType.Binary, SqlType.Binary);
//            sqlTypes.Add(OleDbType.Boolean, SqlType.Boolean);
//            sqlTypes.Add(OleDbType.TinyInt, SqlType.Byte);
//            sqlTypes.Add(OleDbType.Date, SqlType.DateTime);
//            sqlTypes.Add(OleDbType.Numeric, SqlType.Decimal);
//            sqlTypes.Add(OleDbType.Decimal, SqlType.Decimal);
//            sqlTypes.Add(OleDbType.Double, SqlType.Double);
//            sqlTypes.Add(OleDbType.Guid, SqlType.GUID);
//            sqlTypes.Add(OleDbType.SmallInt, SqlType.Int16);
//            sqlTypes.Add(OleDbType.Integer, SqlType.Int32);
//            sqlTypes.Add(OleDbType.VarBinary, SqlType.VarBinary);
//            sqlTypes.Add(OleDbType.VarChar, SqlType.VarChar);
//            sqlTypes.Add(OleDbType.WChar, SqlType.VarChar);

//            connection = driver.CreateConnection();
           
//        }

//        ~AccessSchemaExtractor()
//        {
//            if (connection != null && connection.State != ConnectionState.Closed )
//            {
//                try
//                {
//                    //connection.Close();
//                }
//                finally
//                {
//                    ;
//                }
//            }
//        }

//        public override string[] GetAllTables()
//        {
//            ArrayList allTables = new ArrayList();
//            try
//            {
//                if (connection.State == ConnectionState.Closed )
//                {
//                    connection.Open();
//                }

//                DataTable schema = ((OleDbConnection)connection).GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[0]);

//                DataColumn tableTypeColumn = schema.Columns["TABLE_TYPE"];
//                DataColumn tableNameColumn = schema.Columns["TABLE_NAME"];

//                foreach (DataRow schemaRow in schema.Rows)
//                {
//                    if (string.Compare(schemaRow[tableTypeColumn].ToString(), "TABLE") == 0)
//                    {
//                        string tbname = schemaRow[tableNameColumn].ToString();
//                        allTables.Add(tbname);
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                throw new Exception("Couldn't get the tables to extract model.", e);
//            }
//            return (string[])allTables.ToArray(typeof(string));
//        }

//        public override string[] GetAllViews()
//        {
//            ArrayList allViews = new ArrayList();

//            try
//            {
//                if (connection.State == ConnectionState.Closed)
//                {
//                    connection.Open();
//                }

//                DataTable schema = ((OleDbConnection)connection).GetOleDbSchemaTable(OleDbSchemaGuid.Views, new object[0]);
//                DataColumn tableTypeColumn = schema.Columns["TABLE_TYPE"];
//                DataColumn tableNameColumn = schema.Columns["TABLE_NAME"];

//                foreach (DataRow schemaRow in schema.Rows)
//                {
//                    string viewName = schemaRow[tableNameColumn].ToString();
//                    allViews.Add(viewName);
//                }
//            }
//            catch (Exception e)
//            {
//                throw new Exception("Couldn't get the views to extract model.", e);
//            }
//            return (string[])allViews.ToArray(typeof(string));
//        }

//        public override EasyGenerator.Studio.DbHelper.Info.xColumnInfo[] GetColumns(string tableName)
//        {
//            ArrayList allColumns = new ArrayList();
//            Hashtable columnHashtable = new Hashtable();

//            try
//            {
//                if (connection.State == ConnectionState.Closed)
//                {
//                    connection.Open();
//                }

//                DataTable schema = ((OleDbConnection)connection).GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tableName });
//                DataColumn ordinalPosition = schema.Columns["ORDINAL_POSITION"];
//                DataColumn dataType = schema.Columns["DATA_TYPE"];
//                DataColumn column = schema.Columns["COLUMN_NAME"];
//                DataColumn numericPrecisionColumn = schema.Columns["NUMERIC_PRECISION"];
//                DataColumn allowDBNull = schema.Columns["IS_NULLABLE"];
//                DataColumn columnSize = schema.Columns["CHARACTER_MAXIMUM_LENGTH"];
//                DataColumn numericScale = schema.Columns["NUMERIC_SCALE"];

//                schema.DefaultView.Sort = ordinalPosition.ColumnName;

//                foreach (DataRowView schemaRow in schema.DefaultView)
//                {
//                    xColumnInfo info = new xColumnInfo();

//                    info.Name = schemaRow[column.Ordinal].ToString();
//                    info.AllowNull = (bool)schemaRow[allowDBNull.Ordinal];
//                    OleDbType colType = (OleDbType)schemaRow[dataType.Ordinal];

//                    info.OriginalSQLType = colType.ToString();

//                    if (sqlTypes[colType] != null)
//                        info.SqlType = (SqlType)sqlTypes[colType];
//                    else
//                        info.SqlType = SqlType.Unknown;

//                    if (this.netDataTypes.ContainsKey(info.SqlType))
//                    {
//                        info.NetDataType = (String)this.netDataTypes[info.SqlType];
//                    }
//                    else
//                    {
//                        info.NetDataType = "unknown";
//                    }

//                    if ((info.SqlType == SqlType.VarChar)
//                       || (info.SqlType == SqlType.VarBinary)
//                       || (info.SqlType == SqlType.Binary)
//                      )
//                    {
//                        info.Size = Convert.ToInt32(schemaRow[columnSize.Ordinal]);
//                        if (info.SqlType == SqlType.VarChar)
//                        {
//                            info.SqlType = SqlType.Text;
//                            info.Size = 0;
//                        }
//                    }
//                    else if (info.SqlType == SqlType.Decimal)
//                    {
//                        info.Size = Convert.ToInt32(schemaRow[numericPrecisionColumn.Ordinal]);
//                        info.Scale = Convert.ToInt32(schemaRow[numericScale.Ordinal]);
//                    }
//                    int index = allColumns.Add(info);
//                    columnHashtable.Add(info.Name, index);
//                }

//                return (xColumnInfo[])allColumns.ToArray(typeof(xColumnInfo));
//            }
//            catch (Exception e)
//            {
//                throw new Exception("Could not extract columns (" + e.Message + ").", e);
//            }
//        }

//        public override EasyGenerator.Studio.DbHelper.Info.ConstraintInfo[] GetConstraints(string tableName)
//        {
//            try
//            {
//                ArrayList allConstraints = new ArrayList();
//                if (connection.State == ConnectionState.Closed)
//                {
//                    connection.Open();
//                }

//                DataTable schema = ((OleDbConnection)connection).GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, new object[0]);

//                DataColumn constraintName = schema.Columns["FK_NAME"];
//                DataColumn columnOrdinal = schema.Columns["ORDINAL"];
//                DataColumn childTableName = schema.Columns["FK_TABLE_NAME"];
//                DataColumn parentColumnName = schema.Columns["FK_COLUMN_NAME"];
//                DataColumn updateRule = schema.Columns["UPDATE_RULE"];
//                DataColumn deleteRule = schema.Columns["DELETE_RULE"];
//                DataColumn parentTableName = schema.Columns["PK_TABLE_NAME"];
//                DataColumn childColumnName = schema.Columns["PK_COLUMN_NAME"];

//                schema.DefaultView.Sort = constraintName + "," + columnOrdinal.ColumnName;
//                schema.DefaultView.RowFilter = childTableName.ColumnName + " = '" + tableName + "'";

//                int allConstraintsIndex;
//                HybridDictionary foreignKeyDictionary = new HybridDictionary();
//                foreach (DataRowView schemaRow in schema.DefaultView)
//                {
//                    ConstraintInfo constraintInfo;

//                    string foreignKeyName = schemaRow[constraintName.Ordinal].ToString();
//                    if (foreignKeyDictionary[foreignKeyName] == null)
//                    {
//                        constraintInfo = new ConstraintInfo();
//                        constraintInfo.Name = foreignKeyName;
//                        constraintInfo.PrimaryKeyTable = schemaRow[parentTableName.Ordinal].ToString();
//                        if (string.Compare(schemaRow[updateRule.Ordinal].ToString(), "cascade", true) == 0)
//                            constraintInfo.OnUpdateCascade = true;
//                        if (string.Compare(schemaRow[deleteRule.Ordinal].ToString(), "cascade", true) == 0)
//                            constraintInfo.OnDeleteCascade = true;
//                        constraintInfo.Columns = new string[0];
//                        constraintInfo.PrimaryKeyTableColumns = new string[0];

//                        allConstraintsIndex = allConstraints.Add(constraintInfo);
//                        foreignKeyDictionary[foreignKeyName] = constraintInfo;
//                    }
//                    else
//                    {
//                        constraintInfo = (ConstraintInfo)foreignKeyDictionary[foreignKeyName];
//                        allConstraintsIndex = -1;
//                        for (int constraintIndex = 0; constraintIndex < allConstraints.Count; constraintIndex++)
//                        {
//                            if (((ConstraintInfo)allConstraints[constraintIndex]).Name == foreignKeyName)
//                            {
//                                allConstraintsIndex = constraintIndex;
//                                break;
//                            }
//                        }
//                    }

//                    ArrayList allColInIdx = new ArrayList();
//                    allColInIdx.AddRange(constraintInfo.Columns);

//                    string foreignKeyColumnName = schemaRow[parentColumnName.Ordinal].ToString();
//                    allColInIdx.Add(foreignKeyColumnName);

//                    constraintInfo.Columns = (string[])allColInIdx.ToArray(typeof(string));

//                    allColInIdx = new ArrayList();
//                    allColInIdx.AddRange(constraintInfo.PrimaryKeyTableColumns);

//                    string primaryKeyColumnName = schemaRow[childColumnName.Ordinal].ToString();
//                    allColInIdx.Add(primaryKeyColumnName);

//                    constraintInfo.PrimaryKeyTableColumns = (string[])allColInIdx.ToArray(typeof(string));


//                    allConstraints.RemoveAt(allConstraintsIndex);
//                    allConstraints.Add(constraintInfo);
//                }

//                return (ConstraintInfo[])allConstraints.ToArray(typeof(ConstraintInfo));
//            }
//            catch (Exception e)
//            {
//                throw new Exception("Error get constraint (" + e.Message + ").", e);
//            }
//        }

//        public override EasyGenerator.Studio.Database.Info.KeyInfo[] GetKeys(string tableName)
//        {
//            return new EasyGenerator.Studio.Database.Info.KeyInfo[0];
//        }
//    }
//}
