using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dashboard.Core;
using dashboard.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace dashboard.Persistence
{
    public class PhotosRepository : IPhotosRepository
    {
        private readonly DashboardDbContext context;
        public PhotosRepository(DashboardDbContext context)
        {
            this.context = context;
        }
        
        public async Task<IEnumerable<Photo>> GetPhotos(int vehicleId)
        {
            return await context.Photos
                .Where( p => p.VehicleId == vehicleId).ToListAsync();
        }
    }
}