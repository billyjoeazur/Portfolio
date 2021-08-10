using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Models;

namespace Portfolio.Controllers
{
	public class BillyController : Controller
	{
		private readonly ILogger<BillyController> _logger;

		public BillyController(ILogger<BillyController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Skills()
		{
			return View();
		}

		public IActionResult Projects()
		{
			return View();
		}
		public IActionResult Contact()
		{
			return View();
		}

		public IActionResult Iligtas()
		{
			return View();
		}

		public IActionResult IdSystem()
		{
			return View();
		}

		public IActionResult Filipiknows()
		{
			return View();
		}

		public IActionResult AttendanceDesktop()
		{
			return View();
		}

		public IActionResult AttendanceMobile()
		{
			return View();
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
