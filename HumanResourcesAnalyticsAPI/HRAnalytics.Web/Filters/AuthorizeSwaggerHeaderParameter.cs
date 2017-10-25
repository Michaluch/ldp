using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;

namespace HRAnalytics.Web.Filters
{
    public class AuthorizeSwaggerHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new Parameter
            {
                Name = "Authorization",
                In = "header",
                Required = false,
                Type = "string"
            });
        }

        private class Parameter : IParameter
        {
            public string Name { get; set; }
            public string In { get; set; }
            public string Description { get; set; }
            public bool Required { get; set; }
            public string Type { get; set; }

            public Dictionary<string, object> Extensions { get; }
        }
    }
}
