using System.Collections.Generic;
using bizapps_test.DAL.Entities;

namespace bizapps_test.DAL.Interfaces
{
    public interface IPostRepository
    {
       int CreatePost(Post post, int userId);

         int UpdatePost(Post post);

         int DeletePost(Post post);

         IEnumerable<Post> GetUserPosts(int userId);

        IEnumerable<Post> GetUserPostsByUserName(string userName);

        IEnumerable<Post> GetPostsByUserNameWithoutCategory(string userName);

        IEnumerable<Post> GetPostsByUserNameAndCategory(string userName, int categoryId);

        Post GetPostById(int postId);

         void AddCategoryToPost(int categoryId, int postId);

        void DeleteCategoryFromPost(int categoryId, int postId);
    }
}
