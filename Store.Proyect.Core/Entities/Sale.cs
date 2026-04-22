using Store.Proyect.Core.Enums; // Agrega esta línea

namespace Store.Proyect.Core.Entities;

public class Sale : EntityBase
{
    public int CustomerId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalAmount { get; set; }
    public SalesStatus Status { get; set; } 
}