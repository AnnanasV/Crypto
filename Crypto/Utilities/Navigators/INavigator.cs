using System.Windows.Input;

namespace Crypto.Utilities.Navigators
{
	public enum ViewType
	{
		TopCurrencies,
		CurrencyParameters
	}

	public interface INavigator
	{
		ViewModelBase CurrentVM { get; set; }
		ICommand UpdateCurrentViewCommand { get; }
	}
}
