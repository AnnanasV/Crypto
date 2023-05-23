using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Crypto.Models;

namespace Crypto.Services.APICoinCap
{
	public class CurrencyService : ICryptocurrencyService
	{
		public async Task<IEnumerable<CurrencyModel>> GetCurrency()
		{
			using (var client = new HttpClient())
			{
				string requestUri = "https://api.coincap.io/v2/assets?sort*rank";
				var response = await client.GetAsync(requestUri);

				string jsonResponse = await response.Content.ReadAsStringAsync();
				if (response.IsSuccessStatusCode)
				{
					var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals };
					var data = JsonSerializer.Deserialize<CryptocurrencyList>(jsonResponse, options);

					return data.Cryptocurrencies;
				}
				return null;
			}
		}
	}
}
