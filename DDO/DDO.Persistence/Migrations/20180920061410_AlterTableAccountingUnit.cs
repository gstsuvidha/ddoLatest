using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DDO.Persistence.Migrations
{
    public partial class AlterTableAccountingUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventorySelection",
                table: "AccountingUnits");

            migrationBuilder.DropColumn(
                name: "InvoicePrefix",
                table: "AccountingUnits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InventorySelection",
                table: "AccountingUnits",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "InvoicePrefix",
                table: "AccountingUnits",
                nullable: true);
        }
    }
}
