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
    public abstract class ISchemaExtractor
    {
        public class EntityModel
        {
            public string TableName;
            public string TableCatalog;
            public string TableSchema;
        }
        public class PrimaryKeyModel
        {
            public string ConstraintName;
            public string ColumnName;
            public string TableName;
        }

        public class ForgeinKeyModel
        {
            public string ConstraintName;
            public string ColumnName;
            public string TableName;
            public string ReferencingColumnName;
            public string ReferecingTableName;
        }

        public class ColumnModel
        {
            public string ColumnName;	
            public SqlType DataType;
            public bool Nullable;
            public int Length;
            public int Precision;
            public int Scale;
            public string TableName;
            public bool IsIdentity;
            public string DefaultValue;

        }

        protected Driver driver;
        //protected Hashtable netDataTypes;

        public ISchemaExtractor(Driver driver)
        {
            this.driver = driver;

            //netDataTypes = new Hashtable();

            //netDataTypes.Add(SqlType.Byte, "System.Byte");
            //netDataTypes.Add(SqlType.Boolean, "System.Boolean");
            //netDataTypes.Add(SqlType.Char, "System.String");
            //netDataTypes.Add(SqlType.DateTime, "System.DateTime");
            //netDataTypes.Add(SqlType.Decimal, "System.Decimal");
            //netDataTypes.Add(SqlType.Double, "System.Double");
            //netDataTypes.Add(SqlType.Float, "System.Double");
            ////netDataTypes.Add(SqlType.GUID, "System.Guid");
            //netDataTypes.Add(SqlType.Int16, "System.Int16");
            //netDataTypes.Add(SqlType.Int32, "System.Int32");
            //netDataTypes.Add(SqlType.Int64, "System.Int64");
            ////netDataTypes.Add(SqlType.Image, "System.Byte[]");
            //netDataTypes.Add(SqlType.Money, "System.Decimal");
            //netDataTypes.Add(SqlType.SmallDateTime, "System.DateTime");
            //netDataTypes.Add(SqlType.SmallMoney, "System.Decimal");
            //netDataTypes.Add(SqlType.Text, "System.String");
            ////netDataTypes.Add(SqlType.TimeStamp, "System.DateTime");
            //netDataTypes.Add(SqlType.Unknown, "System.String");
            ////netDataTypes.Add(SqlType.VarBinary, "System.Byte[]");
            ////netDataTypes.Add(SqlType.VarBinaryMax, "System.Byte[]");
            //netDataTypes.Add(SqlType.VarChar, "System.String");
            //netDataTypes.Add(SqlType.VarCharMax, "System.String");
        }

        public abstract IDictionary<string, EntityModel> GetAllTables();
        public abstract IDictionary<string, EntityModel> GetAllViews();
        public abstract IDictionary<string, ColumnModel> GetColumns();
        public abstract IDictionary<string, PrimaryKeyModel> GetAllPrimaryKeys();
        public abstract IDictionary<string, ForgeinKeyModel> GetAllForeignKeys();
    }
}
