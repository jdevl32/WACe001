using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using WACe001.Entity;
using WACe001.Entity.Interface;
using WACe001.Repository;
using WACe001.Repository.Interface;
using WACe001.Service;
using WACe001.Service.Interface;
using WACe001.ViewModel;
using WACe001.ViewModel.Interface;

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
		/// Configure services for the application.
		/// </summary>
		/// <param name="services">
		/// The services to configure.
		/// </param>
		/// <remarks>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		/// Last modification:
		/// Remove non-"true services".
		/// Add transient dependency injection for geo-location service interface and implementation.
		/// </remarks>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<TravelContext>();
			services.AddLogging();

			services.AddMvc().AddJsonOptions
				(
					mvcBuilder =>
					{
						mvcBuilder.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
					}
				);

			// todo|jdevl32: cleanup...
			//services.AddScoped<IAppController, AppController>();
			//services.AddScoped<ICoordinate, Coordinate>();

			// todo|jdevl32: check other environment(s)
			if (HostingEnvironment.IsDevelopment())
			{
				services.AddScoped<IMailService, FakeMailService>();
			} // if
			else
			{
				// todo|jdevl32: implement real mail service...
			} // else

			//services.AddScoped<IStop, Stop>();
			//services.AddScoped<IStopViewModel, StopViewModel>();
			//services.AddScoped<ITravelContext, TravelContext>();
			services.AddScoped<ITravelRepository, TravelRepository>();
			//services.AddScoped<ITrip, Trip>();
			//services.AddScoped<ITripViewModel, TripViewModel>();
			services.AddSingleton(ConfigurationRoot);
			services.AddTransient<IGeoLocationService, GeoLocationService>();
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
		/// Configure auto-mapper.
		/// </remarks>
		public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, ITravelContextSeed travelContextSeed)
		{
			InitializeMapper();

			var logLevel = LogLevel.Error;

			if (hostingEnvironment.IsDevelopment())
			{
				logLevel = LogLevel.Information;
				applicationBuilder.UseDeveloperExceptionPage();
			}

			applicationBuilder.UseMvc
				(
					routeBuilder =>
					{
						routeBuilder.MapRoute
						(
							"Default"
							,
							"{controller}/{action}/{id?}"
							,
							new {controller = "App", action = "Index"}
						);
					}
				);

			applicationBuilder.UseStaticFiles();
			travelContextSeed.EnsureSeed().Wait();
			loggerFactory.AddDebug(logLevel);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Configure mappings for stops.
		/// </remarks>
		private static void InitializeMapper()
		{
			Mapper.Initialize
			(
				config =>
				{
					// todo|jdevl32: cleanup...
					config.CreateMap<IStopViewModel, IStop>().ReverseMap();
					//config.CreateMap<IStopViewModel, Stop>().ReverseMap();
					config.CreateMap<ITripViewModel, ITrip>().ReverseMap();
					//config.CreateMap<ITripViewModel, Trip>().ReverseMap();
					//config.CreateMap<StopViewModel, IStop>().ReverseMap();
					config.CreateMap<StopViewModel, Stop>().ReverseMap();
					//config.CreateMap<TripViewModel, ITrip>().ReverseMap();
					config.CreateMap<TripViewModel, Trip>().ReverseMap();
				}
			);
		}

	}

}
