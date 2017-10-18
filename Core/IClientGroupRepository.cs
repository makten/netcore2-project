using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dashboard.Controllers.Resources;
using dashboard.Core.Models;

namespace dashboard.Core
{
    public interface IClientGroupRepository
    {
        Task<ClientGroup> GetClientGroupById(int id);
        Task<ClientGroup> GetClientGroupByIdWithRelations(int id);
        Task<IEnumerable<ClientGroup>> GetClientGroups();

        void Add(ClientGroup clientGroup);
        void Remove(ClientGroup clientGroup);

    }
}
