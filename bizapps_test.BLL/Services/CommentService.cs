using System;
using System.Collections.Generic;
using bizapps_test.DAL.Entities;
using bizapps_test.BLL.Interfaces;
using bizapps_test.BLL.DTO;
using System.Data.SqlClient;
using bizapps_test.DAL.Interfaces;

namespace bizapps_test.BLL.Services
{
    public class CommentService: ICommentService
    {
        public ICommentRepository CommentRepository { get; private set; }

        public CommentService(ICommentRepository commentRepository)
        {
            CommentRepository = commentRepository;
        }

       public int CreateComment(CommentDto commentDto, int postId)
        {
            try
            {


                int newcommentId = CommentRepository.CreateComment(new Comment(commentDto.CommentText, commentDto.UserName, commentDto.ParentId), postId);

                return newcommentId;

            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
        }

       public int UpdateComment(CommentDto commentDto)
        {
            try
            {


                int updcommentId = CommentRepository.UpdateComment(new Comment(commentDto.Id, commentDto.CommentText));

                return updcommentId;

            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public int DeleteComment(CommentDto commentDto)
        {
            try
            {


                int delcommentId = CommentRepository.DeleteComment(new Comment(commentDto.Id));

                return delcommentId;

            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public IEnumerable<CommentDto> GetIndependentComments(int postId)
        {
            try
            {
                //-----------------------------Получаем список комментариев поста---------------------------------------
                IEnumerable<Comment> comments = CommentRepository.GetIndependentComments(postId);
                List<CommentDto> dtoComments = new List<CommentDto>();
                foreach (Comment comment in comments)
                {
                    CommentDto newcommentDto = new CommentDto();
                    newcommentDto.Id = comment.Id;
                    newcommentDto.CommentText = comment.CommentText;
                    newcommentDto.UserName = comment.UserName;
                    newcommentDto.CreationDate = comment.CreationDate;
                    dtoComments.Add(newcommentDto);
                }


                return dtoComments;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public IEnumerable<CommentDto> GetCommentAnswers(int commentId)
        {
            try
            {
                //-----------------------------Получаем список комментариев поста---------------------------------------
                IEnumerable<Comment> comments = CommentRepository.GetCommentAnswers(commentId);
                List<CommentDto> dtoComments = new List<CommentDto>();
                foreach (Comment comment in comments)
                {
                    CommentDto newcommentDto = new CommentDto();
                    newcommentDto.Id = comment.Id;
                    newcommentDto.CommentText = comment.CommentText;
                    newcommentDto.UserName = comment.UserName;
                    newcommentDto.CreationDate = comment.CreationDate;
                    dtoComments.Add(newcommentDto);
                }


                return dtoComments;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public CommentDto GetComment(int commentId)
        {
            try
            {
                //-----------------------------Получаем пост по идентификатору---------------------------------------
                Comment comment = CommentRepository.GetComment(commentId);

                CommentDto commentDto = new CommentDto
                {
                    Id = comment.Id,
                    CommentText = comment.CommentText,
                    UserName = comment.UserName,
                    CreationDate = comment.CreationDate,
                };

                return commentDto;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}
