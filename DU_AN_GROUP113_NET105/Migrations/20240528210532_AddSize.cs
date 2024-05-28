using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DU_AN_GROUP113_NET105.Migrations
{
    /// <inheritdoc />
    public partial class AddSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SizeCategory",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_SizeCategory",
                table: "Product",
                column: "SizeCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Size_SizeCategory",
                table: "Product",
                column: "SizeCategory",
                principalTable: "Size",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Size_SizeCategory",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropIndex(
                name: "IX_Product_SizeCategory",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SizeCategory",
                table: "Product");
        }
    }
}
