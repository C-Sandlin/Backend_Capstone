using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Capstone.Migrations
{
    public partial class WeeklyPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "MealPlan",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "448a4ba4-a90d-4df8-a1ca-4c2be4238539", "AQAAAAEAACcQAAAAEETFb3ggZV4ElxvlsskWV+/7EHIbB7bmS1POwC2Eijswiy1SNe9rvcZ93EUAJR8kYQ==" });

            migrationBuilder.InsertData(
                table: "MealPlan",
                columns: new[] { "Id", "ApplicationUserId", "DayOfWeek", "RecipeId" },
                values: new object[] { 1, "00000000-ffff-ffff-ffff-ffffffffffff", "Monday", 1 });

            migrationBuilder.InsertData(
                table: "MealPlan",
                columns: new[] { "Id", "ApplicationUserId", "DayOfWeek", "RecipeId" },
                values: new object[] { 2, "00000000-ffff-ffff-ffff-ffffffffffff", "Wednesday", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_RecipeId",
                table: "Favorite",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Recipe_RecipeId",
                table: "Favorite",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_Recipe_RecipeId",
                table: "Favorite");

            migrationBuilder.DropIndex(
                name: "IX_Favorite_RecipeId",
                table: "Favorite");

            migrationBuilder.DeleteData(
                table: "MealPlan",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MealPlan",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "MealPlan");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2d0b4304-654a-4f80-9dcf-95754f946dca", "AQAAAAEAACcQAAAAEOs9Ir3e/NZDqpmv7IFbe/z2ClJaF9cr9v0SRV2dPK80130YyAyLn44ZnQmL41Z9bA==" });
        }
    }
}
