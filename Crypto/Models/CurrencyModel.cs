﻿using System.Text.Json.Serialization;

namespace Crypto.Models
{
	public class CurrencyModel
	{

		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("rank")]
		public string Rank { get; set; }

		[JsonPropertyName("symbol")]
		public string Symbol { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("changePercent24Hr")]
		public float ChangePercent24Hr { get; set; }

		[JsonPropertyName("supply")]
		public string Supply { get; set; }

		[JsonPropertyName("priceUsd")]
		public string PriceUsd { get; set; }

		[JsonPropertyName("volumeUsd24Hr")]
		public string VolumeUsd24Hr { get; set; }

		[JsonPropertyName("marketCapUsd")]
		public string MarketCapUsd { get; set; }
	}
}
