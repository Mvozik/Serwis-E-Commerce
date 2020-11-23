using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Migrations
{
    public partial class categoryaddupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Sections_SectionId1",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId1",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_CategoryId1",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SectionId1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "SectionId1",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "SubCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectionId1",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId1",
                table: "SubCategories",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SectionId1",
                table: "Categories",
                column: "SectionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Sections_SectionId1",
                table: "Categories",
                column: "SectionId1",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId1",
                table: "SubCategories",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
