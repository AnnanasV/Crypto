using System;
using System.Text;
using System.Text.Json.Serialization;

namespace Crypto.Models
{
	public class CurrencyModel
	{
		#region Properties

		[JsonPropertyName("rank")]
		public string Rank { get; set; }

		[JsonPropertyName("symbol")]
		public string Symbol { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("changePercent24Hr")]
		public float ChangePercent24Hr { get; set; }

		#endregion

		#region Change properties

		private string _supply;
		[JsonPropertyName("supply")]
		public string Supply
		{
			get { return FormattingNumbers(_supply); }
			set { _supply = value; }
		}

		private string _priceUsd;
		[JsonPropertyName("priceUsd")]
		public string PriceUsd
		{
			get
			{
				return FormattingNumbers(ReduceNumber(_priceUsd), 5);
			}
			set
			{
				_priceUsd = value;
			}
		}

		private string _volumeUsd24Hr;
		[JsonPropertyName("volumeUsd24Hr")]
		public string VolumeUsd24Hr
		{
			get
			{
				return FormattingNumbers(_volumeUsd24Hr, 2);
			}
			set
			{
				_volumeUsd24Hr = value;
			}
		}

		#endregion

		#region Change format
		private string ReduceNumber(string number)
		{
			StringBuilder sb = new StringBuilder(number);
			sb.Replace('.', ','); //replace to convert
			number = sb.ToString();
			int digits = 2; // after comma
			int indexPoint = number.LastIndexOf(",");
			int indexZero = indexPoint;
			for (int i = indexPoint + 1; number[i] == '0'; i++)
			{
				++indexZero;
			}
			if (Decimal.TryParse(number, out decimal decimalNumber))
			{
				if (number.Length == indexZero)
					return Math.Round(decimalNumber, 0).ToString();
				if (indexZero == indexPoint)
					return Math.Round(decimalNumber, digits).ToString();
				if (Math.Truncate(decimalNumber) == 0)
				{
					return number.Substring(0, indexZero + digits + 1);
				}
				return Math.Round(decimalNumber, indexZero - indexPoint + digits).ToString();
			}

			return Math.Round(decimalNumber, 2).ToString(); ;
		}

		private enum _suffixes
		{
			c, // < Thousand
			K, // Thousand
			M, // Million
			B, // Billion
		}

		private string FormattingNumbers(string number, int digits = 3)
		{
			StringBuilder sb = new StringBuilder(number);
			sb.Replace('.', ','); //replace to convert
			number = sb.ToString();
			int digitsBefore = (digits / 3) * 3; // Before comma
			int digitsAfter = digits % 3; // After comma
			if (digits < 3) { digitsBefore = digits; digitsAfter = 0; }
			double underNumber = 0;
			double.TryParse(number, out double doubleNumber);
			sb = new StringBuilder("00");
			foreach (_suffixes suffix in Enum.GetValues<_suffixes>())
			{
				double currentValue = Math.Pow(10, (int)suffix * 3);
				double previousValue = Math.Pow(10, ((int)suffix - 1) * 3);
				if (currentValue == 1) previousValue = currentValue;
				string? suffixValue = Enum.GetName(typeof(_suffixes), (int)suffix);
				if (suffix == 0) suffixValue = "";
				if (doubleNumber >= currentValue)
				{
					sb.Clear();
					underNumber = doubleNumber % previousValue;
					sb.Append(Math.Round(underNumber * Math.Pow(10, digitsAfter))); // for example, 0.669 => 67
					if (digitsAfter == 0 || doubleNumber < 1000)
					{
						number = $"{Math.Round(doubleNumber / currentValue, digitsBefore)}{suffixValue}";
					}
					else
					{
						number = $"{Math.Round(doubleNumber / currentValue, digitsBefore)}.{sb}{suffixValue}";
					}
				}
				else
					return number;
			}
			return number;
		}

		#endregion
	}
}
