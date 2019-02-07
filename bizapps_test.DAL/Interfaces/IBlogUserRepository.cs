using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bizapps_test.DAL.Entities;

namespace bizapps_test.DAL.Interfaces
{
    public interface IBlogUserRepository
    {
        int CreateBlogUser(BlogUser bloguser);

        int UpdateBlogUser(BlogUser bloguser);

         int DeleteBlogUser(BlogUser bloguser);

         IEnumerable<BlogUser> GetAllBlogUsers();

         BlogUser GetBlogUserById(int bloguserId);
    }
}
