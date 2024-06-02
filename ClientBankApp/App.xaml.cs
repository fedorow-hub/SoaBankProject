using ClientBankApp.Models.Worker;
using ClientBankApp.Services;
using ClientBankApp.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ClientBankApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static bool IsDesignMode { get; private set; } = true;

		private static IHost _host;
		public static IHost Host =>
			_host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

		public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
		{
			//сюда добавляем необходимые сервисы

			services.AddViewModels();

			services.AddSingleton<ICurrentWorkerService, CurrentWorkerService>();
		}

		protected override async void OnStartup(StartupEventArgs e)
		{
			IsDesignMode = false;
			var host = Host;
			base.OnStartup(e);
			await host.StartAsync().ConfigureAwait(false);
		}

		protected override async void OnExit(ExitEventArgs e)
		{
			var host = Host;
			base.OnExit(e);
			await host.StopAsync().ConfigureAwait(false);
			host.Dispose();
			_host = null;
		}

		public static string CurrentDirectory => IsDesignMode
			? Path.GetDirectoryName(GetSourceCodePath())
			: Environment.CurrentDirectory;

		private static string? GetSourceCodePath([CallerFilePath] string? path = null) => path;
	}

}
