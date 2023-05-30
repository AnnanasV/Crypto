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
		public async Task<IEnumerable<CurrencyModel>> GetCurrency(string properties = "")
		{
			using (var client = new HttpClient())
			{
				string requestUri = $"https://api.coincap.io/v2/assets?{properties}";
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

		/// <summary>
		/// Get price of currency
		/// </summary>
		/// <param name="currency">currency id</param>
		/// <param name="interval">m1, m5, m15, m30, h1, h2, h6, h12, d1</param>
		/// <returns></returns>
		public async Task<IEnumerable<HistoryPriceModel>> GetPrices(string currency = "", string interval = "m1")
		{
			using (var client = new HttpClient())
			{
				string requestUri = $"https://api.coincap.io/v2/assets/{currency}/history?interval={interval}";
				var response = await client.GetAsync(requestUri);

				string jsonResponse = await response.Content.ReadAsStringAsync();
				if (response.IsSuccessStatusCode)
				{
					var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals };
					var data = JsonSerializer.Deserialize<HistoryPriceList>(jsonResponse, options);

					return data.HistoryPrices;
				}
				return null;
			}
		}
	}
}
