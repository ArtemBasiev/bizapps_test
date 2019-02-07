﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bizapps_test.BLL.Services;
using bizapps_test.DAL.Interfaces;
using bizapps_test.DAL.Entities;
using bizapps_test.BLL.DTO;
using Moq;

namespace bizapps_test.BLL.Tests
{
    [TestClass]
    public class BlogUserServiceTests
    {
        public BlogUserDto bloguserDTO { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            bloguserDTO = new BlogUserDto();
        }

        [TestMethod]
        public void CreateBlogUser_WhenAddNewUser_Working()
        {
            int expectedUserId = 1;
            IBlogUserRepository bloguserRepository = Mock.Of<IBlogUserRepository>(Id => Id.CreateBlogUser(It.IsAny<BlogUser>()) == expectedUserId);

            BlogUserService bloguserService = new BlogUserService(bloguserRepository);
            int resultUserId = bloguserService.CreateBlogUser(bloguserDTO);

            Assert.AreEqual(expectedUserId, resultUserId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CreateBlogUser_WhenAddNewUser_CatchException()
        {
            Mock<IBlogUserRepository> bloguserRepository = new Mock<IBlogUserRepository>(MockBehavior.Strict);
            bloguserRepository.Setup(Id => Id.CreateBlogUser(It.IsAny<BlogUser>())).Throws(new ApplicationException());

            BlogUserService bloguserService = new BlogUserService(bloguserRepository.Object);
            bloguserService.CreateBlogUser(bloguserDTO);
        }


        [TestMethod]
        public void UpdateBlogUser_WhenUpdateUser_Working()
        {
            int expectedUserId = 1;
            IBlogUserRepository bloguserRepository = Mock.Of<IBlogUserRepository>(Id => Id.UpdateBlogUser(It.IsAny<BlogUser>()) == expectedUserId);

            BlogUserService bloguserService = new BlogUserService(bloguserRepository);
            int resultUserId = bloguserService.UpdateBlogUser(bloguserDTO);

            Assert.AreEqual(expectedUserId, resultUserId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateBlogUser_WhenUpdateUser_CatchException()
        {
            Mock<IBlogUserRepository> bloguserRepository = new Mock<IBlogUserRepository>(MockBehavior.Strict);
            bloguserRepository.Setup(Id => Id.UpdateBlogUser(It.IsAny<BlogUser>())).Throws(new ApplicationException());

            BlogUserService bloguserService = new BlogUserService(bloguserRepository.Object);
            bloguserService.UpdateBlogUser(bloguserDTO);
        }


        [TestMethod]
        public void DeleteBlogUser_WhenDeleteUser_Working()
        {
            int expectedUserId = 1;
            IBlogUserRepository bloguserRepository = Mock.Of<IBlogUserRepository>(Id => Id.DeleteBlogUser(It.IsAny<BlogUser>()) == expectedUserId);

            BlogUserService bloguserService = new BlogUserService(bloguserRepository);
            int resultUserId = bloguserService.DeleteBlogUser(bloguserDTO);

            Assert.AreEqual(expectedUserId, resultUserId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void DeleteBlogUser_WhenDeleteUser_CatchException()
        {
            Mock<IBlogUserRepository> bloguserRepository = new Mock<IBlogUserRepository>(MockBehavior.Strict);
            bloguserRepository.Setup(Id => Id.DeleteBlogUser(It.IsAny<BlogUser>())).Throws(new ApplicationException());

            BlogUserService bloguserService = new BlogUserService(bloguserRepository.Object);
            bloguserService.DeleteBlogUser(bloguserDTO);
        }


        [TestMethod]
        public void GetBlogUserById_WhenGetUser_Working()
        {
            int expectedUserId = 1;
            IBlogUserRepository bloguserRepository = Mock.Of<IBlogUserRepository>(bloguser => bloguser.GetBlogUserById(It.IsAny<int>()) == new BlogUser(expectedUserId));

            BlogUserService bloguserService = new BlogUserService(bloguserRepository);
            int resultUserId = bloguserService.GetBlogUserById(expectedUserId).Id;

            Assert.AreEqual(expectedUserId, resultUserId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetBlogUserById_WhenGetUser_CatchException()
        {
            int TestingId = 0;
            Mock<IBlogUserRepository> bloguserRepository = new Mock<IBlogUserRepository>(MockBehavior.Strict);
            bloguserRepository.Setup(user => user.GetBlogUserById(It.IsAny<int>())).Throws(new ApplicationException());

            BlogUserService bloguserService = new BlogUserService(bloguserRepository.Object);
            bloguserService.GetBlogUserById(TestingId);
        }

        [TestMethod]
        public void GetAllUsers_WhenGetUsers_Working()
        {
            int expectedUserId = 1;
            IBlogUserRepository bloguserRepository = Mock.Of<IBlogUserRepository>(blogusers => blogusers.GetAllBlogUsers() == new List<BlogUser> { new BlogUser(expectedUserId) });

            BlogUserService bloguserService = new BlogUserService(bloguserRepository);
            List<BlogUserDto> gettedBlogUsers = (List<BlogUserDto>)bloguserService.GetAllUsers();
            int  resultUserId = gettedBlogUsers[0].Id;

            Assert.AreEqual(expectedUserId, resultUserId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetAllUsers_WhenGetUsers_CatchException()
        {
            Mock<IBlogUserRepository> bloguserRepository = new Mock<IBlogUserRepository>(MockBehavior.Strict);
            bloguserRepository.Setup(user => user.GetAllBlogUsers()).Throws(new ApplicationException());

            BlogUserService bloguserService = new BlogUserService(bloguserRepository.Object);
            bloguserService.GetAllUsers();
        }
    }
}