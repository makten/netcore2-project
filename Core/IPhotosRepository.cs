using System.Collections.Generic;
using System.Threading.Tasks;
using dashboard.Core.Models;

namespace dashboard.Core
{
    public interface IPhotosRepository
    {
        Task<IEnumerable<Photo>> GetPhotos(int vehicleId);
       
    }
}