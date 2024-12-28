using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class popularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert Into Produtos (produtoId,Nome,Descricao,preco,ImagemUrl,Estoque,DataCadastro,categoriaId) values('c538b39a-849d-4a2c-aae1-72ffff727c72','B2','Com dicionario Biblico',15.00,'b2.png',6,'2024-11-05',1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
