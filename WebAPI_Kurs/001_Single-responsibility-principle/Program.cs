// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//So bitte nicht -> Diese Klasse hat zuviele Aufgabe
public class AntiSingleReposibilityClass
{
    public int Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }  
    

    public void GenerateReport()
    {
        //....
    }

    public void InsertPersonToDB()
    {
        //....
    }
}


//So besser
//POCOs bzw Entity
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}


public class ReportGenerator
{
    public void Generate(Person person)
    {
        //...
    }
}

public class PersonRepository
{
    public void Insert(Person p)
    {
        //...
    }
}




