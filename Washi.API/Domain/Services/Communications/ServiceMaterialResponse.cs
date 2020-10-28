using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class ServiceMaterialResponse : BaseResponse<ServiceMaterial>
    {
        public ServiceMaterialResponse(ServiceMaterial resource) : base(resource)
        {
        }

        public ServiceMaterialResponse(string message) : base(message)
        {
        }
    }
}
