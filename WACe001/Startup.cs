using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WACe001.Service;
using WACe001.Service.Interface;

namespace WACe001
{

	public class Startup
	{

#region Property

		private IHostingEnvironment HostingEnvironment { get; }

#endregion

#region Instance Initialization

		public Startup(IHostingEnvironment hostingEnvironment)
		{
			HostingEnvironment = hostingEnvironment;
		}

#endregion

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			// todo: check other environment(s)
			if (HostingEnvironment.IsDevelopment())
			{
				services.AddScoped<IMailService, FakeMailService>();
			} // if
			else
			{
				// todo: implement real mail service...
			} // else
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			//app.Run(async (context) =>
			//{
			//	await context.Response.WriteAsync("What up!");
			//});

			//app.UseDefaultFiles();

			app.UseMvc(builder => builder.MapRoute(name: "Default", template: "{controller}/{action}/{id?}", defaults: new {controller = "App", action = "Index"}));
			app.UseStaticFiles();
		}
		
	}
	
}
