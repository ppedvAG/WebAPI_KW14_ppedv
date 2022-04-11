//Keine Main Methode mehr -> Top Level Statements


using DefaultWebAPI_NET6.Services;
using Microsoft.Extensions.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services = IServiceCollection        
//In NET 5 wäre dieser Part die -> public void ConfigureServices(IServiceCollection services) - Methode
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICar, MockCar>();
//builder.Services.AddSingleton<ICar, Car>(); //ICar / MockCar wird überschrieben mit -> ICar / Car
//builder.Services.AddScoped<ICar, Car>(); //ICar / MockCar wird überschrieben mit -> ICar / Car
WebApplication app = builder.Build(); //Ab hier wird der IServiceProvider verwendet 


//Frühester Zugriff auf IOC Container
using (IServiceScope scope = app.Services.CreateScope())
{
    ICar mockCar = scope.ServiceProvider.GetService<ICar>();
}
//Fixe Testdaten könnte man in .NET 2.1 manier hinzufügen 



//NET 5 Confiugre Methode->  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
