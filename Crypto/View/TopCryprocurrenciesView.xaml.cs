﻿using Crypto.Utilities.Navigators;
using System.Windows;
using System.Windows.Controls;

namespace Crypto.View
{
	/// <summary>
	/// Interaction logic for TopCryprocurrenciesView.xaml
	/// </summary>
	public partial class TopCryprocurrenciesView : UserControl
	{
		public TopCryprocurrenciesView()
		{
			InitializeComponent();
			ResizeColumnsWidth(TopCurrenciesGV);
		}

		private void ResizeColumnsWidth(GridView gridView)
		{
			if (gridView != null)
			{
				foreach (var col in gridView.Columns)
				{
					if (double.IsNaN(col.Width)) col.Width = col.ActualWidth;
					col.Width = double.NaN;
				}
			}
		}
	}
}
