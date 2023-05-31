using Crypto.Models;
using System;
using System.Globalization;
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
				value = ChangeNumberFormat.ReduceNumber(value.ToString());
			}
			value = ChangeNumberFormat.FormattingNumbers(value.ToString());

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
