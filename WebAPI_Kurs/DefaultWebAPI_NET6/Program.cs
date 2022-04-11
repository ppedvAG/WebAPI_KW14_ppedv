//Keine Main Methode mehr -> Top Level Statements


using DefaultWebAPI_NET6.Services;
using Microsoft.Extensions.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services = IServiceCollection        
//In NET 5 w�re dieser Part die -> public void ConfigureServices(IServiceCollection services) - Methode
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICar, MockCar>();
//builder.Services.AddSingleton<ICar, Car>(); //ICar / MockCar wird �berschrieben mit -> ICar / Car
//builder.Services.AddScoped<ICar, Car>(); //ICar / MockCar wird �berschrieben mit -> ICar / Car
WebApplication app = builder.Build(); //Ab hier wird der IServiceProvider verwendet 


//Fr�hester Zugriff auf IOC Container
using (IServiceScope scope = app.Services.CreateScope())
{
    ICar mockCar = scope.ServiceProvider.GetService<ICar>();
}
//Fixe Testdaten k�nnte man in .NET 2.1 manier hinzuf�gen 



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
