using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RestSharp;
using Assert = NUnit.Framework.Assert;

namespace ApiTest
{

    public class Tests
    {
        private string getUrl = "https://jsonplaceholder.typicode.com/users";
        private List<Root> userList = new List<Root>();
        [SetUp]
        public void SetUp()
        {
            var restClient = new RestClient();
            var restReqest = new RestRequest(getUrl);
            var restResponse = restClient.Get(restReqest);
            string jsonString = restResponse.Content ?? "no content";
            userList = JsonSerializer.Deserialize<List<Root>>(jsonString)??userList;
        }
        [Test]
        public void ApiTest1()
        {
            foreach (var user in userList)
            {
                Assert.That(user.email != "");
            }
        }
        [Test]
        public void ApiTest2()
        {
            var user = userList.Find(x => x.email == "Shanna@melissa.tv");
            Assert.That(user.address.street, Is.EqualTo("Victor Plains"));
            Assert.That(user.address.suite, Is.EqualTo("Suite 879"));
            Assert.That(user.address.city, Is.EqualTo("Wisokyburgh"));
            Assert.That(user.address.zipcode, Is.EqualTo("90566-7771"));
        }
    }

    public class Address
    {
        public string? street { get; set; }
        public string? suite { get; set; }
        public string? city { get; set; }
        public string? zipcode { get; set; }
        public Geo? geo { get; set; }
    }

    public class Company
    {
        public string? name { get; set; }
        public string? catchPhrase { get; set; }
        public string? bs { get; set; }
    }

    public class Geo
    {
        public string? lat { get; set; }
        public string? lng { get; set; }
    }

    public class Root
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public Address? address { get; set; }
        public string? phone { get; set; }
        public string? website { get; set; }
        public Company? company { get; set; }
    }
}