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
    public class CategoryServiceTests
    {
        public CategoryDto CategoryDto { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            CategoryDto = new CategoryDto();
        }

        [TestMethod]
        public void CreateCategory_WhenAddNewCategory_Working()
        {
            int expectedCategoryId = 1;
            ICategoryRepository categoryRepository = Mock.Of<ICategoryRepository>(id => id.CreateCategory(It.IsAny<Category>()) == expectedCategoryId);

            CategoryService categoryService = new CategoryService(categoryRepository);
            int resultCategoryId =  categoryService.CreateCategory(CategoryDto);

            Assert.AreEqual(expectedCategoryId, resultCategoryId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CreateCategory_WhenAddNewCategory_CatchException()
        {
            Mock<ICategoryRepository> categoryRepository = new Mock<ICategoryRepository>(MockBehavior.Strict);
            categoryRepository.Setup(id => id.CreateCategory(It.IsAny<Category>())).Throws(new ApplicationException());

            CategoryService categoryService = new CategoryService(categoryRepository.Object);
            categoryService.CreateCategory(CategoryDto);
        }


        [TestMethod]
        public void UpdateCategory_WhenUpdateCategory_Working()
        {
            int expectedCategoryId = 1;
            ICategoryRepository categoryRepository = Mock.Of<ICategoryRepository>(id => id.UpdateCategory(It.IsAny<Category>()) == expectedCategoryId);

            CategoryService categoryService = new CategoryService(categoryRepository);
            int resultCategoryId = categoryService.UpdateCategory(CategoryDto);

            Assert.AreEqual(expectedCategoryId, resultCategoryId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateCategory_WhenUpdateCategory_CatchException()
        {
            Mock<ICategoryRepository> categoryRepository = new Mock<ICategoryRepository>(MockBehavior.Strict);
            categoryRepository.Setup(id => id.UpdateCategory(It.IsAny<Category>())).Throws(new ApplicationException());

            CategoryService categoryService = new CategoryService(categoryRepository.Object);
           categoryService.UpdateCategory(CategoryDto);
        }


        [TestMethod]
        public void DeleteCategory_WhenDeleteCategory_Working()
        {
            int expectedCategoryId = 1;
            ICategoryRepository categoryRepository = Mock.Of<ICategoryRepository>(id => id.DeleteCategory(It.IsAny<Category>()) == expectedCategoryId);

            CategoryService categoryService = new CategoryService(categoryRepository);
            int resultCategoryId = categoryService.DeleteCategory(CategoryDto);

            Assert.AreEqual(expectedCategoryId, resultCategoryId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void DeleteCategory_WhenDeleteCategory_CatchException()
        {
            Mock<ICategoryRepository> categoryRepository = new Mock<ICategoryRepository>(MockBehavior.Strict);
            categoryRepository.Setup(id => id.DeleteCategory(It.IsAny<Category>())).Throws(new ApplicationException());

            CategoryService categoryService = new CategoryService(categoryRepository.Object);
            categoryService.DeleteCategory(CategoryDto);
        }


        [TestMethod]
        public void GetCategoryById_WhenGetCategory_Working()
        {
            int expectedCategoryId = 1;
            ICategoryRepository categoryRepository = Mock.Of<ICategoryRepository>(category => category.GetCategoryById(It.IsAny<int>()) == new Category(expectedCategoryId));

            CategoryService categoryService = new CategoryService(categoryRepository);
            int resultCategoryId = categoryService.GetCategoryById(expectedCategoryId).Id;

            Assert.AreEqual(expectedCategoryId, resultCategoryId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetCategoryById_WhenGetCategory_CatchException()
        {
            int TestingId = 0;
            Mock<ICategoryRepository> categoryRepository = new Mock<ICategoryRepository>(MockBehavior.Strict);
            categoryRepository.Setup(category => category.GetCategoryById(It.IsAny<int>())).Throws(new ApplicationException());

            CategoryService categoryService = new CategoryService(categoryRepository.Object);
            categoryService.GetCategoryById(TestingId);
        }

        [TestMethod]
        public void GetAllCategories_WhenGetCategories_Working()
        {
            int expectedCategoryId = 1;
            ICategoryRepository categoryRepository = Mock.Of<ICategoryRepository>(categories => categories.GetAllCategories() == new List<Category>{new Category(expectedCategoryId)});

            CategoryService categoryService = new CategoryService(categoryRepository);
            List<CategoryDto> gettedCategories = (List<CategoryDto>)categoryService.GetAllCategories();
            int resultCategoryId = gettedCategories[0].Id;

            Assert.AreEqual(expectedCategoryId, resultCategoryId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetAllCategories_WhenGetCategories_CatchException()
        {
            Mock<ICategoryRepository> categoryRepository = new Mock<ICategoryRepository>(MockBehavior.Strict);
            categoryRepository.Setup(categories => categories.GetAllCategories()).Throws(new ApplicationException());

            CategoryService categoryService = new CategoryService(categoryRepository.Object);
            categoryService.GetAllCategories();
        }

        [TestMethod]
        public void GetPostCategories_WhenGetCategories_Working()
        {
            int expectedCategoryId = 1;
            ICategoryRepository categoryRepository = Mock.Of<ICategoryRepository>(categories => categories.GetPostCategories(It.IsAny<int>()) == new List<Category> { new Category(expectedCategoryId) });

            CategoryService categoryService = new CategoryService(categoryRepository);
            List<CategoryDto> gettedCategories = (List<CategoryDto>)categoryService.GetPostCategories(1);
            int resultCategoryId = gettedCategories[0].Id;

            Assert.AreEqual(expectedCategoryId, resultCategoryId);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetPostCategories_WhenGetCategories_CatchException()
        {
            Mock<ICategoryRepository> categoryRepository = new Mock<ICategoryRepository>(MockBehavior.Strict);
            categoryRepository.Setup(categories => categories.GetPostCategories(It.IsAny<int>())).Throws(new ApplicationException());

            CategoryService categoryService = new CategoryService(categoryRepository.Object);
            categoryService.GetPostCategories(1);
        }

    }
}
