using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNetCore_EF_Employees.Models
{
    [Table("Dept")]
    public class Department
    {
        [Key]
        public int Deptno { get; set; }
        [Column("Dname")]
        public string? Name { get; set; }
        [Column("Loc")]
        public string? Location { get; set; }
    }
}
