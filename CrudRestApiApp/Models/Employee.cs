using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudRestApiApp.Models
{
    public partial class Employee
    {
        public Employee()
        {
            WorksOn = new HashSet<WorksOn>();
        }
        [Key]
        public int EmpNo { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? Salary { get; set; }
        public int? DeptNo { get; set; }

        public virtual Department DeptNoNavigation { get; set; }
        public virtual ICollection<WorksOn> WorksOn { get; set; }
    }
}
