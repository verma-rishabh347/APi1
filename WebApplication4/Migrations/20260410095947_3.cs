using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "States",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_States_Code",
                table: "States",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Pincode",
                table: "Cities",
                column: "Pincode");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_Pincode",
                table: "Cities",
                column: "Pincode",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_Code",
                table: "States",
                column: "Code",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_Pincode",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_Code",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_Code",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Cities_Pincode",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "States");
        }
    }
}
