using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUsers_AspNetUsers_UserId",
                table: "ProjectUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUsers_UserId",
                table: "ProjectUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ProjectUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ProjectUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401CD605-BAEF-45CF-8BB5-FA69DA80DC63",
                column: "ConcurrencyStamp",
                value: "31c679a2-303c-43a5-bb09-5ae227fa3840");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "f5faaf31-f927-4476-8ba5-7cb00bb0a0bb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13D24B5A-E7C9-42B0-BCD2-DF0956FEB2FB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "efd341c7-a373-4c59-97f4-e9bcb3888033", "AQAAAAEAACcQAAAAELM0gBPkdRQtAgwqXbUZOdE0YXGnNBk0noOKPbDDch0dAqpmbDUiLyCFvSgJY3bDZw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2b8c593d-ba27-43d1-8a95-06af49a33628", "AQAAAAEAACcQAAAAEJDQxQXqcuR2e7DkyD2P4WmeKnTg8f0Of8m6omFkCPfwd8ePAjFiFUJZWjNqP2nzyQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_UserId1",
                table: "ProjectUsers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUsers_AspNetUsers_UserId1",
                table: "ProjectUsers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUsers_AspNetUsers_UserId1",
                table: "ProjectUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUsers_UserId1",
                table: "ProjectUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ProjectUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProjectUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401CD605-BAEF-45CF-8BB5-FA69DA80DC63",
                column: "ConcurrencyStamp",
                value: "802120f6-b11a-42e6-ac76-f047fe80a791");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "82a55815-7144-4d28-a163-8c09f11b1b71");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13D24B5A-E7C9-42B0-BCD2-DF0956FEB2FB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0591440a-9423-4a5d-8a79-9b0f59ad0d97", "AQAAAAEAACcQAAAAEKDJnDMy3BtmIcYDBJBtpub86Z4VuGGpG/KmQNKFHZhGKTQkFAVgey0ErWVGmScABw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe7de99a-b505-4a34-a38e-fe483c669214", "AQAAAAEAACcQAAAAEDjyV0C410mAXR4cBjw4d9I9vDeY5qPbs+7kARuIIZbnqISemwspO2j7rtLe6ghdwA==" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_UserId",
                table: "ProjectUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUsers_AspNetUsers_UserId",
                table: "ProjectUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
