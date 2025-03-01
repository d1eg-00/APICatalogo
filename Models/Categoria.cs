using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace APICatalogo.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        
        public Categoria() 
        {
            Produtos = new Collection<Produto>();
        }
        //gerenciar categoria
        [Key]
        public int CategoriaId { get; set; } //chave primaria caracterizando
        [Required]            //atributos datanotations para cada categoria
        [StringLength(80)]
        public string ?Nome { get; set; }
        [Required]
        [StringLength(300)]
        public string ?ImageUrl { get; set; }
        public ICollection<Produto>? Produtos{ get; set; } //Definindo entidade de um para muitos CategoriaxProduto
    }
}