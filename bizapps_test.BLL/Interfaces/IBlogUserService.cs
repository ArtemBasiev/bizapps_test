using System.Collections.Generic;
using bizapps_test.BLL.DTO;

namespace bizapps_test.BLL.Interfaces
{
   public interface IBlogUserService
    {
        int CreateBlogUser(BlogUserDto blogUserDto);
        int DeleteBlogUser(BlogUserDto blogUserDto);
        int UpdateBlogUser(BlogUserDto blogUserDto);
        int ChangePassword(BlogUserDto blogUserDto);
        BlogUserDto GetBlogUserById(int userId);
        BlogUserDto GetBlogUserNameAndPassword(BlogUserDto incomingUser);
        IEnumerable<BlogUserDto> GetAllUsers();
        int GetAdminPermission(string userName);
    }
}
