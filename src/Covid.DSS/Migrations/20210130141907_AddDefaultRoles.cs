using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid.DSS.Migrations
{
    public partial class AddDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca4ac8f6-463b-47be-b13c-470fbcdf9e8b", "281a5d29-bd21-40a1-806f-396cf6c56fb7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba49dd31-03b6-4b21-b2ce-5d5bb2343924", "5f4d1b82-0fdb-4929-850f-fadc6f103ff5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "990a13a8-2f90-440a-8380-ef31b51fbd9c", "3e7c7443-1b41-491f-ab42-d9d7537f9700", "Support", "SUPPORT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "990a13a8-2f90-440a-8380-ef31b51fbd9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba49dd31-03b6-4b21-b2ce-5d5bb2343924");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca4ac8f6-463b-47be-b13c-470fbcdf9e8b");
        }
    }
}
