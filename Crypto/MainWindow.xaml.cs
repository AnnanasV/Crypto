using System.Windows;
using System.Windows.Input;

namespace Crypto
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static MainWindow Window;
		public MainWindow()
		{
			InitializeComponent();
			Window = this;
		}
		
		private void Drag(object sender, MouseButtonEventArgs e)
		{
			if(Mouse.LeftButton == MouseButtonState.Pressed)
			{
				MainWindow.Window.DragMove();
			}
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
