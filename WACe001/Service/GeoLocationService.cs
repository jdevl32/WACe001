using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WACe001.Entity;
using WACe001.Service.Interface;

namespace WACe001.Service
{

	public class GeoLocationService
		:
		ServiceBase<GeoLocationService>
		,
		IGeoLocationService
	{

#region Property

#endregion

#region Instance Initialization

		/// <inheritdoc />
		public GeoLocationService(IConfigurationRoot configurationRoot, ILogger<GeoLocationService> logger)
			:
			base(configurationRoot, logger)
		{
		}

#endregion

		/// <inheritdoc />
		public async Task<IGeoLocationResult> GetCoordinatesAsync(string locationName)
		{
			// todo|jdevl32: contant(s)...
			var result = new GeoLocationResult($"Location \"{locationName}\" could not be found.");
			var apiKey = ConfigurationRoot["Key:API:Bing:Maps"];
			var encodedName = WebUtility.UrlEncode(locationName);
			var url = $"http://dev.virtualearth.net/REST/v1/Locations?q={encodedName}&key={apiKey}";

			// todo|jdevl32: future consideration(s):
			// Good candidate for creating base/helper class(es)...

			//
			// The following code block is sensitive to changes from Bing Maps API.
			//

			{
				// todo|jdevl32: contant(s)...
				JToken jToken;

				using (var httpClient = new HttpClient())
				{
					jToken = JObject.Parse(await httpClient.GetStringAsync(url))["resoureSets"][0]["resources"][0];
				} // using
			
				if (jToken.HasValues)
				{
					jToken = jToken[0];
					var confidence = (string) jToken["confidence"];

					switch (confidence)
					{
						case "High":
							jToken = jToken["geocodePoints"][0]["coordinates"];
							result.Coordinate = new Coordinate((double) jToken[0], (double) jToken[1]);
							result.Message = $"Location \"{locationName}\" found at {result.Coordinate}";
							result.Success = true;
							break;

						default:
							result.Message = $"Location \"{locationName}\" could not be found with high confidence ({confidence}).";
							break;
					} // switch
				} // if
			}

			return result;
		}

	}

}
