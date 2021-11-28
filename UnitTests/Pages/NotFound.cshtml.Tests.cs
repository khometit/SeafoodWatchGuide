﻿using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Pages;
using System.Diagnostics;

namespace UnitTests.Pages.NotFound
{
    /// <summary>
    /// Class containing all unit tests for NotFound page
    /// </summary>
    class NotFound
    {
        #region TestSetup
        //ErrorModel object used to test Error page's model
        public static NotFoundModel PageModel;

        /// <summary>
        /// Test constructor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<NotFoundModel>>();

            PageModel = new NotFoundModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Test OnGet function where a valid activity should not cause the notfound
        /// page to get called
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange

            Activity activity = new Activity("activity");
            activity.Start();

            // Act
            PageModel.OnGet();

            // Reset
            activity.Stop();

            // Assert
            Assert.AreEqual(true, PageModel.ModelState.IsValid);
            Assert.AreEqual(activity.Id, PageModel.RequestId);
        }


        /// <summary>
        /// Test OnGet function where an invalid activity happened, which caused
        /// notfound page to produce a trace
        /// </summary>
        [Test]
        public void OnGet_InValid_Activity_Null_Should_Return_TraceIdentifier()
        {
            // Arrange

            // Act
            PageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, PageModel.ModelState.IsValid);
            Assert.AreEqual("trace", PageModel.RequestId);
            Assert.AreEqual(true, PageModel.ShowRequestId);
        }
        #endregion OnGet
    }
}
