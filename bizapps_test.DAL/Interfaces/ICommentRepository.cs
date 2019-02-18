using System.Collections.Generic;
using bizapps_test.DAL.Entities;

namespace bizapps_test.DAL.Interfaces
{
    public interface ICommentRepository
    {

        int CreateComment(Comment comment, int postId);

        int UpdateComment(Comment comment);

        int DeleteComment(Comment comment);

        IEnumerable<Comment> GetIndependentComments(int postId);

        IEnumerable<Comment> GetCommentAnswers(int commentId);

        Comment GetComment(int commentId);

    }
}
