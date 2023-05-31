using Crypto.Models;
using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Crypto.Utilities.Converters
{
	class NumberConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null) return null;
			if (parameter != null && parameter.ToString() == nameof(CurrencyModel.PriceUsd))
			{
				value = ReduceNumber(value.ToString());
			}
			value = FormattingNumbers(value.ToString());

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

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
			k, // Thousand
			m, // Million
			b, // Billion
			t, // Trillion
			q  // Quadrillion
		}

		private string FormattingNumbers(string number, int afterComma = 3)
		{
			StringBuilder num = new StringBuilder(number);
			num.Replace('.', ',');
			int currentDigit = 0;
			int commaIndex = num.ToString().IndexOf(',');
			for (int i = commaIndex; i >= 0; i -= 3)
			{
				if (i - 3 > 0)
				{
					currentDigit++;
					num.Insert(i - 3, ',');
					num.Remove(i + 1, 1);
					commaIndex -= 3;
				}
			}
			Decimal.TryParse(num.ToString(), out decimal numberDecimal);
			if (currentDigit == 0 && (int)numberDecimal > 0) { afterComma = 2; }
			if ((int)numberDecimal != 0) numberDecimal = Math.Round(numberDecimal, afterComma);
			num.Clear();
			num.Append(numberDecimal.ToString());
			if (num.Length - (commaIndex + 1) > 3 && (int)numberDecimal > 0 && currentDigit != 0)
			{
				num.Insert(commaIndex + 4, '.');
			}

			if (currentDigit != 0)
				num.Append(Enum.GetName(typeof(_suffixes), currentDigit));

			return num.ToString();
		}

	}
}
