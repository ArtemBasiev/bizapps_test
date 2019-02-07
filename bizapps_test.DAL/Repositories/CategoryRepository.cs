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
    public class CategoryRepository : ICategoryRepository
    {
        public static SqlConnection Con = DBUtil.GetDBConnection();


        public int CreateCategory(Category category)
        {
            SqlCommand cmd = new SqlCommand("IUDCategory", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "I";
            cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
            cmd.Parameters["@CategoryId"].Value = 0;
            cmd.Parameters.Add(new SqlParameter("@CategoryName", SqlDbType.VarChar, 50));
            cmd.Parameters["@CategoryName"].Value = category.CategoryName;
            cmd.Parameters.Add(new SqlParameter("@NewCategoryId", SqlDbType.Int, 50, ParameterDirection.InputOutput, false, 0, 0, "@NewPostId", DataRowVersion.Original, null));
            cmd.Parameters["@NewCategoryId"].Value = ParameterDirection.InputOutput;
            try
            {
                Con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@NewCategoryId"].Value;
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

        public int UpdateCategory(Category category)
        {
            SqlCommand cmd = new SqlCommand("IUDCategory", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "U";
            cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
            cmd.Parameters["@CategoryId"].Value = category.Id;
            cmd.Parameters.Add(new SqlParameter("@CategoryName", SqlDbType.VarChar, 50));
            cmd.Parameters["@CategoryName"].Value = category.CategoryName;
            cmd.Parameters.Add(new SqlParameter("@NewCategoryId", SqlDbType.Int, 50, ParameterDirection.InputOutput, false, 0, 0, "@NewPostId", DataRowVersion.Original, null));
            cmd.Parameters["@NewCategoryId"].Value = ParameterDirection.InputOutput;
            try
            {
                Con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@NewCategoryId"].Value;
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

        public int DeleteCategory(Category category)
        {
            SqlCommand cmd = new SqlCommand("IUDCategory", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1));
            cmd.Parameters["@Flag"].Value = "D";
            cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
            cmd.Parameters["@CategoryId"].Value = category.Id;
            cmd.Parameters.Add(new SqlParameter("@CategoryName", SqlDbType.VarChar, 50));
            cmd.Parameters["@CategoryName"].Value = "";
            cmd.Parameters.Add(new SqlParameter("@NewCategoryId", SqlDbType.Int, 50, ParameterDirection.InputOutput, false, 0, 0, "@NewPostId", DataRowVersion.Original, null));
            cmd.Parameters["@NewCategoryId"].Value = ParameterDirection.InputOutput;
            try
            {
                Con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@NewCategoryId"].Value;
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


        public Category GetCategoryById(int categoryId)
        {
            SqlCommand cmd = new SqlCommand("select * from GetCategory(" + categoryId + ")", Con);

            try
            {
                Con.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                reader.Read();
                Category category = new Category((int)reader["CategoryId"], (string)reader["CategoryName"]);
                reader.Close();

                return category;

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
        public IEnumerable<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category> { };
            SqlCommand cmd = new SqlCommand("select * from GetAllCategories()", Con);
            try
            {
                Con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Category cat = new Category((int)reader["CategoryId"], (string)reader["CategoryName"]);
                    categories.Add(cat);
                }
                reader.Close();
                return categories;
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

        public IEnumerable<Category> GetPostCategories(int postId)
        {
            List<Category> categories = new List<Category> { };
            SqlCommand cmd = new SqlCommand("select * from GetPostCategories(" + postId + ")", Con);
            try
            {
                Con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Category cat = new Category((int)reader["CategoryId"], (string)reader["CategoryName"]);
                    categories.Add(cat);
                }
                reader.Close();
                return categories;
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
