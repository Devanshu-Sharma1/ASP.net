using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }
        public int Sal { get; set; }
        public double Deptno { get; set; }
    }
}