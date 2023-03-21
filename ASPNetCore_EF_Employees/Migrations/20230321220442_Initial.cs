using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNetCore_EF_Employees.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dept",
                columns: table => new
                {
                    Deptno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dept", x => x.Deptno);
                });

            migrationBuilder.CreateTable(
                name: "Emp",
                columns: table => new
                {
                    Empno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job = table.Column<int>(type: "int", nullable: false),
                    Mgr = table.Column<int>(type: "int", nullable: true),
                    Hiredate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sal = table.Column<double>(type: "float", nullable: false),
                    Comm = table.Column<double>(type: "float", nullable: false),
                    Deptno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp", x => x.Empno);
                    table.ForeignKey(
                        name: "FK_Emp_Dept_Deptno",
                        column: x => x.Deptno,
                        principalTable: "Dept",
                        principalColumn: "Deptno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emp_Emp_Mgr",
                        column: x => x.Mgr,
                        principalTable: "Emp",
                        principalColumn: "Empno");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emp_Deptno",
                table: "Emp",
                column: "Deptno");

            migrationBuilder.CreateIndex(
                name: "IX_Emp_Mgr",
                table: "Emp",
                column: "Mgr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emp");

            migrationBuilder.DropTable(
                name: "Dept");
        }
    }
}
