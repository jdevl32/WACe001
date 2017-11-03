using WACe001.Entity.Interface;

namespace WACe001.Entity
{

    public class Coordinate
		:
		ICoordinate
    {

#region Property

		/// <inheritdoc />
		public double Latitude { get; set; }

		/// <inheritdoc />
		public double Longitude { get; set; }

#endregion

#region Instance Initialization

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Parameterless constructor required by Entity Framework.
		/// </remarks>
		public Coordinate()
		{
		}

		public Coordinate(double latitude, double longitude)
		{
			Latitude = latitude;
			Longitude = longitude;
		}

#endregion

	}

}
