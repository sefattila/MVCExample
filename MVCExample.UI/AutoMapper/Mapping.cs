using AutoMapper;
using MVCExample.BLL.DTOs.CategoryDTOs;
using MVCExample.BLL.DTOs.UserDTOs;
using MVCExample.UI.Models.VMs.CategoryVMs;
using MVCExample.UI.Models.VMs.UserVMs;

namespace MVCExample.UI.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserVM, UserDTO>().ReverseMap();
            CreateMap<UserRegisterVM,UserRegisterDTO>().ReverseMap();
            CreateMap<UserUpdateVM, UserUpdateDTO>().ReverseMap();
            CreateMap<UserLoginVM,UserLoginDTO>().ReverseMap();
            CreateMap<UserDTO,UserUpdateVM>().ReverseMap();

            CreateMap<CategoryDTO, CategoryVM>().ReverseMap();
            CreateMap<CategoryUpdateDTO,CategoryUpdateVM>().ReverseMap();
            CreateMap<CategoryCreateDTO, CategoryCreateVM>().ReverseMap();
            CreateMap<CategoryDTO,CategoryUpdateVM>().ReverseMap();
        }
    }
}
