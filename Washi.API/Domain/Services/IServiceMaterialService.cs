﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Domain.Services
{
    public interface IServiceMaterialService
    {
        Task<IEnumerable<ServiceMaterial>> ListAsync();
        Task<IEnumerable<ServiceMaterial>> ListByServiceIdAsync(int serviceId);
        Task<IEnumerable<ServiceMaterial>> ListByMaterialIdAsync(int materialId);
        Task<ServiceMaterialResponse> AssignServiceMaterialAsync(int serviceId, int materialId, string name);
        Task<ServiceMaterialResponse> UnassignServiceMaterialAsync(int serviceId, int materialId);
    }
}
