using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace Common.Email
{
	public static class EmailHelper
	{
		public static void SendEmail(string Message)
		{
			MimeMessage message = new MimeMessage();
			//发件人
			message.From.Add(new MailboxAddress("Mark", "528414865@qq.com"));
			//收件人
			message.To.Add(new MailboxAddress("Mark-boss", "528414865@qq.com"));
			//标题
			message.Subject = "测试标题";
			//生成一个支持Html的TextPart
			TextPart body = new TextPart(TextFormat.Html)
			{
				Text = "<h1>测试内容</h1>" + Message
			};
			//测试girhub
			//创建Multipart添加附件
			Multipart multipart = new Multipart("mixed");
			multipart.Add(body);

			//正文
			message.Body = multipart;

			using (SmtpClient client = new SmtpClient())
			{
				//Smtp服务器
				client.Connect("smtp.qq.com", 587, false);
				//登录
				client.Authenticate("528414865@qq.com", "cbyiehnezjxebjia");
				//发送
				client.Send(message);
				//断开
				client.Disconnect(true);
				Console.WriteLine("发送邮件成功");
			}
		}
	}
}
