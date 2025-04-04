namespace DapperTentamens.Model;

public class Supplier
{
    public int SupplierID { get; set; }
    public string SupplierName { get; set; }
    public string ContactName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    
    public List<Product> Products { get; set; } = new List<Product>();
}