using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
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
		/// For more information on Core 1.x -> 2.x migration, visit https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/identity-2x
		/// Last modification:
		/// Configure redirect to login (to setup identity authentication).
		/// </remarks>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<TravelContext>();

			// todo|jdevl32: constant(s)...
			services
				.AddIdentity<Traveler, IdentityRole>
					(
						identityOptions =>
						{
							identityOptions.Password.RequiredLength = 5;
							identityOptions.User.RequireUniqueEmail = true;
						}
					)
				.AddEntityFrameworkStores<TravelContext>();

			// Application cookie is no longer part of identity options (above).
			services.ConfigureApplicationCookie
				(
					options =>
					{
						options.Events = new CookieAuthenticationEvents
						{
							// Take over responsibility for redirect to login.
							OnRedirectToLogin = async context =>
							{
								// Only if the request is an API call and response status code ok (200).
								if (context.Request.Path.StartsWithSegments("/api") && 200 == context.Response.StatusCode)
								{
									// Set the response status code to unauthorized (401).
									context.Response.StatusCode = 401;
								} // if
								else
								{
									// Otherwise, simply redirect.
									context.Response.Redirect(context.RedirectUri);
								} // else

								await Task.Yield();
							}
						};
						options.LoginPath = "/Auth/Login";
					}
				);

			services.AddLogging();

			services
				.AddMvc
					(
						mvcOptions =>
						{
							// todo|jdevl32: HTTPS only required in production ???
							if (HostingEnvironment.IsProduction())
							{
								mvcOptions.Filters.Add(typeof(RequireHttpsAttribute));
							} // if
						}
					)
				.AddJsonOptions
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
		/// Configure the application.
		/// </summary>
		/// <param name="applicationBuilder">
		/// The application builder.
		/// </param>
		/// <param name="hostingEnvironment">
		/// The hosting environment.
		/// </param>
		/// <param name="loggerFactory">
		/// The logger factory.
		/// </param>
		/// <param name="travelContextSeed">
		/// The travel database context seeder.
		/// </param>
		/// <remarks>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// Last modification:
		/// Configure authentication.
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

			loggerFactory.AddDebug(logLevel);

			//
			// Order is impoortant:
			// 

			// 1. Static files.
			applicationBuilder.UseStaticFiles();

			// 2. Authentication
			// todo|jdevl32: verify...
			// Method "UseIdentity" is obsolete -- this is the replacement.
			applicationBuilder.UseAuthentication();

			// 3. MVC -- typically last
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

			// Enable/disable as needed (i.e., disable when rebuilding database).
			travelContextSeed.Seed().Wait();
		}

		/// <summary>
		/// Initialize and configure auto-mapper mappings.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Configure mapping for coordinate.
		/// </remarks>
		private static void InitializeMapper()
		{
			Mapper.Initialize
			(
				expression =>
				{
					// todo|jdevl32: cleanup...
					expression.CreateMap<Coordinate, ICoordinate>()
						.ConstructUsing(coordinate => new Coordinate(/*coordinate.Latitude, coordinate.Longitude*/))
						.ReverseMap();
					expression.CreateMap<IStopViewModel, IStop>().ReverseMap();
					//config.CreateMap<IStopViewModel, Stop>().ReverseMap();
					expression.CreateMap<ITripViewModel, ITrip>().ReverseMap();
					//config.CreateMap<ITripViewModel, Trip>().ReverseMap();
					//config.CreateMap<StopViewModel, IStop>().ReverseMap();
					expression.CreateMap<StopViewModel, Stop>().ReverseMap();
					//config.CreateMap<TripViewModel, ITrip>().ReverseMap();
					expression.CreateMap<TripViewModel, Trip>().ReverseMap();
				}
			);
		}

	}

}
