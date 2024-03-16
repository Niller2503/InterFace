using System;
using System.IO;

// Interface til at definere metoder til at gemme og hente heltal
public interface IDatabase
{
    void GemHelTal(int tal); // Metode til at gemme et heltal i databasen
    void HentHelTal(); // Metode til at hente et heltal fra databasen
}

// Implementering af IDatabase-interfacet
public class Database : IDatabase
{
    private string filsti; // Stien til filen, hvor data gemmes

    // Konstruktør, der modtager filstien som argument og initialiserer variablen
    public Database(string filsti)
    {
        this.filsti = filsti; // Initialisering af filstien
    }

    // Metode til at gemme et heltal i databasen
    public void GemHelTal(int tal)
    {
        string[] strings = { tal.ToString() }; // Konverterer tallet til en streng og opretter et string-array
        File.WriteAllLines(filsti, strings); // Gemmer strengen i filen på angiven sti
        Console.WriteLine("GEMT MED SUCCESS"); // Udskriver en bekræftelse på, at data er gemt
    }

    // Metode til at hente et heltal fra databasen
    public void HentHelTal()
    {
        string[] talArray = File.ReadAllLines(filsti); // Læser alle linjer fra filen og gemmer dem i et string-array
        talArray.ToList().ForEach(tal => Console.WriteLine(tal)); // Udskriver hvert element (tal) i arrayet
    }
}

// Klasse, der indeholder programmet
class Program
{
    // Metode, der fungerer som startpunktet for programmet
    static void Main(string[] args)
    {
        string directoryPath = "C:\\Users\\nikla\\Desktop\\CSV\\Data.txt"; // Stien til filen, hvor data gemmes
        IDatabase database = new Database(directoryPath); // Opretter en instans af Database-klassen med den angivne filsti

        int gemttal = 24; // Det tal, der skal gemmes i databasen

        // Gemmer tallet i databasen
        database.GemHelTal(gemttal);

        // Henter og udskriver tallet fra databasen
        database.HentHelTal();
    }
}
