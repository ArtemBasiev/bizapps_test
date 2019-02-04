using System;
using System.Collections.Generic;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Interfaces;

namespace bizapps_test.BLL.Interfaces
{
    public interface IPostService
    {
        void CreatePost(PostDTO postDTO, int userId, List<CategoryDTO> categoryListDTO);
        void DeletePost(PostDTO postDTO);
        void UpdatePost(PostDTO postDTO, List<CategoryDTO> categoryListDTO);
        PostDTO GetPost(int postId);
        IEnumerable<PostDTO> GetAllUserPosts(int userId);

    }
}
