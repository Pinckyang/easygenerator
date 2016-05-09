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
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using EasyGenerator.Studio.DbHelper.Info;
using EasyGenerator.Studio.Model;
using EasyGenerator.Studio.Model.Db;

namespace EasyGenerator.Studio.DbHelper.MSSQL
{
    public class MSSQL2000SchemaExtractor : OLESchemaExtractor
    {
        Hashtable sqlTypes;
        //Hashtable allColumns;
        //Hashtable allLookup;
        //ArrayList allKeys;
        //private Database database;
        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="driver">Driver to which this instance will be bound.</param>
        /// <param name="connection">Connection through which this instance should operate.</param>
        public MSSQL2000SchemaExtractor(Driver driver, Project project)
            : base(driver, project)
        {
            sqlTypes = new Hashtable(30);
            sqlTypes.Add("bit", SqlType.Boolean);
            //sqlTypes.Add("char", SqlType.AnsiChar);
            sqlTypes.Add("nvarchar", SqlType.VarChar);
            sqlTypes.Add("nvarchar(max)", SqlType.VarCharMax);
           // sqlTypes.Add("text", SqlType.AnsiText);
            sqlTypes.Add("sysname", SqlType.VarChar);
            sqlTypes.Add("ntext", SqlType.Text);
            sqlTypes.Add("nchar", SqlType.Char);
           // sqlTypes.Add("varchar", SqlType.AnsiVarChar);
           // sqlTypes.Add("varchar(max)", SqlType.AnsiVarCharMax);
           // sqlTypes.Add("binary", SqlType.Binary);
           // sqlTypes.Add("varbinary", SqlType.VarBinary);
            sqlTypes.Add("datetime", SqlType.DateTime);
            sqlTypes.Add("decimal", SqlType.Decimal);
            sqlTypes.Add("numeric", SqlType.Decimal);
            sqlTypes.Add("float", SqlType.Double);
            sqlTypes.Add("real", SqlType.Float);
            sqlTypes.Add("smalldatetime", SqlType.SmallDateTime);
            sqlTypes.Add("tinyint", SqlType.Byte); 
            sqlTypes.Add("smallint", SqlType.Int16);
            sqlTypes.Add("int", SqlType.Int32);
            sqlTypes.Add("int identity", SqlType.Int32);
           // sqlTypes.Add("uniqueidentifier", SqlType.GUID);
            sqlTypes.Add("bigint", SqlType.Int64);
           // sqlTypes.Add("image", SqlType.Image);
            //sqlTypes.Add("varbinary(max)", SqlType.VarBinaryMax);
            sqlTypes.Add("money", SqlType.Money);
            sqlTypes.Add("smallmoney", SqlType.SmallMoney);
           // sqlTypes.Add("timestamp", SqlType.TimeStamp);
            sqlTypes.Add("unknown", SqlType.Unknown);

            project.Name = driver.ConnectionInfo.Database;
            project.Caption= driver.ConnectionInfo.Database;
            project.Database.Connection.DataSource = driver.ConnectionInfo.Host;
            project.Database.Connection.InitialCatalog = driver.ConnectionInfo.Database;
            project.Database.Connection.IntegratedSecurity = true;
            project.Database.Connection.UserID = driver.ConnectionInfo.User;
            project.Database.Connection.Password = driver.ConnectionInfo.Password;
        }

        public override string[] GetAllTables()
        {
            ArrayList allTables = new ArrayList();

            IDbCommand cmd = CreateCommand();
            cmd.Connection.Open();

            cmd.CommandText = "SELECT TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,TABLE_TYPE FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_SCHEMA,TABLE_NAME";
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string owner = reader.GetString(1);
                    if (owner == "INFORMATION_SCHEMA" || owner == "sys")
                    {
                        continue;
                    }
                    allTables.Add(reader.GetString(2));
                }
            }

