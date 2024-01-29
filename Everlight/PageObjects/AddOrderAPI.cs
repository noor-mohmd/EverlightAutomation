using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Automation.PageObjects
{
    class AddOrderAPI
    {
        string BaseURL = "https://localhost:44449";
        RestClient client;
        RestRequest request;
        RestResponse response;
        string NewOrderId;

        public void AddNewOrder(OrderAPIData orderAPIData)
        {
            client = new RestClient(BaseURL);
            request = new RestRequest("api/orders");
            request.AddBody(orderAPIData);
            response = client.ExecutePost(request);
        }

        public void CheckStatusCode(int statusCode)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(statusCode));
        }

        public void VerifyOrderExists(OrderAPIData orderAPIData)
        {
            request = new RestRequest("api/orders");
            response = client.ExecuteGet(request);
            // check that the newly added order appears in the GET call response json
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Console.WriteLine(response.Content);
            var arr = JArray.Parse(response.Content);
            var result = new JArray(arr.Where(r => r.Value<string>("accessionNumber").Equals(orderAPIData.accessionNumber)));
            Assert.That(result.Count, Is.GreaterThan(0));
            NewOrderId = (string)result[0]["id"];
        }

        public void DeleteOrder()
        {
            request = new RestRequest("api/orders/{OrderId}", Method.Delete);
            request.AddUrlSegment("OrderId", NewOrderId);
            response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        public void VerifyErrorCode(string errorCode)
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

    }
}
