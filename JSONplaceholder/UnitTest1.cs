using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace JSONplaceholder
{
    [TestClass]
    public class UnitTest1
    {
        string baseURL = "https://jsonplaceholder.typicode.com";

        [TestMethod]
        public void Test_A_CheckPostByTitle()
        {
            /*
                a. Check that a post exists with title "qui est esse"
            */

            // Creating Client connection	
            RestClient restClient = new RestClient(baseURL);

            // Creating request to get data from server
            RestRequest restRequest = new RestRequest("/posts", Method.GET);

            // Adding query params
            restRequest.AddQueryParameter("title", "qui est esse");

            // Executing request to server 
            IRestResponse restResponse = restClient.Execute(restRequest);

            // Extracting output data from received response          
            Console.WriteLine(restResponse.Content);
            JArray jArrayResponse = JArray.Parse(restResponse.Content);
            int statusCode = (int)restResponse.StatusCode;

            // Validating data
            Assert.AreEqual(200, statusCode, " Status code is not 200 ");
            Assert.IsTrue(jArrayResponse.Count != 0, " Post with this title was not found ");            
        }
    }
}


