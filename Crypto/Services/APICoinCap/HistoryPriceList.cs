using Crypto.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Crypto.Services.APICoinCap
{
    public class HistoryPriceList
    {
		[JsonPropertyName("data")]
		public IEnumerable<HistoryPriceModel> HistoryPrices { get; set; }
	}
}
