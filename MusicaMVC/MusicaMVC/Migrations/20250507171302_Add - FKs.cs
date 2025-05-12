using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicaMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAlbum",
                table: "Cancion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdArtista",
                table: "Album",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cancion_IdAlbum",
                table: "Cancion",
                column: "IdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_Album_IdArtista",
                table: "Album",
                column: "IdArtista");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artista_IdArtista",
                table: "Album",
                column: "IdArtista",
                principalTable: "Artista",
                principalColumn: "IdArtista",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cancion_Album_IdAlbum",
                table: "Cancion",
                column: "IdAlbum",
                principalTable: "Album",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artista_IdArtista",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Cancion_Album_IdAlbum",
                table: "Cancion");

            migrationBuilder.DropIndex(
                name: "IX_Cancion_IdAlbum",
                table: "Cancion");

            migrationBuilder.DropIndex(
                name: "IX_Album_IdArtista",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "IdAlbum",
                table: "Cancion");

            migrationBuilder.DropColumn(
                name: "IdArtista",
                table: "Album");
        }
    }
}
