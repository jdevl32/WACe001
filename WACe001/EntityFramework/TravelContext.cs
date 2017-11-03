using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WACe001.EntityFramework.Interface;
using WACe001.Model.Interface;

namespace WACe001.EntityFramework
{

    public class TravelContext
		:
		DbContext
		,
		ITravelContext
    {

#region Property

		private IConfigurationRoot ConfigurationRoot { get; }

		public DbSet<IStop> Stops { get; }

		public DbSet<ITrip> Trips { get; }

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

	}

}
