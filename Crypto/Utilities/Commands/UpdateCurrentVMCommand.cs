using Crypto.Utilities.Navigators;
using Crypto.ViewModels;
using System;

namespace Crypto.Utilities.Commands
{
	public class UpdateCurrentVMCommand : CommandBase
	{
		private Navigator _navigator;
        public UpdateCurrentVMCommand(Navigator navigator)
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
						//if (!(_navigator.CurrentVM is TopCryprocurrenciesVM))
							_navigator.CurrentVM = new TopCryprocurrenciesVM();
						break;
					case ViewType.CurrencyParameters:
						if(!(_navigator.CurrentVM is CurrencyParametersVM))
							_navigator.CurrentVM = new CurrencyParametersVM();
						break;
				}
			}
		}
	}
}
