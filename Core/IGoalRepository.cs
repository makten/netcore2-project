using System.Collections.Generic;
using System.Threading.Tasks;
using dashboard.Core.Models;

namespace dashboard.Core
{
    public interface IGoalRepository
    {
        Task<Goal> GetGoalById(int id);
        Task<Goal> GetGoalByIdWithRelations(int id);

        Task<IEnumerable<Goal>> GetGoals();

        void Add(Goal goal);
        void Remove(Goal goal);
    }
}
