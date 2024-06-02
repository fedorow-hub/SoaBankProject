using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ClientBankApp.Views.DialogWindows
{
	/// <summary>
	/// Логика взаимодействия для AddDialogWindow.xaml
	/// </summary>
	public partial class AddDialogWindow : Window
	{
		public AddDialogWindow()
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
