using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Mssql.Engine
{
    /// <summary>
    /// NameExtension
    /// </summary>
    public static class NameExtension
    {
        /// <summary>
        /// 转换为标准名称
        /// </summary>
        public static string ToStandardName(this string name)
        {
            return "[" + name + "]";
        }
    }
}
