using System;
using System.Collections.Generic;
using bizapps_test.DAL.Entities;
using bizapps_test.BLL.Infrastructure;
using bizapps_test.BLL.Interfaces;
using bizapps_test.BLL.DTO;
using System.Data.SqlClient;

namespace bizapps_test.BLL.Services
{
    public class PostService: IPostService
    {

        public void CreatePost(PostDTO postDTO, int userId, List<CategoryDTO> categoryListDTO)
        {
            //----------------------------------------Добавляем новый пост--------------------------------
            try
            {
                if (categoryListDTO.Count==0)
                {
                    throw new ApplicationException("Пост должен принадлежать хотя бы к одной из категорий");
                }

                int newpostId;
                Post post = new Post(postDTO.Title, postDTO.Body);
                post.InsertPost(userId, out newpostId);

                foreach (CategoryDTO categoryDTO in categoryListDTO)
                {
                    Category newcategory = new Category(categoryDTO.Id, categoryDTO.CategoryName);
                    post.AddCategoryToPost(newcategory, newpostId);
                }

              
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }


        }

        public void UpdatePost(PostDTO postDTO, List<CategoryDTO> categoryListDTO)
        {
            //----------------------------------------Обновляем существующий пост--------------------------------
            try
            {
                Post post = new Post(postDTO.Id, postDTO.Title, postDTO.Body);
                post.UpdatePost();

                IEnumerable<Category> postCategories = new Category().GetPostCategories(post.Id);
                int IsIdentic;
                foreach(Category postCat in postCategories)
                {
                    IsIdentic = 0;
                    foreach (CategoryDTO catDTO in categoryListDTO)
                    { 
                        if (catDTO.Id==postCat.Id)
                        {
                            IsIdentic = 1;
                        }
                        else { }
                    }

                    if (IsIdentic == 0)
                    {
                        post.DeleteCategoryFromPost(postCat);
                    }

                }

                foreach (CategoryDTO catDTO in categoryListDTO)
                {
                    Category newcat = new Category(catDTO.Id);
                    post.AddCategoryToPost(newcat, post.Id);
                }
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }


        public void DeletePost(PostDTO postDTO)
        {
            //----------------------------------------Удаляем пост, а так-же все связанные с ним сущности--------------------------------
            try
            {
                Post post = new Post(postDTO.Id);
                post.DeletePost();
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }


        }

        public IEnumerable<PostDTO> GetAllUserPosts(int userId)
        {
            try
            {
                //-----------------------------Получаем список всех постов пользователя---------------------------------------
                IEnumerable<Post> posts = new Post().GetAllUserPosts(userId);
                List<PostDTO> DTOposts = new List<PostDTO>();
                foreach (Post post in posts)
                {
                    PostDTO newpostDTO = new PostDTO();
                    newpostDTO.Id = post.Id;
                    newpostDTO.Title = post.Title;
                    newpostDTO.Body = post.Body;
                    DTOposts.Add(newpostDTO);
                }


                return DTOposts;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }


        public PostDTO GetPost(int postId)
        {
            try
            {
                //-----------------------------Получаем пост по идентификатору---------------------------------------
                Post post = new Post();
                post.GetPost(postId);
                PostDTO postDTO = new PostDTO();
                postDTO.Id = post.Id;
                postDTO.Title = post.Title;
                postDTO.Body = post.Body;



                return postDTO;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }
    }
}
