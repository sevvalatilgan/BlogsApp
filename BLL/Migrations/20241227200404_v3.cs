using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLL.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Roles_RoleId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Roles");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleId",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Roles_RoleId",
                table: "Roles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
