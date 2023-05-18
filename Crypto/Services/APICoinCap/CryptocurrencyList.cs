using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Crypto.Services.APICoinCap
{
    public class CryptocurrencyList
	{
		[JsonPropertyName("data")]
		public IEnumerable<Cryptocurrency> Cryptocurrencies { get; set; }
	}
}
