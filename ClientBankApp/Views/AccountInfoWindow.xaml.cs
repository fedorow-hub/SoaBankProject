using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ClientBankApp.Views
{
	/// <summary>
	/// Логика взаимодействия для AccountInfoWindow.xaml
	/// </summary>
	public partial class AccountInfoWindow : Window
	{
		public AccountInfoWindow()
		{
			InitializeComponent();
		}

		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			var regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}
	}
}
