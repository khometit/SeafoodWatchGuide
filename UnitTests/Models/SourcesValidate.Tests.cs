﻿using System;
using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using ContosoCrafts.WebSite.RatingEnums;

namespace UnitTests.Model
{
    /// <summary>
    /// This class contains all the tests for the application's ProductModel
    /// </summary>
    public class SourceValidateTests
    {
        #region TestSetup
        //ValidationAtribute object to test string lengths in list of strings
        public ListStringLength attribute;

        /// <summary>
        /// Test constructor.
        /// Creating the mock environment for conducting our test against
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            attribute = new ListStringLength();
        }
        #endregion


        #region DataAnnotationCheck
        /// <summary>
        /// UT for testing the serializer is acting as expected. Author
        /// unknown?
        /// </summary>
        [Test]
        public void ListStringLength_Return_True_When_All_List_Items_Are_Between_Lenght_Boundaries()
        {
            // Arrange
            // declare a list of strings to implement the source field
            List<string> sources = new List<string>();
            int minLenth = 5;
            int maxLenth = 20;
            sources.Add("abcde");
            sources.Add("abcdef");
            sources.Add("abcdedg");
            sources.Add("abcdefgh");
            sources.Add("abcdefghi");

            // Act
            attribute.MaxStringLength = maxLenth;
            attribute.MinStringLength = minLenth;
            var attributeVal = attribute.IsValid(sources);

            // Assert
            Assert.AreEqual(attributeVal, true);
        }

        /// <summary>
        /// UT for testing the serializer is acting as expected. Author
        /// unknown?
        /// </summary>
        [Test]
        public void ListStringLength_Return_False_When_All_List_Items_Are_outside_Lenght_Boundaries()
        {
            // Arrange
            // declare a list of strings to implement the source field
            List<string> sources = new List<string>();
            int minLenth = 5;
            int maxLenth = 8;
            sources.Add("a");
            sources.Add("ab");
            sources.Add("abc");
            sources.Add("abcd");
            sources.Add("abcdefghij");
 
            // Act
            attribute.MaxStringLength = maxLenth;
            attribute.MinStringLength = minLenth;
            var attributeVal = attribute.IsValid(sources);

            // Assert
            Assert.AreEqual(attributeVal, false);
        }
        [Test]
        public void ListStringLength_Return_False_When_Some_List_Items_Are_outside_Lenght_Boundaries()
        {
            // Arrange
            // declare a list of strings to implement the source field
            List<string> sources = new List<string>();
            int minLenth = 4;
            int maxLenth = 8;
            sources.Add("abcde");
            sources.Add("abcdef");
            sources.Add("abcdedg");
            sources.Add("abcdefgh");
            sources.Add("abcdefghi");

            // Act
            attribute.MaxStringLength = maxLenth;
            attribute.MinStringLength = minLenth;
            var attributeVal = attribute.IsValid(sources);

            // Assert
            Assert.AreEqual(attributeVal, false);
        }

        [Test]
        public void ListStringLength_Return_False_List_is_Null()
        {
            // Arrange
            int minLenth = 4;
            int maxLenth = 8;

            // Act
            attribute.MaxStringLength = maxLenth;
            attribute.MinStringLength = minLenth;
            var attributeVal = attribute.IsValid(null);

            // Assert
            Assert.AreEqual(attributeVal, false);
        }
        [Test]
        public void ListStringLength_Return_List_Item_Has_No_Alphabetical_Characters()
        {
            // Arrange
            // declare a list of strings to implement the source field
            List<string> sources = new List<string>();
            int minLenth = 3;
            int maxLenth = 20;
            sources.Add("12345");
            sources.Add("123456");
            sources.Add("1234567");
            sources.Add("12345678");
            sources.Add("123456789");

            // Act
            attribute.MaxStringLength = maxLenth;
            attribute.MinStringLength = minLenth;
            var attributeVal = attribute.IsValid(sources);

            // Assert
            Assert.AreEqual(attributeVal, false);
        }


        #endregion
    }
}