using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services
{
    public interface IServiceMaterialService
    {
        Task<IEnumerable<ServiceMaterial>> ListAsync();
        Task<IEnumerable<ServiceMaterial>> ListByServiceIdAsync(int serviceId);
        Task<IEnumerable<ServiceMaterial>> ListByMaterialIdAsync(int materialId);
        Task<ServiceMaterial> FindByServiceIdAndMaterialId(int serviceId, int materialId);
    }
}
