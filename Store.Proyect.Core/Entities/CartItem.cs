namespace Store.Proyect.Core.Entities;

public class CartItem : EntityBase
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; } 
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal SubTotal => Quantity * UnitPrice; 
}