using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bizapps_test.DAL.Entities;
using bizapps_test.DAL.Utils;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;


namespace bizapps_test.DAL.Tests
{
    [TestClass]
    public class CategoryTests
    {
        public static Category category { get; set; }

        //[ClassInitialize]
        //public static void ClassInitialize(TestContext context)
        //{
        //    CategoryTests.category = new Category(new SqlConnection(@"Data Source=DESKTOP-5QPRQC5\SQLEXPRESS;Initial Catalog=test_BizappsTest;Integrated Security =SSPI;"));
        //}


        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    category.Id = 0;
        //    category.CategoryName = "";
            
        //}

        //[TestMethod]
        //public void InsertCategoryTest()
        //{
        //    string categoryExpectName;
        //    try
        //    {
        //        category.CategoryName = "Test";
        //        categoryExpectName = category.CategoryName;
        //        //-------------Добавляем  категорию--------------------------------
        //        category.InsertCategory();

        //        SqlCommand cmd = new SqlCommand("select CategoryName from Category where Id =IDENT_CURRENT('Category')", Category.con);
        //        Category.con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

              
        //        reader.Read();

        //            string categoryResultName =(string)reader["CategoryName"];

        //            reader.Close();
        //            //-------------Проверяем созданную категорию--------------------------------
        //            Assert.AreEqual(categoryExpectName, categoryResultName);

        //            SqlCommand cmdDelete = new SqlCommand("DELETE from Category where Id = IDENT_CURRENT('Category')", Category.con);
        //            cmdDelete.ExecuteNonQuery();
        //            Category.con.Close();


               
               

        //    }
        //    catch(Exception ex)
        //    {
        //        SqlCommand cmdDelete = new SqlCommand("DELETE from Category where Id = IDENT_CURRENT('Category')", Category.con);
        //        cmdDelete.ExecuteNonQuery();
        //        Category.con.Close();
        //       Assert.Fail(ex.Message);
        //    }
        //}


        //[TestMethod]
        //public void UpdateCategoryTest()
        //{
        //    string categoryExpectName = "RenamedCategory";
        //    string categoryResultName;
        //    try
        //    {
        //        //-------------Добавляем тестовую категорию--------------------------------
        //        SqlCommand cmdAddCategory = new SqlCommand("INSERT INTO Category (CategoryName) VALUES ('TestCategory')", Category.con);
        //        Category.con.Open();
        //        cmdAddCategory.ExecuteNonQuery();


                
        //        SqlCommand cmdSelectCategory = new SqlCommand("select Id, CategoryName from Category where Id =IDENT_CURRENT('Category')", Category.con);
        //        SqlDataReader reader = cmdSelectCategory.ExecuteReader(CommandBehavior.SingleRow);
        //        reader.Read();
        //        category.Id = (int)reader["Id"];
        //        category.CategoryName = categoryExpectName;
        //        reader.Close();
        //        Category.con.Close();

        //        //-------------Обновляем  категорию--------------------------------
        //        category.UpdateCategory();


        //        Category.con.Open();
        //        SqlCommand cmdSelUpdCategory = new SqlCommand("select Id, CategoryName from Category where Id =IDENT_CURRENT('Category')", Category.con);
        //        SqlDataReader readerUpdCategory = cmdSelUpdCategory.ExecuteReader(CommandBehavior.SingleRow);
        //        readerUpdCategory.Read();
        //        categoryResultName = (string)readerUpdCategory["CategoryName"];
        //        readerUpdCategory.Close();

        //        //-------------Сравниваем наименования категорий--------------------------------
        //        Assert.AreEqual(categoryExpectName, categoryResultName);

           
        //        SqlCommand cmdDelete = new SqlCommand("DELETE from Category where Id = IDENT_CURRENT('Category')", Category.con);
        //        cmdDelete.ExecuteNonQuery();
        //        Category.con.Close();


        //    }
        //    catch(Exception ex)
        //    {
        //        //-------------Удаляем тестовую категорию--------------------------------
        //        SqlCommand cmdDelete = new SqlCommand("DELETE from Category where Id = IDENT_CURRENT('Category')", Category.con);
        //        cmdDelete.ExecuteNonQuery();
        //        Category.con.Close();
        //        Assert.Fail(ex.Message);
        //    }
           
