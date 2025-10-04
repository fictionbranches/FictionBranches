using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FictionBranches.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roleclaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleid = table.Column<string>(type: "text", nullable: true),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roleclaims", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    normalizedname = table.Column<string>(type: "text", nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userclaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "text", nullable: true),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userclaims", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userlogins",
                columns: table => new
                {
                    loginprovider = table.Column<string>(type: "text", nullable: false),
                    providerkey = table.Column<string>(type: "text", nullable: false),
                    providerdisplayname = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userlogins", x => new { x.loginprovider, x.providerkey });
                });

            migrationBuilder.CreateTable(
                name: "userroles",
                columns: table => new
                {
                    userid = table.Column<string>(type: "text", nullable: false),
                    roleid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userroles", x => new { x.userid, x.roleid });
                });

            migrationBuilder.CreateTable(
                name: "usertokens",
                columns: table => new
                {
                    userid = table.Column<string>(type: "text", nullable: false),
                    loginprovider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usertokens", x => new { x.userid, x.loginprovider, x.name });
                });

            migrationBuilder.AddColumn<string>(
                name: "securitystamp",
                table: "fbusers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "concurrencystamp", 
                table: "fbusers",
                type: "text",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "normalizedemail", 
                table: "fbusers",
                type: "text",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "normalizedusername", 
                table: "fbusers",
                type: "text",
                nullable: true);

            
            // Update existing records
            migrationBuilder.Sql(@"
                UPDATE fbusers 
                SET securitystamp = gen_random_uuid()::text,
                    concurrencystamp = gen_random_uuid()::text
                WHERE securitystamp IS NULL;
            ");
            migrationBuilder.Sql(@"
                UPDATE fbusers 
                SET normalizedemail = UPPER(email)::text,
                    normalizedusername = UPPER(id)::text
                WHERE normalizedemail IS NULL;
            ");

            
            
            
            migrationBuilder.AddColumn<int>(
                name: "accessfailedcount",
                table: "fbusers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "lockoutend",
                table: "fbusers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "lockoutenabled",
                table: "fbusers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "phonenumber",
                table: "fbusers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "phonenumberconfirmed",
                table: "fbusers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "twofactorenabled",
                table: "fbusers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "emailconfirmed",
                table: "fbusers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
            
            migrationBuilder.Sql(@"
                UPDATE fbusers 
                SET emailconfirmed = true;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
