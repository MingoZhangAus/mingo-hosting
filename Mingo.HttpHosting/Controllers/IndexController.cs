using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Mingo.HttpHosting.Controllers
{
    public class IndexController: ApiController
    {
        [HttpGet]
        [HttpHead]
        [HttpPost]
        [HttpPut]
        public IHttpActionResult Handle(string url)
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            var html = ConfigurationManager.AppSettings["content"];
            html = string.IsNullOrEmpty(html) ? "Hello World!" : html;
            responseMessage.Content = new StringContent(html, Encoding.UTF8, "text/html");
            return ResponseMessage(responseMessage);
        }
    }
}
