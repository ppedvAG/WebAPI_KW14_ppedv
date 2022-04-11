// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Anit Beispiel
public class BadKirsche
{
    public string GetColor()
    {
        return "rot";
    }
}

public class BadErdbeer : BadKirsche
{
    public string GetColor()
    {
        return base.GetColor();
    }
}


//Besseres Beispiel 

public abstract class Fruits
{
    public abstract string GetColor();
}

public class Kirsche : Fruits
{
    public override string GetColor()
    {
        return "rot";
    }
}

public class Erdbeer : Fruits
{
    public override string GetColor()
    {
        return "rot";
    }
}