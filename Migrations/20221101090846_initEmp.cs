using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class initEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpID = table.Column<int>(type: "int", nullable: false),
                        
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConPwd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ph = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpID);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    LID = table.Column<int>(type: "int", nullable: false),
                        
                    LStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.LID);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManID = table.Column<int>(type: "int", nullable: false),
                        
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConPwd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ph = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManID);
                });

            migrationBuilder.CreateTable(
                name: "ApplyLeave",
                columns: table => new
                {
                    Token = table.Column<int>(type: "int", nullable: false),
                        
                    LID = table.Column<int>(type: "int", nullable: false),
                    EmpID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyLeave", x => x.Token);
                    table.ForeignKey(
                        name: "FK_ApplyLeave_Employees_EmpID",
                        column: x => x.EmpID,
                        principalTable: "Employees",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplyLeave_Leaves_LID",
                        column: x => x.LID,
                        principalTable: "Leaves",
                        principalColumn: "LID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplyLeave_EmpID",
                table: "ApplyLeave",
                column: "EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyLeave_LID",
                table: "ApplyLeave",
                column: "LID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyLeave");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Leaves");
        }
    }
}
