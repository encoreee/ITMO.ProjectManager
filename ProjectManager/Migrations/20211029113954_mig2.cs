using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401CD605-BAEF-45CF-8BB5-FA69DA80DC63",
                column: "ConcurrencyStamp",
                value: "ed821411-e0bc-4a51-be86-876c748024a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "db5e7ce6-ff23-4b8d-ab63-bb3e9698d577");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13D24B5A-E7C9-42B0-BCD2-DF0956FEB2FB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3e6fb5dd-b1c5-4ab1-b149-b4ed86e3d6b1", "AQAAAAEAACcQAAAAELfUTwoN115+W37urHd2sZgaMAPI62Tw8RQ5GC2bGdv/wvKxSLvkUj0FfXxKl7HKbg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "591713cf-39d8-44db-80aa-1b5f6136a430", "AQAAAAEAACcQAAAAEJZJmvBUhYF5RWNz5AsWohkVzyHWd9V32HLEOnY2YK3vz5KGVfGDGofNOhKiqRbrPQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401CD605-BAEF-45CF-8BB5-FA69DA80DC63",
                column: "ConcurrencyStamp",
                value: "0eb8bb3c-0019-42b7-946d-3aeef49fe2e0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "32df937d-3333-4120-a990-9fc33540eb7e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13D24B5A-E7C9-42B0-BCD2-DF0956FEB2FB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c37df21c-52c3-46cd-8717-5cc6e31e1068", "AQAAAAEAACcQAAAAEB5YgztD8NXTKaTSEl3CfUmwNXWHLJVDcJvdJ8ZoAwqUMYID7IUQuYcNzSTW6A1Btg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4445783f-98f1-49db-8e36-b46ee6f88c1e", "AQAAAAEAACcQAAAAEDx7/pdH8EKF50rWNUtQhozr3e3GPE7GyJFt37WY+ur8DTg7wJVjjCZes/d/dcTbRw==" });
        }
    }
}
