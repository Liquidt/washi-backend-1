using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;

namespace Washi.API.Services
{
    public class ServiceMaterialService : IServiceMaterialService
    {
        private readonly IServiceMaterialRepository _serviceMaterialRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceMaterialService(IServiceMaterialRepository serviceMaterialRepository, IUnitOfWork unitOfWork)
        {
            _serviceMaterialRepository = serviceMaterialRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceMaterial> FindByServiceIdAndMaterialId(int serviceId, int materialId)
        {
            return await _serviceMaterialRepository.FindByServiceIdAndMaterialId(serviceId, materialId);
        }

        public async Task<IEnumerable<ServiceMaterial>> ListAsync()
        {
            return await _serviceMaterialRepository.ListAsync();
        }

        public async Task<IEnumerable<ServiceMaterial>> ListByMaterialIdAsync(int materialId)
        {
            return await _serviceMaterialRepository.ListByMaterialIdAsync(materialId);
        }

        public async Task<IEnumerable<ServiceMaterial>> ListByServiceIdAsync(int serviceId)
        {
            return await _serviceMaterialRepository.ListByServiceIdAsync(serviceId);
        }
    }
}
