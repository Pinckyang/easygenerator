using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using EasyGenerator.Studio.DbHelper.Info;
using EasyGenerator.Studio.Model;
using EasyGenerator.Studio.Model.DB;
using System.Dynamic;

namespace EasyGenerator.Studio.DbHelper.MSSQL
{
    public class MSSQLSchemaExtractor : ISchemaExtractor
    {
        private Hashtable dataTypeMapping = new Hashtable(30);

        public MSSQLSchemaExtractor(Driver driver)
            : base(driver)
        {
            dataTypeMapping.Add("bigint", SqlType.BigInt);
            dataTypeMapping.Add("varbinary", SqlType.VarBinary);
            dataTypeMapping.Add("binary", SqlType.VarBinary);
            dataTypeMapping.Add("bit", SqlType.Bit);
            dataTypeMapping.Add("char", SqlType.Char);
            dataTypeMapping.Add("date", SqlType.Date);
            dataTypeMapping.Add("datetime", SqlType.DateTime);
            dataTypeMapping.Add("datetime2", SqlType.DateTime2);
            dataTypeMapping.Add("datetimeoffset", SqlType.DateTimeOffset);
            dataTypeMapping.Add("decimal", SqlType.Decimal);
            dataTypeMapping.Add("varbinary(max)", SqlType.VarBinary);
            dataTypeMapping.Add("float", SqlType.Float);
            dataTypeMapping.Add("image", SqlType.Binary);
            dataTypeMapping.Add("int", SqlType.Int);
            dataTypeMapping.Add("money", SqlType.Money);
            dataTypeMapping.Add("nchar", SqlType.NChar);
            dataTypeMapping.Add("ntext", SqlType.NText);
            dataTypeMapping.Add("numeric", SqlType.Decimal);
            dataTypeMapping.Add("varchar", SqlType.VarChar);
            dataTypeMapping.Add("nvarchar", SqlType.NVarChar);
            dataTypeMapping.Add("real", SqlType.Real);
            dataTypeMapping.Add("rowversion", SqlType.Timestamp);
            dataTypeMapping.Add("smalldatetime", SqlType.DateTime);
            dataTypeMapping.Add("smallint", SqlType.SmallInt);
            dataTypeMapping.Add("smallmoney", SqlType.SmallMoney);
            dataTypeMapping.Add("sql_variant", SqlType.Variant);
            dataTypeMapping.Add("text", SqlType.Text);
            dataTypeMapping.Add("time", SqlType.Time);
            dataTypeMapping.Add("timestamp", SqlType.Timestamp);
        }

        public override IDictionary<string, EntityModel> GetAllTables()
        {
            IDictionary<string, EntityModel> entities = new Dictionary<string, EntityModel>(0);

            IDbCommand cmd = this.driver.CreateCommand();
            cmd.Connection.Open();

            cmd.CommandText = "SELECT TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,TABLE_TYPE FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_SCHEMA,TABLE_NAME";
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string owner = reader["TABLE_CATALOG"].ToString();
                    if (owner.Equals("INFORMATION_SCHEMA", StringComparison.CurrentCultureIgnoreCase) || owner.Equals("sys", StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }
                    entities.Add(reader["TABLE_NAME"].ToString(), new EntityModel() { TableName = reader["TABLE_NAME"].ToString(), TableCatalog = reader["TABLE_CATALOG"].ToString(), TableSchema = reader["TABLE_SCHEMA"].ToString() });
                }
            }

            return entities;
        }

