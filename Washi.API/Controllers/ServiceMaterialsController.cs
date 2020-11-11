using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services;
using Washi.API.Resources;

namespace Washi.API.Controllers
{
    [Route("/api")]
    public class ServiceMaterialsController: Controller
    {
        private readonly IServiceMaterialService _serviceMaterialService;
        private readonly IMapper _mapper;

        public ServiceMaterialsController(IServiceMaterialService serviceMaterialService, IMapper mapper)
        {
            _serviceMaterialService = serviceMaterialService;
            _mapper = mapper;
        }
        [HttpGet("servicematerials")]
        public async Task<IEnumerable<ServiceMaterialResource>> GetAllAsync()
        {
            var serviceMaterials = await _serviceMaterialService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<ServiceMaterial>, IEnumerable<ServiceMaterialResource>>(serviceMaterials);
            return resources;
        }
        [HttpGet("services/{serviceId}/materials")]
        public async Task<IEnumerable<ServiceMaterialResource>> GetAllByServiceIdAsync(int serviceId)
        {
            var serviceMaterials = await _serviceMaterialService.ListByServiceIdAsync(serviceId);
            var resources = _mapper
                .Map<IEnumerable<ServiceMaterial>, IEnumerable<ServiceMaterialResource>>(serviceMaterials);
            return resources;
        }

    }
}
