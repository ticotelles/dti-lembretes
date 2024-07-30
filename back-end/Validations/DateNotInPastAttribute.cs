using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeLembretes.Validations
{
public class DateNotInPastAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            DateTime date = (DateTime)value;
            if (date < DateTime.Today)
            {
                return new ValidationResult("Proibido adicionar data anterior ao atual.");
            }
        }
        return ValidationResult.Success;
    }
}
}