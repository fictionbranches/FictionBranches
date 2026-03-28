using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace FictionBranches.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class full_text_search_episode_index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "searchvector",
                table: "fbepisodes",
                type: "tsvector",
                nullable: false)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "newmap", "title", "link", "body" });

            migrationBuilder.CreateIndex(
                name: "ix_fbepisodes_searchvector",
                table: "fbepisodes",
                column: "searchvector")
                .Annotation("Npgsql:IndexMethod", "GIN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_fbepisodes_searchvector",
                table: "fbepisodes");

            migrationBuilder.DropColumn(
                name: "searchvector",
                table: "fbepisodes");
        }
    }
}
