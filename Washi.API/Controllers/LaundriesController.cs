using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services;
using Washi.API.Extensions;
using Washi.API.Resources;

namespace Washi.API.Controllers
{

    [Route("/api/[controller]")]
    public class LaundrysController : Controller
    {
        private readonly ILaundryService _laundryService;
        private readonly IMapper _mapper;

        public LaundrysController(ILaundryService laundryService, IMapper mapper)
        {
            _laundryService = laundryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LaundryResource>> GetAllAsync()
        {
            var laundries = await _laundryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Laundry>, IEnumerable<LaundryResource>>(laundries);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _laundryService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var laundryResource = _mapper.Map<Laundry, LaundryResource>(result.Resource);
            return Ok(laundryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLaundryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var laundry = _mapper.Map<SaveLaundryResource, Laundry>(resource);
            var result = await _laundryService.UpdateAsync(id, laundry);

            if (!result.Success)
                return BadRequest(result.Message);

            var laundryResource = _mapper.Map<Laundry, LaundryResource>(result.Resource);
            return Ok(laundryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _laundryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var laundryResource = _mapper.Map<Laundry, LaundryResource>(result.Resource);
            return Ok(laundryResource);
        }
    }
}