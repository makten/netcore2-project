using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dashboard.Core.Models;
using dashboard.Persistence;

namespace dashboard.Core
{
    public interface ITeamRepository
    {
        Task<Team> GetTeamById(int id);
        Task<Team> GetTeamByIdWithRelations(int id);
        Task<IEnumerable<Team>> GetTeams();

        void Add(Team item);
        void Remove(Team item);
    }
}
