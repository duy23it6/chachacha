// Person.cs
using System;

public abstract class Person
{
    public string Name { get; set; }
}

// Interface.cs
public interface KPI
{
    void kpi();
}

// Student.cs
public class Student : Person, KPI
{
    public string Major { get; set; }

    public void kpi()
    {
        Console.WriteLine("Performing KPI...");
    }
}

// Program.cs
class Program
{
    static void Main(string[] args)
    {
        Person obs = new Student { Name = "Nguyen Van Nam", Major = "ICT" };

        // Check if obs is an instance of Student
        if (obs is Student)
        {
            // Call the kpi() method
            ((Student)obs).kpi();
        }
        else
        {
            Console.WriteLine("obs is not an instance of Student.");
        }

        // If Name and Major do not support get/set
        // Attempting to access them would result in a compile-time error.
        // The program will not compile.
    }
}