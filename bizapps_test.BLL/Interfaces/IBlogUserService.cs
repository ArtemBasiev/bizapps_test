using System;
using System.Collections.Generic;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Interfaces;

namespace bizapps_test.BLL.Interfaces
{
   public interface IBlogUserService
    {
        int CreateBlogUser(BlogUserDTO bloguserDTO);
        int DeleteBlogUser(BlogUserDTO bloguserDTO);
        int UpdateBlogUser(BlogUserDTO bloguserDTO);
        BlogUserDTO GetBlogUserById(int userId);
        IEnumerable<BlogUserDTO> GetAllUsers();
    }
}
