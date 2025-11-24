using System.ComponentModel.DataAnnotations;

namespace FictionBranches.Web.Data.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class ValidatingStringLength : ValidationAttribute
{
    public required int MinLength { get; set; }
    public required int MaxLength { get; set; }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return MinLength > 0 ? new ValidationResult($"{validationContext.MemberName} cannot be empty.") : ValidationResult.Success;
        
        var str = value as string;
        if (str == null)
            return new ValidationResult($"{validationContext.MemberName} must be a string.");

        if (str.Length == 0 && MinLength > 0)
            return new ValidationResult($"{validationContext.MemberName} cannot be empty.");
        
        if (str.Length < MinLength || str.Length > MaxLength)
            return new ValidationResult($"{validationContext.MemberName} must be between {MinLength} and {MaxLength} characters.");
        
        return ValidationResult.Success;
    }
    
}