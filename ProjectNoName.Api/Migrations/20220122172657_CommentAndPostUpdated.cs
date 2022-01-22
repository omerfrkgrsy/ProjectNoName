using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectNoName.Api.Migrations
{
    public partial class CommentAndPostUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "POST",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_POST_ParentId",
                table: "POST",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_POST_POST_ParentId",
                table: "POST",
                column: "ParentId",
                principalTable: "POST",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_POST_POST_ParentId",
                table: "POST");

            migrationBuilder.DropIndex(
                name: "IX_POST_ParentId",
                table: "POST");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "POST");
        }
    }
}
