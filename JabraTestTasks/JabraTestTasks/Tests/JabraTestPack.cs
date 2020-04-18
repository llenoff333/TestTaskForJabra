using JabraTestTasks.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;

namespace JabraTestTasks.Tests
{
    [TestFixture]
    public class JabraTestPack : BaseTest
    {
        [TestCase( 404, "en-us")]
        [TestCase( 425, "fr-fr")]
        public void TestValidateStatusCodeValidDataInput(int familyId, string marketLocale)
        {
            // Arrange 
            var url = $"https://productcatalogueapi.jabra.com/v1/Family/{familyId}?include=available&marketLocale={marketLocale}";

            // Act
            var statusCodeResult = httpHelper.GetStatusCode(url);

            // Assert
            Assert.True(statusCodeResult == HttpStatusCode.OK, $"Http Status Code {statusCodeResult} is not 200 (OK).");
        }

        [TestCase(217, "fr-fr")]
        [TestCase(119, "777")]
        public void TestValidateStatusCodeInvalidDataInput(int familyId, string marketLocale)
        {
            // Arrange 
            var url = $"https://productcatalogueapi.jabra.com/v1/Family/{familyId}?include=available&marketLocale={marketLocale}";

            // Act
            var statusCodeResult = httpHelper.GetStatusCode(url);

            // Assert
            Assert.False(statusCodeResult == HttpStatusCode.OK, $"Http Status Code {statusCodeResult} is 200 (OK) unexpectedly.");
        }

        [TestCase("404", "en-us")]
        [TestCase("425", "fr-fr")]
        public void TestValidateJsonParamsValidDataInput(int familyId, string marketLocale)
        {
            // Arrange 
            var url = $"https://productcatalogueapi.jabra.com/v1/Family/{familyId}?include=available&marketLocale={marketLocale}";

            // Act
            var httpResponseBody = httpHelper.GetJson(url);
            var familyObjForJson = JsonConvert.DeserializeObject<Family>(httpResponseBody);

            // Assert
            Assert.True(!familyObjForJson.IsAnyFieldIsNullOrEmpty(),
                familyObjForJson.GetNotificationAboutFieldsWithNullOrEmptyValue());
        }

        [TestCase("2189", "fr-fr")]
        [TestCase("1193", "fr-fr")]
        public void TestValidateJsonParamsInvalidDataInput(int familyId, string marketLocale)
        {
            // Arrange 
            var url = $"https://productcatalogueapi.jabra.com/v1/Family/{familyId}?include=available&marketLocale={marketLocale}";

            // Assert
            Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("Body does not have any content."), () => httpHelper.GetJson(url));
        }


        // Test method with input data from file
        [TestCaseSource("GetTestDataFromFile")]
        public void TestValidateJsonParamsImputDataFromFile(TestCaseData testCaseData)
        {
            // Arrange 
            var familyId = testCaseData.FamilyId;
            var marketLocale = testCaseData.MarketLocale;
            var url = $"https://productcatalogueapi.jabra.com/v1/Family/{familyId}?include=available&marketLocale={marketLocale}";

            // Act
            var statusCodeResult = httpHelper.GetStatusCode(url);

            // Assert
            Assert.True(statusCodeResult == HttpStatusCode.OK, $"Http Status Code {statusCodeResult} is not 200 (OK).");
        }
    }
}
