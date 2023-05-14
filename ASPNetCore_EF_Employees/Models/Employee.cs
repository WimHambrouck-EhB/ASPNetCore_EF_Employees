using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ASPNetCore_EF_Employees.Attributes;

namespace ASPNetCore_EF_Employees.Models
{
    [Table("Emp")]
    public class Employee
    {
        [Key]
        public int Empno { get; set; }

        [Column("Ename")]
        [Required]
        [DisplayFormat(NullDisplayText = "No manager")]
        public string Name { get; set; } = string.Empty;
        public Job Job { get; set; }

        [Display(Name = nameof(Manager))]
        [ForeignKey(nameof(Manager))]
        [CompareNoMatch(nameof(Empno), ErrorMessage = "An employee cannot be their own manager")]
        public int? Mgr { get; set; }

        public Employee? Manager { get; set; }

        [DataType(DataType.Date)]
        public DateTime Hiredate { get; set; }

        [Column("Sal")]
        [DataType(DataType.Currency)]
        [Range(1000, double.MaxValue, ErrorMessage = "{0} must be at least {1}")] // cf.: https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-6.0#error-messages
        public double Salary { get; set; }

        [Column("Comm")]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "{0} cannot be negative")]
        public double Commission { get; set; }

        [Display(Name = nameof(Department))]
        [ForeignKey(nameof(Department))]
        public int Deptno { get; set; }
        public Department? Department { get; set; }
    }
}
