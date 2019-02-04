using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bizapps_test.DAL.Utils;
using System.Data.SqlClient;
using System.Data;

namespace bizapps_test.DAL.Entities
{
    public class Post
    {

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Body { get; private set; }

        public static SqlConnection con = DBUtil.GetDBConnection();


        public Post(int postId, string title, string body)
        {
            this.Id = postId;
            this.Title = title;
            this.Body = body;
        }

        public Post(string title, string body)
        {
            this.Title = title;
            this.Body = body;
        }

        public Post(int postId)
        {
            this.Id = postId;
        }


         public Post()
         {
         }


        public void GetPost(int postId)
        {
            SqlCommand cmd = new SqlCommand("select * from GetPost(" + postId + ")", con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                reader.Read();
                this.Id =(int)reader["PostId"];
                this.Title=(string)reader["Title"];
                this.Body = (string)reader["Body"];
                reader.Close();

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


        public IEnumerable<Post> GetAllUserPosts(int userId)
        {
            List<Post> Posts = new List<Post> { };
            SqlCommand cmd = new SqlCommand("select * from GetAllUserPosts("+userId+")", con);
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

       public void InsertPost(int userId, out int postId)
       {
           SqlCommand cmd = new SqlCommand("IUDPost", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char,1));
           cmd.Parameters["@Flag"].Value = "I";
           cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
           cmd.Parameters["@PostId"].Value = 0;
           cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
           cmd.Parameters["@UserId"].Value = userId;
           cmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar, 50));
           cmd.Parameters["@Title"].Value = this.Title;
           cmd.Parameters.Add(new SqlParameter("@Body", SqlDbType.Text));
           cmd.Parameters["@Body"].Value = this.Body;
           cmd.Parameters.Add(new SqlParameter("@NewPostId", SqlDbType.Int, 50,ParameterDirection.InputOutput, false, 0, 0,"@NewPostId", DataRowVersion.Original, null));
           cmd.Parameters["@NewPostId"].Value = ParameterDirection.InputOutput;
           try 
           {
               con.Open();
               cmd.ExecuteNonQuery();
               postId = (int)cmd.Parameters["@NewPostId"].Value;
           }
           catch(SqlException e)
           {
               throw new ApplicationException(e.Message);
           }
           finally
           {
               con.Close();
           }
       }


       public void UpdatePost()
       {
           SqlCommand cmd = new SqlCommand("IUDPost", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
           cmd.Parameters["@Flag"].Value = "U";
           cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
           cmd.Parameters["@PostId"].Value = this.Id;
           cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
           cmd.Parameters["@UserId"].Value = 0;
           cmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar, 50));
           cmd.Parameters["@Title"].Value = this.Title;
           cmd.Parameters.Add(new SqlParameter("@Body", SqlDbType.Text));
           cmd.Parameters["@Body"].Value = this.Body;
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

        public void DeletePost()
       {
           SqlCommand cmd = new SqlCommand("IUDPost", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
           cmd.Parameters["@Flag"].Value = "D";
           cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
           cmd.Parameters["@PostId"].Value = this.Id;
           cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
           cmd.Parameters["@UserId"].Value = 0;
           cmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar, 50));
           cmd.Parameters["@Title"].Value = "";
           cmd.Parameters.Add(new SqlParameter("@Body", SqlDbType.Text));
           cmd.Parameters["@Body"].Value = "";
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


        public void AddCategoryToPost(Category category, int postId)
        {
            SqlCommand cmd = new SqlCommand("AddDeleteCategoryPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "I";
            cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
            cmd.Parameters["@PostId"].Value = postId;
            cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
            cmd.Parameters["@CategoryId"].Value = category.Id;
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

        public void DeleteCategoryFromPost(Category category)
        {
            SqlCommand cmd = new SqlCommand("AddDeleteCategoryPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "D";
            cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
            cmd.Parameters["@PostId"].Value = this.Id;
            cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
            cmd.Parameters["@CategoryId"].Value = category.Id;
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
