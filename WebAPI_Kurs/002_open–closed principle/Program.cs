// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");





public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}





public enum ReportType { CR, List10, PDF }

//Anti Beispiel 
public class ReportGenerator
{
    public ReportType Type { get; set; }   

    public void Generate(Person person)
    {
        //...

        if (Type == ReportType.CR)
        {
            //..
        }
        else if (Type == ReportType.List10)
        {
            //..
        }
        else
        {
            //..
        }
    }
}



//Bessere Beispiel

//Open Part
public abstract class ReportGeneratorBase
{
    public abstract void Generate(Person person);
}

public class CRReportGenerator : ReportGeneratorBase
{
    public override void Generate(Person person)
    {
       //...
    }
}


public class PDFReportGenerator : ReportGeneratorBase
{
    public override void Generate(Person person)
    {
        //...
    }
}

public class List10ReportGenerator : ReportGeneratorBase
{
    public override void Generate(Person person)
    {
        //...
    }
}

