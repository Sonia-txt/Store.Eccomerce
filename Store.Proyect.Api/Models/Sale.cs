namespace Store.Proyect.Api.Models;

public class Sale
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Pending";
}