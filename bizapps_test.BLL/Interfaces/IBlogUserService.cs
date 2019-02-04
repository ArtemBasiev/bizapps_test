using System;
using System.Collections.Generic;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Interfaces;

namespace bizapps_test.BLL.Interfaces
{
   public interface IBlogUserService
    {
        void CreateBlogUser(BlogUserDTO bloguserDTO);
        void DeleteBlogUser(BlogUserDTO bloguserDTO);
        void UpdateBlogUser(BlogUserDTO bloguserDTO);
        BlogUserDTO GetBlogUser(int userId);
        IEnumerable<BlogUserDTO> GetAllUsers();
    }
}
