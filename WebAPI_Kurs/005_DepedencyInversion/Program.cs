//Achtung Top - Level - Statement 

//Main Methode

ICarService carService = new CarService();
//Programmierer B kann MockObjekte verwenden, um seine Implementierung zu testen

ICar mockCar = new MockCar(); //Für Testzwecke (Funktionstest)

//Produktiv
ICar car = new Car();

carService.Repair(mockCar);

carService.Repair(car);



//Anti Beispiel

//Programmierer A: 5 Tage (Tag 1 - Tag 5) 
public class BadCar
{
    public string Brand { get; set; }
    public string Model { get; set; }   
    public int ConstructionYear { get; set; }
}


//Programmierer B: 3 Tage 
public class BadCarService
{
    public void Repair(BadCar car)
    {
        //...repariere Auto
    }
}




//Bessere Variante 

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