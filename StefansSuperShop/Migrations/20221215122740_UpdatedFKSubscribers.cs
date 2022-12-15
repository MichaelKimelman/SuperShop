using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StefansSuperShop.Migrations
{
    public partial class UpdatedFKSubscribers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_NewsLetters_NewsLettersId",
                table: "Subscribers");

            migrationBuilder.AlterColumn<int>(
                name: "NewsLettersId",
                table: "Subscribers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_NewsLetters_NewsLettersId",
                table: "Subscribers",
                column: "NewsLettersId",
                principalTable: "NewsLetters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_NewsLetters_NewsLettersId",
                table: "Subscribers");

            migrationBuilder.AlterColumn<int>(
                name: "NewsLettersId",
                table: "Subscribers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_NewsLetters_NewsLettersId",
                table: "Subscribers",
                column: "NewsLettersId",
                principalTable: "NewsLetters",
                principalColumn: "Id");
        }
    }
}
