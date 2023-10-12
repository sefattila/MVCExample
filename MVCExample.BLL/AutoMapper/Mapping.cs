using AutoMapper;
using MVCExample.BLL.DTOs.CategoryDTOs;
using MVCExample.BLL.DTOs.UserDTOs;
using MVCExample.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.BLL.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserDTO, AppUser>().ReverseMap();
            CreateMap<UserRegisterDTO, AppUser>().ReverseMap();
            CreateMap<UserUpdateDTO, AppUser>().ReverseMap();
            CreateMap<UserLoginDTO, AppUser>().ReverseMap();

            CreateMap<CategoryCreateDTO, Category>().ReverseMap();
            CreateMap<CategoryUpdateDTO, Category>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
