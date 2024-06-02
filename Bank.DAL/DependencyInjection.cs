using Microsoft.Extensions.DependencyInjection;
using Bank.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bank.DAL
{
	public static class DependencyInjection
	{

		//public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
		//{
		//	services.AddDbContext<ApplicationDbContext>(options =>
		//	{
		//		options.UseSqlite(connectionString);
		//	});
		//	services.AddScoped<IApplicationDbContext>(provider => 
		//		provider.GetService<ApplicationDbContext>() ?? throw new InvalidOperationException());

		//	return services;
		//}

		public static IServiceCollection AddPersistence(this IServiceCollection services,
		IConfiguration configuration)
		{
			var connectionString = configuration["DbConnection"];
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlite(connectionString);
			});
			services.AddScoped<IApplicationDbContext>(provider =>
				provider.GetService<ApplicationDbContext>() ?? throw new InvalidOperationException());
			return services;
		}
	}
}
