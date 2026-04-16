using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_Pincode",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_Code",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Cities_Pincode",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "States",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_States_Code",
                table: "States",
                newName: "IX_States_CountryId");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Cities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Cities_StateId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "States",
                newName: "Code");

            migrationBuilder.RenameIndex(
                name: "IX_States_CountryId",
                table: "States",
                newName: "IX_States_Code");

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
    }
}
