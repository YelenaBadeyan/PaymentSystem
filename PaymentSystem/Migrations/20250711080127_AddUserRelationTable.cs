using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRelationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRelations",
                columns: table => new
                {
                    FirstUserId = table.Column<int>(type: "int", nullable: false),
                    SecondUserId = table.Column<int>(type: "int", nullable: false),
                    RelationType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRelations", x => new { x.FirstUserId, x.SecondUserId });
                    table.ForeignKey(
                        name: "FK_UserRelations_Users_FirstUserId",
                        column: x => x.FirstUserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRelations_Users_SecondUserId",
                        column: x => x.SecondUserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRelations_SecondUserId",
                table: "UserRelations",
                column: "SecondUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRelations");
        }
    }
}
