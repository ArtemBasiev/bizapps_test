using System;
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
    public class BlogUserRepository: IBlogUserRepository
    {
        public static SqlConnection Con = DBUtil.GetDBConnection();


        public int CreateBlogUser(BlogUser blogUser)
        {
            SqlCommand cmd = new SqlCommand("IUDBlogUser", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "I";
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
            cmd.Parameters["@UserId"].Value = 0;
            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 50));
            cmd.Parameters["@UserName"].Value = blogUser.UserName;
            cmd.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.VarChar, 50));
            cmd.Parameters["@UserPassword"].Value = blogUser.UserPassword;
            cmd.Parameters.Add(new SqlParameter("@BlogName", SqlDbType.VarChar, 50));
            cmd.Parameters["@BlogName"].Value = blogUser.BlogName;
            cmd.Parameters.Add(new SqlParameter("@NewUserId", SqlDbType.Int, 50, ParameterDirection.InputOutput, false, 0, 0, "@NewPostId", DataRowVersion.Original, null));
            cmd.Parameters["@NewUserId"].Value = ParameterDirection.InputOutput;
            try
            {
                Con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@NewUserId"].Value;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        public int UpdateBlogUser(BlogUser blogUser)
        {
            SqlCommand cmd = new SqlCommand("IUDBlogUser",Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "U";
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
            cmd.Parameters["@UserId"].Value = blogUser.Id;
            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 50));
            cmd.Parameters["@UserName"].Value = blogUser.UserName;
            cmd.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.VarChar, 50));
            cmd.Parameters["@UserPassword"].Value = blogUser.UserPassword;
            cmd.Parameters.Add(new SqlParameter("@BlogName", SqlDbType.VarChar, 50));
            cmd.Parameters["@BlogName"].Value = blogUser.BlogName;
            cmd.Parameters.Add(new SqlParameter("@NewUserId", SqlDbType.Int, 50, ParameterDirection.InputOutput, false, 0, 0, "@NewPostId", DataRowVersion.Original, null));
            cmd.Parameters["@NewUserId"].Value = ParameterDirection.InputOutput;
            try
            {
                Con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@NewUserId"].Value;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        public int DeleteBlogUser(BlogUser blogUser)
        {
            SqlCommand cmd = new SqlCommand("IUDBlogUser", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "D";
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
            cmd.Parameters["@UserId"].Value = blogUser.Id;
            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 50));
            cmd.Parameters["@UserName"].Value = "";
            cmd.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.VarChar, 50));
            cmd.Parameters["@UserPassword"].Value = "";
            cmd.Parameters.Add(new SqlParameter("@BlogName", SqlDbType.VarChar, 50));
            cmd.Parameters["@BlogName"].Value = "";
            cmd.Parameters.Add(new SqlParameter("@NewUserId", SqlDbType.Int, 50, ParameterDirection.InputOutput, false, 0, 0, "@NewPostId", DataRowVersion.Original, null));
            cmd.Parameters["@NewUserId"].Value = ParameterDirection.InputOutput;
            try
            {
                Con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@NewUserId"].Value;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        public IEnumerable<BlogUser> GetAllBlogUsers()
        {
            List<BlogUser> users = new List<BlogUser> { };
            SqlCommand cmd = new SqlCommand("select * from GetAllUsers()", Con);
            try
            {
                Con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BlogUser user = new BlogUser((int)reader["UserId"], (string)reader["UserName"]);
                    users.Add(user);
                }
                reader.Close();
                return users;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        public BlogUser GetBlogUserById(int blogUserId)
        {
            SqlCommand cmd = new SqlCommand("select * from GetBlogUser(" + blogUserId + ")", Con);

            try
            {
                Con.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                reader.Read();
                BlogUser blogUser = new BlogUser((int)reader["UserId"], (string)reader["UserName"],(string)reader["UserPassword"], (string)reader["BlogName"]);
                reader.Close();

                return blogUser;

            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                Con.Close();
            }
        }

    }
}
