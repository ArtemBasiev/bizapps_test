using System;
using System.Collections.Generic;
using bizapps_test.DAL.Entities;
using bizapps_test.BLL.Infrastructure;
using bizapps_test.BLL.Interfaces;
using bizapps_test.BLL.DTO;
using AutoMapper;
using Ninject;
using System.Data.SqlClient;

namespace bizapps_test.BLL.Services
{
   public class BlogUserService: IBlogUserService
    {

       public void CreateBlogUser(BlogUserDTO bloguserDTO)
        {
            //----------------------------------------Добавляем нового пользователя--------------------------------
            try
            {
                BlogUser bloguser = new BlogUser(bloguserDTO.UserName, bloguserDTO.UserPassword, bloguserDTO.BlogName);
                bloguser.InsertBlogUser();
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }


        }

       public void UpdateBlogUser(BlogUserDTO bloguserDTO)
        {
            //----------------------------------------Обновляем существующего пользователя--------------------------------
            try
            {
                BlogUser bloguser = new BlogUser(bloguserDTO.Id, bloguserDTO.UserName, bloguserDTO.UserPassword,  bloguserDTO.BlogName);
                bloguser.UpdateBlogUser();
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message);
            }

        }


       public void DeleteBlogUser(BlogUserDTO bloguserDTO)
        {
            //----------------------------------------Удаляем пользователя, а так-же все связанные с ним сущности--------------------------------
            try
            {
                BlogUser bloguser = new BlogUser(bloguserDTO.Id);
                bloguser.DeleteBlogUser();
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
                IEnumerable<BlogUser> users = new BlogUser().GetAllUsers();
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


       public BlogUserDTO GetBlogUser(int userId)
        {
            try
            {
                //-----------------------------Получаем пользователя---------------------------------------
                BlogUser user = new BlogUser();
                user.GetBlogUser(userId);
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
