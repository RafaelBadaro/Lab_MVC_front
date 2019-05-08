﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Bolsa.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Saldo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcaoUsuario",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUsuarioForeignKey = table.Column<long>(nullable: false),
                    IdAcaoForeignKey = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcaoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcaoUsuario_Acao_IdAcaoForeignKey",
                        column: x => x.IdAcaoForeignKey,
                        principalTable: "Acao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcaoUsuario_Usuario_IdUsuarioForeignKey",
                        column: x => x.IdUsuarioForeignKey,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcaoUsuario_IdAcaoForeignKey",
                table: "AcaoUsuario",
                column: "IdAcaoForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_AcaoUsuario_IdUsuarioForeignKey",
                table: "AcaoUsuario",
                column: "IdUsuarioForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcaoUsuario");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
