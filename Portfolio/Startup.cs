using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IEmailServices, EmailServices>();
			services.AddControllersWithViews();

			//services.AddTransient<IEmailSender, MailKitEmailSender>();
			//services.Configure<MailKitEmailSenderOptions>(options =>
			//{
			//	options.Host_Address = "smtp-relay.sendinblue.com";
			//	options.Host_Port = 587;
			//	options.Host_Username = "billyjoethreetwoone@gmail.com";
			//	options.Host_Password = "FcDaLP9ZtIqwHCRz";
			//	options.Sender_EMail = "noreply@mydomain.com";
			//	options.Sender_Name = "My Sender AWWW";
			//});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Billy}/{action=Index}/{id?}");
			});
		}
	}
}
