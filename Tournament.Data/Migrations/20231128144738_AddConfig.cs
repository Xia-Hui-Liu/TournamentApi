using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tournament.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Tour",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TournamentId",
                table: "Game",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Tour");

            migrationBuilder.AlterColumn<int>(
                name: "TournamentId",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
