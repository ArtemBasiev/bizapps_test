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
    public class Category
    {
        public int Id { get; private set; }
        public string CategoryName { get; private set; }

        //public static SqlConnection con = DBUtil.GetDBConnection();

        public Category(int catId, string categoryName)
        {
 
            this.Id = catId;
            this.CategoryName = categoryName;
        }

        public Category(string categoryName)
        {
            this.CategoryName = categoryName;
        }

        public Category(int categoryId)
        {
            this.Id = categoryId;
        }
        public Category()
        {
        }


       // public void GetCategory(int categoryId)
       // {
       //     SqlCommand cmd = new SqlCommand("select * from GetCategory("+categoryId+")", con);

       //     try
       //     {
       //         con.Open();
       //         SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

       //         reader.Read();
       //         this.Id =(int)reader["CategoryId"];
       //         this.CategoryName=(string)reader["CategoryName"];
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


       // public IEnumerable<Category> GetAllCategories()
       // {
       //     List<Category> Categories = new List<Category>{};
       //     SqlCommand cmd = new SqlCommand("select * from GetAllCategories()", con);
       //     try
       //     {
       //         con.Open();
       //         SqlDataReader reader = cmd.ExecuteReader();

       //         while (reader.Read())
       //         {
       //             Category cat = new Category((int)reader["CategoryId"],(string)reader["CategoryName"]);
       //             Categories.Add(cat);
       //         }
       //         reader.Close();
       //         return Categories;
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

       // public IEnumerable<Category> GetPostCategories(int postId)
       // {
       //     List<Category> Categories = new List<Category> { };
       //     SqlCommand cmd = new SqlCommand("select * from GetPostCategories(" + postId + ")", con);
       //     try
       //     {
       //         con.Open();
       //         SqlDataReader reader = cmd.ExecuteReader();

       //         while (reader.Read())
       //         {
       //             Category cat = new Category((int)reader["CategoryId"], (string)reader["CategoryName"]);
       //             Categories.Add(cat);
       //         }
       //         reader.Close();
       //         return Categories;
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

       //public void InsertCategory()
       //{
       //    SqlCommand cmd = new SqlCommand("IUDCategory", con);
       //    cmd.CommandType = CommandType.StoredProcedure;
       //    cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char,1));
       //    cmd.Parameters["@Flag"].Value = "I";
       //    cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
       //    cmd.Parameters["@CategoryId"].Value = 0;
       //    cmd.Parameters.Add(new SqlParameter("@CategoryName", SqlDbType.VarChar,50));
       //    cmd.Parameters["@CategoryName"].Value = this.CategoryName;
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


       //public void UpdateCategory()
       //{
       //    SqlCommand cmd = new SqlCommand("IUDCategory", con);
       //    cmd.CommandType = CommandType.StoredProcedure;
       //    cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
       //    cmd.Parameters["@Flag"].Value = "U";
       //    cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
       //    cmd.Parameters["@CategoryId"].Value = this.Id;
       //    cmd.Parameters.Add(new SqlParameter("@CategoryName", SqlDbType.VarChar, 50));
       //    cmd.Parameters["@CategoryName"].Value = this.CategoryName;
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

       // public void DeleteCategory()
       //{
       //    SqlCommand cmd = new SqlCommand("IUDCategory", con);
       //    cmd.CommandType = CommandType.StoredProcedure;
       //    cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
       //    cmd.Parameters["@Flag"].Value = "D";
       //    cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
       //    cmd.Parameters["@CategoryId"].Value = this.Id;
       //    cmd.Parameters.Add(new SqlParameter("@CategoryName", SqlDbType.VarChar, 50));
       //    cmd.Parameters["@CategoryName"].Value = "";
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
