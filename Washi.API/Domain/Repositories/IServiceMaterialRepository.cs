using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IServiceMaterialRepository
    {
        Task<IEnumerable<ServiceMaterial>> ListAsync();
        Task<IEnumerable<ServiceMaterial>> ListByServiceIdAsync(int serviceId);
        Task<IEnumerable<ServiceMaterial>> ListByMaterialIdAsync(int materialId);
        Task<ServiceMaterial> FindByServiceIdAndByMaterialId(int serviceId, int materialId);
        Task AddAsync(ServiceMaterial serviceMaterial);
        void Remove(ServiceMaterial serviceMaterial);
        Task AssignServiceMaterial(int serviceId, int materialId, string name);
        void UnassignServiceMaterial(int serviceId, int materialId);
    }
}
