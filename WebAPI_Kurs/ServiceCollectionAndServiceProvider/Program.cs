

using Microsoft.Extensions.DependencyInjection;


//IServiceCollection initialisiert meinen IOC Container 
IServiceCollection serviceCollection = new ServiceCollection();
//Car Objekt legen 
serviceCollection.AddSingleton<ICar, MockCar>(); ////ICar car = new MockCar();


//Hier wird der IOC Container als IServiceProvider angeboten 
IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();


//Gibt das MockCar-Objekt zurück, wenn es nicht gefunden wird, dann NULL
ICar mockCar = serviceProvider.GetService<ICar>();

//Gibt das MockCar-Objekt zurück, wenn es nicht gefunden wird, dann Exception 
ICar mockCar2 = serviceProvider.GetRequiredService<ICar>();



public interface ICar
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int ConstructionYear { get; set; }
}

public interface ICarService
{
    public void Repair(ICar car);
}


//Programmierer A: 5 Tage (Tag 1 - Tag 5) 

public class Car : ICar
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int ConstructionYear { get; set; }
}

//Programmierer B: 3 Tage 
public class CarService : ICarService
{
    public void Repair(ICar car)
    {
        //repariere Auto
    }
}

public class MockCar : ICar
{
    public string Brand { get; set; } = "VW";
    public string Model { get; set; } = "Polo";
    public int ConstructionYear { get; set; } = 2012;
}
