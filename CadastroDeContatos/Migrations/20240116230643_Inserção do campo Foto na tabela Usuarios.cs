using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroDeContatos.Migrations
{
    public partial class InserçãodocampoFotonatabelaUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Usuarios");
        }
    }
}
