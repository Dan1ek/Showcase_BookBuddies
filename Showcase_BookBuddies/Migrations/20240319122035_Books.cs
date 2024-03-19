using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Showcase_BookBuddies.Migrations
{
    /// <inheritdoc />
    public partial class Books : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookLists_BookListId",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "BookTitle");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Books",
                newName: "BookAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_Book_BookListId",
                table: "Books",
                newName: "IX_Books_BookListId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookLists_BookListId",
                table: "Books",
                column: "BookListId",
                principalTable: "BookLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookLists_BookListId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameColumn(
                name: "BookTitle",
                table: "Book",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "BookAuthor",
                table: "Book",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Books_BookListId",
                table: "Book",
                newName: "IX_Book_BookListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookLists_BookListId",
                table: "Book",
                column: "BookListId",
                principalTable: "BookLists",
                principalColumn: "Id");
        }
    }
}
