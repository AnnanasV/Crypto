using Crypto.Models;
using Crypto.Services.APICoinCap;
using Crypto.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Crypto.ViewModels
{
	public class TopCryprocurrenciesVM : ViewModelBase, IDisposable
	{

		#region Properties

		private string _searchText;
		public string SearchText
		{
			get { return _searchText; }
			set { _searchText = value; OnPropertyChanged(nameof(SearchText)); SetSelected(); }
		}

		private IEnumerable<CurrencyModel> _selectedCurrencies;
		public IEnumerable<CurrencyModel> SelectedCurrencies
		{
			get { return _selectedCurrencies; }
			set { _selectedCurrencies = value; OnPropertyChanged(nameof(SelectedCurrencies)); }
		}

		private CurrencyService _currencyService;
		private object _syncData = new object();
		private bool _isJobData = false;
		private volatile bool _isDisposed = false;

		#endregion


		public TopCryprocurrenciesVM()
		{
			_currencyService = new CurrencyService();
			CheckJobUpdateData();
		}

		#region Set data methods

		private void CheckJobUpdateData()
		{
			if (!_isJobData)
			{
				bool isStart = false;
				lock (_syncData)
				{
					if (!_isJobData)
						_isJobData = isStart = true;
				}
				if (isStart)
				{
					Task.Run(async () =>
					{
						while (true)
						{
							lock (_syncData)
							{
								isStart = _isJobData;
							}
							if (!isStart)
								break;
							SetSelected();
							Thread.Sleep(5000);
						}
					});
				}
			}
		}

		private async void SetSelected()
		{
			var text = SearchText?.ToLower() ?? string.Empty;
			StringBuilder prop = new StringBuilder("");
			var currencies = await new CurrencyService().GetCurrency();
			if (!string.IsNullOrEmpty(text))
			{
				prop.Append("ids=");
				foreach (var currency in currencies.Where(s => s.Name.ToLower().StartsWith(text) || s.Symbol.ToLower().StartsWith(text)))
				{
					prop.Append(currency.Id);
					prop.Append(',');
				}
				prop.Remove(prop.Length - 1, 1);
			}
			SelectedCurrencies = await _currencyService.GetCurrency(prop.ToString());
		}

		#endregion

		public void Dispose()
		{
			if (_isDisposed) return;
			_isDisposed = true;
			lock (_syncData)
			{
				_isJobData = false;
			}
		}
	}
}