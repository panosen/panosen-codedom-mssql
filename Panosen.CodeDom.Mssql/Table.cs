using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Mssql
{
    /// <summary>
    /// Table
    /// </summary>
    public class Table
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey { get; set; }

        /// <summary>
        /// 字段
        /// </summary>
        public List<Field> FieldList { get; set; }
    }

    /// <summary>
    /// MssqlTable Extension
    /// </summary>
    public static class TableExtension
    {

        /// <summary>
        /// SetName
        /// </summary>
        public static TTable SetName<TTable>(this TTable mysqlTable, string name) where TTable : Table
        {
            mysqlTable.Name = name;

            return mysqlTable;
        }

        /// <summary>
        /// SetComment
        /// </summary>
        public static TTable SetComment<TTable>(this TTable mysqlTable, string comment) where TTable : Table
        {
            mysqlTable.Comment = comment;

            return mysqlTable;
        }

        /// <summary>
        /// 
        /// </summary>
        public static TTable SetPrimaryKey<TTable>(this TTable mysqlTable, string primaryKey) where TTable : Table
        {
            mysqlTable.PrimaryKey = primaryKey;

            return mysqlTable;
        }

        /// <summary>
        /// 添加一个字段
        /// </summary>
        public static Table AddField(this Table table, Field field)
        {
            if (table.FieldList == null)
            {
                table.FieldList = new List<Field>();
            }

            table.FieldList.Add(field);

            return table;
        }

        /// <summary>
        /// 添加一个字段
        /// </summary>
        public static Field AddField(this Table table, string name)
        {
            if (table.FieldList == null)
            {
                table.FieldList = new List<Field>();
            }

            Field field = new Field();
            field.Name = name;

            table.FieldList.Add(field);

            return field;
        }
    }
}
