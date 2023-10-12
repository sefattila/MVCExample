using MVCExample.BLL.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.BLL.CategoryService
{
    public interface ICategoryService
    {
        void Create(CategoryCreateDTO categoryCreateDTO);
        void Update(CategoryUpdateDTO categoryUpdateDTO);
        void Delete(int id);
        IList<CategoryDTO> GetActive();

        CategoryDTO GetById(int id);
    }
}
