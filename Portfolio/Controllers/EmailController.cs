using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
	public class EmailController : BaseController
	{
		private readonly IEmailServices _emailServices;

		public EmailController(IEmailServices emailServices)
		{
			_emailServices = emailServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SendMail(EmailModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await _emailServices.SendEmail(model);
			Notify("Your e-mail has been successfully sent.");
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Success()
		{
			return View();
		}

	}
}
