using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Columnid",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Endtime",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Starttime",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401CD605-BAEF-45CF-8BB5-FA69DA80DC63",
                column: "ConcurrencyStamp",
                value: "3ec6e759-c5d8-49c8-9b19-130f1fb4aa9a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "e87da8bf-4f9c-4618-8146-175e210cee66");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13D24B5A-E7C9-42B0-BCD2-DF0956FEB2FB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ca20ecf9-c7b8-474a-b391-01420f8f5243", "AQAAAAEAACcQAAAAECOg9nHUVv5AtZoAK+gNyOq6RvqOC1ZM7q0+1pq4eyN7Wu452wW2vFwCtEXMSQD6uQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d221d27b-b6d8-4fdc-b894-6179be3250bf", "AQAAAAEAACcQAAAAEFHjmGCe1nx+yBWQctm9r9vxP1pgxeCkoqW7ezjjblLwVvFM+iJvUiQlTsnAms71qg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Columnid",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Endtime",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Starttime",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401CD605-BAEF-45CF-8BB5-FA69DA80DC63",
                column: "ConcurrencyStamp",
                value: "2b8ade52-2709-4314-b5da-c66762dcee55");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "d2d9d84a-2b45-4e65-908e-76598f044366");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13D24B5A-E7C9-42B0-BCD2-DF0956FEB2FB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0c7ce26e-cf5f-42e0-a115-43464cc4a0fb", "AQAAAAEAACcQAAAAEPTiOCyePi1gH2MqU1Ta+j/UL20txeFOmEyTc6SI1pf6ZVlrxOUQl8xmHbmzP1kCbg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "48b3053d-a897-4906-91df-cfe838883e82", "AQAAAAEAACcQAAAAEFgFQHwyEtid3Slom3bACtBQb1iXUN5Qtmx60DS7kQ9v5SFjb1tbj4vktUj9SMRr5A==" });
        }
    }
}
