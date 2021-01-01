using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
	public class ContactController : Controller
	{
        public IEmailSender EmailSender { get; set; }

        public void RegisterController(IEmailSender emailSender)
        {
            EmailSender = emailSender;
        }

        public async Task<IActionResult> Send(string toAddress)
        {
            var subject = "sample subject";
            var body = "sample body";
            await EmailSender.SendEmailAsync(toAddress, subject, body);
            return View();
        }
    }
}
