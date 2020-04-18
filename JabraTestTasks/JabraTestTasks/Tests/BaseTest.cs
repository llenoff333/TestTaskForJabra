using JabraTestTasks.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace JabraTestTasks.Tests
{
    public class BaseTest
    {
        protected HttpHelper httpHelper;
        [SetUp]
        public void BeforeTest()
        {
            httpHelper = new HttpHelper();
        }

        [TearDown]
        public void AfterTest()
        {

        }

        public class TestCaseData
        {
            public int FamilyId { get; set; }
            public string MarketLocale { get; set; }
            public TestCaseData(int familyId, string marketLocale)
            {
                FamilyId = familyId;
                MarketLocale = marketLocale;
            }
        }

        protected static IEnumerable<TestCaseData> GetTestDataFromFile()
        {
            string folderPath = GetPathToFile(@"Data\");
            string[] fileNames = Directory.GetFileSystemEntries(folderPath);
            List<TestCaseData> testData = new List<TestCaseData>();
            for (int i = 0; i < fileNames.Length; i++)
            {
                testData.AddRange(GetInfoFromOneFile(fileNames[i]));
            }
            return testData;
        }

        private static IEnumerable<TestCaseData> GetInfoFromOneFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs,Encoding.ASCII);
            while(reader.Peek()>0)
            {
                string line = reader.ReadLine();
                string[] info = line.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                TestCaseData testCaseData = new TestCaseData(int.Parse(info[0]), info[1]);
                yield return testCaseData;
            }
            reader.Close();
            fs.Close();
        }

        public static string GetPathToFile(string fileRelativePath)
        {
            var pathToFileDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Replace(@"\bin\Debug", ""));
            return Path.Combine(pathToFileDir, fileRelativePath);
        }
    }
}
