using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Mssql.Engine.MSTest
{
    [TestClass]
    public class CreateTableEngineTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CreateTable createTable = new CreateTable();

            createTable.Name = "Student";
            createTable.PrimaryKey = "Id";
            createTable.FieldList = new System.Collections.Generic.List<Field>();
            createTable.FieldList.Add(new Field
            {
                Name = "Id",
                ColumnType = "int",
                AutoIncrement = true,
                NotNull = true,
            });
            createTable.FieldList.Add(new Field
            {
                Name = "Name",
                Comment = "ÐÕÃû",
                ColumnType = "nvarchar(50)",
                DefaultValue = "''",
                NotNull = true,
            });
            createTable.FieldList.Add(new Field
            {
                Name = "DataStatus",
                ColumnType = "int",
                DefaultValue = "1",
                NotNull = true,
            });
            createTable.FieldList.Add(new Field
            {
                Name = "CreateTime",
                ColumnType = "datetime",
                NotNull = true,
            });
            createTable.FieldList.Add(new Field
            {
                Name = "LastUpdateTime",
                ColumnType = "datetime",
                NotNull = true,
            });
            createTable.FieldList.Add(new Field
            {
                Name = "CreateUser",
                ColumnType = "nvarchar(100)",
                NotNull = true,
            });
            createTable.FieldList.Add(new Field
            {
                Name = "LastUpdateUser",
                ColumnType = "nvarchar(100)",
                NotNull = true,
            });
            createTable.DefaultCharset = "utf8mb4";

            var expected = @"CREATE TABLE [dbo].[Student]
(
  [Id] int IDENTITY(1,1) NOT NULL,
  [Name] nvarchar(50) NOT NULL,
  [DataStatus] int NOT NULL,
  [CreateTime] datetime NOT NULL,
  [LastUpdateTime] datetime NOT NULL,
  [CreateUser] nvarchar(100) NOT NULL,
  [LastUpdateUser] nvarchar(100) NOT NULL,
  CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([Id] ASC)
)

ALTER TABLE [dbo].[Student] ADD CONSTRAINT [DF_Student_Name] DEFAULT ('') FOR [Name]
ALTER TABLE [dbo].[Student] ADD CONSTRAINT [DF_Student_DataStatus] DEFAULT (1) FOR [DataStatus]

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ÐÕÃû' , @level0type=N'SCHEMA', @level0name=N'dbo',  @level1type=N'TABLE', @level1name=N'Student', @level2type=N'COLUMN', @level2name=N'Name'
";

            var actual = createTable.TransformText();

            Assert.AreEqual(expected, actual);
        }
    }
}
