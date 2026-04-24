using Dapper.Contrib.Extensions; 

namespace Store.Proyect.Core.Entities;

[Table("categories")] 
public class Category : EntityBase
{
    public string name { get; set; } = string.Empty;
}