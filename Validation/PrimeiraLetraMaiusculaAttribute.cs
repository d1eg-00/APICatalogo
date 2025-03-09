using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Validation
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
//Aplicando método de validação da informação do meu atributo
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }
//Pego a letra do indice 0 e verifico se ela é maiúscula e retorno a validação
            var primeiraLetra = value.ToString()![0].ToString();
            if (primeiraLetra != primeiraLetra.ToUpper())
            {
                return new ValidationResult("A Primeira Letra do Produto Deve Ser Maiúscula!");
            }
            return ValidationResult.Success;
        }


    }
}