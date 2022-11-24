using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Mssql
{
    /// <summary>
    /// 创建表
    /// </summary>
    public class CreateTable
    {
        /// <summary>
        /// 架构
        /// </summary>
        public string Schema { get; set; }

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

        /// <summary>
        /// 默认字符集
        /// </summary>
        public string DefaultCharset { get; set; }
    }

    /// <summary>
    /// CreateTableExtension
    /// </summary>
    public static class CreateTableExtension
    {
        /// <summary>
        /// SetName
        /// </summary>
        public static TCreateTable SetName<TCreateTable>(this TCreateTable createTable, string name) where TCreateTable : CreateTable
        {
            createTable.Name = name;

            return createTable;
        }

        /// <summary>
        /// SetComment
        /// </summary>
        public static TCreateTable SetComment<TCreateTable>(this TCreateTable createTable, string comment) where TCreateTable : CreateTable
        {
            createTable.Comment = comment;

            return createTable;
        }

        /// <summary>
        /// SetPrimaryKey
        /// </summary>
        public static TCreateTable SetPrimaryKey<TCreateTable>(this TCreateTable createTable, string primaryKey) where TCreateTable : CreateTable
        {
            createTable.PrimaryKey = primaryKey;

            return createTable;
        }

        /// <summary>
        /// set DefaultCharset
        /// </summary>
        public static TCreateTable DefaultCharset<TCreateTable>(this TCreateTable createTable, string defaultCharset) where TCreateTable : CreateTable
        {
            createTable.DefaultCharset = defaultCharset;

            return createTable;
        }

        /// <summary>
        /// 添加一个字段
        /// </summary>
        public static CreateTable AddField(this CreateTable table, Field field)
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
        public static Field AddField(this CreateTable table, string name)
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
