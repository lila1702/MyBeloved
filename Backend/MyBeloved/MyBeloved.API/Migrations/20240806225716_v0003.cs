using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBeloved.API.Migrations
{
    /// <inheritdoc />
    public partial class v0003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Notebooks_NotebookId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_NotebookId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NotebookId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "CategoryNotebook",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    NotebooksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryNotebook", x => new { x.CategoryId, x.NotebooksId });
                    table.ForeignKey(
                        name: "FK_CategoryNotebook_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryNotebook_Notebooks_NotebooksId",
                        column: x => x.NotebooksId,
                        principalTable: "Notebooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryNotebook_NotebooksId",
                table: "CategoryNotebook",
                column: "NotebooksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryNotebook");

            migrationBuilder.AddColumn<int>(
                name: "NotebookId",
                table: "Categories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NotebookId",
                table: "Categories",
                column: "NotebookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Notebooks_NotebookId",
                table: "Categories",
                column: "NotebookId",
                principalTable: "Notebooks",
                principalColumn: "Id");
        }
    }
}
