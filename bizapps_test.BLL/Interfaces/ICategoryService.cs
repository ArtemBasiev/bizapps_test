using System;
using System.Collections.Generic;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Interfaces;

namespace bizapps_test.BLL.Interfaces
{
    public interface ICategoryService
    {
        int CreateCategory(CategoryDTO categoryDto);
        int DeleteCategory(CategoryDTO categoryDTO);
        int UpdateCategory(CategoryDTO categoryDTO);
        CategoryDTO GetCategoryById(int categiryId);
        IEnumerable<CategoryDTO> GetAllCategories();
        IEnumerable<CategoryDTO> GetPostCategories(int postId);

    }
}
