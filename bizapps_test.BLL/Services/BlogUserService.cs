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
       public IBlogUserRepository bloguserRepository { get; private set; }

       public BlogUserService(IBlogUserRepository bloguserrepository)
       {
           bloguserRepository = bloguserrepository;
       }

       public int CreateBlogUser(BlogUserDTO bloguserDTO)
        {
            //----------------------------------------Добавляем нового пользователя--------------------------------
            try
            {

              return  bloguserRepository.CreateBlogUser(new BlogUser(bloguserDTO.UserName, bloguserDTO.UserPassword, bloguserDTO.BlogName));

            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }


        }

       public int UpdateBlogUser(BlogUserDTO bloguserDTO)
        {
            //----------------------------------------Обновляем существующего пользователя--------------------------------
            try
            {
              return  bloguserRepository.UpdateBlogUser(new BlogUser(bloguserDTO.Id, bloguserDTO.UserName, bloguserDTO.UserPassword,  bloguserDTO.BlogName));
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }


       public int DeleteBlogUser(BlogUserDTO bloguserDTO)
        {
            //----------------------------------------Удаляем пользователя, а так-же все связанные с ним сущности--------------------------------
            try
            {
               return bloguserRepository.DeleteBlogUser(new BlogUser(bloguserDTO.Id));
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }


        }

       public IEnumerable<BlogUserDTO> GetAllUsers()
        {
            try
            {
                //-----------------------------Получаем список всех пользователей---------------------------------------
                IEnumerable<BlogUser> users = bloguserRepository.GetAllBlogUsers();
                List<BlogUserDTO> DTOusers = new List<BlogUserDTO>();
                foreach (BlogUser bu in users)
                {
                    BlogUserDTO newbuDTO = new BlogUserDTO();
                    newbuDTO.Id = bu.Id;
                    newbuDTO.UserName = bu.UserName;
                    DTOusers.Add(newbuDTO);
                }


                return DTOusers;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }


       public BlogUserDTO GetBlogUserById(int userId)
        {
            try
            {
                //-----------------------------Получаем пользователя---------------------------------------
                BlogUser user = bloguserRepository.GetBlogUserById(userId);
                
                BlogUserDTO newbuDTO = new BlogUserDTO();
                newbuDTO.Id = user.Id;
                newbuDTO.UserName = user.UserName;
                newbuDTO.UserPassword = user.UserPassword;
                newbuDTO.BlogName = user.BlogName;

                return newbuDTO;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }
    }
}
