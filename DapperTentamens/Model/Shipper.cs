namespace DapperTentamens.Model;

public class Shipper
{
    public int ShipperID { get; set; }
    public string ShipperName { get; set; }
    public string Phone { get; set; }
    
    List<Order> Orders { get; set; } = new List<Order>();
}