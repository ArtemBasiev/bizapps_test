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
        int CreateBlogUser(BlogUser blogUser);

        int UpdateBlogUser(BlogUser blogUser);

         int DeleteBlogUser(BlogUser blogUser);

         IEnumerable<BlogUser> GetAllBlogUsers();

         BlogUser GetBlogUserById(int blogUserId);

         BlogUser GetBlogUserByNameAndPassword(string userName, string userPassword);

        int GetAdminPermission(string userName);

    }
}
