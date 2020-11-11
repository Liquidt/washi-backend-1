using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Washi.API.Domain.Persistence.Contexts;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;
using Washi.API.Extensions;
using Washi.API.Persistence.Repositories;
using Washi.API.Repositories;
using Washi.API.Services;

namespace Washi.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });
            //Scoped Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IUserPaymentMethodRepository, UserPaymentMethodRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IUserSubscriptionRepository, UserSubscriptionRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<ICountryCurrencyRepository, CountryCurrencyRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IServiceMaterialRepository, ServiceMaterialRepository>();
            services.AddScoped<ILaundryServiceMaterialRepository, LaundryServiceMaterialRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            //Scoped Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IUserPaymentMethodService, UserPaymentMethodService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IUserSubscriptionService, UserSubscriptionService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ICountryCurrencyService, CountryCurrencyService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderStatusService, OrderStatusService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IServiceMaterialService, ServiceMaterialService>();
            services.AddScoped<ILaundryServiceMaterialService, LaundryServiceMaterialService>();
            services.AddScoped<IPromotionService, PromotionService>();
            //Mapper
            services.AddAutoMapper(typeof(Startup));

            //Swagger
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddCustomSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UserCustomSwagger();
        }
    }
}
