using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using System.Reflection;
using Model.Mark;
using Model.Common;

namespace Common.Email
{
	public static class EmailHelper
	{
        /// <summary>
        /// 邮件发送
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
		public static string SendEmail(EmailModel email)
		{
            try
            {
                MimeMessage message = new MimeMessage();

                //标题
                message.Subject = email.Title;

                //发件人
                if (email.FromPeople != null && email.FromPeople.Any())
                {
                    foreach (var from in email.FromPeople)
                    {
                        message.From.Add(new MailboxAddress(from.Name, from.Email));
                    }
                }
                else
                {
                    return "邮件不能没有发件人！";
                }

                //收件人
                if (email.ToPeople != null && email.ToPeople.Any())
                {
                    foreach (var to in email.ToPeople)
                    {
                        message.To.Add(new MailboxAddress(to.Name, to.Email));
                    }
                }
                else
                {
                    return "邮件不能没有收件人！";
                }

                //抄送人
                if (email.CcPeople != null && email.CcPeople.Any())
                {
                    foreach (var cc in email.CcPeople)
                    {
                        message.Cc.Add(new MailboxAddress(cc.Name, cc.Email));
                    }
                }

                var builder = new BodyBuilder { HtmlBody = email.Content };

                //添加附件
                if (email.Annexes != null && email.Annexes.Any())
                {
                    foreach (var file in email.Annexes)
                    {
                        if (string.IsNullOrEmpty(file.AnnexName) || string.IsNullOrEmpty(file.FileLoad))
                        {
                            continue;
                        }
                        FileStream fileStream = new FileStream(file.FileLoad, FileMode.Open, FileAccess.Read);
                        byte[] intbytes = new byte[(int)fileStream.Length];
                        fileStream.Read(intbytes, 0, intbytes.Length);
                        fileStream.Close();
                        Stream stream = new MemoryStream(intbytes);
                        builder.Attachments.AddAsync(file.AnnexName, stream);
                    }
                }

                //正文
                message.Body = builder.ToMessageBody();

                //using (SmtpClient client = new SmtpClient())
                //{
                //	//Smtp服务器
                //	client.Connect("smtp.qq.com", 587, false);
                //	//登录
                //	client.Authenticate("528414865@qq.com", "cbyiehnezjxebjia");
                //	//发送
                //	client.Send(message);
                //	//断开
                //	client.Disconnect(true);
                //	Console.WriteLine("发送邮件成功");
                //}

                // ServerEmail.smtpEmail 
                using (SmtpClient client = new SmtpClient())
                {
                    //Smtp服务器
                    client.Connect(ServerEmail.smtpEmail.Host, ServerEmail.smtpEmail.Port, false);
                    //登录
                    client.Authenticate(ServerEmail.smtpEmail.UserName, ServerEmail.smtpEmail.Password);
                    //发送
                    client.Send(message);
                    //断开
                    client.Disconnect(true);
                }
                return "邮件发送成功";
            }
            catch (Exception ex)
            {
                return "邮件发送失败！";
            }
        }
    }
}
