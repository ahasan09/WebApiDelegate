using EcapPipeline.Models;
using EcapPipeline.Repository;
using EcapPipeline.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace EcapPipeline.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomerController : ApiController
    {
        [Route("")]
        public string GetBooks() {
            return "Get New Customer";
        }

        [Route("{id:int}",Name ="GetCustomerById")]
        [HttpGet]
        public string GetCustomer(int id)
        {
            return $"Get Customer by Id: {id}";
        }

        [Route("")]
        [HttpPost]
        [ValidateModelState]
        public HttpResponseMessage CreateNewCustomer(Customer customer)
        {
            //return $"Create New Customer: {customer.Name}";
            // Validate and add book to database (not shown)

            var response = Request.CreateResponse(HttpStatusCode.Created);

            // Generate a link to the new book and set the Location header in the response.
            string uri = Url.Link("GetCustomerById", new { id = customer.Id });
            response.Headers.Location = new Uri(uri);
            Debug.WriteLine($"User Name on header : {StaticUser.UserName}");
            return response;
        }
    }
}
