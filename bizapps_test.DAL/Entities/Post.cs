using System;

namespace bizapps_test.DAL.Entities
{
    public class Post
    {

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Body { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string PostImage { get; private set; }

        //public static SqlConnection Con = DBUtil.GetDBConnection();


        public Post(int postId, string title, string body, DateTime creationDate, string postImage)
        {
            Id = postId;
            Title = title;
            Body = body;
            CreationDate = creationDate;
            PostImage = postImage;
        }


        public Post(int postId, string title, string body, DateTime creationDate)
        {
            Id = postId;
            Title = title;
            Body = body;
            CreationDate = creationDate;
        }


        public Post(int postId, string title, string body, string postImage)
        {
            Id = postId;
            Title = title;
            Body = body;
            PostImage = postImage;
        }

        public Post( string title, string body, string postImage)
        {
         
            Title = title;
            Body = body;
            PostImage = postImage;
        }

        public Post(string title, string body)
        {
            Title = title;
            Body = body;
        }

        public Post(int postId)
        {
            Id = postId;
        }


         public Post()
         {
         }


       // public void GetPost(int postId)
       // {
       //     SqlCommand cmd = new SqlCommand("select * from GetPost(" + postId + ")", Con);

       //     try
       //     {
       //         Con.Open();
       //         SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

       //         reader.Read();
       //         this.Id =(int)reader["PostId"];
       //         this.Title=(string)reader["Title"];
       //         this.Body = (string)reader["Body"];
       //         reader.Close();

       //     }
       //     catch (SqlException e)
       //     {
       //         throw new ApplicationException(e.Message);
       //     }
       //     finally
       //     {
       //         Con.Close();
       //     }
       // }


       // public IEnumerable<Post> GetAllUserPosts(int userId)
       // {
       //     List<Post> posts = new List<Post> { };
       //     SqlCommand cmd = new SqlCommand("select * from GetAllUserPosts("+userId+")", Con);
       //     try
       //     {
       //         Con.Open();
       //         SqlDataReader reader = cmd.ExecuteReader();

       //         while (reader.Read())
       //         {
       //             Post post = new Post((int)reader["PostId"], (string)reader["Title"], (string)reader["Body"]);
       //             posts.Add(post);
       //         }
       //         reader.Close();
       //         return posts;
       //     }
       //     catch (SqlException e)
       //     {
       //         throw new ApplicationException(e.Message);
       //     }
       //     finally
       //     {
       //         Con.Close();
       //     }
            
           
       // }

       //public void InsertPost(int userId, out int postId)
       //{
       //    SqlCommand cmd = new SqlCommand("IUDPost", Con);
       //    cmd.CommandType = CommandType.StoredProcedure;
       //    cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char,1));
       //    cmd.Parameters["@Flag"].Value = "I";
       //    cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
       //    cmd.Parameters["@PostId"].Value = 0;
       //    cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
       //    cmd.Parameters["@UserId"].Value = userId;
       //    cmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar, 50));
       //    cmd.Parameters["@Title"].Value = this.Title;
       //    cmd.Parameters.Add(new SqlParameter("@Body", SqlDbType.Text));
       //    cmd.Parameters["@Body"].Value = this.Body;
       //    cmd.Parameters.Add(new SqlParameter("@NewPostId", SqlDbType.Int, 50,ParameterDirection.InputOutput, false, 0, 0,"@NewPostId", DataRowVersion.Original, null));
       //    cmd.Parameters["@NewPostId"].Value = ParameterDirection.InputOutput;
       //    try 
       //    {
       //        Con.Open();
       //        cmd.ExecuteNonQuery();
       //        postId = (int)cmd.Parameters["@NewPostId"].Value;
       //    }
       //    catch(SqlException e)
       //    {
       //        throw new ApplicationException(e.Message);
       //    }
       //    finally
       //    {
       //        Con.Close();
       //    }
       //}


       //public void UpdatePost()
       //{
       //    SqlCommand cmd = new SqlCommand("IUDPost", Con);
       //    cmd.CommandType = CommandType.StoredProcedure;
       //    cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
       //    cmd.Parameters["@Flag"].Value = "U";
       //    cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
       //    cmd.Parameters["@PostId"].Value = this.Id;
       //    cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
       //    cmd.Parameters["@UserId"].Value = 0;
       //    cmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar, 50));
       //    cmd.Parameters["@Title"].Value = this.Title;
       //    cmd.Parameters.Add(new SqlParameter("@Body", SqlDbType.Text));
       //    cmd.Parameters["@Body"].Value = this.Body;
       //    try
       //    {
       //        Con.Open();
       //        cmd.ExecuteNonQuery();
       //    }
       //    catch (SqlException e)
       //    {
       //        throw new ApplicationException(e.Message);
       //    }
       //    finally
       //    {
       //        Con.Close();
       //    }
       //}

       // public void DeletePost()
       //{
       //    SqlCommand cmd = new SqlCommand("IUDPost", Con);
       //    cmd.CommandType = CommandType.StoredProcedure;
       //    cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
       //    cmd.Parameters["@Flag"].Value = "D";
       //    cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
       //    cmd.Parameters["@PostId"].Value = this.Id;
       //    cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
       //    cmd.Parameters["@UserId"].Value = 0;
       //    cmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar, 50));
       //    cmd.Parameters["@Title"].Value = "";
       //    cmd.Parameters.Add(new SqlParameter("@Body", SqlDbType.Text));
       //    cmd.Parameters["@Body"].Value = "";
       //    try
       //    {
       //        Con.Open();
       //        cmd.ExecuteNonQuery();
       //    }
       //    catch (SqlException e)
       //    {
       //        throw new ApplicationException(e.Message);
       //    }
       //    finally
       //    {
       //        Con.Close();
       //    }
       //}


       // public void AddCategoryToPost(Category category, int postId)
       // {
       //     SqlCommand cmd = new SqlCommand("AddDeleteCategoryPost", Con);
       //     cmd.CommandType = CommandType.StoredProcedure;
       //     cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
       //     cmd.Parameters["@Flag"].Value = "I";
       //     cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
       //     cmd.Parameters["@PostId"].Value = postId;
       //     cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
       //     cmd.Parameters["@CategoryId"].Value = category.Id;
       //     try
       //     {
       //         Con.Open();
       //         cmd.ExecuteNonQuery();
       //     }
       //     catch (SqlException e)
       //     {
       //         throw new ApplicationException(e.Message);
       //     }
       //     finally
       //     {
       //         Con.Close();
       //     }
       // }

       // public void DeleteCategoryFromPost(Category category)
       // {
       //     SqlCommand cmd = new SqlCommand("AddDeleteCategoryPost", Con);
       //     cmd.CommandType = CommandType.StoredProcedure;
       //     cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
       //     cmd.Parameters["@Flag"].Value = "D";
       //     cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
       //     cmd.Parameters["@PostId"].Value = this.Id;
       //     cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
       //     cmd.Parameters["@CategoryId"].Value = category.Id;
       //     try
       //     {
       //         Con.Open();
       //         cmd.ExecuteNonQuery();
       //     }
       //     catch (SqlException e)
       //     {
       //         throw new ApplicationException(e.Message);
       //     }

       //     finally
       //     {
       //         Con.Close();
       //     }
        //}
    }
}
