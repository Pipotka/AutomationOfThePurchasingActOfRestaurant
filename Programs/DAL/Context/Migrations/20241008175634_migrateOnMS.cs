using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Migrations
{
    /// <inheritdoc />
    public partial class migrateOnMS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeePosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormKey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OKUD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OKPO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OKDP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormKey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementUnit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OKEIKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StructuralUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Approver",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SignatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Approver_EmployeePosition_PositionId",
                        column: x => x.PositionId,
                        principalTable: "EmployeePosition",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeePosition_PositionId",
                        column: x => x.PositionId,
                        principalTable: "EmployeePosition",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Merchandise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchandiseKey = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchandise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchandise_MeasurementUnit_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Signature",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Points = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignatureDecryption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Signature_Approver_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Approver",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MerchandisePrice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MerchandiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CostPerUnit = table.Column<double>(type: "float", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchandisePrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchandisePrice_Merchandise_MerchandiseId",
                        column: x => x.MerchandiseId,
                        principalTable: "Merchandise",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseForm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SponsorOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovingOfficerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficerSignatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentNumber = table.Column<int>(type: "int", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressOfPurchase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcurementSpecialistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesmanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseForm_Approver_ApprovingOfficerId",
                        column: x => x.ApprovingOfficerId,
                        principalTable: "Approver",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseForm_Employee_ProcurementSpecialistId",
                        column: x => x.ProcurementSpecialistId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseForm_FormKey_FormKeyId",
                        column: x => x.FormKeyId,
                        principalTable: "FormKey",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseForm_Organization_SponsorOrganizationId",
                        column: x => x.SponsorOrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseForm_Signature_OfficerSignatureId",
                        column: x => x.OfficerSignatureId,
                        principalTable: "Signature",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseForm_Supplier_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MerchandisePricePurchaseForm",
                columns: table => new
                {
                    PricesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseFormsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchandisePricePurchaseForm", x => new { x.PricesId, x.PurchaseFormsId });
                    table.ForeignKey(
                        name: "FK_MerchandisePricePurchaseForm_MerchandisePrice_PricesId",
                        column: x => x.PricesId,
                        principalTable: "MerchandisePrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MerchandisePricePurchaseForm_PurchaseForm_PurchaseFormsId",
                        column: x => x.PurchaseFormsId,
                        principalTable: "PurchaseForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchandisePurchaseForm",
                columns: table => new
                {
                    PurchaseFormsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchasedMerchandisesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchandisePurchaseForm", x => new { x.PurchaseFormsId, x.PurchasedMerchandisesId });
                    table.ForeignKey(
                        name: "FK_MerchandisePurchaseForm_Merchandise_PurchasedMerchandisesId",
                        column: x => x.PurchasedMerchandisesId,
                        principalTable: "Merchandise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MerchandisePurchaseForm_PurchaseForm_PurchaseFormsId",
                        column: x => x.PurchaseFormsId,
                        principalTable: "PurchaseForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approver_PositionId",
                table: "Approver",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionId",
                table: "Employee",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchandise_MeasurementUnitId",
                table: "Merchandise",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchandisePrice_MerchandiseId",
                table: "MerchandisePrice",
                column: "MerchandiseId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchandisePricePurchaseForm_PurchaseFormsId",
                table: "MerchandisePricePurchaseForm",
                column: "PurchaseFormsId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchandisePurchaseForm_PurchasedMerchandisesId",
                table: "MerchandisePurchaseForm",
                column: "PurchasedMerchandisesId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_ApprovingOfficerId",
                table: "PurchaseForm",
                column: "ApprovingOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_FormKeyId",
                table: "PurchaseForm",
                column: "FormKeyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_OfficerSignatureId",
                table: "PurchaseForm",
                column: "OfficerSignatureId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_ProcurementSpecialistId",
                table: "PurchaseForm",
                column: "ProcurementSpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_SalesmanId",
                table: "PurchaseForm",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_SponsorOrganizationId",
                table: "PurchaseForm",
                column: "SponsorOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Signature_ApproverId",
                table: "Signature",
                column: "ApproverId",
                unique: true,
                filter: "[ApproverId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MerchandisePricePurchaseForm");

            migrationBuilder.DropTable(
                name: "MerchandisePurchaseForm");

            migrationBuilder.DropTable(
                name: "MerchandisePrice");

            migrationBuilder.DropTable(
                name: "PurchaseForm");

            migrationBuilder.DropTable(
                name: "Merchandise");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "FormKey");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "Signature");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "MeasurementUnit");

            migrationBuilder.DropTable(
                name: "Approver");

            migrationBuilder.DropTable(
                name: "EmployeePosition");
        }
    }
}
