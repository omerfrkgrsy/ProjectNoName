using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectNoName.Api.Migrations
{
    public partial class followadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "POST");

            migrationBuilder.CreateTable(
                name: "UserUser",
                columns: table => new
                {
                    FollowedId = table.Column<int>(type: "integer", nullable: false),
                    FollowersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser", x => new { x.FollowedId, x.FollowersId });
                    table.ForeignKey(
                        name: "FK_UserUser_USER_FollowedId",
                        column: x => x.FollowedId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUser_USER_FollowersId",
                        column: x => x.FollowersId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUser_FollowersId",
                table: "UserUser",
                column: "FollowersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUser");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "POST",
                type: "text",
                nullable: true);
        }
    }
}
