using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyApi.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Subordinate = new HashSet<Employee>();
        }

        public int EmployeeId { get; set; }
        [StringLength(15)]
        public string FirstName { get; set; }
        [StringLength(15)]
        public string LastName { get; set; }
        public int? ManagerId { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal? Salary { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal? Bonus { get; set; }
        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        [InverseProperty("Employee")]
        public Department Department { get; set; }
        [ForeignKey("ManagerId")]
        [InverseProperty("Subordinate")]
        public Employee Manager { get; set; }
        [InverseProperty("Manager")]
        public ICollection<Employee> Subordinate { get; set; }
    }
}
