namespace BWAF_API.DependencyInjection
{
    using AutoMapper;
    using BWAF_Business.Services;
    using BWAF_API.ActionFilters;
    using BWAF_Core.AutoMapper;
    using BWAF_Core.Interfaces;
    using BWAF_Core.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyIndejction
    {
        public static void Init(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddScoped<PerformanceFilter>();
            services.AddScoped<IRepositoryService, RepositoryService>();
            services.AddScoped<ICrudServices, CrudService>();

            SetAutoMapper(services);
        }

        private static void SetAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
