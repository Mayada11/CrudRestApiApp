using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudRestApiApp.Models
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }
        [Key]
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }

        internal Department include()
        {
            throw new NotImplementedException();
        }
    }
}
