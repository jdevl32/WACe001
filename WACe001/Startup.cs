﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WACe001.Controller.Web;
using WACe001.Controller.Web.Interface;
using WACe001.Entity;
using WACe001.Entity.Interface;
using WACe001.Repository;
using WACe001.Repository.Interface;
using WACe001.Service;
using WACe001.Service.Interface;

namespace WACe001
{

	public class Startup
	{

#region Property

		private IConfigurationRoot ConfigurationRoot { get; }

		private IHostingEnvironment HostingEnvironment { get; }

#endregion

#region Instance Initialization

		public Startup(IHostingEnvironment hostingEnvironment)
		{
			ConfigurationRoot = BuildConfiguration(hostingEnvironment);
			HostingEnvironment = hostingEnvironment;
		}

#endregion

		private static IConfigurationRoot BuildConfiguration(IHostingEnvironment hostingEnvironment) => new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("Config/appsettings.json").AddEnvironmentVariables().Build();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="services">
		/// 
		/// </param>
		/// <remarks>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		/// Last modification:
		/// Add logging.
		/// Add scoped dependency injection for app controller interface and implementation.
		/// </remarks>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<TravelContext>();
			services.AddLogging();
			services.AddMvc();
			services.AddScoped<IAppController, AppController>();

			// todo: check other environment(s)
			if (HostingEnvironment.IsDevelopment())
			{
				services.AddScoped<IMailService, FakeMailService>();
			} // if
			else
			{
				// todo: implement real mail service...
			} // else

			services.AddScoped<ITravelContext, TravelContext>();
			services.AddScoped<ITravelRepository, TravelRepository>();
			services.AddSingleton(ConfigurationRoot);
			services.AddTransient<ITravelContextSeed, TravelContextSeed>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="applicationBuilder">
		/// 
		/// </param>
		/// <param name="hostingEnvironment">
		/// 
		/// </param>
		/// <param name="loggerFactory">
		/// 
		/// </param>
		/// <param name="travelContextSeed">
		/// 
		/// </param>
		/// <remarks>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// Last modification:
		/// Replace seed implementation with interface.
		/// Refactoring of names.
		/// </remarks>
		public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, ITravelContextSeed travelContextSeed)
		{
			var logLevel = LogLevel.Error;

			if (hostingEnvironment.IsDevelopment())
			{
				logLevel = LogLevel.Information;
				applicationBuilder.UseDeveloperExceptionPage();
			}

			applicationBuilder.UseMvc(routeBuilder => routeBuilder.MapRoute(name: "Default", template: "{controller}/{action}/{id?}", defaults: new {controller = "App", action = "Index"}));
			applicationBuilder.UseStaticFiles();
			travelContextSeed.EnsureSeed().Wait();
			loggerFactory.AddDebug(logLevel);
		}

	}

}
