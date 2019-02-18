using System.Collections.Generic;
using bizapps_test.BLL.DTO;

namespace bizapps_test.BLL.Interfaces
{
    public interface ICommentService
    {
        int CreateComment(CommentDto comment, int postId);

        int UpdateComment(CommentDto comment);

        int DeleteComment(CommentDto comment);

        IEnumerable<CommentDto> GetIndependentComments(int postId);

        IEnumerable<CommentDto> GetCommentAnswers(int commentId);

        CommentDto GetComment(int commentId);
    }
}
