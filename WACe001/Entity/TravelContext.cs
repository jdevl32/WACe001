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
		public DbSet<Stop> Stop { get; set; }

		/// <inheritdoc />
		public DbSet<Trip> Trip { get; set; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <summary>
		/// Create a travel context.
		/// </summary>
		/// <param name="configurationRoot">
		/// 
		/// </param>
		/// <param name="dbContextOptions">
		/// 
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public TravelContext(IConfigurationRoot configurationRoot, DbContextOptions dbContextOptions)
			:
			base(dbContextOptions) => ConfigurationRoot = configurationRoot;

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
		/// </remarks>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
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
