using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCExample.BLL.DTOs.UserDTOs;
using MVCExample.BLL.UserService;
using MVCExample.UI.Models.VMs.UserVMs;

namespace MVCExample.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        public IActionResult Index()
        {
            IList<UserDTO> users = _userService.GetActive();
            IList<UserVM> userVMs = _mapper.Map<IList<UserVM>>(users);
            return View(userVMs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRegisterVM userRegisterVMs)
        {
            if (ModelState.IsValid)
            {
                UserRegisterDTO userRegisterDTO = _mapper.Map<UserRegisterDTO>(userRegisterVMs);
                IdentityResult result = await _userService.Create(userRegisterDTO, userRegisterVMs.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    if (error.Code == "DuplicateUserName")
                    {
                        ModelState.AddModelError(string.Empty, "Bu kullanıcı adı zaten kullanılıyor.");
                    }
                    ModelState.AddModelError(string.Empty, error.Description.ToString());
                }
            }
            return View(userRegisterVMs);
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UserLoginVM userLoginVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserLoginDTO userLoginDTO = _mapper.Map<UserLoginDTO>(userLoginVM);
                    await _userService.LogIn(userLoginDTO);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(userLoginVM);
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.LogOut();
            return RedirectToAction("Login");
        }

        [Authorize]
        public async Task<IActionResult> Update(string id)
        {
            UserDTO user = await _userService.GetById(id);
            if (user == null)
                return NotFound();
            UserUpdateVM userUpdateVM = _mapper.Map<UserUpdateVM>(user);
            return View(userUpdateVM);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateVM userUpdateVM)
        {
            if (ModelState.IsValid)
            {
                UserUpdateDTO userUpdateDTO = _mapper.Map<UserUpdateDTO>(userUpdateVM);
                var result = await _userService.Update(userUpdateDTO);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View(userUpdateVM);
        }

        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _userService.Delete(id);
            if (result.Succeeded)
                return RedirectToAction("Index");
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(result);
        }

    }
}
