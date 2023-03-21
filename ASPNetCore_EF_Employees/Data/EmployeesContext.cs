using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPNetCore_EF_Employees.Models;

namespace ASPNetCore_EF_Employees.Data
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions<EmployeesContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasData(
                    new Department { Deptno = 10, Name = "DT", Location = "Kaai" },
                    new Department { Deptno = 20, Name = "RITCS", Location = "Danseart" },
                    new Department { Deptno = 30, Name = "MMM", Location = "Bloemenhof" },
                    new Department { Deptno = 40, Name = "GL", Location = "Jette" }
                );

            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee { Empno = 100, Name = "Steve", Job = Job.Manager, Hiredate = new DateTime(2010, 9, 1), Salary = 1000, Commission = 100, Deptno = 10 },
                    new Employee { Empno = 200, Name = "Wim", Job = Job.Analyst, Mgr = 100, Hiredate = new DateTime(2016, 10, 1), Salary = 1000, Commission = 0, Deptno = 10 }
                );
        }

        public DbSet<Employee> Employees { get; set; } = default!;
        public DbSet<Department> Departments { get; set; } = default!;
    }
}
