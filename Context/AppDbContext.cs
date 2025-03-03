using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context
{
    public class AppDbContext : DbContext //realiza comunicação entre as entidades e o banco de dados relacional / operação com o bd
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Categoria>? Categorias { get; set;}
        public DbSet<Produto>? Produtos { get; set;}
    }
}