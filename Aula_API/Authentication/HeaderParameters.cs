using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Aula_API.Authentication
{
    public class HeaderParameters : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = Constants.ApiKeyHeaderName,
                In = ParameterLocation.Header,
                Required = true
            });

            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = Constants.ApiTokenHeaderName,
                In = ParameterLocation.Header,
                Required = true
            });
        }
    }
}

