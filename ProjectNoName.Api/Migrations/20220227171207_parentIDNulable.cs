using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectNoName.Api.Migrations
{
    public partial class parentIDNulable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_POST_POST_ParentId",
                table: "POST");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "POST",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_POST_POST_ParentId",
                table: "POST",
                column: "ParentId",
                principalTable: "POST",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_POST_POST_ParentId",
                table: "POST");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "POST",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_POST_POST_ParentId",
                table: "POST",
                column: "ParentId",
                principalTable: "POST",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