        //}

        //[TestMethod]
        //public void DeleteCategoryTest()
        //{
        //    try
        //    {
        //        //-------------Добавляем тестовую категорию--------------------------------
        //        SqlCommand cmdAddCategory = new SqlCommand("INSERT INTO Category (CategoryName) VALUES ('TestCategory')", Category.con);
        //        Category.con.Open();
        //        cmdAddCategory.ExecuteNonQuery();



        //        SqlCommand cmdSelectCategory = new SqlCommand("select Id, CategoryName from Category where Id =IDENT_CURRENT('Category')", Category.con);
        //        SqlDataReader reader = cmdSelectCategory.ExecuteReader(CommandBehavior.SingleRow);
        //        reader.Read();
        //        category.Id = (int)reader["Id"];
        //        reader.Close();
        //        Category.con.Close();

        //        //-------------Удаляем категорию--------------------------------
        //        category.DeleteCategory();


        //        Category.con.Open();
        //        SqlCommand cmdSelDeletedCategory = new SqlCommand("select Id, CategoryName from Category where Id =IDENT_CURRENT('Category')", Category.con);
        //        SqlDataReader readerDelCategory = cmdSelDeletedCategory.ExecuteReader(CommandBehavior.SingleRow);
        //        readerDelCategory.Read();


        //        //-------------Проверяем вернул ли запрос удаленной  категории строку--------------------------------
        //        if(readerDelCategory.HasRows)
        //        {
        //            readerDelCategory.Close();
        //            throw new Exception("Категория не удалена");
        //        }

        //        readerDelCategory.Close();
        //        Category.con.Close();


        //    }
        //    catch (Exception ex)
        //    {
        //        //-------------Удаляем категорию--------------------------------
        //        SqlCommand cmdDelete = new SqlCommand("DELETE from Category where Id = IDENT_CURRENT('Category')", Category.con);
        //        cmdDelete.ExecuteNonQuery();
        //        Category.con.Close();
        //        Assert.Fail(ex.Message);
        //    }
        //}

        //[TestMethod]
        //public void GetCategoryTest()
        //{
        //    int AddedCategoryId;
        //    try
        //    {

        //        //-------------Добавляем тестовую категорию--------------------------------
        //        SqlCommand cmdAddCategory = new SqlCommand("INSERT INTO Category (CategoryName) VALUES ('TestCategory')", Category.con);
        //        Category.con.Open();
        //        cmdAddCategory.ExecuteNonQuery();


        //        SqlCommand cmd = new SqlCommand("select Id from Category where Id =IDENT_CURRENT('Category')", Category.con);
        //        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
        //        reader.Read();
        //        AddedCategoryId = (int)reader["Id"];
        //        reader.Close();

        //        Category.con.Close();

        //        category.GetCategory(AddedCategoryId);
        //        Category.con.Open();
               
        //        //-------------Проверяем полученную категорию--------------------------------
        //        Assert.AreEqual(AddedCategoryId, category.Id);

                
        //        SqlCommand cmdDelete = new SqlCommand("DELETE from Category where Id = IDENT_CURRENT('Category')", Category.con);
        //        cmdDelete.ExecuteNonQuery();
                
        //        Category.con.Close();





        //    }
        //    catch (Exception ex)
        //    {
        //        //Category.con.Open();
        //        SqlCommand cmdDelete = new SqlCommand("DELETE from Category where Id = IDENT_CURRENT('Category')", Category.con);
        //        cmdDelete.ExecuteNonQuery();
        //        Category.con.Close();
        //        Assert.Fail(ex.Message);
        //    }
        //}

        //[TestMethod]
        //public void GetAllCategoriesTest()
        //{
        //    try
        //    {

        //        //-------------Добавляем тестовые категории--------------------------------
        //        SqlCommand cmdAddCategories = new SqlCommand("INSERT INTO Category (CategoryName) VALUES ('TestCategory1'); INSERT INTO Category (CategoryName) VALUES ('TestCategory2'); INSERT INTO Category (CategoryName) VALUES ('TestCategory3');", Category.con);
        //        Category.con.Open();
        //        cmdAddCategories.ExecuteNonQuery();
        //        Category.con.Close();

