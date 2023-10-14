using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HumanFriends.Migrations
{
    /// <inheritdoc />
    public partial class postgresqlcontainer_migration_885 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Command",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Command", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicabilityCommand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimalID = table.Column<int>(type: "integer", nullable: false),
                    CommandID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicabilityCommand", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicabilityCommand_Animal_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicabilityCommand_Command_CommandID",
                        column: x => x.CommandID,
                        principalTable: "Command",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicabilityCommand_AnimalID",
                table: "ApplicabilityCommand",
                column: "AnimalID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicabilityCommand_CommandID",
                table: "ApplicabilityCommand",
                column: "CommandID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicabilityCommand");

            migrationBuilder.DropTable(
                name: "Command");
        }
    }
}
