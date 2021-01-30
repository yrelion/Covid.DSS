using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid.DSS.Migrations
{
    public partial class AddNormalizedUserFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { "1ae0a7c6-1955-4997-b703-2a04a83b7bfa", "02cde5c4-221e-4942-8c57-8afc5324cc1f", "User", "USER" },
                    { "21381825-5cf5-4780-a9a7-164df4bc02c1", "d2138670-04d1-49ff-bb0a-e81dad4cc4c1", "Admin", "ADMIN" },
                    { "e4c57a67-bef1-4ba9-a5b4-f4185a4d5123", "1310a889-e0a5-41ac-aa08-a56790cdbaae", "Support", "SUPPORT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bd73f2b3-126b-4b84-94aa-7ae8c5393158", 0, "69a064f0-3dcd-4832-82e4-d094d7cea5e1", "user@dss.com", true, false, null, "USER@DSS.COM", "USER@DSS.COM", "AQAAAAEAACcQAAAAEIgGkawBMNq08AQqwjA0kn0W1XUzwSbjqmJ73j5EQX5Cgqclevxa7xC4ZoZrTINdIw==", null, false, "3aa0ee1a-bdd4-4dfa-a6c2-ece060763307", false, "user@dss.com" },
                    { "10d96a29-5161-4f72-9351-ed16085b4417", 0, "58f4ae21-43eb-42fa-843e-a4451da74859", "admin@dss.com", true, false, null, "ADMIN@DSS.COM", "ADMIN@DSS.COM", "AQAAAAEAACcQAAAAEG/w22W8v9jDo65ItCsQdh23BtHU62cUgc/EvWrF9dTyx/IbTO3Cu9eyK+W1t08msQ==", null, false, "2d55a87b-5ede-49fb-b19b-208e08752f0c", false, "admin@dss.com" },
                    { "7b2b8d8a-7444-410c-9a6e-c92b85064e68", 0, "90673f7a-dbea-44fc-b3e0-92ea0e2bb2ba", "support@dss.com", true, false, null, "SUPPORT@DSS.COM", "SUPPORT@DSS.COM", "AQAAAAEAACcQAAAAECysU9avW9lAdPEPoO4kV1oFiBsuRMmPysUWRr6ZFq5GInip5ecqSRX+BDrNSYFjJA==", null, false, "ff733d9c-abd6-4a0c-bc8e-87095260af11", false, "support@dss.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "bd73f2b3-126b-4b84-94aa-7ae8c5393158", "1ae0a7c6-1955-4997-b703-2a04a83b7bfa" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "10d96a29-5161-4f72-9351-ed16085b4417", "21381825-5cf5-4780-a9a7-164df4bc02c1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "7b2b8d8a-7444-410c-9a6e-c92b85064e68", "e4c57a67-bef1-4ba9-a5b4-f4185a4d5123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "10d96a29-5161-4f72-9351-ed16085b4417", "21381825-5cf5-4780-a9a7-164df4bc02c1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "7b2b8d8a-7444-410c-9a6e-c92b85064e68", "e4c57a67-bef1-4ba9-a5b4-f4185a4d5123" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "bd73f2b3-126b-4b84-94aa-7ae8c5393158", "1ae0a7c6-1955-4997-b703-2a04a83b7bfa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae0a7c6-1955-4997-b703-2a04a83b7bfa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21381825-5cf5-4780-a9a7-164df4bc02c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4c57a67-bef1-4ba9-a5b4-f4185a4d5123");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10d96a29-5161-4f72-9351-ed16085b4417");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b2b8d8a-7444-410c-9a6e-c92b85064e68");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bd73f2b3-126b-4b84-94aa-7ae8c5393158");

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
    }
}