        //        List<Category> categories = (List<Category>)category.GetAllCategories();

        //         if(categories.Count<3)
        //         {

        //            throw new ApplicationException("Возвращен неполный список категорий");

        //         }
        //         else
        //         {
        //             //-------------Удаляем тестовые категории--------------------------------
        //             Category.con.Open();
        //             SqlCommand cmdDelete = new SqlCommand("DELETE from Category where CategoryName = 'TestCategory1'; DELETE from Category where CategoryName = 'TestCategory2'; DELETE from Category where CategoryName = 'TestCategory3';", Category.con);
        //             cmdDelete.ExecuteNonQuery();
        //             Category.con.Close();
        //         }

        //    }
        //    catch (Exception ex)
        //    {
        //        //-------------Удаляем тестовые категории--------------------------------
        //        Category.con.Open();
        //        SqlCommand cmdDelete = new SqlCommand("DELETE from Category where CategoryName = 'TestCategory1'; DELETE from Category where CategoryName = 'TestCategory2'; DELETE from Category where CategoryName = 'TestCategory3';", Category.con);
        //        cmdDelete.ExecuteNonQuery();
        //        Category.con.Close();
        //        Assert.Fail(ex.Message);
        //    }
        //}

        //[TestMethod]
        //public void GetPostCategoriesTest()
        //{
        //    try
        //    {

        //        //-------------Добавляем тестовые данные--------------------------------
        //        SqlCommand cmdAddCategories = new SqlCommand("INSERT INTO BlogUser (UserName, UserPassword) VALUES ('TestUser', '12345'); INSERT INTO Blog (BlogName, CreationDate, UserId) VALUES ('TestBlog', GETDATE(), IDENT_CURRENT('BlogUser')); INSERT INTO Post (Title, Body, CreationDate, BlogId) VALUES ('TestPostTitle', 'TestPostBody', GETDATE(), IDENT_CURRENT('Blog')); INSERT INTO Category (CategoryName) VALUES ('TestCategory'); INSERT INTO RelationPostCategory (PostId, CategoryId) VALUES (IDENT_CURRENT('Post'), IDENT_CURRENT('Category'));", Category.con);
        //        Category.con.Open();
        //        cmdAddCategories.ExecuteNonQuery();

        //        SqlCommand cmd = new SqlCommand("select Id from Post where Id =IDENT_CURRENT('Post')", Category.con);
        //        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
        //        reader.Read();
        //        int AddedPostId = (int)reader["Id"];
        //        reader.Close();
        //        Category.con.Close();

        //        List<Category> categories = (List<Category>)category.GetPostCategories(AddedPostId);

        //        if (categories.Count < 1)
        //        {

        //            throw new ApplicationException("Метод не возвращает список категорий");

        //        }
        //        else
        //        {
        //            //-------------Удаляем тестовые данные--------------------------------
        //            Category.con.Open();
        //            SqlCommand cmdDelete = new SqlCommand("DELETE from RelationPostCategory where PostId = IDENT_CURRENT('Post'); DELETE from Category where Id = IDENT_CURRENT('Category'); DELETE from Post where Id = IDENT_CURRENT('Post'); DELETE FROM Blog WHERE Id=IDENT_CURRENT('Blog'); DELETE FROM BlogUser WHERE Id=IDENT_CURRENT('BlogUser');", Category.con);
        //            cmdDelete.ExecuteNonQuery();
        //            Category.con.Close();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //-------------Удаляем тестовые данные--------------------------------
        //        Category.con.Open();
        //        SqlCommand cmdDelete = new SqlCommand("DELETE from RelationPostCategory where PostId = IDENT_CURRENT('Post'); DELETE from Category where Id = IDENT_CURRENT('Category'); DELETE from Post where Id = IDENT_CURRENT('Post'); DELETE FROM Blog WHERE Id=IDENT_CURRENT('Blog'); DELETE FROM BlogUser WHERE Id=IDENT_CURRENT('BlogUser');", Category.con);
        //        cmdDelete.ExecuteNonQuery();
        //        Category.con.Close();
        //        Assert.Fail(ex.Message);
        //    }
        //}
    }
}
