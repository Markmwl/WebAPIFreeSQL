using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
    /// <summary>
    /// 邮件发送模型
    /// </summary>
    public class EmailModel
    {
        /// <summary>
        /// 邮件标题
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 发件人信息(支持多个)
        /// </summary>
        [Required]
        public IList<Person> FromPeople { get; set; }

        /// <summary>
        /// 收件人信息(支持多个)
        /// </summary>
        [Required]
        public IList<Person> ToPeople { get; set; }

        /// <summary>
        /// 抄送人信息(支持多个)
        /// </summary>
        public IList<Person> CcPeople { get; set; }

        /// <summary>
        /// 邮件正文
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public IList<AnnexFile> Annexes { get; set; }
    }

    /// <summary>
    /// 发件/收件人/抄送人 通用类
    /// </summary>
    public class Person
    {
        /// <summary>
        /// 发件/收件人/抄送人名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
    }

    /// <summary>
    /// 附件信息
    /// </summary>
    public class AnnexFile
    {
        /// <summary>
        /// 附件名称
        /// </summary>
        public string AnnexName { get; set; }
        /// <summary>
        /// 文件路径+文件名称
        /// </summary>
        public string FileLoad { get; set; }
    }

    /// <summary>
    /// 邮件服务器
    /// </summary>
    public static class ServerEmail
    {
        /// <summary>
        /// smtp服务器
        /// </summary>
        public static SmtpEmail smtpEmail { get; set; }
    }

    /// <summary>
    /// Smtp邮件服务器信息
    /// </summary>
    public class SmtpEmail
    {
        /// <summary>
        /// 邮件服务器
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }
    }
}
