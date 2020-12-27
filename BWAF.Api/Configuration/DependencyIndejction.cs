namespace BWAF.Api.DependencyInjection
{
    using AutoMapper;
    using BWAF.Business.Services;
    using BWAF.Api.ActionFilters;
    using BWAF.Core.AutoMapper;
    using BWAF.Core.Interfaces;
    using BWAF.Core.Services;
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
