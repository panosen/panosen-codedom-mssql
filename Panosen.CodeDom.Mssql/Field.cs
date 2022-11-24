using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Mssql
{
    /// <summary>
    /// MssqlField
    /// </summary>
    public class Field
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// varchar(10), int(11), bigint(20) 包含长度
        /// COLUMN_TYPE
        /// </summary>
        public string ColumnType { get; set; }

        /// <summary>
        /// 不可为空
        /// </summary>
        public bool NotNull { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 自增长
        /// </summary>
        public bool AutoIncrement { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }
    }

    /// <summary>
    /// FieldExtension
    /// </summary>
    public static class FieldExtension
    {
        /// <summary>
        /// SetName
        /// </summary>
        public static TField SetName<TField>(this TField field, string name) where TField : Field
        {
            field.Name = name;

            return field;
        }

        /// <summary>
        /// SetColumnType
        /// </summary>
        public static TField SetColumnType<TField>(this TField field, string columnType) where TField : Field
        {
            field.ColumnType = columnType;

            return field;
        }

        /// <summary>
        /// SetNotNull
        /// </summary>
        public static TField SetNotNull<TField>(this TField field, bool notNull) where TField : Field
        {
            field.NotNull = notNull;

            return field;
        }

        /// <summary>
        /// SetComment
        /// </summary>
        public static TField SetComment<TField>(this TField field, string comment) where TField : Field
        {
            field.Comment = comment;

            return field;
        }

        /// <summary>
        /// SetAutoIncrement
        /// </summary>
        public static TField SetAutoIncrement<TField>(this TField field, bool autoIncrement) where TField : Field
        {
            field.AutoIncrement = autoIncrement;

            return field;
        }

        /// <summary>
        /// SetDefaultValue
        /// </summary>
        public static TField SetDefaultValue<TField>(this TField field, string defaultValue) where TField : Field
        {
            field.DefaultValue = defaultValue;

            return field;
        }
    }
}
