using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Capstone.Migrations
{
    public partial class updateFavoriteProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2d0b4304-654a-4f80-9dcf-95754f946dca", "AQAAAAEAACcQAAAAEOs9Ir3e/NZDqpmv7IFbe/z2ClJaF9cr9v0SRV2dPK80130YyAyLn44ZnQmL41Z9bA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d721b317-147f-4e5a-87d1-339b65909404", "AQAAAAEAACcQAAAAEALpW4zTORaVSHBD5LpnAocrXHOlfVM68TXRIMHNJvqXmrSiEOyRyqh73XMeiGmi6g==" });
        }
    }
}
