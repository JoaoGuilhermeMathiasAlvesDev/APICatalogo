using APICatalogo.Data;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly Context _context;
        public ProdutoController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> ObterProdutos()
        {

            var produtos = _context.produtos.ToList();

            if (produtos is null)
                return NotFound("Produtos não encontrado.");

            return produtos;
        }

        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> ObterProduto(Guid id)
        {

            var produto = _context.produtos.FirstOrDefault(x => x.produtoId == id);

            if (produto is null)
                return NotFound("Produto não encontrado.");

            return produto;
        }

        [HttpPost]
        public ActionResult AdicionarProduto(Produto produto)
        {
            _context.produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.produtoId }, produto);
        }

        [HttpPut("{id}")]
        public ActionResult AlterarProduto(Guid id, Produto produto)
        {

            if (id != produto.produtoId)
                return BadRequest();

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduto(Guid id)
        { 
        
            var produto = _context.produtos.FirstOrDefault(p => p.produtoId.Equals(id));


            if (produto is null) return NotFound();

            _context.produtos.Remove(produto);
            _context.SaveChanges();

            return Ok( produto);
        
        }
    }
}