using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WACe001.Entity.Interface;

namespace WACe001.Entity
{

	public class TravelContext
		:
		DbContext
		,
		ITravelContext
	{

#region Property

		/// <inheritdoc />
		public IConfigurationRoot ConfigurationRoot { get; }

		/// <inheritdoc />
		public DbSet<Coordinate> Coordinate { get; set; }

		/// <inheritdoc />
		public IHostingEnvironment HostingEnvironment { get; }

		/// <inheritdoc />
		public DbSet<Stop> Stop { get; set; }

		/// <inheritdoc />
		public DbSet<Trip> Trip { get; set; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <summary>
		/// Create a travel context.
		/// </summary>
		/// <param name="dbContextOptions">
		/// The database context options.
		/// </param>
		/// <param name="configurationRoot">
		/// The configuration root.
		/// </param>
		/// <param name="hostingEnvironment">
		/// The hosting environment of the application.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Add hosting environment.
		/// </remarks>
		public TravelContext(DbContextOptions dbContextOptions, IConfigurationRoot configurationRoot, IHostingEnvironment hostingEnvironment)
			:
			base(dbContextOptions)
		{
			ConfigurationRoot = configurationRoot;
			HostingEnvironment = hostingEnvironment;
		}

#endregion

		/// <inheritdoc />
		/// <summary>
		/// 
		/// </summary>
		/// <param name="optionsBuilder">
		/// 
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Enable sensitive data logging (depending on hosting environment).
		/// </remarks>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			if (HostingEnvironment.IsDevelopment())
			{
				optionsBuilder.EnableSensitiveDataLogging();
			} // if

			optionsBuilder.UseSqlServer(ConfigurationRoot["ConnectionStrings:TravelConnection"]);
		}

		/// <inheritdoc />
		/// <summary>
		/// 
		/// </summary>
		/// <param name="modelBuilder">
		/// 
		/// </param>
		/// <remarks>
		/// This is required to support the Coordinate composite primary key.
		/// Last modification:
		/// </remarks>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Coordinate>().HasKey(coordinate => new { coordinate.Latitude, coordinate.Longitude });
		}

	}

}
