using System.Collections.Generic;
using System.Text.Json.Serialization;
using Crypto.Models;

namespace Crypto.Services.APICoinCap
{
    public class CryptocurrencyList
	{
		[JsonPropertyName("data")]
		public IEnumerable<CurrencyModel> Cryptocurrencies { get; set; }
	}
}
