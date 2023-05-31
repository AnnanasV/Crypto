using System;
using System.Text.Json.Serialization;

namespace Crypto.Models
{
    public class HistoryPriceModel
    {
		[JsonPropertyName("priceUsd")]
		public decimal PriceUsd { get; set; }

		[JsonPropertyName("date")]
		public DateTime Date { get; set; }

		[JsonPropertyName("time")]
		public long Time { get; set; }
	}
}
