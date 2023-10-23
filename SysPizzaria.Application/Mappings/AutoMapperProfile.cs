using AutoMapper;
using SysPizzaria.Application.DTOs;
using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Application.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        #region Person
        CreateMap<Person, PersonDTO>().ReverseMap();
        #endregion

        #region Product
        CreateMap<Product, ProductDTO>().ReverseMap();
        #endregion

        #region Purchase
        CreateMap<Purchase, PurchaseDTO>().ReverseMap();
        #endregion
    }
}