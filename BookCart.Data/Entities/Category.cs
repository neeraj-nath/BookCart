using System.ComponentModel.DataAnnotations;

namespace BookCart.Data.Entities; 

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; } 
    public int DisplayOrder { get; set; }
}
