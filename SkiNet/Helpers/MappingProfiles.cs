//-------------------------------------------------------------------------------
// <copyright file="MappingProfiles.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Helpers
{
    using AutoMapper;
    using SkiNet.WebAPI.Core.Models.Identity;
    using SkiNet.WebAPI.Models.DTOs;

    /// <summary>
    /// Defines a mapper profiles.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfiles"/> class.
        /// </summary>
        public MappingProfiles()
        {
            this.CreateMap<Core.Models.Product, Core.Models.ProductToReturnDto>()
                .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());

            this.CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}

