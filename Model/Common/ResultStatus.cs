using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
    /// <summary>
    /// 响应状态
    /// </summary>
    public static class ResultStatus
    {
        /// <summary>
        /// 成功
        /// </summary>
        public static int OK = 1;
        /// <summary>
        /// 失败
        /// </summary>
        public static int NG = -1;
        /// <summary>
        /// 系统错误
        /// </summary>
        public static int ER = -2;
    }
}
