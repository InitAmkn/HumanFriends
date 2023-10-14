using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HumanFriends.Migrations
{
    /// <inheritdoc />
    public partial class postgresqlcontainer_migration_341 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicabilityAnimal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicabilityAnimal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypeAnimal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ApplicabilityAnimalID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAnimal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TypeAnimal_ApplicabilityAnimal_ApplicabilityAnimalID",
                        column: x => x.ApplicabilityAnimalID,
                        principalTable: "ApplicabilityAnimal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    TypeAnimalID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Animal_TypeAnimal_TypeAnimalID",
                        column: x => x.TypeAnimalID,
                        principalTable: "TypeAnimal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_TypeAnimalID",
                table: "Animal",
                column: "TypeAnimalID");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAnimal_ApplicabilityAnimalID",
                table: "TypeAnimal",
                column: "ApplicabilityAnimalID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "TypeAnimal");

            migrationBuilder.DropTable(
                name: "ApplicabilityAnimal");
        }
    }
}
