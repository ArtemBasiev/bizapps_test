using System;
using System.Collections.Generic;
using bizapps_test.DAL.Entities;
using bizapps_test.BLL.Infrastructure;
using bizapps_test.BLL.Interfaces;
using bizapps_test.BLL.DTO;
using System.Data.SqlClient;
using bizapps_test.DAL.Interfaces;

namespace bizapps_test.BLL.Services
{
    public class PostService: IPostService
    {
        //[Ninject.Inject]
        public ICategoryRepository categoryRepository { get; private set; }
        public IPostRepository postRepository { get; private set; }

        public PostService(IPostRepository postrepository, ICategoryRepository categoryrepository)
        {
            categoryRepository = categoryrepository;
            postRepository = postrepository;
        }
   

        public int CreatePost(PostDTO postDTO, int userId, List<CategoryDTO> categoryListDTO)
        {
            //----------------------------------------Добавляем новый пост--------------------------------
            try
            {
                if (categoryListDTO.Count==0)
                {
                    throw new ApplicationException("Пост должен принадлежать хотя бы к одной из категорий");
                }

                
                 int newpostId = postRepository.CreatePost(new Post(postDTO.Title, postDTO.Body), userId);

                foreach (CategoryDTO categoryDTO in categoryListDTO)
                {
                   
                    postRepository.AddCategoryToPost(categoryDTO.Id, newpostId);
                }
                return newpostId;
              
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }


        }

        public int UpdatePost(PostDTO postDTO, List<CategoryDTO> categoryListDTO)
        {
            //----------------------------------------Обновляем существующий пост--------------------------------
            try
            {

                int updpostid = postRepository.UpdatePost(new Post(postDTO.Id, postDTO.Title, postDTO.Body));
                IEnumerable<Category> postCategories = categoryRepository.GetPostCategories(updpostid);
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
                        postRepository.DeleteCategoryFromPost(postCat.Id, updpostid);
                    }

                }

                foreach (CategoryDTO catDTO in categoryListDTO)
                {

                    postRepository.AddCategoryToPost(catDTO.Id, updpostid);
                }
                return updpostid;
                    
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }


        public int DeletePost(PostDTO postDTO)
        {
            //----------------------------------------Удаляем пост, а так-же все связанные с ним сущности--------------------------------
            try
            {
              return  postRepository.DeletePost(new Post(postDTO.Id));
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }


        }

        public IEnumerable<PostDTO> GetUserPosts(int userId)
        {
            try
            {
                //-----------------------------Получаем список всех постов пользователя---------------------------------------
                IEnumerable<Post> posts = postRepository.GetUserPosts(userId);
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
                Post post = postRepository.GetPostById(postId);

                PostDTO postDTO = new PostDTO
                {
                    Id =post.Id,
                    Title = post.Title,
                    Body =post.Body
                };

                return postDTO;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }
    }
}
