using System.ComponentModel.DataAnnotations;

namespace Application.Validations
{
    public class StatusAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var entrada = value.ToString();

            if (entrada != "Pendiente" && entrada != "Terminada")
            {
                return new ValidationResult("El estado debe ser Pendiente o Terminada");
            }

            return ValidationResult.Success;
        }
    }
}
