using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401CD605-BAEF-45CF-8BB5-FA69DA80DC63",
                column: "ConcurrencyStamp",
                value: "68203c54-9949-4b67-9a61-11335be7a24f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "1c5cf656-5cfd-4128-b0a4-dba8122602cb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13D24B5A-E7C9-42B0-BCD2-DF0956FEB2FB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6aa91585-be15-4e25-9e12-e58cca3329ee", "AQAAAAEAACcQAAAAEGiPIj3RvPCNzTYtG8o4aG4hk+MYu4qwyWFV+zlJI40P2NkoRqsfnl3SMgkFz/C28g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "177a325f-8c28-4f03-bbfe-b3375ba9b7d2", "AQAAAAEAACcQAAAAEN1YlUctKCzFLMXWEJZ//6I/+EqEx5/mGYoV9Uo7kV6KeRUKC3FV/I7J9KS3fQL9ZQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
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
    }
}
