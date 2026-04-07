using System;
using System.ComponentModel.DataAnnotations;

public class TitleStartsWithCapitalAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        
        if (value is string title && !string.IsNullOrEmpty(title))
        {
            if (char.IsUpper(title[0]))
                return ValidationResult.Success;
            else
                return new ValidationResult("Title must start with a capital letter");
        }
        return ValidationResult.Success;
    }
}