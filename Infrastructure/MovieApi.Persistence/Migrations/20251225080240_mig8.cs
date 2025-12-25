using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeazonCount",
                table: "Serieses",
                newName: "SeasonCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeasonCount",
                table: "Serieses",
                newName: "SeazonCount");
        }
    }
}
