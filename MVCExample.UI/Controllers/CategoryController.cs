using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCExample.BLL.CategoryService;
using MVCExample.BLL.DTOs.CategoryDTOs;
using MVCExample.UI.Models.VMs.CategoryVMs;

namespace MVCExample.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            IList<CategoryDTO> list = _categoryService.GetActive();
            IList<CategoryVM> categoryVMs=_mapper.Map<IList<CategoryVM>>(list);
            return View(categoryVMs);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CategoryCreateVM categoryCreateVM)
        {
            try
            {
                CategoryCreateDTO categoryCreateDTO = _mapper.Map<CategoryCreateDTO>(categoryCreateVM);
                _categoryService.Create(categoryCreateDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        public IActionResult Update(int id)
        {
            CategoryDTO categoryDTO=_categoryService.GetById(id);
            CategoryUpdateVM categoryUpdateVM = _mapper.Map<CategoryUpdateVM>(categoryDTO);
            return View(categoryUpdateVM);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(CategoryUpdateVM categoryUpdateVM)
        {
            try
            {
                CategoryUpdateDTO categoryUpdateDTO = _mapper.Map<CategoryUpdateDTO>(categoryUpdateVM);
                _categoryService.Update(categoryUpdateDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
