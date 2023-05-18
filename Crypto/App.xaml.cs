using Crypto.Services.APICoinCap;
using System.Windows;

namespace Crypto
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override async void OnStartup(StartupEventArgs e)
		{
			CurrencyService currencyService = new CurrencyService();
			var result = await currencyService.GetCurrency();

			base.OnStartup(e);
		}
	}
}
