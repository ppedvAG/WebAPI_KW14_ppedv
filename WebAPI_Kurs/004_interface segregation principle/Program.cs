// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public interface IVehicle
{
    public void Fly();
    public void Drive();
    public void Swim();
}


public class Vehicle : IVehicle
{
    public void Drive()
    {
        //...
    }

    public void Fly()
    {
        //...
    }

    public void Swim()
    {
        //...
    }
}


//Problem kommt hier zustande#

public class Car : IVehicle
{
    public void Drive()
    {
        //können wir ausimplementieren
    }

    public void Fly()
    {
       //wird nicht implementiert
    }

    public void Swim()
    {
        //wird nicht implementiert
    }
}



//Interfaces kann man mehrfach in einer Klasse hnzufügen

public interface IDrive
{
    void Drive();
}

public interface ISwim
{
    void Swim();
}

public interface IFly
{
    void Fly();
}


//Mehrfache Interfaceverwendung 
public class AmphibischesFahrzeug : IDrive, ISwim
{
    public void Drive()
    {
        //Drive  Methode
    }

    public void Swim()
    {
        //Swim Methode
    }
}