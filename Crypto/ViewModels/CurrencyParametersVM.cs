using Crypto.Models;
using Crypto.Services.APICoinCap;
using Crypto.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crypto.ViewModels
{
	public class CurrencyParametersVM : ViewModelBase
	{
		#region Properties

		private CurrencyModel _selectedCurrency;
		public CurrencyModel SelectedCurrency
		{
			get { return _selectedCurrency; }
			set { _selectedCurrency = value; OnPropertyChanged(nameof(SelectedCurrency)); }
		}


		private IEnumerable<CurrencyModel> _currencies;
		public IEnumerable<CurrencyModel> Currencies
		{
			get { return _currencies; }
			set { _currencies = value; OnPropertyChanged(nameof(Currencies)); }
		}


		private IEnumerable<HistoryPriceModel> _timePrices;
		public IEnumerable<HistoryPriceModel> TimePrices
		{
			get { return _timePrices; }
			set { _timePrices = value; OnPropertyChanged(nameof(TimePrices)); }
		}

		private CurrencyService _currencyService { get; set; }

		#endregion

		public CurrencyParametersVM()
		{
			_currencyService = new CurrencyService();
			GetAllCurrencies();

		}

		#region Methods

		private async void GetAllCurrencies()
		{
			Currencies = await _currencyService.GetCurrency("sort*rank");
		}

		private async void GetPrices()
		{
			// TODO: Add prices, then draw the chart.
		}

		#endregion
	}
}
