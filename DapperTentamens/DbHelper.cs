using System.Data;
using MySqlConnector;
using Dapper;

namespace DapperTentamens;

public class DbHelper
{
    public static IDbConnection GetConnection()
    {
        return new MySqlConnection("Server=localhost;Database=Webshop;Uid=root;Pwd=Test@1234!;");
    }
    public static void CreateTablesAndInsertData()
    {
        var createSchema = "CREATE DATABASE IF NOT EXISTS `Webshop`;";
        var tempConnection = new MySqlConnection("Server=localhost;Uid=root;Pwd=Test@1234!;");
        tempConnection.Execute(createSchema);
        tempConnection.Close();
        
        using var connection = GetConnection();
        string[] tables = ["Categories", "Customers", "Employees", "OrderDetails", "Orders", "Products", "Shippers", "Suppliers"];

        bool allExists = tables.All(table => connection.QuerySingleOrDefault<bool>(
            $"""
                 SELECT COUNT(1) = 1
                 FROM   information_schema.tables
                 WHERE      table_schema = 'Webshop' 
                            AND table_name = '{table}'
                 LIMIT 1; 
             """));
    
        if(allExists && CorrectRecordCountInTables())
            return;
        
        //create tables and insert data
        var createTables = File.ReadAllText("SQL/CreateTablesAndInsertData.sql");
        connection.Execute(createTables);
        
       
        bool CorrectRecordCountInTables()
        {
            var tableCount = connection.QuerySingleOrDefault<TableCount>(
                """
                    SELECT 
                        (SELECT COUNT(1) FROM Categories) as CategoryCount,
                        (SELECT COUNT(1) FROM Customers) as CustomerCount,
                        (SELECT COUNT(1) FROM Employees) as EmployeeCount,
                        (SELECT COUNT(1) FROM OrderDetails) as OrderDetailCount,
                        (SELECT COUNT(1) FROM Orders) as OrderCount,
                        (SELECT COUNT(1) FROM Products) as ProductCount,
                        (SELECT COUNT(1) FROM Shippers) as ShipperCount,
                        (SELECT COUNT(1) FROM Suppliers) as SupplierCount
                """);

            return tableCount is { CategoryCount: 8, CustomerCount: 91, EmployeeCount: 10, OrderDetailCount: 518, OrderCount: 196, ProductCount: 77, ShipperCount: 3, SupplierCount: 29 };
                   
        }
    }
    
    private class TableCount
    {
        public int CategoryCount { get; set; }
        public int CustomerCount { get; set; }
        public int EmployeeCount { get; set; }
        public int OrderDetailCount { get; set; }
        public int OrderCount { get; set; }
        public int ProductCount { get; set; }
        public int ShipperCount { get; set; }
        public int SupplierCount { get; set; }
    }

    
}