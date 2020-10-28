using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Persistence.Contexts;
using Washi.API.Domain.Repositories;

namespace Washi.API.Persistence.Repositories
{
    public class ServiceMaterialRepository : BaseRepository, IServiceMaterialRepository
    {
        public ServiceMaterialRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(ServiceMaterial serviceMaterial)
        {
            await _context.ServiceMaterials.AddAsync(serviceMaterial);
        }

        public async Task AssignServiceMaterial(int serviceId, int materialId, string name)
        {
            ServiceMaterial serviceMaterial = await FindByServiceIdAndByMaterialId(serviceId, materialId);
            if (serviceMaterial == null)
            {
                serviceMaterial = new ServiceMaterial { MaterialId = materialId, ServiceId = serviceId, Name = name };
                await AddAsync(serviceMaterial);
            }
        }

        public async Task<ServiceMaterial> FindByServiceIdAndByMaterialId(int serviceId, int materialId)
        {
            return await _context.ServiceMaterials.FindAsync(serviceId, materialId);
        }

        public async Task<IEnumerable<ServiceMaterial>> ListAsync()
        {
            return await _context.ServiceMaterials
                .Include(p => p.Service)
                .Include(p => p.Material)
                .Include(p=>p.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceMaterial>> ListByMaterialIdAsync(int materialId)
        {
            return await _context.ServiceMaterials
                .Where(p=>p.MaterialId == materialId)
                .Include(p => p.Service)
                .Include(p => p.Material)
                .Include(p => p.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceMaterial>> ListByServiceIdAsync(int serviceId)
        {
            return await _context.ServiceMaterials
                .Where(p => p.ServiceId == serviceId)
                .Include(p => p.Service)
                .Include(p => p.Material)
                .Include(p => p.Name)
                .ToListAsync();
        }

        public void Remove(ServiceMaterial serviceMaterial)
        {
            _context.ServiceMaterials.Remove(serviceMaterial);
        }

        public async void UnassignServiceMaterial(int serviceId, int materialId)
        {
            ServiceMaterial serviceMaterial = await FindByServiceIdAndByMaterialId(serviceId, materialId);
            if (serviceMaterial != null)
            {
                Remove(serviceMaterial);
            }
        }
    }
}
