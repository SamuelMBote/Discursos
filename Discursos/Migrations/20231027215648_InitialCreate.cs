using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Discursos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Designacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false, defaultValue: 2)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Temas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DuracaoEmMinutos = table.Column<int>(type: "int", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaVezEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temas", x => x.Id);
                    table.UniqueConstraint("AK_Temas_Numero", x => x.Numero);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false, defaultValue: 3),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Congregacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    CoordenadoraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Congregacoes", x => x.Id);
                    table.UniqueConstraint("AK_Congregacoes_Nome_Cidade_UF", x => new { x.Nome, x.Cidade, x.UF });
                    table.ForeignKey(
                        name: "FK_Congregacoes_Congregacoes_CoordenadoraId",
                        column: x => x.CoordenadoraId,
                        principalTable: "Congregacoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Congregacoes_Tipos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CongregacaoId = table.Column<int>(type: "int", nullable: false),
                    DesignacaoId = table.Column<int>(type: "int", nullable: false),
                    UltimaVezEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oradores_Congregacoes_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalTable: "Congregacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Oradores_Designacoes_DesignacaoId",
                        column: x => x.DesignacaoId,
                        principalTable: "Designacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OradorTema",
                columns: table => new
                {
                    OradoresId = table.Column<int>(type: "int", nullable: false),
                    TemasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OradorTema", x => new { x.OradoresId, x.TemasId });
                    table.ForeignKey(
                        name: "FK_OradorTema_Oradores_OradoresId",
                        column: x => x.OradoresId,
                        principalTable: "Oradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OradorTema_Temas_TemasId",
                        column: x => x.TemasId,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OradorId = table.Column<int>(type: "int", nullable: false),
                    TemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programacao_Oradores_OradorId",
                        column: x => x.OradorId,
                        principalTable: "Oradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programacao_Temas_TemaId",
                        column: x => x.TemaId,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Designacoes",
                columns: new[] { "Id", "Codigo", "Descricao" },
                values: new object[,]
                {
                    { 1, 1, "Servo Ministerial" },
                    { 2, 2, "Ancião" },
                    { 3, 3, "Pioneiro Especial" },
                    { 4, 4, "Superintendente de Circuito" },
                    { 5, 5, "Evento Especial" }
                });

            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "Id", "Codigo", "Descricao" },
                values: new object[,]
                {
                    { 1, 1, "Grupo" },
                    { 2, 2, "Grupo Isolado" },
                    { 3, 3, "Congregação" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Congregacoes_CoordenadoraId",
                table: "Congregacoes",
                column: "CoordenadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Congregacoes_TipoId",
                table: "Congregacoes",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Oradores_CongregacaoId",
                table: "Oradores",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Oradores_DesignacaoId",
                table: "Oradores",
                column: "DesignacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_OradorTema_TemasId",
                table: "OradorTema",
                column: "TemasId");

            migrationBuilder.CreateIndex(
                name: "IX_Programacao_OradorId",
                table: "Programacao",
                column: "OradorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programacao_TemaId",
                table: "Programacao",
                column: "TemaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OradorTema");

            migrationBuilder.DropTable(
                name: "Programacao");

            migrationBuilder.DropTable(
                name: "Oradores");

            migrationBuilder.DropTable(
                name: "Temas");

            migrationBuilder.DropTable(
                name: "Congregacoes");

            migrationBuilder.DropTable(
                name: "Designacoes");

            migrationBuilder.DropTable(
                name: "Tipos");
        }
    }
}
