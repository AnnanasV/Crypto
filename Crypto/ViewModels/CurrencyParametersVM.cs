using Crypto.Models;
using Crypto.Services.APICoinCap;
using Crypto.Utilities;
using LiveCharts;
using System.Collections.Generic;
using System.Linq;

namespace Crypto.ViewModels
{
	public class CurrencyParametersVM : ViewModelBase
	{
		public CurrencyParametersVM()
		{
			_currencyService = new CurrencyService();
			GetAllCurrencies();
		}

		#region Properties

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

		private async void GetPrices(string interval = "h1")
		{
			if (SelectedCurrency == null) return;
			_timePrices = await _currencyService.GetPrices(SelectedCurrency.Id, interval);
			Prices = new ChartValues<decimal>(_timePrices.Select(t => t.PriceUsd));
			Times = _timePrices.Select(t => t.Date.ToString("g")).ToArray();
		}

		#endregion
	}
}
