using AutoMapper;
using WebGraduationProject.DTOs;
using WebGraduationProject.Models;

namespace WebGraduationProject.Profiles
{
    public class productProfile : Profile
    {
        public productProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductUpdateDto>();
        }
    }
} 