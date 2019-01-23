using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bizapps_test.BLL.Interfaces;
using bizapps_test.BLL.DTO;
using bizapps_test.WEB.Models;
using AutoMapper;
using bizapps_test.BLL.Infrastructure;

namespace bizapps_test
{
    public class CategoryOperations
    {
       
        public ICategoryService categoryService { get; set; }

        public CategoryOperations(ICategoryService catservice)
        {
            categoryService = catservice;
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            //---------------------------------Получаем список всех категорий-------------------------
            IEnumerable<CategoryDTO> categoryDtos = categoryService.GetCategories();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryViewModel>()).CreateMapper();
            var categories = mapper.Map<IEnumerable<CategoryDTO>, List<CategoryViewModel>>(categoryDtos);
            return categories;
        }

        public void MakeCategory(string categoryName)
        {
               //---------------------------Создаем новую категорию----------------------
                var modelcategory = new CategoryViewModel { CategoryName = categoryName };

                var categoryDto = new CategoryDTO { CategoryName = modelcategory.CategoryName };

                categoryService.MakeCategory(categoryDto);

          
        }


    }
}