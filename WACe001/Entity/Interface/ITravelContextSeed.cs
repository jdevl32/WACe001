using System.Threading.Tasks;

namespace WACe001.Entity.Interface
{

	public interface ITravelContextSeed
	{

#region Property

		/// <summary>
		/// The travel database context.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Re-declare in interface.
		/// </remarks>
		TravelContext TravelContext { get; }

#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		Task EnsureSeed();

	}

}
