using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Capstone.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "277a5097-6743-4ebe-9041-0ab58e234a74", "AQAAAAEAACcQAAAAEJf5wqQBYvXgtZDpo6v0yKByRN175bSVQsnwFoKL279p+v5KXSz0x2jDeSdnPaY1Ug==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d46ac282-d061-42a0-8224-f15e2fa40be0", "AQAAAAEAACcQAAAAEJ5eHrkV3UGizlkFNnFzYpN0M3XPow8IesyQX0JyPW3m9DCJspfK3OkJE4+hfShTuA==" });
        }
    }
}
