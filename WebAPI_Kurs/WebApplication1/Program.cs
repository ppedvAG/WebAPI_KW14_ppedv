using ControllerSamples.Data;
using WebApiContrib.Core.Formatter.Csv;
using Serilog;
using Serilog.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ControllerSamples.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDbContext")));



builder.Services.AddDbContext<ContactDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactDbContext")));


//HttpClient wird via IHttpClient Factory in Service (Konstruktur Injection) zur Verfügung gestellt
builder.Services.AddHttpClient<IVideoService, VideoService>();
builder.Services.AddTransient<IFileService, FileService>();


Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("Log\\log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();









builder.Services.AddControllers()
    .AddXmlSerializerFormatters()
    .AddCsvSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IContactRepository, ContactRepository>();


builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



// Add services to the container.
//builder.Host.UseSerilog((ctx, lc) => lc
//    .WriteTo.Console()
//    .WriteTo.Seq("http://localhost:5341"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
