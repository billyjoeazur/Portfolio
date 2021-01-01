using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Services
{
	public class EmailServices : IEmailServices
	{
		private readonly string _mailServer;
		private readonly string _myMail;
		private readonly string _mailPort;
		private readonly string _password;
		//private readonly string _senderName;
		public EmailServices(IConfiguration configuration)
		{
			_mailServer = configuration.GetSection("EmailSettings").GetSection("MailServer").Value;
			_myMail = configuration.GetSection("EmailSettings").GetSection("Sender").Value;
			_mailPort = configuration.GetSection("EmailSettings").GetSection("MailPort").Value;
			_password = configuration.GetSection("EmailSettings").GetSection("Password").Value;
			//_senderName = configuration.GetSection("EmailSettings").GetSection("SenderName").Value;
		}
		public async Task SendEmail(EmailModel model)
		{
			try
			{
				var mimeMessage = new MimeMessage();
				mimeMessage.From.Add(new MailboxAddress(model.Mail, model.Mail));
				mimeMessage.To.Add(MailboxAddress.Parse(_myMail));
				mimeMessage.Subject = model.Subject;
				mimeMessage.Body = new TextPart("html")
				{
					Text = model.Message
				};

				using(var client = new SmtpClient())
				{
					int port = Convert.ToInt32(_mailPort);
					await client.ConnectAsync(_mailServer, port, true);
					await client.AuthenticateAsync(_myMail, _password);
					await client.SendAsync(mimeMessage);
					await client.DisconnectAsync(true);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
