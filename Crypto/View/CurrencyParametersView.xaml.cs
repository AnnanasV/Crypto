﻿using Crypto.Utilities.Converters;
using System.Windows.Controls;

namespace Crypto.View
{
	/// <summary>
	/// Interaction logic for CurrencyParametersView.xaml
	/// </summary>
	public partial class CurrencyParametersView : UserControl
	{
		public CurrencyParametersView()
		{
			InitializeComponent();
			PricesChartAxisY.LabelFormatter = value => $"${ChangeNumberFormat.ReduceNumber(((decimal)value).ToString())}";
		}
	}
}
