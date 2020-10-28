using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;
using Washi.API.Domain.Services.Communications;

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

        public async Task<ServiceMaterialResponse> AssignServiceMaterialAsync(int serviceId, int materialId, string name)
        {
            try
            {
                await _serviceMaterialRepository.AssignServiceMaterial(serviceId, materialId, name);
                await _unitOfWork.CompleteAsync();
                ServiceMaterial serviceMaterial = await _serviceMaterialRepository.FindByServiceIdAndByMaterialId(serviceId, materialId);
                return new ServiceMaterialResponse(serviceMaterial);
            }
            catch (Exception ex)
            {
                return new ServiceMaterialResponse($"An error ocurred while assigning Material to Service: {ex.Message}");
            }
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

        public async Task<ServiceMaterialResponse> UnassignServiceMaterialAsync(int serviceId, int materialId)
        {
            try
            {
                _serviceMaterialRepository.UnassignServiceMaterial(serviceId, materialId);
                await _unitOfWork.CompleteAsync();
                return new ServiceMaterialResponse(new ServiceMaterial { ServiceId = serviceId, MaterialId = materialId });
            }
            catch (Exception ex)
            {
                return new ServiceMaterialResponse($"An error ocurred while unassigning Material to Service: {ex.Message}");
            }
        }
    }
}
