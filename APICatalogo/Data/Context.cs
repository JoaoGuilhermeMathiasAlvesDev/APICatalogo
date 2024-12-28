using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context>options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> produtos { get; set; }
    }
}
