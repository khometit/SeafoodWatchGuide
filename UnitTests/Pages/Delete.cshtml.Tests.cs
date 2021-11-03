using System;
using System.Collections.Generic;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using Moq;

namespace UnitTests.Pages.Delete
{
    /// <summary>
    /// Class containing all unit tests for Delete page
    /// </summary>
    public class DeleteTests
    {
        #region TestSetup
        //DeleteModel object used to test Delete page's model
        public static DeleteModel PageName;


        /// <summary>
        /// Test constructor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<DeleteModel>>();

            PageName = new DeleteModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }


        #endregion TestSetup

        /// <summary>
        /// Test OnGet function, which should fetch the correct item requested
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_get_data()
        {
            // Arrange
            var randomProduct = TestHelper.ProductService.GetAllData().FirstOrDefault();
            var sampleProduct = TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(randomProduct.Id));

            //Act
            PageName.OnGet(sampleProduct.Id);

            //Reset

            // Assert
            Assert.AreEqual(sampleProduct.Id, PageName.Product.Id);

        }


        /// <summary>
        /// Test OnPost function where deletion should happen successfully, and
        /// user gets directed back to Admin page.
        /// </summary>
        [Test]
        public void OnPost_delete_and_redirect()
        {
            // Arrange
            var randomProduct = TestHelper.ProductService.GetAllData().FirstOrDefault();
            PageName.Product = randomProduct;
            RedirectToPageResult page;

            //Act
            page = PageName.OnPost() as RedirectToPageResult;
            var sampleProduct = TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(randomProduct.Id));

            //Reset

            // Assert
            Assert.AreEqual(null, sampleProduct);
            Assert.AreEqual("Admin", page.PageName);


        }
        #endregion OnGet
    }
}