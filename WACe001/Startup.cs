using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
		/// <![CDATA[
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		/// ]]>
		/// Last modification:
		/// Add scoped dependency injection for travel context.
		/// Expand dependency injection for travel context seed (to include interface).
		/// </remarks>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<TravelContext>();
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

			services.AddScoped<ITravelContext, TravelContext>();
			services.AddScoped<ITravelRepository, TravelRepository>();
			services.AddSingleton(ConfigurationRoot);
			services.AddTransient<ITravelContextSeed, TravelContextSeed>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="app">
		/// 
		/// </param>
		/// <param name="env">
		/// 
		/// </param>
		/// <param name="contextSeed">
		/// 
		/// </param>
		/// <remarks>
		/// <![CDATA[
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// ]]>
		/// Last modification:
		/// Replace seed implementation with interface.
		/// </remarks>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ITravelContextSeed contextSeed)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc(builder => builder.MapRoute(name: "Default", template: "{controller}/{action}/{id?}", defaults: new {controller = "App", action = "Index"}));
			app.UseStaticFiles();
			contextSeed.EnsureSeed().Wait();
		}

	}

}
