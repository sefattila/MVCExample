using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MVCExample.BLL.DTOs.UserDTOs;
using MVCExample.CORE.Entities;
using MVCExample.CORE.Enums;
using MVCExample.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.BLL.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserRepository userRepo, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Create(UserRegisterDTO userRegisterDTO, string password)
        {
            AppUser user = _mapper.Map<AppUser>(userRegisterDTO);
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı Bulunamadı" });

            user.DeleteDate = DateTime.Now;
            user.Status = Status.Passive;

            return await _userManager.DeleteAsync(user);
        }

        public IList<UserDTO> GetActive()
        {
            IList<AppUser> appUsers = _userRepo.GetDefaults(x => x.Status != Status.Passive);
            IList<UserDTO> userDTOs = _mapper.Map<IList<AppUser>, IList<UserDTO>>(appUsers);
            return userDTOs;
        }

        public IList<UserDTO> GetAll()
        {
            IList<AppUser> appUsers = _userRepo.GetAll();
            IList<UserDTO> userDTOs = _mapper.Map<IList<AppUser>, IList<UserDTO>>(appUsers);
            return userDTOs;
        }

        public async Task<UserDTO> GetById(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);
            return _mapper.Map<UserDTO>(appUser);
        }

        public bool IsIdExist(string id)
        {
            return _userRepo.Any(x => x.Id == id);
        }

        public async Task LogIn(UserLoginDTO userLoginDTO)
        {
            if (userLoginDTO == null)
                throw new Exception("Login Entity Boş");
            AppUser appUser = await _userManager.FindByNameAsync(userLoginDTO.UserName);
            if (appUser == null)
                throw new Exception("Böyle Bir Kullanıcı Yok");
            await _signInManager.PasswordSignInAsync(appUser, userLoginDTO.Password, true, false);
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Update(UserUpdateDTO userUpdateDTO)
        {
            if (userUpdateDTO == null)
                throw new Exception("Update entity boş");

            var user = await _userManager.FindByIdAsync(userUpdateDTO.Id);
            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı Bulunamadı" });

            _mapper.Map(userUpdateDTO, user);

            user.UpdateDate = DateTime.Now;
            user.Status = Status.Modified;

            return await _userManager.UpdateAsync(user);
        }
    }
}
