using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCopy.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAuthorsAndBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorEntityBookEntity");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Authors");

            migrationBuilder.AddColumn<int>(
                name: "BookEntityId",
                table: "Authors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BookEntityId",
                table: "Authors",
                column: "BookEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_BookEntityId",
                table: "Authors",
                column: "BookEntityId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_BookEntityId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_BookEntityId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "BookEntityId",
                table: "Authors");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AuthorEntityBookEntity",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorEntityBookEntity", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorEntityBookEntity_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorEntityBookEntity_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorEntityBookEntity_BooksId",
                table: "AuthorEntityBookEntity",
                column: "BooksId");
        }
    }
}
