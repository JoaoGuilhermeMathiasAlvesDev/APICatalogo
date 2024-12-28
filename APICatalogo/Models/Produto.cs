using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public Guid produtoId { get; set; }

        [Required]
        [StringLength(80)]
        public string Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName ="decimal(10,2)")]
        public decimal preco { get; set; }

        [Required]
        [StringLength(300)]
        public string ImagemUrl { get; set; }

        public float Estoque { get; set; }

        public DateTime DataCadastro { get; set; }

        // EF
        public int categoriaId { get; set; }

        public Categoria  Categoria { get; set; }

        public Produto()
        {
               produtoId = Guid.NewGuid();
        }
    }
}
