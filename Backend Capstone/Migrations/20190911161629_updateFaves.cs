using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Capstone.Migrations
{
    public partial class updateFaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d721b317-147f-4e5a-87d1-339b65909404", "AQAAAAEAACcQAAAAEALpW4zTORaVSHBD5LpnAocrXHOlfVM68TXRIMHNJvqXmrSiEOyRyqh73XMeiGmi6g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "15b74bb9-d3ad-4cf1-aaa3-777d66ae0cff", "AQAAAAEAACcQAAAAEPVubhK3ytUWtYRhByyBf0ntnmlWEYMAtafnaUq3TWrCQ2jrrimmGAdtThsTKGewKQ==" });
        }
    }
}
