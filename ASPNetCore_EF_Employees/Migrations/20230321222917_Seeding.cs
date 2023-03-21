using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNetCore_EF_Employees.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dept",
                columns: new[] { "Deptno", "Loc", "Dname" },
                values: new object[,]
                {
                    { 10, "Kaai", "DT" },
                    { 20, "Danseart", "RITCS" },
                    { 30, "Bloemenhof", "MMM" },
                    { 40, "Jette", "GL" }
                });

            migrationBuilder.InsertData(
                table: "Emp",
                columns: new[] { "Empno", "Comm", "Deptno", "Hiredate", "Job", "Mgr", "Ename", "Sal" },
                values: new object[] { 100, 100.0, 10, new DateTime(2010, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Steve", 1000.0 });

            migrationBuilder.InsertData(
                table: "Emp",
                columns: new[] { "Empno", "Comm", "Deptno", "Hiredate", "Job", "Mgr", "Ename", "Sal" },
                values: new object[] { 200, 0.0, 10, new DateTime(2016, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 100, "Wim", 1000.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dept",
                keyColumn: "Deptno",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Dept",
                keyColumn: "Deptno",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Dept",
                keyColumn: "Deptno",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Emp",
                keyColumn: "Empno",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Emp",
                keyColumn: "Empno",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Dept",
                keyColumn: "Deptno",
                keyValue: 10);
        }
    }
}
