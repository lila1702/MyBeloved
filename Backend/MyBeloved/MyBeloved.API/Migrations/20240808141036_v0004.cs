using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBeloved.API.Migrations
{
    /// <inheritdoc />
    public partial class v0004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryNotebook");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Pages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotebooksCategories");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Pages",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}
