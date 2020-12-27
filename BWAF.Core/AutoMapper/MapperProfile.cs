namespace BWAF.Core.AutoMapper
{
    using BWAF.Core.ViewModels;
    using BWAF.Data.Models;
    using global::AutoMapper;

    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Entity, EntityViewModel>().ReverseMap();
        }
    }
}
