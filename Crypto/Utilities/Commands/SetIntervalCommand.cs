using Crypto.ViewModels;
using System;

namespace Crypto.Utilities.Commands
{
	public class SetIntervalCommand : CommandBase
	{
		private CurrencyParametersVM _currencyParametersVM;
		public SetIntervalCommand(CurrencyParametersVM currencyParametersVM)
        {
            _currencyParametersVM = currencyParametersVM;
        }
        public override void Execute(object? parameter)
		{
			if(parameter is Intervals)
			{
                Intervals intervals = (Intervals)parameter;
				_currencyParametersVM.Interval = Enum.GetName(typeof(Intervals), intervals);
			}
		}
	}
}
