using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
    /// <summary>
    /// 响应类
    /// </summary>
    public class RestResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int code;
        /// <summary>
        /// 提示信息
        /// </summary>
        public string message;
        /// <summary>
        /// 响应数据
        /// </summary>
        public object data;

        /// <summary>
        /// 返回响应数据
        /// </summary>
        /// <param name="_code">状态码</param>
        /// <param name="_message">提示信息</param>
        public RestResult(int _code, String _message)
        {
            code = _code;
            message = _message;
        }

        /// <summary>
        /// 返回响应数据
        /// </summary>
        /// <param name="_code">状态码</param>
        /// <param name="_message">提示信息</param>
        /// <param name="_data">响应数据</param>
        public RestResult(int _code, string _message, object _data)
        {
            code = _code;
            message = _message;
            data = _data;
        }
    }
}
