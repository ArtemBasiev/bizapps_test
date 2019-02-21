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
        public PostDto PostDto { get; set; }
        public Mock<ICategoryRepository> CategoryRepository { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            PostDto = new PostDto();
            CategoryRepository = new Mock<ICategoryRepository>();
        }

        [TestMethod]
        public void CreatePost_WhenAddNewPost_Working()
        {
            int expectedPostId = 1;
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
            postRepository.Setup(id => id.CreatePost(It.IsAny<Post>(), It.IsAny<int>())).Returns(expectedPostId);

            PostService postService = new PostService(postRepository.Object, CategoryRepository.Object);
            int resultPostId = postService.CreatePost(PostDto, 2, new List<CategoryDto> {new CategoryDto()});

            Assert.AreEqual(expectedPostId, resultPostId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CreatePost_WhenAddNewPost_CatchException()
        {
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>(MockBehavior.Strict);
            postRepository.Setup(id => id.CreatePost(It.IsAny<Post>(), It.IsAny<int>())).Throws(new ApplicationException());

            PostService postService = new PostService(postRepository.Object, CategoryRepository.Object);
            postService.CreatePost(PostDto, 2, new List<CategoryDto> { new CategoryDto() });
        }


        [TestMethod]
        public void UpdatePost_WhenUpdatePost_Working()
        {
            int expectedPostId = 1;
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
            postRepository.Setup(id => id.UpdatePost(It.IsAny<Post>())).Returns(expectedPostId);

            PostService postService = new PostService(postRepository.Object, CategoryRepository.Object);
            int resultPostId = postService.UpdatePost(PostDto, new List<CategoryDto> { new CategoryDto() });

            Assert.AreEqual(expectedPostId, resultPostId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdatePost_WhenUpdatePost_CatchException()
        {
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>(MockBehavior.Strict);
            postRepository.Setup(id => id.UpdatePost(It.IsAny<Post>())).Throws(new ApplicationException());

            PostService postService = new PostService(postRepository.Object, CategoryRepository.Object);
            postService.UpdatePost(PostDto, new List<CategoryDto> { new CategoryDto() });
        }


        [TestMethod]
        public void DeletePost_WhenDeletePost_Working()
        {
            int expectedPostId = 1;
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
            postRepository.Setup(id => id.DeletePost(It.IsAny<Post>())).Returns(expectedPostId);

            PostService postService = new PostService(postRepository.Object, CategoryRepository.Object);
            int resultPostId = postService.DeletePost(PostDto);

            Assert.AreEqual(expectedPostId, resultPostId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void DeletePost_WhenDeletePost_CatchException()
        {
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>(MockBehavior.Strict);
            postRepository.Setup(id => id.DeletePost(It.IsAny<Post>())).Throws(new ApplicationException());

            PostService postService = new PostService(postRepository.Object, CategoryRepository.Object);
            postService.DeletePost(PostDto);
        }


        [TestMethod]
        public void GetPost_WhenGetPost_Working()
        {
            int expectedPostId = 1;
            IPostRepository postRepository = Mock.Of<IPostRepository>(post => post.GetPostById(It.IsAny<int>()) == new Post(expectedPostId));

            PostService postService = new PostService(postRepository, CategoryRepository.Object);
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

            PostService postService = new PostService(postRepository.Object, CategoryRepository.Object);
            postService.GetPost(TestingId);
        }

        [TestMethod]
        public void GetUserPosts_WhenGetPosts_Working()
        {
            int expectedPostId = 1;
            IPostRepository postRepository = Mock.Of<IPostRepository>(posts => posts.GetUserPosts(It.IsAny<int>()) == new List<Post> { new Post(expectedPostId) });

            PostService postService = new PostService(postRepository, CategoryRepository.Object);
            List<PostDto> gettedPosts = (List<PostDto>)postService.GetUserPosts(2);
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

            PostService postService = new PostService(postRepository.Object, CategoryRepository.Object);
            postService.GetUserPosts(TestingId);
        }





    }
}
