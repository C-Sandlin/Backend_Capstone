using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Capstone.Migrations
{
    public partial class FavoritesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "15b74bb9-d3ad-4cf1-aaa3-777d66ae0cff", "AQAAAAEAACcQAAAAEPVubhK3ytUWtYRhByyBf0ntnmlWEYMAtafnaUq3TWrCQ2jrrimmGAdtThsTKGewKQ==" });

            migrationBuilder.InsertData(
                table: "Favorite",
                columns: new[] { "Id", "ApplicationUserId", "RecipeId" },
                values: new object[] { 1, "00000000-ffff-ffff-ffff-ffffffffffff", 1 });

            migrationBuilder.InsertData(
                table: "Favorite",
                columns: new[] { "Id", "ApplicationUserId", "RecipeId" },
                values: new object[] { 2, "00000000-ffff-ffff-ffff-ffffffffffff", 29 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "277a5097-6743-4ebe-9041-0ab58e234a74", "AQAAAAEAACcQAAAAEJf5wqQBYvXgtZDpo6v0yKByRN175bSVQsnwFoKL279p+v5KXSz0x2jDeSdnPaY1Ug==" });
        }
    }
}
