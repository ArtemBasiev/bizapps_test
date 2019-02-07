using System;
using System.Collections.Generic;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Interfaces;

namespace bizapps_test.BLL.Interfaces
{
   public interface IBlogUserService
    {
        int CreateBlogUser(BlogUserDto blogUserDto);
        int DeleteBlogUser(BlogUserDto blogUserDto);
        int UpdateBlogUser(BlogUserDto blogUserDto);
        BlogUserDto GetBlogUserById(int userId);
        IEnumerable<BlogUserDto> GetAllUsers();
    }
}
