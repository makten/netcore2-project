using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dashboard.Core.Models;

namespace dashboard.Controllers.Resources
{
    public class ClientGroupResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TeamEnvironment> TeamEnvironments { get; set; }

        public ClientGroupResource()
        {
            TeamEnvironments = new List<TeamEnvironment>();
        }
    }
}
