using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublisherProjectData.Migrations
{
    /// <inheritdoc />
    public partial class NavigationsAndRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistCover_Artists_ArtistsArtistId",
                table: "ArtistCover");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistCover_Covers_CoversCoverId",
                table: "ArtistCover");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistCover",
                table: "ArtistCover");

            migrationBuilder.RenameTable(
                name: "ArtistCover",
                newName: "CoverArtist");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistCover_CoversCoverId",
                table: "CoverArtist",
                newName: "IX_CoverArtist_CoversCoverId");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Covers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoverArtist",
                table: "CoverArtist",
                columns: new[] { "ArtistsArtistId", "CoversCoverId" });

            migrationBuilder.CreateIndex(
                name: "IX_Covers_BookId",
                table: "Covers",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoverArtist_Artists_ArtistsArtistId",
                table: "CoverArtist",
                column: "ArtistsArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoverArtist_Covers_CoversCoverId",
                table: "CoverArtist",
                column: "CoversCoverId",
                principalTable: "Covers",
                principalColumn: "CoverId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Covers_Books_BookId",
                table: "Covers",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoverArtist_Artists_ArtistsArtistId",
                table: "CoverArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_CoverArtist_Covers_CoversCoverId",
                table: "CoverArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_Covers_Books_BookId",
                table: "Covers");

            migrationBuilder.DropIndex(
                name: "IX_Covers_BookId",
                table: "Covers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoverArtist",
                table: "CoverArtist");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Covers");

            migrationBuilder.RenameTable(
                name: "CoverArtist",
                newName: "ArtistCover");

            migrationBuilder.RenameIndex(
                name: "IX_CoverArtist_CoversCoverId",
                table: "ArtistCover",
                newName: "IX_ArtistCover_CoversCoverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistCover",
                table: "ArtistCover",
                columns: new[] { "ArtistsArtistId", "CoversCoverId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistCover_Artists_ArtistsArtistId",
                table: "ArtistCover",
                column: "ArtistsArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistCover_Covers_CoversCoverId",
                table: "ArtistCover",
                column: "CoversCoverId",
                principalTable: "Covers",
                principalColumn: "CoverId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
