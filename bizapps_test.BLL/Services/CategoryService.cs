using System;
using System.Collections.Generic;
using bizapps_test.DAL.Entities;
using bizapps_test.BLL.Infrastructure;
using bizapps_test.BLL.Interfaces;
using bizapps_test.BLL.DTO;
using AutoMapper;
using Ninject;
using System.Data.SqlClient;


namespace bizapps_test.BLL.Services
{
    public class CategoryService: ICategoryService
    {


        public void CreateCategory(CategoryDTO categoryDTO)
        {
            //----------------------------------------Добавляем новую категорию--------------------------------
            try
            {
                Category category = new Category
                {
          
                    CategoryName = categoryDTO.CategoryName
                };
                category.InsertCategory();
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
     

        }

        public void UpdateCategory(CategoryDTO categoryDTO)
        {
            //----------------------------------------Обновляем существующую категорию--------------------------------
            try
            {
                Category category = new Category
                {
                    Id = categoryDTO.Id,
                    CategoryName = categoryDTO.CategoryName
                };
                category.UpdateCategory();
            }
            catch(SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
          
        }


        public void DeleteCategory(CategoryDTO categoryDTO)
        {
            //----------------------------------------Удаляем категорию--------------------------------
            try
            {
                Category category = new Category
                {

                    Id = categoryDTO.Id
                };
                category.DeleteCategory();
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }


        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            try
            { 
                     //-----------------------------Получаем список категорий---------------------------------------
            IEnumerable<Category> categories = new Category().GetAllCategories();
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
                IEnumerable<Category> categories = new Category().GetPostCategories(postId);
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


        public CategoryDTO GetCategory(int categoryId)
        {
            try
            {
                //-----------------------------Получаем категорию---------------------------------------
                Category category =  new Category();
                category.GetCategory(categoryId);
                CategoryDTO newcatDTO = new CategoryDTO();
                newcatDTO.Id = category.Id;
                newcatDTO.CategoryName = category.CategoryName;



                return newcatDTO;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }


    }
}
