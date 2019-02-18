using System;
using System.Collections.Generic;
using bizapps_test.DAL.Utils;
using System.Data.SqlClient;
using System.Data;
using bizapps_test.DAL.Interfaces;
using bizapps_test.DAL.Entities;

namespace bizapps_test.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public static SqlConnection Con = DbUtil.GetDbConnection();

        public int CreateComment(Comment comment, int postId)
        {
            SqlCommand cmd = new SqlCommand("IUDComment", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "I";
            cmd.Parameters.Add(new SqlParameter("@CommentText", SqlDbType.VarChar, 500));
            cmd.Parameters["@CommentText"].Value = comment.CommentText;
            cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
            cmd.Parameters["@PostId"].Value = postId;
            cmd.Parameters.Add(new SqlParameter("@ParentId", SqlDbType.Int));
            cmd.Parameters["@ParentId"].Value = comment.ParentId;
            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 50));
            cmd.Parameters["@UserName"].Value = comment.UserName;
            cmd.Parameters.Add(new SqlParameter("@NewCommentId", SqlDbType.Int, 50, ParameterDirection.InputOutput, false, 0, 0, "@NewCommentId", DataRowVersion.Original, null));
            cmd.Parameters["@NewCommentId"].Value = ParameterDirection.InputOutput;
            try
            {
                if (Con.State==ConnectionState.Closed)
                {
                    Con.Open();
                }
                
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@NewCommentId"].Value;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

        public int UpdateComment(Comment comment)
        {
            SqlCommand cmd = new SqlCommand("IUDComment", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "U";
            cmd.Parameters.Add(new SqlParameter("@CommentId", SqlDbType.Int));
            cmd.Parameters["@CommentId"].Value = comment.Id;
            cmd.Parameters.Add(new SqlParameter("@CommentText", SqlDbType.VarChar, 500));
            cmd.Parameters["@CommentText"].Value = comment.CommentText;      
            cmd.Parameters.Add(new SqlParameter("@NewCommentId", SqlDbType.Int, 50, ParameterDirection.InputOutput, false, 0, 0, "@NewCommentId", DataRowVersion.Original, null));
            cmd.Parameters["@NewCommentId"].Value = ParameterDirection.InputOutput;
            try
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@NewCommentId"].Value;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

        public int DeleteComment(Comment comment)
        {
            SqlCommand cmd = new SqlCommand("IUDComment", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "D";
            cmd.Parameters.Add(new SqlParameter("@CommentId", SqlDbType.Int));
            cmd.Parameters["@CommentId"].Value = comment.Id;
            cmd.Parameters.Add(new SqlParameter("@NewCommentId", SqlDbType.Int, 50, ParameterDirection.InputOutput, false, 0, 0, "@NewCommentId", DataRowVersion.Original, null));
            cmd.Parameters["@NewCommentId"].Value = ParameterDirection.InputOutput;
            try
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@NewCommentId"].Value;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

        public IEnumerable<Comment> GetIndependentComments(int postId)
        {
            List<Comment> comments = new List<Comment> ();
            SqlCommand cmd = new SqlCommand("select * from GetIndependentPostComments('" + postId + "') order by CreationDate desc", Con);
            try
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Comment comment = new Comment((int)reader["CommentId"], (string)reader["CommentText"], (string)reader["UserName"], (DateTime)reader["CreationDate"]);
                    comments.Add(comment);
                }
                reader.Close();
                return comments;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

        public IEnumerable<Comment> GetCommentAnswers(int commentId)
        {
            List<Comment> comments = new List<Comment> ();
            SqlCommand cmd = new SqlCommand("select * from GetCommentAnswers('" + commentId + "') order by CreationDate desc", Con);
            try
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Comment comment = new Comment((int)reader["CommentId"], (string)reader["CommentText"], (string)reader["UserName"], (DateTime)reader["CreationDate"]);
                    comments.Add(comment);
                }
                reader.Close();
                return comments;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

        public Comment GetComment(int commentId)
        {
            SqlCommand cmd = new SqlCommand("select * from GetComment(" + commentId + ")", Con);

            try
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                reader.Read();
                Comment comment = new Comment((int)reader["CommentId"], (string)reader["CommentText"], (string)reader["UserName"], (DateTime)reader["CreationDate"]);
                reader.Close();
                return comment;

            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }    
            }
        }
    }
}
