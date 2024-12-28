using APICatalogo.Data;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly Context _context;

        public CategoriaController(Context context)
        {
            _context = context;
        }

        [HttpGet("/produtos")]
        public ActionResult<IEnumerable<Categoria>> CategoriasProdutos() 
        { 
            return _context.Categorias.Include(p=> p.Produtos).ToList();
        
        }

         
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Categorias()
        {
           return _context.Categorias.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Categoria> CategoriaId(int id)
        { 
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

            if (categoria is null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Adicioan(Categoria categoria)
        {

            if (categoria == null)
                return BadRequest();

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new {id = categoria.Id},categoria);
        }

        [HttpPut("id:int")]
        public ActionResult Atualizar(int id,Categoria categoria) 
        {
            if(id != categoria.Id)
                return BadRequest();

            _context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("id:int")]
        public ActionResult Delete(int id) 
        { 
            var categoria = _context.Categorias.FirstOrDefault(p=> p.Id == id);
            
            if(categoria is null) return NotFound();

            _context.Categorias.Remove(categoria);

            _context.SaveChanges();

            return Ok(categoria);
        }


    }
}
