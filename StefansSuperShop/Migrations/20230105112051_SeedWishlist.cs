using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StefansSuperShop.Migrations
{
    public partial class SeedWishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Wishlist",
                columns: new[] { "Id", "ExtendedUserId", "ProductId" },
                values: new object[,]
                {
                    { 1, "80e9ddc5-feec-4624-87d8-6000c82c0ef4", 1 },
                    { 2, "80e9ddc5-feec-4624-87d8-6000c82c0ef4", 2 },
                    { 3, "80e9ddc5-feec-4624-87d8-6000c82c0ef4", 3 },
                    { 4, "80e9ddc5-feec-4624-87d8-6000c82c0ef4", 4 },
                    { 5, "eba557ce-b4ad-42cc-a6be-7e80d2b304d1", 1 },
                    { 6, "eba557ce-b4ad-42cc-a6be-7e80d2b304d1", 2 },
                    { 7, "eba557ce-b4ad-42cc-a6be-7e80d2b304d1", 5 },
                    { 8, "eba557ce-b4ad-42cc-a6be-7e80d2b304d1", 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
