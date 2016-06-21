using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace HiMVC.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Book_Author_AuthorID", table: "Book");
            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "Student",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Book_Author_AuthorID", table: "Book");
            migrationBuilder.AlterColumn<int>(
                name: "Sex",
                table: "Student",
                nullable: false);
            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
