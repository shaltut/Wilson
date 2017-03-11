﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wilson.Accounting.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Accounting");

            migrationBuilder.CreateTable(
                name: "Addresss",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Country = table.Column<string>(maxLength: 70, nullable: false),
                    Floor = table.Column<int>(nullable: true),
                    Note = table.Column<string>(maxLength: 250, nullable: true),
                    PostCode = table.Column<string>(maxLength: 10, nullable: false),
                    Street = table.Column<string>(maxLength: 70, nullable: false),
                    StreetNumber = table.Column<int>(nullable: false),
                    Town = table.Column<string>(maxLength: 70, nullable: false),
                    UnitNumber = table.Column<string>(maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Мeasure = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storehouses",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    HasVatRegistration = table.Column<bool>(nullable: false),
                    IndetificationNumber = table.Column<string>(maxLength: 9, nullable: false),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    VatNumber = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Addresss_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Accounting",
                        principalTable: "Addresss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ItemId = table.Column<Guid>(nullable: true),
                    PaymentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Accounting",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StorehouseItems",
                schema: "Accounting",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(nullable: false),
                    StorehouseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorehouseItems", x => new { x.ItemId, x.StorehouseId });
                    table.ForeignKey(
                        name: "FK_StorehouseItems_Storehouses_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Accounting",
                        principalTable: "Storehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorehouseItems_Items_StorehouseId",
                        column: x => x.StorehouseId,
                        principalSchema: "Accounting",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 70, nullable: false),
                    LastName = table.Column<string>(maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Accounting",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BullId = table.Column<Guid>(nullable: true),
                    BuyerId = table.Column<Guid>(nullable: false),
                    DateOfPayment = table.Column<DateTime>(nullable: true),
                    DaysOfDelayedPayment = table.Column<int>(nullable: false),
                    InvoicePaymentType = table.Column<int>(nullable: false),
                    InvoiceType = table.Column<int>(nullable: false),
                    InvoiceVariant = table.Column<int>(nullable: false),
                    IsPayed = table.Column<bool>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(maxLength: 10, nullable: false),
                    PayedAmount = table.Column<decimal>(nullable: false),
                    SellerId = table.Column<Guid>(nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Vat = table.Column<int>(nullable: false),
                    VatAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Companies_BuyerId",
                        column: x => x.BuyerId,
                        principalSchema: "Accounting",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Companies_SellerId",
                        column: x => x.SellerId,
                        principalSchema: "Accounting",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 900, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Companies_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                schema: "Accounting",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false),
                    PriceId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => new { x.InvoiceId, x.ItemId, x.PriceId });
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Accounting",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Prices_PriceId",
                        column: x => x.PriceId,
                        principalSchema: "Accounting",
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    InvoiceId = table.Column<Guid>(nullable: false),
                    PaymentId = table.Column<Guid>(nullable: true),
                    PriceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Prices_PaymentId",
                        column: x => x.PaymentId,
                        principalSchema: "Accounting",
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    InvoiceId = table.Column<Guid>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Accounting",
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_InvoiceId",
                schema: "Accounting",
                table: "Bills",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ProjectId",
                schema: "Accounting",
                table: "Bills",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                schema: "Accounting",
                table: "Companies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                schema: "Accounting",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_BuyerId",
                schema: "Accounting",
                table: "Invoices",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SellerId",
                schema: "Accounting",
                table: "Invoices",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_ItemId",
                schema: "Accounting",
                table: "InvoiceItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_PriceId",
                schema: "Accounting",
                table: "InvoiceItems",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoiceId",
                schema: "Accounting",
                table: "Payments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentId",
                schema: "Accounting",
                table: "Payments",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ItemId",
                schema: "Accounting",
                table: "Prices",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerId",
                schema: "Accounting",
                table: "Projects",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StorehouseItems_StorehouseId",
                schema: "Accounting",
                table: "StorehouseItems",
                column: "StorehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "InvoiceItems",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "StorehouseItems",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Prices",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Storehouses",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Addresss",
                schema: "Accounting");
        }
    }
}
