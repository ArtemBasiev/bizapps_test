using System;
using System.Collections.Generic;
using bizapps_test.DAL;
using bizapps_test.DAL.Interfaces;
using bizapps_test.DAL.Repositories;
using bizapps_test.BLL.Infrastructure;
using bizapps_test.BLL.Interfaces;
using bizapps_test.BLL.DTO;
using AutoMapper;
using Ninject;


namespace bizapps_test.BLL.Services
{
    public class CategoryService: ICategoryService
    {
        [Ninject.Inject]
        IUnitOfWork Database { get; set; }
        public CategoryService(IUnitOfWork efunitofWork)
        {
            Database = efunitofWork;
        }


        public void MakeCategory(CategoryDTO CategoryDto)
        {
            //----------------------------Валидация введенных данных---------------------
           IEnumerable<Category> CategoriesToCompare = Database.Categories.GetAll();
            foreach (Category i in CategoriesToCompare)
            {
                if (i.CategoryName ==CategoryDto.CategoryName)
                {
                    throw new ValidationException("Введенная категория уже существует", CategoryDto.CategoryName.ToString());
                }
                
            }
            if((CategoryDto.CategoryName.Trim()=="")||(CategoryDto.CategoryName ==null))
            {
                throw new ValidationException("Попытка ввести нулевое значение",CategoryDto.CategoryName.ToString());
            }
            //----------------------------------------Добавляем новую категорию--------------------------------
            Category category = new Category
            {
                CategoryName=CategoryDto.CategoryName
            };
            Database.Categories.Create(category);
            Database.Save();

        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            //-----------------------------Получаем список категорий---------------------------------------
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll());
        }


    }
}
