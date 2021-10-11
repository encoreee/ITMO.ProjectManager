using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColumnTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Taskid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Columnid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnTasks", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401CD605-BAEF-45CF-8BB5-FA69DA80DC63",
                column: "ConcurrencyStamp",
                value: "fa5bc37e-2057-455b-9e0a-dc7542fef9dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "7a4a0631-af85-435c-a4da-d07fab60f017");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13D24B5A-E7C9-42B0-BCD2-DF0956FEB2FB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "874d0181-aa09-4035-a8ea-bc14ef0eeffb", "AQAAAAEAACcQAAAAEDSHocZPzLF7CnYOBWIf9e8pDCKNKmrQQBj4rS/ffTQMeVybMTpDQV6xVKRLKv+KEg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b52ecaee-3d6a-4f71-bab7-8638fa4c9cbf", "AQAAAAEAACcQAAAAEBzrKs3UEVs0g7E2oNIJAjp4NyiNODFrGke9uW0L3LrTRrqF0iE9euq6oD2f9c4xZw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColumnTasks");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401CD605-BAEF-45CF-8BB5-FA69DA80DC63",
                column: "ConcurrencyStamp",
                value: "6c09ac79-faf7-42e1-9263-9797fe6b2d19");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "1751d1a1-c13d-4207-b05f-fed7e4f6ad84");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13D24B5A-E7C9-42B0-BCD2-DF0956FEB2FB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe612e12-bd42-4c6f-a26a-8a4328e9c127", "AQAAAAEAACcQAAAAEKdb9r6UwqbERxDY/SvbSTcm0RPe5udblg9QXxFZRp+6KBtGpjulXhyAFfLf86mIXg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cb4d2993-e5a6-4ebb-b627-d92d23789567", "AQAAAAEAACcQAAAAEAFBIM1pcUgCMZ+Z5bOQfIR/C9C2p3VvOrqxfE4ZRTFjD6ScerGTTxPD7BUUOvc7zA==" });
        }
    }
}
