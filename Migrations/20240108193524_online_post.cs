using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONLINE_POST.Migrations
{
    public partial class online_post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charges",
                columns: table => new
                {
                    c_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    min_weight = table.Column<int>(type: "int", nullable: false),
                    max_weight = table.Column<int>(type: "int", nullable: false),
                    c_rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charges", x => x.c_id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    c_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.c_id);
                });

            migrationBuilder.CreateTable(
                name: "Delivery_Histories",
                columns: table => new
                {
                    DeliverableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tracking_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfPosting = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DestinationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDelivered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    package_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    normal_charges = table.Column<int>(type: "int", nullable: false),
                    service_charges = table.Column<int>(type: "int", nullable: false),
                    Total_Price = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery_Histories", x => x.DeliverableId);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    p_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    p_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    p_dis = table.Column<int>(type: "int", nullable: false),
                    p_price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.p_id);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    p_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    p_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.p_id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    r_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    r_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__roles__C476232731402581", x => x.r_id);
                });

            migrationBuilder.CreateTable(
                name: "servicetypes",
                columns: table => new
                {
                    s_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    service_charges = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicetypes", x => x.s_id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    s_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    s_type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.s_id);
                });

            migrationBuilder.CreateTable(
                name: "branches",
                columns: table => new
                {
                    b_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    b_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    c_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branches", x => x.b_id);
                    table.ForeignKey(
                        name: "FK_branches_cities_c_id",
                        column: x => x.c_id,
                        principalTable: "cities",
                        principalColumn: "c_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "personal_informations",
                columns: table => new
                {
                    p_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    p_user_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    p_email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    p_password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    p_role_id = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((2))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__personal__82E06B91B4ACF851", x => x.p_id);
                    table.ForeignKey(
                        name: "FK__personal___p_rol__412EB0B6",
                        column: x => x.p_role_id,
                        principalTable: "roles",
                        principalColumn: "r_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emplogs",
                columns: table => new
                {
                    EId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch = table.Column<int>(type: "int", nullable: false),
                    ERoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emplogs", x => x.EId);
                    table.ForeignKey(
                        name: "FK_emplogs_branches_Branch",
                        column: x => x.Branch,
                        principalTable: "branches",
                        principalColumn: "b_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emplogs_roles_ERoleId",
                        column: x => x.ERoleId,
                        principalTable: "roles",
                        principalColumn: "r_id");
                });

            migrationBuilder.CreateTable(
                name: "employee_informations",
                columns: table => new
                {
                    e_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    e_user_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    e_email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    e_password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Branch = table.Column<int>(type: "int", nullable: false),
                    e_role_id = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((3))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__employee__3E2ED64A7C1E550E", x => x.e_id);
                    table.ForeignKey(
                        name: "FK__employee___e_rol__3B75D760",
                        column: x => x.e_role_id,
                        principalTable: "roles",
                        principalColumn: "r_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_informations_branches_Branch",
                        column: x => x.Branch,
                        principalTable: "branches",
                        principalColumn: "b_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Packages",
                columns: table => new
                {
                    c_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    package_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    package_discount = table.Column<int>(type: "int", nullable: false),
                    package_price = table.Column<int>(type: "int", nullable: false),
                    expired = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Packages", x => x.c_id);
                    table.ForeignKey(
                        name: "FK_Customer_Packages_personal_informations_user_id",
                        column: x => x.user_id,
                        principalTable: "personal_informations",
                        principalColumn: "p_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliverables",
                columns: table => new
                {
                    DeliverableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tracking_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    DateOfPosting = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeOfDelivery = table.Column<int>(type: "int", nullable: false),
                    pay_id = table.Column<int>(type: "int", nullable: false),
                    DestinationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDelivered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    package_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    branch_id = table.Column<int>(type: "int", nullable: false),
                    c_id = table.Column<int>(type: "int", nullable: false),
                    Total_Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverables", x => x.DeliverableId);
                    table.ForeignKey(
                        name: "FK_Deliverables_branches_branch_id",
                        column: x => x.branch_id,
                        principalTable: "branches",
                        principalColumn: "b_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliverables_Charges_c_id",
                        column: x => x.c_id,
                        principalTable: "Charges",
                        principalColumn: "c_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliverables_payments_pay_id",
                        column: x => x.pay_id,
                        principalTable: "payments",
                        principalColumn: "p_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliverables_personal_informations_User_id",
                        column: x => x.User_id,
                        principalTable: "personal_informations",
                        principalColumn: "p_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliverables_servicetypes_TypeOfDelivery",
                        column: x => x.TypeOfDelivery,
                        principalTable: "servicetypes",
                        principalColumn: "s_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_branches_c_id",
                table: "branches",
                column: "c_id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Packages_user_id",
                table: "Customer_Packages",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverables_branch_id",
                table: "Deliverables",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverables_c_id",
                table: "Deliverables",
                column: "c_id");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverables_pay_id",
                table: "Deliverables",
                column: "pay_id");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverables_TypeOfDelivery",
                table: "Deliverables",
                column: "TypeOfDelivery");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverables_User_id",
                table: "Deliverables",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_emplogs_Branch",
                table: "emplogs",
                column: "Branch");

            migrationBuilder.CreateIndex(
                name: "IX_emplogs_ERoleId",
                table: "emplogs",
                column: "ERoleId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_informations_Branch",
                table: "employee_informations",
                column: "Branch");

            migrationBuilder.CreateIndex(
                name: "IX_employee_informations_e_role_id",
                table: "employee_informations",
                column: "e_role_id");

            migrationBuilder.CreateIndex(
                name: "UQ__employee__12E5DDF5AACC7E40",
                table: "employee_informations",
                column: "e_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__employee__EA4040794CADA275",
                table: "employee_informations",
                column: "e_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_personal_informations_p_role_id",
                table: "personal_informations",
                column: "p_role_id");

            migrationBuilder.CreateIndex(
                name: "UQ__personal__05B441C35D5C8B1F",
                table: "personal_informations",
                column: "p_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__personal__37393E4664DDC0F2",
                table: "personal_informations",
                column: "p_email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_Packages");

            migrationBuilder.DropTable(
                name: "Deliverables");

            migrationBuilder.DropTable(
                name: "Delivery_Histories");

            migrationBuilder.DropTable(
                name: "emplogs");

            migrationBuilder.DropTable(
                name: "employee_informations");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Charges");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "personal_informations");

            migrationBuilder.DropTable(
                name: "servicetypes");

            migrationBuilder.DropTable(
                name: "branches");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
