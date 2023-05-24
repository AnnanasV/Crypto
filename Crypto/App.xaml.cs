using Crypto.ViewModels;
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
			MainWindow = new MainWindow() { DataContext = new MainVM() };
			MainWindow.Show();

			base.OnStartup(e);
		}
	}
}
