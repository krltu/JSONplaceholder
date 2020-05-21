using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace JSONplaceholder
{
    [TestClass]
    public class UnitTest2
    {
        string baseURL = "https://jsonplaceholder.typicode.com";

        [TestMethod]
        public void Test_B_AddNewUser()
        {
            /*
                b. Add a new user and specify a name, username and email
            */

            var nameValue = "John Doe";
            var usernameValue = "JohnD";
            var emailValue = "john.doe@gmail.com";

            // Creating Client connection	
            RestClient restClient = new RestClient(baseURL);

            // Creating request to get data from server
            RestRequest restRequest = new RestRequest("/users", Method.POST);

            // Adding body
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(new { name = nameValue, username = usernameValue, email = emailValue });

            // Adding headers
            restRequest.AddHeader("Content-type", "application/json; charset=UTF-8");

            // Executing request to server 
            IRestResponse restResponse = restClient.Execute(restRequest);

            // Extracting output data from received response           
            var jsonObjectResponse = JObject.Parse(restResponse.Content);
            int statusCode = (int)restResponse.StatusCode;

            // Validating data
            Assert.AreEqual(201, statusCode, " Status code is not 201 ");
            Assert.AreEqual(nameValue, jsonObjectResponse.GetValue("name"), " name value is not correct ");
            Assert.AreEqual(usernameValue, jsonObjectResponse.GetValue("username"), " username value is not correct ");
            Assert.AreEqual(emailValue, jsonObjectResponse.GetValue("email"), " email value is not correct ");
        }

    }
}


