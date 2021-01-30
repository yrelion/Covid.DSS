using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid.DSS.Migrations
{
    public partial class AddDefaultUsersWithRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "882ea168-ea3c-4fe2-b592-7051219052ec", "2c5ed60b-b543-4505-867b-b832586782e1", "User", "USER" },
                    { "1045ad76-9854-4f90-8a67-bb69f5993231", "b01086ef-e1ea-42fd-8189-db04ddadad2e", "Admin", "ADMIN" },
                    { "be9c13ab-9a76-4ad8-860f-17f1b3a97bef", "a6259ba9-7395-4369-9988-4f1fb44af495", "Support", "SUPPORT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7e3a93b2-e09e-4301-ae7b-31232c4ea50d", 0, "370cf240-866a-4ed0-95a6-9e512ecf121d", "user@dss.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEEYGI5XG6oYmS2+ZzULEO8fxnMngzbmEmikdygcl6CPtXlkBmUNw5005w4TxKMANRA==", null, false, "e27cebef-40c8-412b-b5b3-eeb019d7cf3a", false, "user@dss.com" },
                    { "7087339c-9bfe-4f01-806b-3aa423e9a217", 0, "b5c47f4b-a2da-4fd4-bf45-941432604693", "admin@dss.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEHYFA6V9CThmuZMFUMFLld/S6Dsf7IO1zzSBP5yF6CYXmmlyOWrcoI7qXUECOnW2eA==", null, false, "7587839b-6b58-45ef-9abd-ff8288266df0", false, "admin@dss.com" },
                    { "fd8af5a9-4838-4dea-bed0-6cf650c2d135", 0, "4dfe146f-3b3a-4b40-806d-8396a813b0f0", "support@dss.com", true, false, null, null, null, "AQAAAAEAACcQAAAAENkmVJynzocGsVisGUGiZV1u5r3/Obn59lrJswZbdPO0SOpIFmSJcgtz37Mw3iDn5Q==", null, false, "bb47b807-84f6-4c30-89e7-1d37be4f94ca", false, "support@dss.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "7e3a93b2-e09e-4301-ae7b-31232c4ea50d", "882ea168-ea3c-4fe2-b592-7051219052ec" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "7087339c-9bfe-4f01-806b-3aa423e9a217", "1045ad76-9854-4f90-8a67-bb69f5993231" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "fd8af5a9-4838-4dea-bed0-6cf650c2d135", "be9c13ab-9a76-4ad8-860f-17f1b3a97bef" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "7087339c-9bfe-4f01-806b-3aa423e9a217", "1045ad76-9854-4f90-8a67-bb69f5993231" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "7e3a93b2-e09e-4301-ae7b-31232c4ea50d", "882ea168-ea3c-4fe2-b592-7051219052ec" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "fd8af5a9-4838-4dea-bed0-6cf650c2d135", "be9c13ab-9a76-4ad8-860f-17f1b3a97bef" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1045ad76-9854-4f90-8a67-bb69f5993231");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "882ea168-ea3c-4fe2-b592-7051219052ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be9c13ab-9a76-4ad8-860f-17f1b3a97bef");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7087339c-9bfe-4f01-806b-3aa423e9a217");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e3a93b2-e09e-4301-ae7b-31232c4ea50d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd8af5a9-4838-4dea-bed0-6cf650c2d135");

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
    }
}
