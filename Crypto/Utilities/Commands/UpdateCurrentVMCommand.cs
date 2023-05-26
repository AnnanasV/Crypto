using Crypto.Utilities.Navigators;
using Crypto.ViewModels;

namespace Crypto.Utilities.Commands
{
	public class UpdateCurrentVMCommand : CommandBase
	{
		private INavigator _navigator;
        public UpdateCurrentVMCommand(INavigator navigator)
        {
			_navigator = navigator;
        }

        public override void Execute(object? parameter)
		{
			if(parameter is ViewType)
			{
				ViewType viewType = (ViewType)parameter;
				switch(viewType)
				{
					case ViewType.TopCurrencies:
						_navigator.CurrentVM = new TopCryprocurrenciesVM();
						break;
					case ViewType.Exchange:
						_navigator.CurrentVM = new CurrencyExchangeVM();
						break;
				}
			}
		}
	}
}
