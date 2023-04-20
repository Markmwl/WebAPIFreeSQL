using Microsoft.AspNetCore.Mvc;
using Model.Common;

namespace WebAPIFreeSQL.Controllers
{
    [ApiController]
    [Route("Nacos")]
    public class NacosController : Controller
    {
        private IConfiguration _configuration;

        public NacosController(IConfiguration configuration) => _configuration = configuration;

        [HttpGet]
        public string Get() => _configuration["name"];

        /// <summary>
        /// 数据连接池配置
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetDatasource")]
        public DataSourceProperty GetDatasource() => _configuration.GetSection("DataSource").Get<DataSourceProperty>();

        /// <summary>
        /// 邮件服务器配置
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetEmail")]
        public SmtpEmail GetEmail() => _configuration.GetSection("Email").Get<SmtpEmail>();
    }
}
