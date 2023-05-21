using Crypto.Models;
using Crypto.Services.APICoinCap;
using Crypto.Utilities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Crypto.ViewModels
{
	public class TopCryprocurrenciesVM : ViewModelBase
	{
		#region Properties

		private IEnumerable<CurrencyModel> _cryptocurrencies;
		public IEnumerable<CurrencyModel> Cryptocurrencies
		{
			get { return _cryptocurrencies; }
			set { _cryptocurrencies = value; OnPropertyChanged(nameof(Cryptocurrencies)); }
		}

		#endregion

		public TopCryprocurrenciesVM()
		{
			Task.Factory.StartNew(() =>
			{
				while (true)
				{
					GetData();
					Task.Delay(5000).Wait();
				}
			});
		}

		private async void GetData()
		{
			Cryptocurrencies = await new CurrencyService().GetCurrency();
		}

	}
}
