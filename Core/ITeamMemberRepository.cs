using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dashboard.Core.Models;

namespace dashboard.Core
{
    public interface ITeamMemberRepository
    {
        Task<TeamMember> GetMemberById(int id);
        Task<TeamMember> GetTeamMemberByIdWithRelations(int id);

        Task<IEnumerable<TeamMember>> GetMembers();

        void Add(TeamMember member);
        void Remove(TeamMember member);
    }
}
