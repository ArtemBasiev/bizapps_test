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
        public ICategoryRepository categoryRepository { get; set; }

        public CategoryService(ICategoryRepository categoryrepository)
        {
            categoryRepository = categoryrepository;
        }

        public int CreateCategory(CategoryDTO categoryDTO)
        {
            //----------------------------------------Добавляем новую категорию--------------------------------
            try
            {


                return  categoryRepository.CreateCategory(new Category(categoryDTO.CategoryName));
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
     

        }

        public int UpdateCategory(CategoryDTO categoryDTO)
        {
            //----------------------------------------Обновляем существующую категорию--------------------------------
            try
            {
               return categoryRepository.UpdateCategory(new Category(categoryDTO.Id, categoryDTO.CategoryName));
            }
            catch(SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
          
        }


        public int DeleteCategory(CategoryDTO categoryDTO)
        {
            //----------------------------------------Удаляем категорию--------------------------------
            try
            {
               return categoryRepository.DeleteCategory(new Category(categoryDTO.Id));
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }


        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            try
            { 
                     //-----------------------------Получаем список категорий---------------------------------------
                IEnumerable<Category> categories = categoryRepository.GetAllCategories();
            List<CategoryDTO> DTOCategories = new List<CategoryDTO>();
            foreach(Category c in categories)
            {
                CategoryDTO newcatDTO = new CategoryDTO();
                newcatDTO.Id = c.Id;
                newcatDTO.CategoryName = c.CategoryName;
                DTOCategories.Add(newcatDTO);
            }

     
            return DTOCategories;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
       
        }

        public IEnumerable<CategoryDTO> GetPostCategories(int postId)
        {
            try
            {
                //-----------------------------Получаем список категорий---------------------------------------
                IEnumerable<Category> categories = categoryRepository.GetPostCategories(postId);
                List<CategoryDTO> DTOCategories = new List<CategoryDTO>();
                foreach (Category c in categories)
                {
                    CategoryDTO newcatDTO = new CategoryDTO();
                    newcatDTO.Id = c.Id;
                    newcatDTO.CategoryName = c.CategoryName;
                    DTOCategories.Add(newcatDTO);
                }


                return DTOCategories;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }


        public CategoryDTO GetCategoryById(int categoryId)
        {
            try
            {
                //-----------------------------Получаем категорию---------------------------------------
                Category category = categoryRepository.GetCategoryById(categoryId);
                CategoryDTO newcatDTO = new CategoryDTO {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                };

                return newcatDTO;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }


    }
}
