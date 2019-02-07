using System;
using System.Collections.Generic;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Interfaces;

namespace bizapps_test.BLL.Interfaces
{
    public interface IPostService
    {
        int CreatePost(PostDTO postDTO, int userId, List<CategoryDTO> categoryListDTO);
        int DeletePost(PostDTO postDTO);
        int UpdatePost(PostDTO postDTO, List<CategoryDTO> categoryListDTO);
        PostDTO GetPost(int postId);
        IEnumerable<PostDTO> GetUserPosts(int userId);

    }
}
