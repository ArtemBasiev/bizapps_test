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
    public class BlogUser
    {
        public int Id { get;  set; }
        public string UserName { get;  set; }
        public string UserPassword { get; set; }
        public string BlogName { get; set; }

        //public static SqlConnection con = DBUtil.GetDBConnection();


        public BlogUser(int userId, string userName, string userPassword, string blogName)
        {
            this.Id = userId;
            this.UserName = userName;
            this.UserPassword = userPassword;
            this.BlogName = blogName;
        }


        public BlogUser(string userName, string userPassword, string blogName)
        {
            this.UserName = userName;
            this.UserPassword = userPassword;
            this.BlogName = blogName;
        }

        public BlogUser(int userId, string userName, string blogName)
         {
             this.Id = userId;
             this.UserName = userName;
             this.BlogName = blogName;
         }

        public BlogUser(int userId, string userName)
        {
            this.Id = userId;
            this.UserName = userName;
        }

        public BlogUser(int userId)
        {
            this.Id = userId;
        }

         public BlogUser()
         {
         }


       // public void GetBlogUser(int userId)
       // {
       //     SqlCommand cmd = new SqlCommand("select * from GetBlogUser(" + userId + ")", con);

       //     try
       //     {
       //         con.Open();
       //         SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

       //         reader.Read();
       //         this.Id =(int)reader["UserId"];
       //         this.UserName=(string)reader["UserName"];
       //         this.UserPassword = (string)reader["UserPassword"];
       //         this.BlogName = (string)reader["BlogName"];
       //         reader.Close();

       //     }
       //     catch (SqlException e)
       //     {
       //         throw new ApplicationException(e.Message);
       //     }
       //     finally
       //     {
       //         con.Close();
       //     }
       // }


       // public IEnumerable<BlogUser> GetAllUsers()
       // {
       //     List<BlogUser> Users = new List<BlogUser> { };
       //     SqlCommand cmd = new SqlCommand("select * from GetAllUsers()", con);
       //     try
       //     {
       //         con.Open();
       //         SqlDataReader reader = cmd.ExecuteReader();

       //         while (reader.Read())
       //         {
       //             BlogUser user = new BlogUser((int)reader["UserId"], (string)reader["UserName"]);
       //             Users.Add(user);
       //         }
       //         reader.Close();
       //         return Users;
       //     }
       //     catch (SqlException e)
       //     {
       //         throw new ApplicationException(e.Message);
       //     }
       //     finally
       //     {
       //         con.Close();
       //     }
            
           
       // }

       //public void InsertBlogUser()
       //{
       //    SqlCommand cmd = new SqlCommand("IUDBlogUser", con);
       //    cmd.CommandType = CommandType.StoredProcedure;
       //    cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char,1));
       //    cmd.Parameters["@Flag"].Value = "I";
       //    cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
       //    cmd.Parameters["@UserId"].Value = 0;
       //    cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar,50));
       //    cmd.Parameters["@UserName"].Value = this.UserName;
       //    cmd.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.VarChar, 50));
       //    cmd.Parameters["@UserPassword"].Value = this.UserPassword;
       //    cmd.Parameters.Add(new SqlParameter("@BlogName", SqlDbType.VarChar, 50));
       //    cmd.Parameters["@BlogName"].Value = this.BlogName;
       //    try 
       //    {
       //        con.Open();
       //        cmd.ExecuteNonQuery();
       //    }
       //    catch(SqlException e)
       //    {
       //        throw new ApplicationException(e.Message);
       //    }
       //    finally
       //    {
       //        con.Close();
       //    }
       //}


       //public void UpdateBlogUser()
       //{
       //    SqlCommand cmd = new SqlCommand("IUDBlogUser", con);
       //    cmd.CommandType = CommandType.StoredProcedure;
       //    cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
       //    cmd.Parameters["@Flag"].Value = "U";
       //    cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
       //    cmd.Parameters["@UserId"].Value = this.Id;
       //    cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 50));
       //    cmd.Parameters["@UserName"].Value = this.UserName;
       //    cmd.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.VarChar, 50));
       //    cmd.Parameters["@UserPassword"].Value = this.UserPassword;
       //    cmd.Parameters.Add(new SqlParameter("@BlogName", SqlDbType.VarChar, 50));
       //    cmd.Parameters["@BlogName"].Value = this.BlogName;
       //    try
       //    {
       //        con.Open();
       //        cmd.ExecuteNonQuery();
       //    }
       //    catch (SqlException e)
       //    {
       //        throw new ApplicationException(e.Message);
       //    }

       //    finally
       //    {
       //        con.Close();
       //    }
       //}

       // public void DeleteBlogUser()
       //{
       //    SqlCommand cmd = new SqlCommand("IUDBlogUser", con);
       //    cmd.CommandType = CommandType.StoredProcedure;
       //    cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
       //    cmd.Parameters["@Flag"].Value = "D";
       //    cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
       //    cmd.Parameters["@UserId"].Value = this.Id;
       //    cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 50));
       //    cmd.Parameters["@UserName"].Value = "";
       //    cmd.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.VarChar, 50));
       //    cmd.Parameters["@UserPassword"].Value = "";
       //    cmd.Parameters.Add(new SqlParameter("@BlogName", SqlDbType.VarChar, 50));
       //    cmd.Parameters["@BlogName"].Value = "";
       //    try
       //    {
       //        con.Open();
       //        cmd.ExecuteNonQuery();
       //    }
       //    catch (SqlException e)
       //    {
       //        throw new ApplicationException(e.Message);
       //    }
       //    finally
       //    {
       //        con.Close();
       //    }
       //}


    }
}
