using System;
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
    public class PostServiceTests
    {
        public PostDTO postDTO { get; set; }
        public Mock<ICategoryRepository> categoryRepository { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            postDTO = new PostDTO();
            categoryRepository = new Mock<ICategoryRepository>();
        }

        [TestMethod]
        public void CreatePost_WhenAddNewPost_Working()
        {
            int expectedPostId = 1;
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
            postRepository.Setup(Id => Id.CreatePost(It.IsAny<Post>(), It.IsAny<int>())).Returns(expectedPostId);

            PostService postService = new PostService(postRepository.Object, categoryRepository.Object);
            int resultPostId = postService.CreatePost(postDTO, 2, new List<CategoryDTO> {new CategoryDTO()});

            Assert.AreEqual(expectedPostId, resultPostId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CreatePost_WhenAddNewPost_CatchException()
        {
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>(MockBehavior.Strict);
            postRepository.Setup(Id => Id.CreatePost(It.IsAny<Post>(), It.IsAny<int>())).Throws(new ApplicationException());

            PostService postService = new PostService(postRepository.Object, categoryRepository.Object);
            postService.CreatePost(postDTO, 2, new List<CategoryDTO> { new CategoryDTO() });
        }


        [TestMethod]
        public void UpdatePost_WhenUpdatePost_Working()
        {
            int expectedPostId = 1;
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
            postRepository.Setup(Id => Id.UpdatePost(It.IsAny<Post>())).Returns(expectedPostId);

            PostService postService = new PostService(postRepository.Object, categoryRepository.Object);
            int resultPostId = postService.UpdatePost(postDTO, new List<CategoryDTO> { new CategoryDTO() });

            Assert.AreEqual(expectedPostId, resultPostId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdatePost_WhenUpdatePost_CatchException()
        {
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>(MockBehavior.Strict);
            postRepository.Setup(Id => Id.UpdatePost(It.IsAny<Post>())).Throws(new ApplicationException());

            PostService postService = new PostService(postRepository.Object, categoryRepository.Object);
            postService.UpdatePost(postDTO, new List<CategoryDTO> { new CategoryDTO() });
        }


        [TestMethod]
        public void DeletePost_WhenDeletePost_Working()
        {
            int expectedPostId = 1;
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
            postRepository.Setup(Id => Id.DeletePost(It.IsAny<Post>())).Returns(expectedPostId);

            PostService postService = new PostService(postRepository.Object, categoryRepository.Object);
            int resultPostId = postService.DeletePost(postDTO);

            Assert.AreEqual(expectedPostId, resultPostId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void DeletePost_WhenDeletePost_CatchException()
        {
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>(MockBehavior.Strict);
            postRepository.Setup(Id => Id.DeletePost(It.IsAny<Post>())).Throws(new ApplicationException());

            PostService postService = new PostService(postRepository.Object, categoryRepository.Object);
            postService.DeletePost(postDTO);
        }


        [TestMethod]
        public void GetPost_WhenGetPost_Working()
        {
            int expectedPostId = 1;
            IPostRepository postRepository = Mock.Of<IPostRepository>(post => post.GetPostById(It.IsAny<int>()) == new Post(expectedPostId));

            PostService postService = new PostService(postRepository, categoryRepository.Object);
            int resultPostId = postService.GetPost(expectedPostId).Id;

            Assert.AreEqual(expectedPostId, resultPostId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetPost_WhenGetPost_CatchException()
        {
            int TestingId = 0;
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>(MockBehavior.Strict);
            postRepository.Setup(post => post.GetPostById(It.IsAny<int>())).Throws(new ApplicationException());

            PostService postService = new PostService(postRepository.Object, categoryRepository.Object);
            postService.GetPost(TestingId);
        }

        [TestMethod]
        public void GetUserPosts_WhenGetPosts_Working()
        {
            int expectedPostId = 1;
            IPostRepository postRepository = Mock.Of<IPostRepository>(posts => posts.GetUserPosts(It.IsAny<int>()) == new List<Post> { new Post(expectedPostId) });

            PostService postService = new PostService(postRepository, categoryRepository.Object);
            List<PostDTO> gettedPosts = (List<PostDTO>)postService.GetUserPosts(2);
            int resultPostId = gettedPosts[0].Id;

            Assert.AreEqual(expectedPostId, resultPostId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetUserPosts_WhenGetPosts_CatchException()
        {
            int TestingId = 0;
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>(MockBehavior.Strict);
            postRepository.Setup(post => post.GetUserPosts(It.IsAny<int>())).Throws(new ApplicationException());

            PostService postService = new PostService(postRepository.Object, categoryRepository.Object);
            postService.GetUserPosts(TestingId);
        }





    }
}
