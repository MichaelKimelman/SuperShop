using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StefansSuperShop.Migrations
{
    public partial class SubscriberUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Subscribers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_UserId",
                table: "Subscribers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_AspNetUsers_UserId",
                table: "Subscribers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_AspNetUsers_UserId",
                table: "Subscribers");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_UserId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Subscribers");
        }
    }
}
