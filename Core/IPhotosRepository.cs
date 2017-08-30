using System.Collections.Generic;
using System.Threading.Tasks;
using dashboard.Core.Models;
using Microsoft.AspNetCore.Hosting;

namespace dashboard.Core
{
    public interface IPhotosRepository
    {
        Task<IEnumerable<Photo>> GetPhotos(int vehicleId);

        void DeletePhoto(int photoId, string uploadFolderPath);
       
    }
}