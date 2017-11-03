namespace WACe001.Entity.Interface
{

	public interface ICoordinate
	{

#region Property

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Must provide a setter -- needed for Entiry Framework.
		/// </remarks>
		double Latitude { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Must provide a setter -- needed for Entiry Framework.
		/// </remarks>
		double Longitude { get; set; }

#endregion

	}

}
