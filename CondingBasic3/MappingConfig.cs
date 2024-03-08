using AutoMapper;
using CondingBasic3.DTOs;
using CondingBasic3.Models;

namespace CondingBasic3
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Product,  ProductDto>().ReverseMap();
        }
    }
}
