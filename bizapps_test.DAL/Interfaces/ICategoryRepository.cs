
using System.Collections.Generic;
using bizapps_test.DAL.Entities;

namespace bizapps_test.DAL.Interfaces
{
    public interface ICategoryRepository
    {
      int CreateCategory(Category category);

       int UpdateCategory(Category category);

        int DeleteCategory(Category category);

        IEnumerable<Category> GetAllCategories();

         IEnumerable<Category> GetPostCategories(int postId);

        Category GetCategoryById(int categoryId);

        IEnumerable<Category> GetBlogCategories(string userName);


    }
}
