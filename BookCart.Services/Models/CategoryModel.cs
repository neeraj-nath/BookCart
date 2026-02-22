using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using BookCart.Utilities.CustomValidations;

namespace BookCart.Services.Models;

public class CategoryModel
{
    [MaxLength(30)]
    [NotInteger]
    public required string Name { get; set; }

    [DisplayName("Display Order")]
    [Range(1, 100, ErrorMessage="Please Provide Display Order in the range of 1 - 100")]
    public required int DisplayOrder { get; set; }
}
