using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PunchcodeStudios.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GalleryCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GalleryTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GalleryGalleryCategory",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GalleriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryGalleryCategory", x => new { x.CategoriesId, x.GalleriesId });
                    table.ForeignKey(
                        name: "FK_GalleryGalleryCategory_Galleries_GalleriesId",
                        column: x => x.GalleriesId,
                        principalTable: "Galleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GalleryGalleryCategory_GalleryCategories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "GalleryCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GalleryGalleryType",
                columns: table => new
                {
                    GalleriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryGalleryType", x => new { x.GalleriesId, x.TypesId });
                    table.ForeignKey(
                        name: "FK_GalleryGalleryType_Galleries_GalleriesId",
                        column: x => x.GalleriesId,
                        principalTable: "Galleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GalleryGalleryType_GalleryTypes_TypesId",
                        column: x => x.TypesId,
                        principalTable: "GalleryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GalleryGalleryCategory_GalleriesId",
                table: "GalleryGalleryCategory",
                column: "GalleriesId");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryGalleryType_TypesId",
                table: "GalleryGalleryType",
                column: "TypesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryGalleryCategory");

            migrationBuilder.DropTable(
                name: "GalleryGalleryType");

            migrationBuilder.DropTable(
                name: "GalleryCategories");

            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropTable(
                name: "GalleryTypes");
        }
    }
}
