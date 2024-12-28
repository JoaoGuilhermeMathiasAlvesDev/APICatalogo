using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required]
        [StringLength(300)]
        public string ImagemUrl { get; set; }

        //EF
        public ICollection<Produto> Produtos { get; set; }
       

        public Categoria()
        {
             Produtos = new Collection<Produto>();
        }


    }
}
