﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bizapps_test.DAL.Utils;
using System.Data.SqlClient;
using System.Data;
using bizapps_test.DAL.Interfaces;
using bizapps_test.DAL.Entities;

namespace bizapps_test.DAL.Repositories
{
    public class PostRepository: IPostRepository
    {
        public static SqlConnection con = DBUtil.GetDBConnection();

        public int CreatePost(Post post, int userId)
        {
            SqlCommand cmd = new SqlCommand("IUDPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "I";
            cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
            cmd.Parameters["@PostId"].Value = 0;
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
            cmd.Parameters["@UserId"].Value = userId;
            cmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar, 50));
            cmd.Parameters["@Title"].Value = post.Title;
            cmd.Parameters.Add(new SqlParameter("@Body", SqlDbType.Text));
            cmd.Parameters["@Body"].Value = post.Body;
            cmd.Parameters.Add(new SqlParameter("@NewPostId", SqlDbType.Int, 50, ParameterDirection.InputOutput, false, 0, 0, "@NewPostId", DataRowVersion.Original, null));
            cmd.Parameters["@NewPostId"].Value = ParameterDirection.InputOutput;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@NewPostId"].Value;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public int UpdatePost(Post post)
        {
            SqlCommand cmd = new SqlCommand("IUDPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "U";
            cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
            cmd.Parameters["@PostId"].Value = post.Id;
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
            cmd.Parameters["@UserId"].Value = 0;
            cmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar, 50));
            cmd.Parameters["@Title"].Value = post.Title;
            cmd.Parameters.Add(new SqlParameter("@Body", SqlDbType.Text));
            cmd.Parameters["@Body"].Value = post.Body;
            cmd.Parameters.Add(new SqlParameter("@NewPostId", SqlDbType.Int, 50, ParameterDirection.InputOutput, false, 0, 0, "@NewPostId", DataRowVersion.Original, null));
            cmd.Parameters["@NewPostId"].Value = ParameterDirection.InputOutput;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@NewPostId"].Value;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public int DeletePost(Post post)
        {
            SqlCommand cmd = new SqlCommand("IUDPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "D";
            cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
            cmd.Parameters["@PostId"].Value = post.Id;
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
            cmd.Parameters["@UserId"].Value = 0;
            cmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar, 50));
            cmd.Parameters["@Title"].Value = "";
            cmd.Parameters.Add(new SqlParameter("@Body", SqlDbType.Text));
            cmd.Parameters["@Body"].Value = "";
            cmd.Parameters.Add(new SqlParameter("@NewPostId", SqlDbType.Int, 50, ParameterDirection.InputOutput, false, 0, 0, "@NewPostId", DataRowVersion.Original, null));
            cmd.Parameters["@NewPostId"].Value = ParameterDirection.InputOutput;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@NewPostId"].Value;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<Post> GetUserPosts(int userId)
        {
            List<Post> Posts = new List<Post> { };
            SqlCommand cmd = new SqlCommand("select * from GetAllUserPosts(" + userId + ")", con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Post post = new Post((int)reader["PostId"], (string)reader["Title"], (string)reader["Body"]);
                    Posts.Add(post);
                }
                reader.Close();
                return Posts;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public Post GetPostById(int postId)
        {
            SqlCommand cmd = new SqlCommand("select * from GetPost(" + postId + ")", con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                reader.Read();
                Post post = new Post((int)reader["PostId"], (string)reader["Title"], (string)reader["Body"]);
                reader.Close();
                return post;

            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                con.Close();
            }
        }


        public void AddCategoryToPost(int categoryId, int postId)
        {
            SqlCommand cmd = new SqlCommand("AddDeleteCategoryPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "I";
            cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
            cmd.Parameters["@PostId"].Value = postId;
            cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
            cmd.Parameters["@CategoryId"].Value = categoryId;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                con.Close();
            }
        }


        public void DeleteCategoryFromPost(int categoryId, int postId)
        {
            SqlCommand cmd = new SqlCommand("AddDeleteCategoryPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "D";
            cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
            cmd.Parameters["@PostId"].Value = postId;
            cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
            cmd.Parameters["@CategoryId"].Value = categoryId;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

            finally
            {
                con.Close();
            }
        }

    }
}
