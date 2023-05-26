using Crypto.Utilities.Navigators;
using Crypto.ViewModels;
using System;

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
				if (_navigator.CurrentVM is IDisposable)
					((IDisposable)_navigator.CurrentVM).Dispose();
				switch (viewType)
				{
					case ViewType.TopCurrencies:
							_navigator.CurrentVM = new TopCryprocurrenciesVM();
						break;
					case ViewType.Exchange:
						if (!(_navigator.CurrentVM is CurrencyExchangeVM))
							_navigator.CurrentVM = new CurrencyExchangeVM();
						break;
				}
			}
		}
	}
}
