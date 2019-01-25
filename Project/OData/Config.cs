using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.OData
{
    public class Config
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            var GetProducts = builder.EntityType<Product>().Collection.Function("GetProducts");
            GetProducts.ReturnsCollectionFromEntitySet<Product>("Products");
            GetProducts.Namespace = "Rpc";

            builder.EntitySet<Color>("Colors");
            return builder.GetEdmModel();
        }
    }
}
