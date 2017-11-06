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
		/// Create a new (empty) coordinate.
		/// </summary>
		/// <remarks>
		/// Parameterless constructor required by Entity Framework.
		/// </remarks>
		public Coordinate()
		{
		}

		/// <summary>
		/// Create a new coordinate.
		/// </summary>
		/// <param name="latitude">
		/// The coordinate latitude point.
		/// </param>
		/// <param name="longitude">
		/// The coordinate longitude point.
		/// </param>
		/// <remarks>
		/// 
		/// </remarks>
		public Coordinate(double latitude, double longitude)
		{
			Latitude = latitude;
			Longitude = longitude;
		}

#endregion

#region Object

		/// <inheritdoc />
		public override string ToString() => $"[({Latitude},{Longitude})]";

#endregion

	}

}
