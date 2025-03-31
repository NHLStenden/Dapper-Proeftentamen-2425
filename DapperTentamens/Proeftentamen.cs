using Dapper;
using DapperTentamens.Model;
using DapperTentamens.Tests;


namespace DapperTentamens;

public class Proeftentamen : TestHelper
{
    // Opdracht 1:
    // Geef het aantal orders van de medewerker die de meeste orders heeft verkocht.
    public static int MaxNumberOfOrdersByEmployee()
    {
        var connection = DbHelper.GetConnection();
        
        throw new NotImplementedException();
    }

   
    // Opdracht 2:
    // Geef de producten terug die een prijs hebben tussen minPrice en maxPrice.
    // Als minPrice of maxPrice null is, dan wordt er niet gefilterd op die waarde.
    // De producten moeten gesorteerd worden op prijs en daarna naam.
    // Onder de methode staan 4 testen die je kunt gebruiken om de methode te testen.
    // 1 Query mag gebruikt worden (dus geen branching (if else constructies in de C# code)).
    public static List<Product> GetProducts(int? minPrice = null, int? maxPrice = null)
    {
        var connection = DbHelper.GetConnection();
        
        throw new NotImplementedException();
    }

    // Opdracht 3:
    // Haal alle categorieën op, inclusief de producten van de categorie.
    // Sorteer eerst op categorienaam en dan op productnaam.
    // Een categorie heeft een lijst van producten. Deze moet gevuld worden.(multimapping)
    
    public static List<Category> GetCategoriesIncludeProducts()
    {
        var connection = DbHelper.GetConnection();
        
        throw new NotImplementedException();
    }
}