using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dashboard.Core.Models;

namespace dashboard.Core
{
    public interface ITeamEnvironmentRepository
    {
        Task<TeamEnvironment> GetTeamEvironmentById(int id);
        Task<TeamEnvironment> GetTeamEvironmentByIdWithRelations(int id);

        Task<IEnumerable<TeamEnvironment>> GetTeamEvironments(int teamId);

        void Add(TeamEnvironment environment);
        void Remove(TeamEnvironment environment);
    }
}
