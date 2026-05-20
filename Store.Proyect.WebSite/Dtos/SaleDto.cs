namespace Store.Proyect.WebSite.Dtos;

public class SaleDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalAmount { get; set; }
    public int Status { get; set; } // Representing the Enum as an int for simplicity in DTO
}