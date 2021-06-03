using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudRestApiApp.Models
{
    public partial class Project
    {
        public Project()
        {
            WorksOn = new HashSet<WorksOn>();
        }
        [Key]
        public int ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public decimal? Budget { get; set; }

        public virtual ICollection<WorksOn> WorksOn { get; set; }
    }
}
