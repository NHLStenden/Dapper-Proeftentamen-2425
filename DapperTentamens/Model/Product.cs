namespace DapperTentamens.Model;

public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int SupplierID { get; set; }
    
    public int CategoryID { get; set; }
    public Category Category { get; set; }
    
    public string Unit { get; set; }
    public decimal Price { get; set; }
    
    public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
}