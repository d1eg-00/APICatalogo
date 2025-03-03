using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext ?_context;

        public CategoriasController(AppDbContext? context)
        {
            _context = context;
        }

        [HttpGet("produtos")]

        public ActionResult<IEnumerable<Categoria>> GetCategoriaProdutos() // obtem as categorias e os produtos da categoria
        {
            //return _context!.Categorias!.Include(p => p.Produtos).ToList();
            return _context!.Categorias!.Include(p => p.Produtos).Where(c => c.CategoriaId <= 5).ToList(); //retorna categoria menor ou igual a 5
        }

        [HttpGet]

        public ActionResult<IEnumerable<Categoria>>Get()
        {
            try
            {
                return _context!.Categorias!.AsNoTracking().ToList(); //

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a solicitação.");
                throw;
            }
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")] //definição de rota para obter itens
        public ActionResult<IEnumerable<Categoria>> Get(int id)
        {
            
            try
            {
            var categoria = _context!.Categorias!.FirstOrDefault(p => p.CategoriaId == id);
            if(categoria == null)
            {
                return NotFound($"Categoria com id= {id} Não Encontrada!");
            }
            return Ok(categoria);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a solicitação.");
                throw;
            }
            
        }

        [HttpPost]

        public ActionResult Post (Categoria categoria)
        {
            if (categoria is null)
            {
                return BadRequest();
            }

            _context!.Categorias!.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new {id = categoria.CategoriaId}, categoria);
        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, Categoria categoria)
        {
            if(id != categoria.CategoriaId)
            {
                return BadRequest();
            }
            _context!.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]

        public ActionResult Delete(int id)
        {
            var categoria = _context!.Categorias!.FirstOrDefault(p => p.CategoriaId == id);

            if(categoria == null)
            {
                return NotFound($"Categoria com id= {id} Não Encontrada!");
            }

            _context.Categorias!.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }




    }
}