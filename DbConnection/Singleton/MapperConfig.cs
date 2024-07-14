using AutoMapper;
using DbConnection.db.Supercharge.Model;
using DbConnection.Resources;
using DbConnection.Tools.ModelTools;

namespace DbConnection.Singleton
{
    internal class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            MapperConfiguration config = new(cfg =>
            {
                //Model to resource
                cfg.CreateMap<User, UserResource>()
                .ForMember(dest => dest.CreatedOnUtc, opt => opt.MapFrom(src => $"{src.CreatedOnUtc:yyyy-MM-dd}"))
                .ForMember(dest => dest.ModifiedOnUtc, opt => opt.MapFrom(src => $"{src.ModifiedOnUtc:yyyy-MM-dd}"))
                .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src => UserTools.GetFullName(src.CreatedByNavigation)))
                .ForMember(dest => dest.ModifiedByName, opt => opt.MapFrom(src => UserTools.GetFullName(src.ModifiedByNavigation)))
                ;

                //Resource to model
                cfg.CreateMap<UserResource, User>()
                .ForMember(dest => dest.ModifiedBy, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.ModifiedOnUtc, opt => opt.MapFrom(src => DateTime.UtcNow))
                .AfterMap((src, dest) =>
                {
                    if (!dest.CreatedOnUtc.HasValue)
                    {
                        dest.CreatedOnUtc = DateTime.UtcNow;
                    }
                    if (!dest.CreatedBy.HasValue)
                    {
                        dest.CreatedBy = 1;
                    }
                });

            });
            Mapper mapper = new(config);
            return mapper;
        }
    }
}
