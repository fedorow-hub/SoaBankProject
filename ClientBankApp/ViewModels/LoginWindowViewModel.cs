using ClientBankApp.Infrastructure.Commands;
using ClientBankApp.ViewModels.Base;
using System.Windows;
using System.Windows.Input;
using ClientBankApp.Views;
using ClientBankApp.Models.Worker;

namespace ClientBankApp.ViewModels
{
	public class LoginWindowViewModel : ViewModel
	{
		private readonly ICurrentWorkerService _currentWorkerService;
		public LoginWindowViewModel(ICurrentWorkerService workerService)
		{
			_currentWorkerService = workerService;
			SetConsultantMode = new LambdaCommand(OnSetConsultantModeExecuted, CanSetConsultantModeExecute);
			SetManagerMode = new LambdaCommand(OnSetManagerModeExecuted, CanSetManagerModeExecute);
			OutCommand = new LambdaCommand(OnOutCommandExecuted, CanOutCommandExecute);
		}

		#region Commands

		public ICommand SetConsultantMode { get; }
		private void OnSetConsultantModeExecuted(object p)
		{
			OpenMainWindow(new Consultant(), p);

			if (p is Window window)
			{
				window.Close();
			}
		}
		private bool CanSetConsultantModeExecute(object p) => true;
		#endregion

		#region SetManagerMode
		public ICommand SetManagerMode { get; }
		private void OnSetManagerModeExecuted(object p)
		{
			OpenMainWindow(new Manager(), p);

			if (p is Window window)
			{
				window.Close();
			}
		}
		private bool CanSetManagerModeExecute(object p) => true;

		#endregion

		#region OutCommand
		public ICommand OutCommand { get; }
		private static void OnOutCommandExecuted(object p)
		{
			Application.Current.Shutdown();
		}
		private static bool CanOutCommandExecute(object p) => true;
		#endregion

		private void OpenMainWindow(Worker worker, object p)
		{
			var mainWindow = new MainWindow();
			var mainWindowVm = new MainWindowViewModel(worker, _currentWorkerService);

			mainWindow.DataContext = mainWindowVm;
			mainWindow.Show();

			if (p is Window window)
			{
				window.Close();
			}
		}
	}
}
