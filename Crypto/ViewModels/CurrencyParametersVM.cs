using Crypto.Models;
using Crypto.Services.APICoinCap;
using Crypto.Utilities;
using Crypto.Utilities.Commands;
using LiveCharts;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Crypto.ViewModels
{
	public enum Intervals
	{
		m1,
		m5,
		m15,
		m30,
		h1,
		h2,
		h6,
		h12,
		d1
	}

	public class CurrencyParametersVM : ViewModelBase
	{
		public CurrencyParametersVM()
		{
			_currencyService = new CurrencyService();
			GetAllCurrencies();
		}

		#region Properties
		
		public ICommand IsCheckedCommand => new SetIntervalCommand(this);

		private string _interval = "h1";
		public string Interval
		{
			get => _interval;
			set { _interval = value; OnPropertyChanged(nameof(Interval)); GetPrices(); }
		}

		private CurrencyModel _selectedCurrency;
		public CurrencyModel SelectedCurrency
		{
			get { return _selectedCurrency; }
			set { _selectedCurrency = value; OnPropertyChanged(nameof(SelectedCurrency)); GetPrices(); }
		}

		private IEnumerable<CurrencyModel> _currencies;
		public IEnumerable<CurrencyModel> Currencies
		{
			get { return _currencies; }
			set { _currencies = value; OnPropertyChanged(nameof(Currencies)); }
		}

		private ChartValues<decimal> _prices;
		public ChartValues<decimal> Prices
		{
			get { return _prices; }
			set { _prices = value; OnPropertyChanged(nameof(Prices)); }
		}

		private string[] _times;
		public string[] Times
		{
			get { return _times;  }
			set { _times = value; OnPropertyChanged(nameof(Times)); }
		}

		private IEnumerable<HistoryPriceModel> _timePrices;
		private CurrencyService _currencyService { get; set; }

		#endregion

		#region Methods

		private async void GetAllCurrencies()
		{
			Currencies = await _currencyService.GetCurrency();
		}

		private async void GetPrices()
		{
			if (SelectedCurrency == null) return;
			_timePrices = await _currencyService.GetPrices(SelectedCurrency.Id, Interval);
			Prices = new ChartValues<decimal>(_timePrices.Select(t => t.PriceUsd));
			Times = _timePrices.Select(t => t.Date.ToString("g")).ToArray();
		}

		#endregion
	}
}
