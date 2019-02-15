using System;
using System.Collections.Generic;
using bizapps_test.DAL.Entities;
using bizapps_test.BLL.Infrastructure;
using bizapps_test.BLL.Interfaces;
using bizapps_test.BLL.DTO;
using AutoMapper;
using Ninject;
using System.Data.SqlClient;
using bizapps_test.DAL.Interfaces;

namespace bizapps_test.BLL.Services
{
   public class BlogUserService: IBlogUserService
    {
       [Ninject.Inject]
       public IBlogUserRepository BloguserRepository { get; private set; }

       public BlogUserService(IBlogUserRepository bloguserRepository)
       {
           BloguserRepository = bloguserRepository;
       }

       public int CreateBlogUser(BlogUserDto bloguserDto)
        {
            //----------------------------------------Добавляем нового пользователя--------------------------------
            try
            {

              return  BloguserRepository.CreateBlogUser(new BlogUser(bloguserDto.UserName, bloguserDto.UserPassword, bloguserDto.BlogName));

            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }


        }

       public int UpdateBlogUser(BlogUserDto bloguserDTO)
        {
            //----------------------------------------Обновляем существующего пользователя--------------------------------
            try
            {
              return  BloguserRepository.UpdateBlogUser(new BlogUser(bloguserDTO.Id, bloguserDTO.UserName, bloguserDTO.UserPassword,  bloguserDTO.BlogName));
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }


       public int DeleteBlogUser(BlogUserDto bloguserDto)
        {
            //----------------------------------------Удаляем пользователя, а так-же все связанные с ним сущности--------------------------------
            try
            {
               return BloguserRepository.DeleteBlogUser(new BlogUser(bloguserDto.Id));
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }


        }

       public IEnumerable<BlogUserDto> GetAllUsers()
        {
            try
            {
                //-----------------------------Получаем список всех пользователей---------------------------------------
                IEnumerable<BlogUser> users = BloguserRepository.GetAllBlogUsers();
                List<BlogUserDto> userDtos = new List<BlogUserDto>();
                foreach (BlogUser bu in users)
                {
                    BlogUserDto newbuDto = new BlogUserDto();
                    newbuDto.Id = bu.Id;
                    newbuDto.UserName = bu.UserName;
                    userDtos.Add(newbuDto);
                }


                return userDtos;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }


       public BlogUserDto GetBlogUserById(int userId)
        {
            try
            {
                //-----------------------------Получаем пользователя---------------------------------------
                BlogUser user = BloguserRepository.GetBlogUserById(userId);
                
                BlogUserDto newbuDto = new BlogUserDto();
                newbuDto.Id = user.Id;
                newbuDto.UserName = user.UserName;
                newbuDto.UserPassword = user.UserPassword;
                newbuDto.BlogName = user.BlogName;

                return newbuDto;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }

       public BlogUserDto GetBlogUserNameAndPassword(BlogUserDto incomingUser)
        {
            try
            {
                //-----------------------------Получаем пользователя---------------------------------------
                BlogUser user = BloguserRepository.GetBlogUserByNameAndPassword(incomingUser.UserName, incomingUser.UserPassword);

                BlogUserDto newbuDto = new BlogUserDto();
                newbuDto.UserName = user.UserName;

                return newbuDto;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public int GetAdminPermission(string userName)
        {
            try
            {
                //-----------------------------Получаем пользователя---------------------------------------
                int userId = BloguserRepository.GetAdminPermission(userName);

                return userId;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

        }
    }
}
