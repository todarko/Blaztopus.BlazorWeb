using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blaztopus.BlazorWeb.Migrations
{
    public partial class restri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_FormChildren_FormChildId",
                table: "Forms");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_FormChildren_FormChildId",
                table: "Forms",
                column: "FormChildId",
                principalTable: "FormChildren",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_FormChildren_FormChildId",
                table: "Forms");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_FormChildren_FormChildId",
                table: "Forms",
                column: "FormChildId",
                principalTable: "FormChildren",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
