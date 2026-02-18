using System.ComponentModel;

namespace BookCart.Services.Models;

public class CategoryModel
{
    public required string Name { get; set; }

    [DisplayName("Display Order")]
    public int DisplayOrder { get; set; }
}
