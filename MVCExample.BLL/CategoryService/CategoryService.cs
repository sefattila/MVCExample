using AutoMapper;
using MVCExample.BLL.DTOs.CategoryDTOs;
using MVCExample.CORE.Entities;
using MVCExample.CORE.Enums;
using MVCExample.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.BLL.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public void Create(CategoryCreateDTO categoryCreateDTO)
        {
            if (categoryCreateDTO == null)
                throw new Exception("Oluşturulacak Veri Yok");
            Category category = _mapper.Map<Category>(categoryCreateDTO);
            _categoryRepository.Create(category);
        }

        public void Delete(int id)
        {
            Category category=_categoryRepository.GetDefaultById(id);
            category.DeleteDate= DateTime.Now;
            category.Status = Status.Passive;
            _categoryRepository.Delete(category);
        }

        public IList<CategoryDTO> GetActive()
        {
            IList<Category> categories = _categoryRepository.GetDefaults(x => x.Status != Status.Passive).ToList();
            IList<CategoryDTO> categoryDTOs=_mapper.Map<IList<Category>,IList<CategoryDTO>>(categories);
            return categoryDTOs;
        }

        public CategoryDTO GetById(int id)
        {
            return _mapper.Map<CategoryDTO>(_categoryRepository.GetDefaultById(id));
        }

        public void Update(CategoryUpdateDTO categoryUpdateDTO)
        {
            Category category=_mapper.Map<Category>(categoryUpdateDTO);
            category.UpdateDate = DateTime.Now;
            category.Status = Status.Modified;
            _categoryRepository.Update(category);
        }
    }
}
