using System.ComponentModel.DataAnnotations;

namespace _66BitTestovoe.Server.Attributes;

public class ValidCountryNameAttribute: ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is string teamName && teamName is "Россия" or "США" or "Италия")
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Invalid team name. Only 'Россия', 'США', and 'Италия' are allowed.");
    }
}