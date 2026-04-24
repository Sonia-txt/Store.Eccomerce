using System.ComponentModel.DataAnnotations.Schema; 
using Dapper.Contrib.Extensions;
using Store.Proyect.Core.Entities;

public class EntityBase
{
    [Key]
    public int Id { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Computed] 
    [Column("created_date")]
    public DateTime CreatedDate { get; set; }

    [Column("updated_by")]
    public string? UpdatedBy { get; set; }

    [Computed]
    [Column("updated_date")]
    public DateTime? UpdatedDate { get; set; }
}