        public override IDictionary<string, EntityModel> GetAllViews()
        {
            IDictionary<string, EntityModel> entities = new Dictionary<string, EntityModel>(0);
            IDbCommand cmd = this.driver.CreateCommand();

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            cmd.CommandText = "SELECT TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,TABLE_TYPE FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'VIEW' ORDER BY TABLE_SCHEMA,TABLE_NAME";
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string owner = reader["TABLE_CATALOG"].ToString();
                    if (owner.Equals("INFORMATION_SCHEMA", StringComparison.CurrentCultureIgnoreCase) || owner.Equals("sys", StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }
                    entities.Add(reader["TABLE_NAME"].ToString(), new EntityModel() { TableName = reader["TABLE_NAME"].ToString(), TableCatalog = reader["TABLE_CATALOG"].ToString(), TableSchema = reader["TABLE_SCHEMA"].ToString() });
                }
            }
            return entities;
        }

        public override IDictionary<string, ColumnModel> GetColumns()
        {
            IDictionary<string, ColumnModel> entities = new Dictionary<string, ColumnModel>();
            IDbCommand cmd = this.driver.CreateCommand();

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            cmd.CommandText = "Select COLUMN_NAME, DATA_TYPE, IS_NULLABLE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE, CHARACTER_SET_NAME, COLLATION_NAME, TABLE_NAME, COLUMNPROPERTY(OBJECT_ID(TABLE_NAME), COLUMN_NAME, 'IsIdentity') as IS_IDENTITY " +
                           " from  INFORMATION_SCHEMA.COLUMNS "+
                           " order by ORDINAL_POSITION";

            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ColumnModel model = new ColumnModel();
                    model.ColumnName = reader["COLUMN_NAME"].ToString();
                    model.DataType = (SqlType)dataTypeMapping[reader["DATA_TYPE"].ToString()];
                    model.Nullable = reader["IS_NULLABLE"].ToString() == "YES";
                    model.Length = (reader["CHARACTER_MAXIMUM_LENGTH"].GetType() == typeof(DBNull)) ? 0 : int.Parse(reader["CHARACTER_MAXIMUM_LENGTH"].ToString());
                    model.Precision = (reader["NUMERIC_PRECISION"].GetType() == typeof(DBNull)) ? 0 : int.Parse(reader["NUMERIC_PRECISION"].ToString());
                    model.Scale = (reader["NUMERIC_SCALE"].GetType() == typeof(DBNull)) ? 0 : int.Parse(reader["NUMERIC_SCALE"].ToString());
                    model.TableName = reader["TABLE_NAME"].ToString();
                    model.IsIdentity = (int)reader["IS_IDENTITY"]==1;
                    entities.Add(reader["COLUMN_NAME"].ToString() + "-" + reader["TABLE_NAME"].ToString(), model);
                }
            }
            return entities;
        }

        public override IDictionary<string, ForgeinKeyModel> GetAllForeignKeys()
        {
            IDictionary<string, ForgeinKeyModel> entities = new Dictionary<string, ForgeinKeyModel>();
            IDbCommand cmd = this.driver.CreateCommand();

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            cmd.CommandText = "select "+
                            "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.CONSTRAINT_NAME,"+
                            "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.TABLE_NAME,"+
                            "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.COLUMN_NAME,"+
                            "INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME as REFERECING_TABLE_NAME," +
                            "unique_usage.COLUMN_NAME AS REFERENCING_COLUMN_NAME " +
                            "from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE "+
                            "inner join INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS "+
                            "on  "+
                            "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.CONSTRAINT_NAME =  "+
                            "INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS.CONSTRAINT_NAME "+
                            "inner join INFORMATION_SCHEMA.TABLE_CONSTRAINTS "+
                            "on "+
                            "INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME =  "+
                            "INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS.UNIQUE_CONSTRAINT_NAME "+
                            "inner join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE unique_usage "+
                            "on "+
                            "INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME = "+
                            "unique_usage.CONSTRAINT_NAME";

            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string constraintName = reader["CONSTRAINT_NAME"].ToString();
                    string tableName = reader["TABLE_NAME"].ToString();
                    string columnName = reader["COLUMN_NAME"].ToString();
                    string referecingTableName = reader["REFERECING_TABLE_NAME"].ToString();
                    string referencingColumnName = reader["REFERENCING_COLUMN_NAME"].ToString();

                    entities.Add(constraintName, new ForgeinKeyModel { ConstraintName = constraintName, ColumnName = columnName, TableName = tableName, ReferecingTableName = referecingTableName, ReferencingColumnName = referencingColumnName });
                }
            }
            return entities;
        }

        public override IDictionary<string,PrimaryKeyModel> GetAllPrimaryKeys()
        {
            IDictionary<string, PrimaryKeyModel> entities = new Dictionary<string,PrimaryKeyModel>();
            IDbCommand cmd = this.driver.CreateCommand();

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            cmd.CommandText = "select kcu.TABLE_SCHEMA, kcu.TABLE_NAME, kcu.CONSTRAINT_NAME, tc.CONSTRAINT_TYPE, kcu.COLUMN_NAME, kcu.ORDINAL_POSITION " +
                                 " from INFORMATION_SCHEMA.TABLE_CONSTRAINTS as tc " +
                                 " join INFORMATION_SCHEMA.KEY_COLUMN_USAGE as kcu " +
                                 "   on kcu.CONSTRAINT_SCHEMA = tc.CONSTRAINT_SCHEMA " +
                                 "  and kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME " +
                                 "  and kcu.TABLE_SCHEMA = tc.TABLE_SCHEMA " +
                                 "  and kcu.TABLE_NAME = tc.TABLE_NAME " +
                                 " where tc.CONSTRAINT_TYPE in ( 'PRIMARY KEY') " +
                                 " order by kcu.TABLE_SCHEMA, kcu.TABLE_NAME, tc.CONSTRAINT_TYPE, kcu.CONSTRAINT_NAME, kcu.ORDINAL_POSITION";

            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string constraintName = reader["CONSTRAINT_NAME"].ToString();
                    string tableName = reader["TABLE_NAME"].ToString();
                    string columnName = reader["COLUMN_NAME"].ToString();

                    entities.Add(constraintName + "-" + columnName, new PrimaryKeyModel { ConstraintName = constraintName, ColumnName = columnName, TableName = tableName });
                }
            }
            return entities;
        }
    }
}
