using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DDO.Persistence.Migrations
{
    public partial class addedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Tdss",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Suppliers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "AccountingUnits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tdss_AdminId",
                table: "Tdss",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_AdminId",
                table: "Suppliers",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingUnits_AdminId",
                table: "AccountingUnits",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingUnits_Admins_AdminId",
                table: "AccountingUnits",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Admins_AdminId",
                table: "Suppliers",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tdss_Admins_AdminId",
                table: "Tdss",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingUnits_Admins_AdminId",
                table: "AccountingUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Admins_AdminId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tdss_Admins_AdminId",
                table: "Tdss");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Tdss_AdminId",
                table: "Tdss");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_AdminId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_AccountingUnits_AdminId",
                table: "AccountingUnits");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Tdss");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "AccountingUnits");
        }
    }
}
