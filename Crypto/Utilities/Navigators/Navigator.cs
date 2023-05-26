using Crypto.Utilities.Commands;
using Crypto.ViewModels;
using System.Windows.Input;

namespace Crypto.Utilities.Navigators
{
	public class Navigator : ViewModelBase, INavigator
	{
        public Navigator()
        {
			CurrentVM = new TopCryprocurrenciesVM();
        }

        private ViewModelBase _currentVM;
		public ViewModelBase CurrentVM
		{
			get { return _currentVM; }
			set { _currentVM = value; OnPropertyChanged(nameof(CurrentVM)); }
		}

		public ICommand UpdateCurrentViewCommand => new UpdateCurrentVMCommand(this);
	}
}
