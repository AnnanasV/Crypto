using Crypto.Models;
using Crypto.Services.APICoinCap;
using Crypto.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.ViewModels
{
	public class TopCryprocurrenciesVM : ViewModelBase
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

		#endregion


		public TopCryprocurrenciesVM()
		{
			GetData();
		}


		#region Set data methods

		private async void GetData()
		{
			await Task.Run(async () =>
			{
				while (true)
				{
					SetSelected();
					Task.Delay(5000).Wait();
				}
			});
		}

		private async void SetSelected()
		{
			var text = SearchText?.ToLower() ?? string.Empty;
			StringBuilder prop = new StringBuilder("");
			var currencies = await new CurrencyService().GetCurrency();
			if (!string.IsNullOrEmpty(text))
			{
				prop.Append("ids=");
				foreach (var currency in currencies.Where(s => s.Name.ToLower().StartsWith(text) || s.Symbol.ToLower().StartsWith(text) ))
				{
					prop.Append(currency.Id);
					prop.Append(',');
				}
				prop.Remove(prop.Length - 1, 1);
			}
			SelectedCurrencies = await new CurrencyService().GetCurrency(prop.ToString());
		}

		#endregion

	}
}
