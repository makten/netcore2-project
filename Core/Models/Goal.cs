using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dashboard.Core.Models
{
    [Table("Goals")]
    public class Goal
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string SprintCode { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public DateTime? GoalStart { get; set; }
        public DateTime? GoalEnd { get; set; }
        public int TeamMemberId { get; set; }
    }
}
