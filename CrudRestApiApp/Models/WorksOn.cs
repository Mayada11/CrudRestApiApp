using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudRestApiApp.Models
{
    public partial class WorksOn
    {
         [Key]
        public int EmpNo { get; set; }
         [Key]
        public int ProjectNo { get; set; }
        public string Job { get; set; }
        public DateTime? EnterDate { get; set; }

        public virtual Employee EmpNoNavigation { get; set; }
        public virtual Project ProjectNoNavigation { get; set; }
    }
}
