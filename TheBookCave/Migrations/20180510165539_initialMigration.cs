using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TheBookCave.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    age = table.Column<int>(nullable: false),
                    alive = table.Column<bool>(nullable: false),
                    countryOfBirth = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    shortDescription = table.Column<string>(nullable: true),
                    yearOfBirth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    author = table.Column<string>(nullable: true),
                    authorId = table.Column<int>(nullable: false),
                    genre = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    language = table.Column<string>(nullable: true),
                    originalLanguage = table.Column<string>(nullable: true),
                    pages = table.Column<int>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    publisher = table.Column<string>(nullable: true),
                    releaseYear = table.Column<int>(nullable: false),
                    shortDescription = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    translator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    name = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    socialSecurityNumber = table.Column<string>(nullable: true),
                    userId = table.Column<int>(nullable: true),
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: true),
                    staff = table.Column<bool>(nullable: false),
                    username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cart_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_bookId",
                table: "Cart",
                column: "bookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
