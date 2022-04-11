namespace DefaultWebAPI_NET5.Services
{
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
}
