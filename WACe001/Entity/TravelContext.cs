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

		private IConfigurationRoot ConfigurationRoot { get; }

		/// <inheritdoc />
		public DbSet<Stop> Stops { get; set; }

		/// <inheritdoc />
		public DbSet<Trip> Trips { get; set; }

#endregion

#region Instance Initialization

		public TravelContext(IConfigurationRoot configurationRoot, DbContextOptions dbContextOptions)
			:
			base(dbContextOptions) => ConfigurationRoot = configurationRoot;

#endregion

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
		/// </param>
		/// <remarks>
		/// This is required to support the Coordinate composite primary key.
		/// </remarks>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Coordinate>().HasKey(coordinate => new { coordinate.Latitude, coordinate.Longitude });
		}

	}

}
