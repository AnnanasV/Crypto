using Crypto.Models;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Crypto.Utilities.Converters
{
	class PercentsToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			float percent = (float)((CurrencyModel)value).ChangePercent24Hr;
			if (percent > 0)
				return new SolidColorBrush(Color.FromRgb(135, 201, 131));
			else return new SolidColorBrush(Colors.Red);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
