using ClientBankApp.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ClientBankApp
{
	public static class Program
	{
		[STAThread]
		public static void Main()
		{
            MyHttpClient.InitialiseHttpClient("https://localhost:7271/api/");
            var app = new App();
			app.InitializeComponent();
			app.Run();			
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseContentRoot(App.CurrentDirectory)
				.ConfigureAppConfiguration((_, cfg) => cfg
					.SetBasePath(App.CurrentDirectory)
					.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true))
				.ConfigureServices(App.ConfigureServices);
	}
}
