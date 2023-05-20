using Crypto.Utilities;

namespace Crypto.ViewModels
{
	public class MainVM
	{
		public ViewModelBase CurrentViewModel { get; }

        public MainVM()
        {
            CurrentViewModel = new TopCryprocurrenciesVM();
        }
    }
}
