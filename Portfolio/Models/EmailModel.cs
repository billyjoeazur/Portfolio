using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
	public class EmailModel
	{

		[Required]
		[EmailAddress]
		public string Mail { get; set; }

		[Required]
		public string Subject { get; set; }

		[Required]
		public string Message { get; set; }

	}
}
