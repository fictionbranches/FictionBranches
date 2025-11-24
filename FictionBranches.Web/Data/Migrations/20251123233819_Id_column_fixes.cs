using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FictionBranches.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class Id_column_fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbupvotes",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbtags",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbrecentuserblocks",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbnotifications",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbmodepisodes",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbflaggedepisodes",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbflaggedcomments",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbfaveps",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbfailedloginattempts",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbepisodeviews",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbepisodetags",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "generatedid",
                table: "fbepisodes",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbcommentsubs",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbcomments",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbauthorsubscriptions",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbarchivetokens",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbannouncementviews",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbannouncements",
                type: "bigint",
                nullable: false,
                defaultValueSql: "nextval('hibernate_sequence')",
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbupvotes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbtags",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbrecentuserblocks",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbnotifications",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbmodepisodes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbflaggedepisodes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbflaggedcomments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbfaveps",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbfailedloginattempts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbepisodeviews",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbepisodetags",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "generatedid",
                table: "fbepisodes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbcommentsubs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbcomments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbauthorsubscriptions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbarchivetokens",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbannouncementviews",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "fbannouncements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('hibernate_sequence')");
        }
    }
}
