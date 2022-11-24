using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Mssql.Engine
{
    /// <summary>
    /// CreateTableEngine
    /// </summary>
    public class CreateTableEngine
    {
        /// <summary>
        /// Generate
        /// </summary>
        public void Generate(CreateTable createTable, CodeWriter codeWriter)
        {
            if (createTable == null)
            {
                return;
            }

            codeWriter.WriteLine($"CREATE TABLE {(createTable.Schema ?? "dbo").ToStandardName()}.{(createTable.Name ?? string.Empty).ToStandardName()}");
            codeWriter.WriteLine("(");

            GenerateFields(createTable.Name, createTable.PrimaryKey, createTable.FieldList, codeWriter);

            codeWriter.WriteLine($")");

            GenerateDefaultValue(createTable.Schema, createTable.Name, createTable.FieldList, codeWriter);

            GenerateFieldComment(createTable.Schema, createTable.Name, createTable.FieldList, codeWriter);
        }

        private void GenerateFields(string tableName, string primaryKey, List<Field> fieldList, CodeWriter codeWriter)
        {
            if (fieldList == null || fieldList.Count <= 0)
            {
                return;
            }

            var firstField = fieldList.FirstOrDefault(v => v.AutoIncrement);
            var otherFields = fieldList.Where(v => !v.AutoIncrement).ToList();

            List<Field> fields = new List<Field>();
            if (firstField != null)
            {
                fields.Add(firstField);
            }
            if (otherFields.Count > 0)
            {
                fields.AddRange(otherFields);
            }

            for (int i = 0; i < fields.Count; i++)
            {
                var field = fields[i];

                GenerateField(field, codeWriter);

                if (i < fields.Count - 1 || !string.IsNullOrEmpty(primaryKey))
                {
                    codeWriter.Write(",");
                }

                codeWriter.WriteLine();
            }

            if (!string.IsNullOrEmpty(primaryKey))
            {
                codeWriter.Write($"  CONSTRAINT [PK_{tableName}]")
                    .Write(" PRIMARY KEY CLUSTERED")
                    .WriteLine($" ([{primaryKey}] ASC)");
            }
        }

        private void GenerateDefaultValue(string tableSchema, string tableName, List<Field> fieldList, CodeWriter codeWriter)
        {
            if (fieldList == null || fieldList.Count <= 0)
            {
                return;
            }

            if (!fieldList.Any(v => !string.IsNullOrEmpty(v.DefaultValue)))
            {
                return;
            }

            codeWriter.WriteLine();

            foreach (var field in fieldList)
            {
                if (string.IsNullOrEmpty(field.DefaultValue))
                {
                    continue;
                }
                codeWriter.Write("ALTER TABLE ")
                    .Write($"{(tableSchema ?? "dbo").ToStandardName()}.{(tableName ?? string.Empty).ToStandardName()}")
                    .Write(" ADD CONSTRAINT")
                    .Write($" [DF_{tableName}_{field.Name}]")
                    .Write($" DEFAULT ({field.DefaultValue})")
                    .Write($" FOR {(field.Name ?? string.Empty).ToStandardName()}")
                    .WriteLine();
            }
        }

        private void GenerateFieldComment(string tableSchema, string tableName, List<Field> fieldList, CodeWriter codeWriter)
        {
            if (fieldList == null || fieldList.Count <= 0)
            {
                return;
            }

            if (!fieldList.Any(v => !string.IsNullOrEmpty(v.Comment)))
            {
                return;
            }

            codeWriter.WriteLine();

            foreach (var field in fieldList)
            {
                if (string.IsNullOrEmpty(field.Comment))
                {
                    continue;
                }
                codeWriter.Write("EXEC sys.sp_addextendedproperty")
                    .Write(" @name=N'MS_Description',")
                    .Write($" @value=N'{field.Comment}' ,")
                    .Write(" @level0type=N'SCHEMA',")
                    .Write($" @level0name=N'{tableSchema ?? "dbo"}', ")
                    .Write(" @level1type=N'TABLE',")
                    .Write($" @level1name=N'{tableName}',")
                    .Write(" @level2type=N'COLUMN',")
                    .Write($" @level2name=N'{field.Name}'")
                    .WriteLine();
            }
        }

        private void GenerateField(Field field, CodeWriter codeWriter)
        {
            codeWriter.Write($"  {(field.Name ?? string.Empty).ToStandardName()} {field.ColumnType ?? string.Empty}");

            if (field.AutoIncrement)
            {
                codeWriter.Write(" IDENTITY(1,1)");
            }

            if (field.NotNull)
            {
                codeWriter.Write(" NOT NULL");
            }
        }
    }
}
