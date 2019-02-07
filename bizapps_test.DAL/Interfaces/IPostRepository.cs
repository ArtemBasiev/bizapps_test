using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bizapps_test.DAL.Utils;
using System.Data.SqlClient;
using System.Data;
using bizapps_test.DAL.Interfaces;
using bizapps_test.DAL.Entities;

namespace bizapps_test.DAL.Interfaces
{
    public interface IPostRepository
    {
       int CreatePost(Post post, int userId);

         int UpdatePost(Post post);

         int DeletePost(Post post);

         IEnumerable<Post> GetUserPosts(int userId);

        Post GetPostById(int postId);

         void AddCategoryToPost(int categoryId, int postId);

        void DeleteCategoryFromPost(int categoryId, int postId);
    }
}
