using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APICatalogo.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        [StringLength(80)]
        public string ?Nome { get; set; }
        [Required]
        [StringLength(300)]
        public string ?Descricao { get; set; }
        [Required]
        [Column(TypeName ="decimal(10,2)")]
        public decimal Preco { get; set; }
        [Required]
        [StringLength(300)]
        public string ?ImageUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public Categoria? Categoria { get; set; } //propriedade de navegação
    }
}