using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Net;

namespace JSONplaceholder
{
    [TestClass]
    public class UnitTest3
    {
        string baseURL = "https://jsonplaceholder.typicode.com";

        [TestMethod]
        public void Test_C_ResponseTimeThreshold()
        {
            /*
                c. Write a test for one of the api endpoints that will fail if the response time passes a given threshold.
            */

            // Creating resource path and threshold value in milliseconds 
            string resourcePath = baseURL + "/photos";
            long threshold = 10; //long threshold = 100;

            // Creating request to get data from server
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resourcePath);
            System.Diagnostics.Stopwatch timer = new Stopwatch();

            // Executing request to server 
            timer.Start();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Close();
            timer.Stop();
            long elapsedMilliseconds = (long)(object)timer.ElapsedMilliseconds;

            // Validating response time
            Assert.IsTrue(elapsedMilliseconds < threshold, " Response time " + elapsedMilliseconds + " milliseconds exceeded threshold " + threshold + " milliseconds ");
        }
    }
}


