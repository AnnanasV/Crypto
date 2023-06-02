using System.Text;
using System;

namespace Crypto.Utilities.Converters
{
    abstract class ChangeNumberFormat
    {
		public static string ReduceNumber(string number)
		{
			StringBuilder sb = new StringBuilder(number);
			sb.Replace('.', ','); //replace to convert
			number = sb.ToString();
			int digits = 2; // after comma
			int indexPoint = number.LastIndexOf(",");
			int indexZero = indexPoint;
			for (int i = indexPoint + 1; number.Length >= i && number[i] == '0' && indexPoint >= 0; i++)
			{
				++indexZero;
			}
			if (Decimal.TryParse(number, out decimal decimalNumber))
			{
				if (number.Length == indexZero)
					return Math.Round(decimalNumber, 0).ToString();
				if (indexZero == indexPoint)
					return Math.Round(decimalNumber, digits).ToString();
				if (Math.Truncate(decimalNumber) == 0 && number.Length > indexZero + digits + 1)
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

		public static string FormattingNumbers(string number, int afterComma = 3)
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
