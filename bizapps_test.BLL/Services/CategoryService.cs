using System;
using System.Collections.Generic;
using bizapps_test.DAL.Entities;
using bizapps_test.BLL.Infrastructure;
using bizapps_test.BLL.Interfaces;
using bizapps_test.BLL.DTO;
using bizapps_test.DAL.Interfaces;
using Ninject;
using System.Data.SqlClient;


namespace bizapps_test.BLL.Services
{
   

    public class CategoryService: ICategoryService
    {
        [Ninject.Inject]
        public ICategoryRepository CategoryRepository { get; set; }

        public CategoryService(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public int CreateCategory(CategoryDto categoryDto)
        {
            //----------------------------------------Добавляем новую категорию--------------------------------
            try
            {


                return  CategoryRepository.CreateCategory(new Category(categoryDto.CategoryName));
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
     

        }

        public int UpdateCategory(CategoryDto categoryDto)
        {
            //----------------------------------------Обновляем существующую категорию--------------------------------
            try
            {
               return CategoryRepository.UpdateCategory(new Category(categoryDto.Id, categoryDto.CategoryName));
            }
            catch(SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
          
        }


        public int DeleteCategory(CategoryDto categoryDto)
        {
            //----------------------------------------Удаляем категорию--------------------------------
            try
            {
               return CategoryRepository.DeleteCategory(new Category(categoryDto.Id));
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }


        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            try
            { 
                     //-----------------------------Получаем список категорий---------------------------------------
                IEnumerable<Category> categories = CategoryRepository.GetAllCategories();
            List<CategoryDto> dtoCategories = new List<CategoryDto>();
            foreach(Category c in categories)
            {
                CategoryDto newcatDto = new CategoryDto();
                newcatDto.Id = c.Id;
                newcatDto.CategoryName = c.CategoryName;
                dtoCategories.Add(newcatDto);
            }

     
            return dtoCategories;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
       
        }

        public IEnumerable<CategoryDto> GetPostCategories(int postId)
        {
            try
            {
                //-----------------------------Получаем список категорий---------------------------------------
                IEnumerable<Category> categories = CategoryRepository.GetPostCategories(postId);
                List<CategoryDto> dtoCategories = new List<CategoryDto>();
                foreach (Category c in categories)
                {
                    CategoryDto newcatDto = new CategoryDto();
                    newcatDto.Id = c.Id;
                    newcatDto.CategoryName = c.CategoryName;
                    dtoCategories.Add(newcatDto);
                }


                return dtoCategories;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }

        public IEnumerable<CategoryDto> GetBlogCategories(string userName)

        {
            try
            {
                //-----------------------------Получаем список категорий---------------------------------------
                IEnumerable<Category> categories = CategoryRepository.GetBlogCategories(userName);
                List<CategoryDto> dtoCategories = new List<CategoryDto>();
                foreach (Category c in categories)
                {
                    CategoryDto newcatDto = new CategoryDto();
                    newcatDto.Id = c.Id;
                    newcatDto.CategoryName = c.CategoryName;
                    dtoCategories.Add(newcatDto);
                }


                return dtoCategories;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }

        public CategoryDto GetCategoryById(int categoryId)
        {
            try
            {
                //-----------------------------Получаем категорию---------------------------------------
                Category category = CategoryRepository.GetCategoryById(categoryId);
                CategoryDto newcatDto = new CategoryDto {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                };

                return newcatDto;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }


    }
}
