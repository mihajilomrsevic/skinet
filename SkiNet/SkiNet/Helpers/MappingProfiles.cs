
namespace SkiNet.WebAPI.Helpers
{
    using AutoMapper;

    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            this.CreateMap<Core.Models.Product, Core.Models.ProductToReturnDto>()
                .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());
        }
    }
}
