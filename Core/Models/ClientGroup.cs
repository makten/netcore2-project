using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dashboard.Core.Models
{
    [Table("ClientGroups")]
    public class ClientGroup
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        public List<TeamEnvironment> TeamEnvironments { get; set; }

        public ClientGroup()
        {
            TeamEnvironments = new List<TeamEnvironment>();
        }

    }
}
