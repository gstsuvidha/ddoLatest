using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DDO.Persistence.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountingUnits",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    AuthorizedRepresentativeName = table.Column<string>(nullable: true),
                    BankAccountName = table.Column<string>(nullable: true),
                    BankAccountNumber = table.Column<string>(nullable: true),
                    BusinessName = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    CurrentGrossTurnOver = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gstin = table.Column<string>(nullable: true),
                    GstinPassword = table.Column<string>(nullable: true),
                    IfscCode = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    InventorySelection = table.Column<bool>(nullable: false),
                    InvoicePrefix = table.Column<string>(nullable: true),
                    LastGrossTurnOver = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Pan = table.Column<string>(nullable: true),
                    PlaceOfSupply = table.Column<string>(nullable: true),
                    RegistrationType = table.Column<string>(nullable: true),
                    SelectedYear = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    TdsGstin = table.Column<string>(nullable: true),
                    TermsAndCondition = table.Column<string>(nullable: true),
                    TurnOver = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountingUnitId = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gstin = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RegistrationType = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_AccountingUnits_AccountingUnitId",
                        column: x => x.AccountingUnitId,
                        principalTable: "AccountingUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tdss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountingUnitId = table.Column<string>(nullable: true),
                    AmountPaid = table.Column<double>(nullable: false),
                    CgstAmount = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IgstAmount = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PlaceOfSupply = table.Column<string>(nullable: true),
                    SgstAmount = table.Column<double>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    TdsAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tdss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tdss_AccountingUnits_AccountingUnitId",
                        column: x => x.AccountingUnitId,
                        principalTable: "AccountingUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tdss_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_AccountingUnitId",
                table: "Suppliers",
                column: "AccountingUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Tdss_AccountingUnitId",
                table: "Tdss",
                column: "AccountingUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Tdss_SupplierId",
                table: "Tdss",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tdss");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "AccountingUnits");
        }
    }
}
