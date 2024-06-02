using Bank.Application;
using Bank.Application.Common.Mapping;
using Bank.Application.Interfaces;
using Bank.DAL;
using Bank.DAL.ExchangeRateService;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using SoaBankProject.Middleware;
using SoaBankProject.Services;
using System.Reflection;

//�������� ������������ �������
Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
	.WriteTo.File("SoaAppLog-.txt", rollingInterval:
		RollingInterval.Day)
	.CreateLogger();


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

var configuration = builder.Configuration;

builder.Services.AddAutoMapper(config =>
{
	config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
	config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);

//��� ����� ���� ������ �� �������� �������� ���� ������, ��� ������
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", policy =>
	{
		policy.AllowAnyHeader();
		policy.AllowAnyMethod();
		policy.AllowAnyOrigin();
	});
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var urlExchangeServise = configuration["UrlExchangeService"];

builder.Services.AddSingleton<string>(urlExchangeServise);

builder.Services.AddSingleton<IExchangeRateService, ExchangeRateService>();

builder.Services.AddSingleton<ICurrentWorkerService, CurrentWorkerService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var serviceProvider = scope.ServiceProvider;
	try
	{
		//�������� �������� ��
		var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
		//������������� �� � ������� ����� ���������� ������ DbInitializer
		DbInitializer.Initialize(context);
	}
	catch (Exception exeption)
	{
		Log.Fatal(exeption, "An error occurred while app initialization");
	}
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

//������ UseEndpoints ����� �������, ����� ������� �������� �� �������� ������������ � �� ������
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.Run();
