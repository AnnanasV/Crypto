using Crypto.Utilities.Navigators;

namespace Crypto.ViewModels
{
	public class MainVM
	{
		public INavigator Navigator { get; set; } = new Navigator();
    }
}