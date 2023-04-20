using Common.Email;
using Microsoft.AspNetCore.Mvc;
using Model.Common;
using Model.Mark;
using Service.User.Impl;
using Service.User;
using System.ComponentModel.DataAnnotations;
using Service.Blazor;

namespace WebAPIFreeSQL.Controllers
{
    /// <summary>
    /// 邮件发送
    /// </summary>
    [ApiController]
    [Route("Email")]
    public class EmailController : Controller
    {
        private BlazorToHtmlString Service = new BlazorToHtmlString();

        /// <summary>
        /// 邮件发送
        /// </summary>
        /// <param name="email">邮件信息</param>
        /// <returns></returns>
        [HttpPost, Route("EmailSend")]
        public IActionResult EmailSend(EmailModel email)
        {
            try
            {
                string msg = EmailHelper.SendEmail(email);
                return Ok(new RestResult(ResultStatus.OK, msg,"已发送"));
            }
            catch (Exception ex)
            {
                return NotFound(new RestResult(ResultStatus.NG, "邮件发送失败，原因：" + ex.Message));
            }
        }

        /// <summary>
        /// 用户表信息推送
        /// </summary>
        /// <param name="UserName">用户名称</param>
        /// <param name="Email">邮件地址</param>
        /// <returns></returns>
        [HttpGet, Route("UserSend")]
        public IActionResult UserSend([Required]string UserName,[Required]string Email)
        {
            try
            {
                string html = Service.GetEmailTable();
                EmailModel email = new EmailModel()
                {
                    Title = "用户表信息推送",
                    Content = html,
                    FromPeople = new List<Person>() { new Person() { Name = "Mark", Email = "528414865@qq.com" } },
                    ToPeople = new List<Person>() { new Person() { Name = UserName, Email = Email } }
                };
                string msg = EmailHelper.SendEmail(email);
                return Ok(new RestResult(ResultStatus.OK, msg));
            }
            catch (Exception ex)
            {
                return NotFound(new RestResult(ResultStatus.NG, "用户表信息推送失败，原因：" + ex.Message));
            }
        }
    }
}
