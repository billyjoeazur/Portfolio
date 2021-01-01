using System.Threading.Tasks;

namespace Portfolio.Models
{
	public interface IEmailSender
	{
		Task Execute(string to, string subject, string message);
		Task SendEmailAsync(string email, string subject, string message);
	}
}