            return (string[])allTables.ToArray(typeof(string));
        }

        public override string[] GetAllViews()
        {
            ArrayList allViews = new ArrayList();
            IDbCommand cmd = CreateCommand();

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            cmd.CommandText = "select  u.name,  v.name,   substring(t.text, 1, 1),   t.text  from   sysusers u,   sysobjects v,   syscomments t where   t.id=v.id   and u.uid=v.uid   and v.type='V'";
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    allViews.Add(reader.GetString(1));
                }
            }
            return (string[])allViews.ToArray(typeof(string));
        }

        public override Hashtable GetEntites()
        {
            return BuildEntites();
        }

        public override Hashtable GetConstraints()
        {
            //if (this.allLookup == null)
            return  BuildLookup();

           // ArrayList constraints = this.allLookup[tableName] as ArrayList;
            //return (constraints == null ? new ConstraintInfo[0] : (ConstraintInfo[])constraints.ToArray(typeof(ConstraintInfo)));
             //   return null;
        }

        public override Hashtable GetAllPrimaryKeys()
        {
           // if (this.allKeys == null)
            return  BuildKeys();

            //return (this.allKeys == null ? new KeyInfo[0] : (KeyInfo[])this.allKeys.ToArray(typeof(KeyInfo)));
             //   return null;
        }

        private Hashtable BuildKeys()
        {
           // this.allKeys = new ArrayList();
            string commandText = "";

            //if (driver.ConnectionInfo.Provider == "mssql")
            //{
                commandText = "select kcu.TABLE_SCHEMA, kcu.TABLE_NAME, kcu.CONSTRAINT_NAME, tc.CONSTRAINT_TYPE, kcu.COLUMN_NAME, kcu.ORDINAL_POSITION " +
                                 " from INFORMATION_SCHEMA.TABLE_CONSTRAINTS as tc " +
                                 " join INFORMATION_SCHEMA.KEY_COLUMN_USAGE as kcu " +
                                 "   on kcu.CONSTRAINT_SCHEMA = tc.CONSTRAINT_SCHEMA " +
                                 "  and kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME " +
                                 "  and kcu.TABLE_SCHEMA = tc.TABLE_SCHEMA " +
                                 "  and kcu.TABLE_NAME = tc.TABLE_NAME " +
                                 " where tc.CONSTRAINT_TYPE in ( 'PRIMARY KEY', 'UNIQUE' ) " +
                                 " order by kcu.TABLE_SCHEMA, kcu.TABLE_NAME, tc.CONSTRAINT_TYPE, kcu.CONSTRAINT_NAME, kcu.ORDINAL_POSITION";

            //}
            //else if (driver.ConnectionInfo.Provider == "mssql2005")
            //{
            //    commandText = "select s.name as TABLE_SCHEMA, t.name as TABLE_NAME, k.name as CONSTRAINT_NAME, k.type_desc as CONSTRAINT_TYPE, c.name as COLUMN_NAME, ic.key_ordinal AS ORDINAL_POSITION " +
            //                  " from sys.key_constraints as k " +
            //                  " join sys.tables as t " +
            //                  "   on t.object_id = k.parent_object_id " +
            //                  " join sys.schemas as s " +
            //                  "   on s.schema_id = t.schema_id " +
            //                  " join sys.index_columns as ic " +
            //                  "   on ic.object_id = t.object_id " +
            //                  "  and ic.index_id = k.unique_index_id " +
            //                  " join sys.columns as c " +
            //                  "   on c.object_id = t.object_id " +
            //                  "  and c.column_id = ic.column_id " +
            //                 " order by TABLE_SCHEMA, TABLE_NAME, CONSTRAINT_TYPE, CONSTRAINT_NAME, ORDINAL_POSITION ";
            //}
            SqlCommand cmd = (SqlCommand)CreateCommand();
            cmd.Connection.Open();
            cmd.CommandText = commandText;

            Hashtable entities = new Hashtable();

            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string tableName = (string)reader["TABLE_NAME"];

                    if (entities[tableName] == null)
                    {
                        entities.Add(tableName, new ArrayList());
                    }

                    ArrayList references = (ArrayList)entities[tableName];
                    references.Add((string)reader["COLUMN_NAME"]);

                    //ReferenceInfo constraintInfo = new PrimaryKeyReferenceInfo();
                    //constraintInfo.Name = (string)reader[1];
                    //constraintInfo.TableName = (string)reader[0];
                    //constraintInfo.ColumnName = (string)reader[4];

                    ////constraintInfo.OnDeleteCascade = reader[2].ToString().StartsWith("CASCADE");
                    ////constraintInfo.OnUpdateCascade = reader[3].ToString().StartsWith("CASCADE");

                    ////String constraintKeys = (string)reader[4];
                    ////constraintInfo.Columns = constraintKeys.Split(",".ToCharArray());
                    //constraintInfo.ReferenceColumnName = (string)reader[6];
                    //constraintInfo.ReferenceTableName = (string)reader[5];

                    //references.Add(constraintInfo);
                }
            }
            return entities;

        }

        private Hashtable BuildEntites()
        {
            SqlCommand cmd = (SqlCommand)CreateCommand();
            cmd.Connection.Open();
            //                            0             1           2               3                         4                5                 6                  7            8             9   
            string commandText = "Select COLUMN_NAME, DATA_TYPE, IS_NULLABLE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE, CHARACTER_SET_NAME, COLLATION_NAME, TABLE_NAME, COLUMNPROPERTY(OBJECT_ID(TABLE_NAME), COLUMN_NAME, 'IsIdentity') as IS_IDENTITY\n" +
                 "  from  INFORMATION_SCHEMA.COLUMNS\n" +
                 "  order by ORDINAL_POSITION";

            cmd.CommandText = commandText;

            //ArrayList allColumns = new ArrayList();
            Hashtable entities = new Hashtable();

            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string tableName = (string)reader["TABLE_NAME"];

                    if (entities[tableName] == null)
                    {
                        entities.Add(tableName, new ArrayList());
                    }

                    ArrayList columns = (ArrayList)entities[tableName];

                    ColumnInfo column = new ColumnInfo(null);
                    column.Name = ((string)reader["COLUMN_NAME"]);//.Replace(" ","").Replace("-","");

                    // SqlType detection
                    string dataType = (string)reader["DATA_TYPE"];

                    column.SqlType = (SqlType)Enum.Parse(typeof(SqlType), dataType, true);

                    object maxlength=reader["CHARACTER_MAXIMUM_LENGTH"];
                    if (maxlength != DBNull.Value)
                    {
                        column.Length = int.Parse(maxlength.ToString());
                    }
                    //else if (newColumn.SqlType == SqlType.Decimal)
                    //{
                    object precision = reader["NUMERIC_PRECISION"];
                    object scale = reader["NUMERIC_SCALE"];
                    if (precision != DBNull.Value)
                    {
                        column.Precision = int.Parse(precision.ToString());
                    }

                    if (scale != DBNull.Value)
                    {
                        column.Scale = int.Parse(scale.ToString());
                    }
                    object isnullable = reader["IS_NULLABLE"];
                    if (isnullable != DBNull.Value)
                    {
                        string s = isnullable.ToString();
                        column.IsRequire = ("yes" == s.ToLower());
                    }

                    column.IsIdentity = (int)reader["IS_IDENTITY"] == 1;
                    columns.Add(column);
                    //allColumns.Add(column);
                }
            }
            return entities;
        }

        private Hashtable BuildLookup()
        {
          //  this.allLookup = new Hashtable();
            SqlCommand cmd = (SqlCommand)CreateCommand();

            cmd.Connection.Open();
            string query = "select " +
              "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.TABLE_NAME, " + /*0*/
              "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.CONSTRAINT_NAME, " + /*1*/
              "INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS.DELETE_RULE, " + /*2*/
              "INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS.UPDATE_RULE, " + /*3*/
              "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.COLUMN_NAME, " + /*4*/
              "INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME, " + /*5*/
              "unique_usage.COLUMN_NAME " + /*6*/
              "from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE " +
              "inner join INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS " +
              "on  " +
              "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.CONSTRAINT_NAME =  " +
              "INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS.CONSTRAINT_NAME " +
              "inner join INFORMATION_SCHEMA.TABLE_CONSTRAINTS " +
              "on " +
              "INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME =  " +
              "INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS.UNIQUE_CONSTRAINT_NAME " +
              "inner join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE unique_usage " +
              "on " +
              "INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME = " +
              "unique_usage.CONSTRAINT_NAME";

            cmd.CommandText = query;

            Hashtable entities = new Hashtable();

            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string tableName = (string)reader[0];

                    if (entities[tableName] == null)
                    {
                        entities.Add(tableName, new ArrayList());
                    }

                    ArrayList freferences = (ArrayList)entities[tableName];


                    ReferencingInfo foreignInfo = new ReferencingInfo(null);
                    foreignInfo.Name = (string)reader[1];
                    foreignInfo.TableName = (string)reader[0];
                    foreignInfo.ColumnName = (string)reader[4];

                    //TODO:foreignInfo.ReferencingKey = (string)reader[6];
                    //TODO:foreignInfo.ReferenceTableName = (string)reader[5];

                    freferences.Add(foreignInfo);

                    string primaryTableName = (string)reader[5];
                    if (entities[primaryTableName] == null)
                    {
                        entities.Add(primaryTableName, new ArrayList());
                    }

                    ArrayList preferences = (ArrayList)entities[primaryTableName];

                    ReferencedInfo primaryInfo = new ReferencedInfo(null);
                    primaryInfo.Name = (string)reader[1];
                    primaryInfo.TableName = (string)reader[5];
                    primaryInfo.ColumnName = (string)reader[6]; 

                    //TODO:primaryInfo.ReferenceColumnName = (string)reader[4];
                    //TODO:primaryInfo.ReferenceTableName = (string)reader[0];

                    preferences.Add(primaryInfo);
                }
            }
            return entities;

        }

    }
}
