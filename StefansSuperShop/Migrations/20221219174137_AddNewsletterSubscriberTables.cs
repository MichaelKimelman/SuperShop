using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StefansSuperShop.Migrations
{
    public partial class AddNewsletterSubscriberTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Newsletters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsletterSubscribers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsletterId = table.Column<int>(type: "int", nullable: false),
                    SubscriberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsletterSubscribers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsletterSubscribers_Newsletters_NewsletterId",
                        column: x => x.NewsletterId,
                        principalTable: "Newsletters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsletterSubscribers_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Newsletters",
                columns: new[] { "Id", "Message", "Title" },
                values: new object[,]
                {
                    { 1, "This is our first newsletter!", "Newsletter 1" },
                    { 2, "This is our second newsletter!", "Newsletter 2" }
                });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "Id", "Email" },
                values: new object[,]
                {
                    { 1, "sven.svensson@mail.se" },
                    { 2, "karl.karlsson@mail.se" },
                    { 3, "anders.andersson@mail.se" },
                    { 4, "magnus.magnusson@mail.se" },
                    { 5, "johan.johansson@mail.se" },
                    { 6, "mats.matsson@mail.se" }
                });

            migrationBuilder.InsertData(
                table: "NewsletterSubscribers",
                columns: new[] { "Id", "NewsletterId", "SubscriberId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 2, 1 },
                    { 6, 2, 2 },
                    { 7, 2, 5 },
                    { 8, 2, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsletterSubscribers_NewsletterId",
                table: "NewsletterSubscribers",
                column: "NewsletterId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsletterSubscribers_SubscriberId",
                table: "NewsletterSubscribers",
                column: "SubscriberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsletterSubscribers");

            migrationBuilder.DropTable(
                name: "Newsletters");

            migrationBuilder.DropTable(
                name: "Subscribers");
        }
    }
}
