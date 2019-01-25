using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OData.UriParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.OData
{
    public class ProductsController : ODataController
    {
        [HttpGet]
        [EnableQuery]
        public IActionResult GetProducts()
        {
            var domain = $"{ Request.Scheme }://{ Request.Host.Value }";
            Uri domainAndPrefixApi = new Uri(domain + "/odata");
            //var requestUri = new Uri($"{domain}/odata/Products/Rpc.GetProducts?$expand=colors"); // ok
            var requestUri = new Uri($"{domain}/odata/Products/Rpc.GetProducts?$expand=colors($orderby=Id desc)"); // fail
            //var requestUri = new Uri($"{domain}/odata/Products/Rpc.GetProducts?$expand=colors($filter=Id eq 5)");  // fail
            var model = HttpContext.Request.GetModel();
            try
            {
                var parser = new ODataUriParser(Request.GetModel(), domainAndPrefixApi, requestUri) { Resolver = new ODataUriResolver { EnableCaseInsensitive = true } };
                var request = parser.ParseUri();
            }
            catch (Exception ex)
            {
                // Value cannot be null.Parameter name: type
            }

            return Ok(new List<Product> {
                new Product { Id = 1, code = "mk100", colors = new List<Color> { new Color { Id = 1, name = "red" }, new Color { Id = 2, name = "yellow" } } },
                new Product { Id = 2, code = "mk200", colors = new List<Color> { new Color { Id = 1, name = "red" }, new Color { Id = 2, name = "yellow" } } },
                new Product { Id = 3, code = "mk200", colors = new List<Color> { new Color { Id = 1, name = "red" }, new Color { Id = 2, name = "yellow" } } },
                new Product { Id = 4, code = "mk400", colors = new List<Color> { new Color { Id = 1, name = "red" }, new Color { Id = 2, name = "yellow" } } }
            }.AsQueryable());
        }
    }
}
