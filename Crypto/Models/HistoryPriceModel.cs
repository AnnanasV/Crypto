using System;
using System.Text.Json.Serialization;

namespace Crypto.Models
{
    public class HistoryPriceModel
    {
		[JsonPropertyName("priceUsd")]
		public string PriceUsd { get; set; }

		[JsonPropertyName("date")]
		public DateTime Date { get; set; }
	}
}
