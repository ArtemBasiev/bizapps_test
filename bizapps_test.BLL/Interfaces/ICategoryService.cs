using System;
using System.Collections.Generic;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Interfaces;

namespace bizapps_test.BLL.Interfaces
{
    public interface ICategoryService
    {
        int CreateCategory(CategoryDto categoryDto);
        int DeleteCategory(CategoryDto categoryDto);
        int UpdateCategory(CategoryDto categoryDto);
        CategoryDto GetCategoryById(int categoryId);
        IEnumerable<CategoryDto> GetAllCategories();
        IEnumerable<CategoryDto> GetPostCategories(int postId);
        IEnumerable<CategoryDto> GetBlogCategories(string userName);

    }
}
