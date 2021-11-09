using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401CD605-BAEF-45CF-8BB5-FA69DA80DC63",
                column: "ConcurrencyStamp",
                value: "ed334f74-db65-4500-89af-2a5bb9628f59");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "d91e683a-4e15-4705-b3c9-d9e95574fe00");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13D24B5A-E7C9-42B0-BCD2-DF0956FEB2FB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1d288ce2-8921-4904-824b-fddf9c654303", "AQAAAAEAACcQAAAAEHmr9t/fEMCcMQ4BTJHoK3LV6Ul5Z//jxS8MqsLYzlg5225OE95n7rTnIVsWsurqpQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e6e51abb-6571-4f48-b4a6-9d54a61edba7", "AQAAAAEAACcQAAAAEEbv2B6q9WuND55VkffGk6udVhEWDxDwHIy/evPCrjmqlnm0eNMiIsTp6KYxkKleuw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
