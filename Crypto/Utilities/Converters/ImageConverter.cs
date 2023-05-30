﻿using Crypto.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Crypto.Utilities.Converters
{
	class ImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
			string path = ((CurrencyModel)value).Symbol.ToLower();
			return $"https://assets.coincap.io/assets/icons/{path}@2x.png";

			}
			catch
			{
				return null;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
