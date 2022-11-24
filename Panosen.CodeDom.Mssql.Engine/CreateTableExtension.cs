using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Mssql.Engine
{
    /// <summary>
    /// CreateTableExtension
    /// </summary>
    public static class CreateTableExtension
    {
        /// <summary>
        /// TransformText
        /// </summary>
        public static string TransformText(this CreateTable createTable)
        {
            var builder = new StringBuilder();

            new CreateTableEngine().Generate(createTable, builder);

            return builder.ToString();
        }
    }
}
