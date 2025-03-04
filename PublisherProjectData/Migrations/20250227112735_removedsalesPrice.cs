using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublisherProject.Migrations
{
    /// <inheritdoc />
    public partial class removedsalesPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesPrice",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SalesPrice",
                table: "Books",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
