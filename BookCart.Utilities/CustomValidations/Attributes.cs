using System.ComponentModel.DataAnnotations;

namespace BookCart.Utilities.CustomValidations;

public class NotIntegerAttribute: ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        string? data = value?.ToString();

        if (data is null)
        {
            return ValidationResult.Success;
        }

        if(int.TryParse(data, out _))
        {
            return new ValidationResult($"{validationContext.DisplayName} cannot be a numeric value");
        }

        return ValidationResult.Success;
    }
}
