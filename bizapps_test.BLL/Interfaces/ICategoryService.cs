using System;
using System.Collections.Generic;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Interfaces;

namespace bizapps_test.BLL.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategory(CategoryDTO categoryDto);
        void DeleteCategory(CategoryDTO categoryDTO);
        void UpdateCategory(CategoryDTO categoryDTO);
        CategoryDTO GetCategory(int categiryId);
        IEnumerable<CategoryDTO> GetCategories();
        IEnumerable<CategoryDTO> GetPostCategories(int postId);

    }
}
