using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using WACe001.Model;
using WACe001.Model.Interface;

namespace WACe001.Service
{

	public class GeoLocationService
	{

#region Property

		public ILogger<GeoLocationService> Logger { get; }

#endregion

#region Instance Initialization

		public GeoLocationService(ILogger<GeoLocationService> logger) => Logger = logger;

#endregion

		public async Task<IGeoLocationResult> GetCoordinatesAsync(string locationName)
		{
			// todo|jdevl32: default message ???
			var result = new GeoLocationResult("");
			var apiKey = "";
			var encodedName = WebUtility.UrlEncode(locationName);
			var url = $"http://dev.virtualearth.net/REST/v1/Locations?q={encodedName}&key={apiKey}";
		}

	}

}
