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
    public class BlogUserTests
    {
        public static BlogUser bloguser { get; set; }

        //[ClassInitialize]
        //public static void ClassInitialize(TestContext context)
        //{
        //    BlogUserTests.bloguser = new BlogUser(new SqlConnection(@"Data Source=DESKTOP-5QPRQC5\SQLEXPRESS;Initial Catalog=test_BizappsTest;Integrated Security =SSPI;"));
        //}


        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    bloguser.Id = 0;
        //    bloguser.UserName = "";
        //    bloguser.UserPassword="";
        //    bloguser.BlogName = "";

        //}

        //[TestMethod]
        //public void InsertBlogUserTest()
        //{
        //    string BlogUserExpectName;
        //    string BlogUserExpectPassword;
        //    string BlogUserExpectBlogName;

        //    try
        //    {
        //        bloguser.UserName = "TestUser";
        //        bloguser.UserPassword = "1111";
        //        bloguser.BlogName = "TestUserBlog";

        //        BlogUserExpectName = bloguser.UserName;
        //        BlogUserExpectPassword = bloguser.UserPassword;
        //        BlogUserExpectBlogName = bloguser.BlogName;

        //        //-------------Добавляем  ползователя--------------------------------
        //        bloguser.InsertBlogUser();

        //        SqlCommand cmd = new SqlCommand("select bu.UserName, bu.UserPassword, b.BlogName from BlogUser bu join Blog b on b.UserId = bu.Id where bu.Id =IDENT_CURRENT('BlogUser')", BlogUser.con);
        //        BlogUser.con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);


        //        reader.Read();

        //        string BlogUserResultName = (string)reader["UserName"];
        //        string BlogUserResultPassword = (string)reader["UserPassword"];
        //        string BlogUserResultBlogName = (string)reader["BlogName"];

        //        reader.Close();
        //        //-------------Проверяем созданного пользователя--------------------------------
        //        Assert.AreEqual(BlogUserExpectName, BlogUserResultName);
        //        Assert.AreEqual(BlogUserExpectPassword, BlogUserResultPassword);
        //        Assert.AreEqual(BlogUserExpectBlogName, BlogUserResultBlogName);

        //        SqlCommand cmdDelete = new SqlCommand("DELETE from Blog where UserId = IDENT_CURRENT('BlogUser'); DELETE FROM BlogUser WHERE Id=IDENT_CURRENT('BlogUser');", BlogUser.con);
        //        cmdDelete.ExecuteNonQuery();
        //        Category.con.Close();





        //    }
        //    catch (Exception ex)
        //    {
        //        SqlCommand cmdDelete = new SqlCommand("DELETE from Blog where UserId = IDENT_CURRENT('BlogUser'); DELETE FROM BlogUser WHERE Id=IDENT_CURRENT('BlogUser');", BlogUser.con);
        //        cmdDelete.ExecuteNonQuery();
        //        Category.con.Close();
        //        Assert.Fail(ex.Message);
        //    }
        //}


        //[TestMethod]
        //public void UpdateBlogUserTest()
        //{
        //    string BlogUserExpectName="RenamedUser";
        //    string BlogUserExpectPassword="ChangedPassword";
        //    string BlogUserExpectBlogName="RenamedBlogName";
        //    try
        //    {
        //        //-------------Добавляем тестового пользователя и его блог--------------------------------
        //        SqlCommand cmdAddBlogUser = new SqlCommand("INSERT INTO BlogUser (UserName, UserPassword) VALUES ('TestUser','Testpassword'); INSERT INTO Blog (BlogName, CreationDate, UserId) VALUES ('UserTestBlog', GETDATE(), IDENT_CURRENT('BlogUser'));", BlogUser.con);
        //        BlogUser.con.Open();
        //        cmdAddBlogUser.ExecuteNonQuery();



        //        SqlCommand cmdSelectBlogUser = new SqlCommand("select bu.Id from BlogUser bu WHERE bu.Id =IDENT_CURRENT('BlogUser')", BlogUser.con);
        //        SqlDataReader reader = cmdSelectBlogUser.ExecuteReader(CommandBehavior.SingleRow);
        //        reader.Read();
        //        bloguser.Id = (int)reader["Id"];
        //        bloguser.UserName = BlogUserExpectName;
        //        bloguser.UserPassword = BlogUserExpectPassword;
        //        bloguser.BlogName = BlogUserExpectBlogName;
        //        reader.Close();
        //        BlogUser.con.Close();

        //        //-------------Обновляем  пользователя и блог--------------------------------
        //        bloguser.UpdateBlogUser();


        //        BlogUser.con.Open();
        //        SqlCommand cmdSelUpdBlogUser = new SqlCommand("select bu.Id, bu.UserName, bu.UserPassword, b.BlogName from BlogUser bu JOIN Blog b ON b.UserId = bu.Id WHERE bu.Id =IDENT_CURRENT('BlogUser')", BlogUser.con);
        //        SqlDataReader readerUpdBlogUser = cmdSelUpdBlogUser.ExecuteReader(CommandBehavior.SingleRow);
        //        readerUpdBlogUser.Read();

        //        string BlogUserResultName = (string)reader["UserName"];
        //        string BlogUserResultPassword = (string)reader["UserPassword"];
        //        string BlogUserResultBlogName = (string)reader["BlogName"];


        //        readerUpdBlogUser.Close();

        //        //-------------Проверяем изменения пользователя и блога--------------------------------
        //        Assert.AreEqual(BlogUserExpectName, BlogUserResultName);
        //        Assert.AreEqual(BlogUserExpectPassword, BlogUserResultPassword);
        //        Assert.AreEqual(BlogUserExpectBlogName, BlogUserResultBlogName);


        //        SqlCommand cmdDelete = new SqlCommand("DELETE from Blog where UserId = IDENT_CURRENT('BlogUser'); DELETE FROM BlogUser WHERE Id=IDENT_CURRENT('BlogUser');", BlogUser.con);
        //        cmdDelete.ExecuteNonQuery();
        //        Category.con.Close();


        //    }
        //    catch (Exception ex)
        //    {
        //        //-------------Удаляем тестовую категорию--------------------------------
        //        SqlCommand cmdDelete = new SqlCommand("DELETE from Blog where UserId = IDENT_CURRENT('BlogUser'); DELETE FROM BlogUser WHERE Id=IDENT_CURRENT('BlogUser');", BlogUser.con);
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
        //        if (readerDelCategory.HasRows)
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

        //        if (categories.Count < 3)
        //        {

        //            throw new ApplicationException("Возвращен неполный список категорий");

        //        }
        //        else
        //        {
        //            //-------------Удаляем тестовые категории--------------------------------
        //            Category.con.Open();
        //            SqlCommand cmdDelete = new SqlCommand("DELETE from Category where CategoryName = 'TestCategory1'; DELETE from Category where CategoryName = 'TestCategory2'; DELETE from Category where CategoryName = 'TestCategory3';", Category.con);
        //            cmdDelete.ExecuteNonQuery();
        //            Category.con.Close();
        //        }

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
