using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using APICatalogo.Validation;

namespace APICatalogo.Models
{
    [Table("Produtos")]
    public class Produto //: IValidatableObject
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "Nome do Produto Obrigatório!")]
        [StringLength(10, ErrorMessage = "O Nome Deve Conter no Mínimo 5 Caracteres e no Máximo 10!", MinimumLength = 5)]
        [PrimeiraLetraMaiuscula]
        public string ?Nome { get; set; }
        [Required(ErrorMessage = "Descrição do Produto Obrigatório!")]
        [StringLength(80, ErrorMessage = "A Descrição deve ter no máximo {1} Caracteres!")]
        public string ?Descricao { get; set; }
        [Required]
        [Range(1,10000, ErrorMessage="O Preço deve estar entre {1} e {2}")]
        [Column(TypeName ="decimal(10,2)")]
        public decimal Preco { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string ?ImageUrl { get; set; }
        [EstoqueNaoNulo]
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public Categoria? Categoria { get; set; } //propriedade de navegação

//aplicando metodo de validação IValidatableObject
        // public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        // {
        
        //         if (this.Estoque <= 0)
        //         {
        //             yield return new ValidationResult(
        //                 "O Valor Inserido no Estoque Deve ser Maior que Zero!", 
        //             new[] 
        //             {nameof(this.Estoque)});
        //         }
            
        // }
    }
}