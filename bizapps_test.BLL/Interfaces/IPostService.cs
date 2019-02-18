using System.Collections.Generic;
using bizapps_test.BLL.DTO;

namespace bizapps_test.BLL.Interfaces
{
    public interface IPostService
    {
        int CreatePost(PostDto postDto, int userId, List<CategoryDto> categoryListDto);
        int DeletePost(PostDto postDto);
        int UpdatePost(PostDto postDto, List<CategoryDto> categoryListDto);
        PostDto GetPost(int postId);
        IEnumerable<PostDto> GetUserPosts(int userId);
        IEnumerable<PostDto> GetUserPostsByUserName(string userName);
        IEnumerable<PostDto> GetPostsByUserNameWithoutCategory(string userName);
        IEnumerable<PostDto> GetPostsByUserNameAndCategory(string userName, int categoryId);

    }
}
