using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crypto.Services.APICoinCap
{
    public class CurrencyService : ICryptocurrencyService
	{
		public async Task<IEnumerable<Cryptocurrency>> GetCurrency()
		{
			using(var client = new HttpClient())
			{
				string requestUri = "https://api.coincap.io/v2/assets?sort*rank";
				var response = await client.GetAsync(requestUri);

				string jsonResponse = await response.Content.ReadAsStringAsync();

				var data = JsonSerializer.Deserialize<CryptocurrencyList>(jsonResponse, new JsonSerializerOptions()
				{
					PropertyNameCaseInsensitive = true
				});

				return data.Cryptocurrencies;
			}
		}
	}
}
