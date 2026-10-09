using System.ComponentModel.DataAnnotations;

namespace FictionBranches.Web.Data.Attributes;

public class MatchingOtherString(string comparisonProperty) : ValidationAttribute
{

    protected override ValidationResult? IsValid(object? obj, ValidationContext validationContext)
    {
        ErrorMessage = ErrorMessageString;
        var currentValue = (string?)obj;

        var property = validationContext.ObjectType.GetProperty(comparisonProperty);
        if (property == null)
            throw new ArgumentException("Property not found");

        var comparisonValue = (string?)property.GetValue(validationContext.ObjectInstance);

        var a = string.IsNullOrEmpty(comparisonValue);
        var b = string.IsNullOrEmpty(currentValue);
        if (a && b)
            return ValidationResult.Success;
        
        if (a != b)
            return new ValidationResult(ErrorMessage);
        
        // comparison condition
        if (!currentValue!.Equals(comparisonValue))
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}
