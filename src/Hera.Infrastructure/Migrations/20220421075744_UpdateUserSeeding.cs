using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hera.Infrastructure.Migrations
{
    public partial class UpdateUserSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$5Eh7piUI9mmYADj7FE99deuQvFoSnPvW13n9GvgR/ijGoI5ZDAo9.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "123456");
        }
    }
}
