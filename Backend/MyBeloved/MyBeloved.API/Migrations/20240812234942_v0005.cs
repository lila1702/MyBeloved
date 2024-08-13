using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBeloved.API.Migrations
{
    /// <inheritdoc />
    public partial class v0005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotebooksCategories");

            migrationBuilder.CreateTable(
                name: "CategoryNotebook",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    NotebooksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryNotebook", x => new { x.CategoriesId, x.NotebooksId });
                    table.ForeignKey(
                        name: "FK_CategoryNotebook_Categories_CategoriesId",
                        column: x => x.CategoriesId,
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

            migrationBuilder.CreateTable(
                name: "NotebooksCategories",
                columns: table => new
                {
                    NotebookId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotebooksCategories", x => new { x.NotebookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_NotebooksCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotebooksCategories_Notebooks_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Notebooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotebooksCategories_CategoryId",
                table: "NotebooksCategories",
                column: "CategoryId");
        }
    }
}
