using System;
using WACe001.Entity.Interface;

namespace WACe001.Entity
{

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Implement equatable interface.
	/// </remarks>
	public class Coordinate
		:
		ICoordinate
		,
		IEquatable<Coordinate>
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

#region Equality members

		/// <inheritdoc />
		public bool Equals(Coordinate other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			if (obj.GetType() != GetType())
			{
				return false;
			}

			return Equals((Coordinate) obj);
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			unchecked
			{
				return (Latitude.GetHashCode() * 397) ^ Longitude.GetHashCode();
			}
		}

		public static bool operator ==(Coordinate left, Coordinate right) => Equals(left, right);

		public static bool operator !=(Coordinate left, Coordinate right) => !Equals(left, right);

#endregion

	}

}
