using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "emp");

            migrationBuilder.CreateSequence(
                name: "EmployeeDb",
                schema: "emp",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Employeelevel",
                schema: "emp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeelevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePosition",
                schema: "emp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "emp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_Country = table.Column<string>(nullable: true),
                    EmployeeLevelId = table.Column<int>(nullable: false),
                    EmployeePositionId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employeelevel_EmployeeLevelId",
                        column: x => x.EmployeeLevelId,
                        principalSchema: "emp",
                        principalTable: "Employeelevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeePosition_EmployeePositionId",
                        column: x => x.EmployeePositionId,
                        principalSchema: "emp",
                        principalTable: "EmployeePosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeLevelId",
                schema: "emp",
                table: "Employees",
                column: "EmployeeLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeePositionId",
                schema: "emp",
                table: "Employees",
                column: "EmployeePositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees",
                schema: "emp");

            migrationBuilder.DropTable(
                name: "Employeelevel",
                schema: "emp");

            migrationBuilder.DropTable(
                name: "EmployeePosition",
                schema: "emp");

            migrationBuilder.DropSequence(
                name: "EmployeeDb",
                schema: "emp");
        }
    }
}
