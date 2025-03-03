using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace APICatalogo.controllers
{
    [Route("[controller]")] //rota básica 
    [ApiController]
    
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get() //retorna a lista de produtos
        {
            var produtos = _context.Produtos?.AsNoTracking().ToList();
            if(produtos is null)
            {
                return NotFound("Produtos Não Encontrados.");
            }
            return produtos;
        }

        [HttpGet("{id:int}", Name="ObterProduto")]
 
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos?.FirstOrDefault(p => p.ProdutoId == id); //[BUSCA PRODUTO POR ID]codigo do produto tem que ser igual ao id do request
            if(produto == null)
            {
                return NotFound("Produto Não Encontrado.");
            }
            return produto;
        }


        [HttpPost] // criar produto

        public ActionResult Post(Produto produto)
        {

            if(produto is null)
            {
                return BadRequest();
            }
            _context.Produtos?.Add(produto);
            _context.SaveChanges(); //persiste os dados dentro da tabela

            return new CreatedAtRouteResult("ObterProduto", 
            new {id = produto.ProdutoId}, produto);
        }

        [HttpPut("{id:int}")] //realizar alteração no produto
        public ActionResult Put(int id, Produto produto) // passar o id do produto bem como no corpo da requisiçao o produto
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("id:int")] //Deletar produto

        public ActionResult Delete(int id) //solicita apenas o id para deletar
        {
            var produto = _context.Produtos?.FirstOrDefault(p => p.ProdutoId==id);
            if(produto is null)
            {
                return NotFound("Produto Não Localizado!");

            }
            _context.Produtos?.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}