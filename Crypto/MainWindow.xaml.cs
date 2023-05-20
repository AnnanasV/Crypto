using System;
using System.Windows;
using System.Windows.Controls.Primitives;
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

		private void SwitchColorMode_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Resources.Clear();
			if((sender as ToggleButton).IsChecked ?? false)
			{
				var uri1 = new Uri(@"Utilities/LightTemplate.xaml", UriKind.Relative);
				ResourceDictionary resourceDictionary1 = Application.LoadComponent(uri1) as ResourceDictionary;
				Application.Current.Resources.MergedDictionaries.Add(resourceDictionary1);
			}
			else
			{
				var uri2 = new Uri(@"Utilities/DarkTemplate.xaml", UriKind.Relative);
				ResourceDictionary resourceDictionary2 = Application.LoadComponent(uri2) as ResourceDictionary;
				Application.Current.Resources.MergedDictionaries.Add(resourceDictionary2);
			}
		}

		#region Window operations

		private void Drag(object sender, MouseButtonEventArgs e)
		{
			if(Mouse.LeftButton == MouseButtonState.Pressed)
			{
				Window.DragMove();
			}
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void MinimizeButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.MainWindow.WindowState = WindowState.Minimized;
		}

		#endregion

	}
}
