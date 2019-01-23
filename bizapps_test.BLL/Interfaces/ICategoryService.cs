using System;
using System.Collections.Generic;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Interfaces;

namespace bizapps_test.BLL.Interfaces
{
    public interface ICategoryService
    {
        void MakeCategory(CategoryDTO categoryDto);
        IEnumerable<CategoryDTO> GetCategories();

    }
}
