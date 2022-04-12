using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebAPIWithEFCore.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<ContactDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("ContactDbContext")));


//AddDbContext bindet GeoDataContext als 'Scoped' Life-Circle ein
builder.Services.AddDbContext<GeoDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GeoDbContext"));
    options.UseLazyLoadingProxies();
});

var app = builder.Build();

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
