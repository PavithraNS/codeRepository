using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiThreading;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace RestSharpJson
{
    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient("http://localhost:4000");
        }
        private IRestResponse GetEmployeeList()
        {
            //Arrange
            RestRequest request = new RestRequest("/Employees/list", Method.GET);
            //Act
            IRestResponse response= client.Execute(request);

            return response;
        }
        [TestMethod]
        public void OnCallingGetAPI_ReturnEmployeeList()
        {
            IRestResponse response = GetEmployeeList();
            Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);

            List<Employees> employeeList = JsonConvert.DeserializeObject<List<Employees>>(response.Content);
            Assert.AreEqual(6,employeeList.Count);
            foreach(Employees emp in employeeList)
            {
                Console.WriteLine(emp.id+"\t"+emp.firstName+"\t"+emp.lastName);
            }
        }

        [TestMethod]
        public void OnCallingPostAPI_ReturnEmployeeObject()
        {
            RestRequest request = new RestRequest("/Employees/list", Method.POST);
            JsonObject jsonObj = new JsonObject();
            jsonObj.Add("jobTitleName", "Testing");
            jsonObj.Add("firstName", "Kalpana");
            jsonObj.Add("lastName", "V");
            request.AddParameter("application/json",jsonObj,ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            Employees employee = JsonConvert.DeserializeObject<Employees>(response.Content);
            Assert.AreEqual("Kalpana", employee.firstName);
            Assert.AreEqual("V", employee.lastName);

        }
    }
}
