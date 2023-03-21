using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPNetCore_EF_Employees.Models;

namespace ASPNetCore_EF_Employees.Data
{
    public class ASPNetCore_EF_EmployeesContext : DbContext
    {
        public ASPNetCore_EF_EmployeesContext (DbContextOptions<ASPNetCore_EF_EmployeesContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } = default!;
        public DbSet<Department> Departments { get; set; } = default!;
    }
}
