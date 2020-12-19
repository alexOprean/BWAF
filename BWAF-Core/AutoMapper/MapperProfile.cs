namespace BWAF_Core.AutoMapper
{
    using BWAF_Core.ViewModels;
    using BWAF_DAL.Models;
    using global::AutoMapper;

    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Entity, EntityViewModel>().ReverseMap();
        }
    }
}
