using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstMVCApp.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    IdAnnouncement = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.IdAnnouncement);
                });

            migrationBuilder.CreateTable(
                name: "CodeSnippets",
                columns: table => new
                {
                    IDCodeSnippet = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDMember = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Revision = table.Column<int>(type: "int", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    DateTimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeSnippets", x => x.IDCodeSnippet);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    IDMember = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.IDMember);
                });

            migrationBuilder.CreateTable(
                name: "MembershipTypes",
                columns: table => new
                {
                    IDMembershipType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionLengthInMonths = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTypes", x => x.IDMembershipType);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    IDMembership = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberIDMember = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDMembershipType1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.IDMembership);
                    table.ForeignKey(
                        name: "FK_Memberships_Members_MemberIDMember",
                        column: x => x.MemberIDMember,
                        principalTable: "Members",
                        principalColumn: "IDMember",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_MembershipTypes_IDMembershipType1",
                        column: x => x.IDMembershipType1,
                        principalTable: "MembershipTypes",
                        principalColumn: "IDMembershipType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_IDMembershipType1",
                table: "Memberships",
                column: "IDMembershipType1");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_MemberIDMember",
                table: "Memberships",
                column: "MemberIDMember");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "CodeSnippets");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "MembershipTypes");
        }
    }
}
