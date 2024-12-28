using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class populaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Name,ImagemUrl) values('Biblia','Biblia.jpg')");
            mb.Sql("Insert into Categorias(Name,ImagemUrl) values('Hinario','Hinario.jpg')");
            mb.Sql("Insert into Categorias(Name,ImagemUrl) values('Veu','Veu.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");

        }
    }
}
