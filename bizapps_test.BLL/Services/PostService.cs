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
        public ICategoryRepository CategoryRepository { get; private set; }
        public IPostRepository PostRepository { get; private set; }

        public PostService(IPostRepository postRepository, ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
            PostRepository = postRepository;
        }
   

        public int CreatePost(PostDto postDto, int userId, List<CategoryDto> categoryListDto)
        {
            //----------------------------------------Добавляем новый пост--------------------------------
            try
            {
                if (categoryListDto.Count==0)
                {
                    throw new ApplicationException("Пост должен принадлежать хотя бы к одной из категорий");
                }

                
                 int newpostId = PostRepository.CreatePost(new Post(postDto.Title, postDto.Body), userId);

                foreach (CategoryDto categoryDto in categoryListDto)
                {
                   
                    PostRepository.AddCategoryToPost(categoryDto.Id, newpostId);
                }
                return newpostId;
              
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }


        }

        public int UpdatePost(PostDto postDto, List<CategoryDto> categoryListDto)
        {
            //----------------------------------------Обновляем существующий пост--------------------------------
            try
            {

                int updpostId = PostRepository.UpdatePost(new Post(postDto.Id, postDto.Title, postDto.Body));
                IEnumerable<Category> postCategories = CategoryRepository.GetPostCategories(updpostId);
                int isIdentic;
                foreach(Category postCat in postCategories)
                {
                    isIdentic = 0;
                    foreach (CategoryDto catDto in categoryListDto)
                    { 
                        if (catDto.Id==postCat.Id)
                        {
                            isIdentic = 1;
                        }
                        else { }
                    }

                    if (isIdentic == 0)
                    {
                        PostRepository.DeleteCategoryFromPost(postCat.Id, updpostId);
                    }

                }

                foreach (CategoryDto catDto in categoryListDto)
                {

                    PostRepository.AddCategoryToPost(catDto.Id, updpostId);
                }
                return updpostId;
                    
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }


        public int DeletePost(PostDto postDto)
        {
            //----------------------------------------Удаляем пост, а так-же все связанные с ним сущности--------------------------------
            try
            {
              return  PostRepository.DeletePost(new Post(postDto.Id));
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }


        }

        public IEnumerable<PostDto> GetUserPosts(int userId)
        {
            try
            {
                //-----------------------------Получаем список всех постов пользователя---------------------------------------
                IEnumerable<Post> posts = PostRepository.GetUserPosts(userId);
                List<PostDto> dtoPosts = new List<PostDto>();
                foreach (Post post in posts)
                {
                    PostDto newpostDto = new PostDto();
                    newpostDto.Id = post.Id;
                    newpostDto.Title = post.Title;
                    newpostDto.Body = post.Body;
                    newpostDto.CreationDate = post.CreationDate;
                    dtoPosts.Add(newpostDto);
                }


                return dtoPosts;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }

        public IEnumerable<PostDto> GetUserPostsByUserName(string userName)
        {
            try
            {
                //-----------------------------Получаем список всех постов пользователя---------------------------------------
                IEnumerable<Post> posts = PostRepository.GetUserPostsByUserName(userName);
                List<PostDto> dtoPosts = new List<PostDto>();
                foreach (Post post in posts)
                {
                    PostDto newpostDto = new PostDto();
                    newpostDto.Id = post.Id;
                    newpostDto.Title = post.Title;
                    newpostDto.Body = post.Body;
                    newpostDto.CreationDate = post.CreationDate;
                    dtoPosts.Add(newpostDto);
                }


                return dtoPosts;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
        }


        public IEnumerable<PostDto> GetPostsByUserNameWithoutCategory(string userName)
        {
            try
            {
                //-----------------------------Получаем список всех постов пользователя---------------------------------------
                IEnumerable<Post> posts = PostRepository.GetPostsByUserNameWithoutCategory(userName);
                List<PostDto> dtoPosts = new List<PostDto>();
                foreach (Post post in posts)
                {
                    PostDto newpostDto = new PostDto();
                    newpostDto.Id = post.Id;
                    newpostDto.Title = post.Title;
                    newpostDto.Body = post.Body;
                    newpostDto.CreationDate = post.CreationDate;
                    dtoPosts.Add(newpostDto);
                }


                return dtoPosts;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public  IEnumerable<PostDto> GetPostsByUserNameAndCategory(string userName, int categoryId)
        {
            try
            {
                //-----------------------------Получаем список всех постов пользователя---------------------------------------
                IEnumerable<Post> posts = PostRepository.GetPostsByUserNameAndCategory(userName, categoryId);
                List<PostDto> dtoPosts = new List<PostDto>();
                foreach (Post post in posts)
                {
                    PostDto newpostDto = new PostDto();
                    newpostDto.Id = post.Id;
                    newpostDto.Title = post.Title;
                    newpostDto.Body = post.Body;
                    newpostDto.CreationDate = post.CreationDate;
                    dtoPosts.Add(newpostDto);
                }


                return dtoPosts;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
        }


        public PostDto GetPost(int postId)
        {
            try
            {
                //-----------------------------Получаем пост по идентификатору---------------------------------------
                Post post = PostRepository.GetPostById(postId);

                PostDto postDto = new PostDto
                {
                    Id =post.Id,
                    Title = post.Title,
                    Body =post.Body,
                    CreationDate = post.CreationDate
                };

                return postDto;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }
    }
}
