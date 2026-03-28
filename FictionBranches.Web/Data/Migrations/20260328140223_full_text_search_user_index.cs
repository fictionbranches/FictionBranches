using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace FictionBranches.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class full_text_search_user_index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "searchvector",
                table: "fbusers",
                type: "tsvector",
                nullable: false)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "id", "author" });

            migrationBuilder.CreateIndex(
                name: "ix_fbusers_searchvector",
                table: "fbusers",
                column: "searchvector")
                .Annotation("Npgsql:IndexMethod", "GIN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_fbusers_searchvector",
                table: "fbusers");

            migrationBuilder.DropColumn(
                name: "searchvector",
                table: "fbusers");
        }
    }
}
