using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.Infrastructure.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Dashboard");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Dashboard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoyaltyScore = table.Column<int>(type: "int", nullable: false),
                    Credit = table.Column<int>(type: "int", nullable: false),
                    OpenTickets = table.Column<int>(type: "int", nullable: false),
                    MobileSpent = table.Column<long>(type: "bigint", nullable: false),
                    NonMobileSpent = table.Column<long>(type: "bigint", nullable: false),
                    LastLoginedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSinceLastPurchase = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Dashboard",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IdentityId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpertNotes",
                schema: "Dashboard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdaterId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreaterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpertNotes_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Dashboard",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertNotes_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalSchema: "Dashboard",
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                schema: "Dashboard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExternalLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Dashboard",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalSchema: "Dashboard",
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpertNotes_CustomerId",
                schema: "Dashboard",
                table: "ExpertNotes",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertNotes_CustomerId1",
                schema: "Dashboard",
                table: "ExpertNotes",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomerId",
                schema: "Dashboard",
                table: "Tickets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomerId1",
                schema: "Dashboard",
                table: "Tickets",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdentityId",
                schema: "Dashboard",
                table: "Users",
                column: "IdentityId",
                unique: true,
                filter: "[IdentityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                schema: "Dashboard",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpertNotes",
                schema: "Dashboard");

            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "Dashboard");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Dashboard");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Dashboard");
        }
    }
}
