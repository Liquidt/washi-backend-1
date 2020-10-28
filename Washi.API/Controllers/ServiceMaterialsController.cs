using AutoMapper;
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
    [Route("/api/services/{serviceId}/materials")]
    public class ServiceMaterialsController: Controller
    {
        private readonly IServiceMaterialService _serviceMaterialService;
        private readonly IMaterialService _materialService;
        private readonly IMapper _mapper;

        public ServiceMaterialsController(IServiceMaterialService serviceMaterialService, IMaterialService materialService, IMapper mapper)
        {
            _serviceMaterialService = serviceMaterialService;
            _materialService = materialService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MaterialResource>> GetAllByServiceIdAsync(int serviceId)
        {
            var materials = await _materialService.ListByServiceIdAsync(serviceId);
            var resources = _mapper
                .Map<IEnumerable<Material>, IEnumerable<MaterialResource>>(materials);
            return resources;
        }

        [HttpPost("{materialId}")]
        public async Task<IActionResult> AssignServiceMaterial(int serviceId, int materialId, [FromBody] string name)
        {
            var result = await _serviceMaterialService.AssignServiceMaterialAsync(serviceId, materialId, name);
            if (!result.Success) return BadRequest(result.Message);
            var materialResource = _mapper.Map<Material, MaterialResource>(result.Resource.Material);
            return Ok(materialResource);
        }
        [HttpDelete("{materialId}")]
        public async Task<IActionResult> UnassignServiceMaterial(int serviceId, int materialId)
        {
            var result = await _serviceMaterialService.UnassignServiceMaterialAsync(serviceId, materialId);
            if (!result.Success)
                return BadRequest(result.Message);
            var materialResource = _mapper.Map<Material, MaterialResource>(result.Resource.Material);
            return Ok(materialResource);
        }

    }
}
