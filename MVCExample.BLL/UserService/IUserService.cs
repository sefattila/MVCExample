using Microsoft.AspNetCore.Identity;
using MVCExample.BLL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.BLL.UserService
{
    public interface IUserService
    {
        Task<IdentityResult> Create(UserRegisterDTO userRegisterDTO, string password);
        Task<IdentityResult> Update(UserUpdateDTO userUpdateDTO);
        Task<IdentityResult> Delete(string id);
        Task LogIn(UserLoginDTO userLoginDTO);
        Task LogOut();
        Task<UserDTO> GetById(string id);
        bool IsIdExist(string id);
        IList<UserDTO> GetAll();
        IList<UserDTO> GetActive();
    }
}
