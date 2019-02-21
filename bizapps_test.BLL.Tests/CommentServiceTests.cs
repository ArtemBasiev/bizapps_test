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
    /// <summary>
    /// Summary description for CommentServiceTests
    /// </summary>
    [TestClass]
    public class CommentServiceTests
    {
        public CommentDto CommentDto { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            CommentDto = new CommentDto();
        }

        [TestMethod]
        public void CreateComment_WhenAddNewComment_Working()
        {
            int expectedCommentId = 1;
            ICommentRepository commentRepository = Mock.Of<ICommentRepository>(id => id.CreateComment(It.IsAny<Comment>(), It.IsAny<int>()) == expectedCommentId);

            CommentService commentService = new CommentService(commentRepository);
            int resultCommentId = commentService.CreateComment(CommentDto, It.IsAny<int>());

            Assert.AreEqual(expectedCommentId, resultCommentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CreateComment_WhenAddNewComment_CatchException()
        {
            Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>(MockBehavior.Strict);
            commentRepository.Setup(id => id.CreateComment(It.IsAny<Comment>(), It.IsAny<int>())).Throws(new ApplicationException());

            CommentService commentService = new CommentService(commentRepository.Object);
            commentService.CreateComment(CommentDto, It.IsAny<int>());
        }

        [TestMethod]
        public void UpdateComment_WhenUpdateComment_Working()
        {
            int expectedCommentId = 1;
            ICommentRepository commentRepository = Mock.Of<ICommentRepository>(id => id.UpdateComment(It.IsAny<Comment>()) == expectedCommentId);

            CommentService commentService = new CommentService(commentRepository);
            int resultCommentId = commentService.UpdateComment(CommentDto);

            Assert.AreEqual(expectedCommentId, resultCommentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateComment_WhenUpdateComment_CatchException()
        {
            Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>(MockBehavior.Strict);
            commentRepository.Setup(id => id.UpdateComment(It.IsAny<Comment>())).Throws(new ApplicationException());

            CommentService commentService = new CommentService(commentRepository.Object);
            commentService.UpdateComment(CommentDto);
        }



        [TestMethod]
        public void DeleteComment_WhenDeleteComment_Working()
        {
            int expectedCommentId = 1;
            ICommentRepository commentRepository = Mock.Of<ICommentRepository>(id => id.DeleteComment(It.IsAny<Comment>()) == expectedCommentId);

            CommentService commentService = new CommentService(commentRepository);
            int resultCommentId = commentService.DeleteComment(CommentDto);

            Assert.AreEqual(expectedCommentId, resultCommentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void DeleteComment_WhenDeleteComment_CatchException()
        {
            Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>(MockBehavior.Strict);
            commentRepository.Setup(id => id.DeleteComment(It.IsAny<Comment>())).Throws(new ApplicationException());

            CommentService commentService = new CommentService(commentRepository.Object);
            commentService.DeleteComment(CommentDto);
        }


        [TestMethod]
        public void GetComment_WhenGetComment_Working()
        {
            int expectedCommentId = 1;
            ICommentRepository commentRepository = Mock.Of<ICommentRepository>(comments => comments.GetComment(It.IsAny<int>()) == new Comment(expectedCommentId) );

            CommentService commentService = new CommentService(commentRepository);
            CommentDto gettedComment = commentService.GetComment(It.IsAny<int>());
            int resultCommentId = gettedComment.Id;

            Assert.AreEqual(expectedCommentId, resultCommentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetComment_WhenGetComment_CatchException()
        {
            Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>(MockBehavior.Strict);
            commentRepository.Setup(comments => comments.GetComment(It.IsAny<int>())).Throws(new ApplicationException());

            CommentService commentService = new CommentService(commentRepository.Object);
            commentService.GetComment(It.IsAny<int>());
        }

        [TestMethod]
        public void GetIndependentComments_WhenGetComments_Working()
        {
            int expectedCommentId = 1;
            ICommentRepository commentRepository = Mock.Of<ICommentRepository>(comments => comments.GetIndependentComments(It.IsAny<int>()) == new List<Comment> { new Comment(expectedCommentId) });

            CommentService commentService = new CommentService(commentRepository);
            List<CommentDto> gettedComments = (List<CommentDto>)commentService.GetIndependentComments(It.IsAny<int>());
            int resultCommentId = gettedComments[0].Id;

            Assert.AreEqual(expectedCommentId, resultCommentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetIndependentComments_WhenGetComments_CatchException()
        {
            Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>(MockBehavior.Strict);
            commentRepository.Setup(comments => comments.GetIndependentComments(It.IsAny<int>())).Throws(new ApplicationException());

            CommentService commentService = new CommentService(commentRepository.Object);
            commentService.GetIndependentComments(It.IsAny<int>());
        }

        [TestMethod]
        public void GetCommentAnswers_WhenGetAnswers_Working()
        {
            int expectedCommentId = 1;
            ICommentRepository commentRepository = Mock.Of<ICommentRepository>(comments => comments.GetCommentAnswers(It.IsAny<int>()) == new List<Comment> { new Comment(expectedCommentId) });

            CommentService commentService = new CommentService(commentRepository);
            List<CommentDto> gettedComments = (List<CommentDto>)commentService.GetCommentAnswers(It.IsAny<int>());
            int resultCommentId = gettedComments[0].Id;

            Assert.AreEqual(expectedCommentId, resultCommentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetCommentAnswers_WhenGetAnswers_CatchException()
        {
            Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>(MockBehavior.Strict);
            commentRepository.Setup(comments => comments.GetCommentAnswers(It.IsAny<int>())).Throws(new ApplicationException());

            CommentService commentService = new CommentService(commentRepository.Object);
            commentService.GetCommentAnswers(It.IsAny<int>());
        }
    }
}
