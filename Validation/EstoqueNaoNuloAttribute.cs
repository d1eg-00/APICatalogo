using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Validation
{
    public class EstoqueNaoNuloAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult ("O Estoque não pode ser nulo!"); // Se o valor for nulo, a validação é ignorada
            }

            if (value is float estoque && estoque <= 0)
            {
                return new ValidationResult("O Valor Inserido no Estoque Deve ser Maior que Zero!");
            }

            return ValidationResult.Success;
        }
    }
}
    
