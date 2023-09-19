using Aula_API;
using Aula_API.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ApiKeyAuthFilter : IAuthorizationFilter
{
    private readonly IApiKeyValidation _apiKeyValidation;

    public ApiKeyAuthFilter(IApiKeyValidation apiKeyValidation)
    {
        _apiKeyValidation = apiKeyValidation;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string userApiKey = context.HttpContext.Request.Headers[Constants.ApiKeyHeaderName].ToString();
        string userApiToken = context.HttpContext.Request.Headers[Constants.ApiTokenHeaderName].ToString();

        if (string.IsNullOrWhiteSpace(userApiKey) || string.IsNullOrWhiteSpace(userApiToken))
        {
            context.Result = new BadRequestResult();
            return;
        }

        if (!_apiKeyValidation.IsValidApiKey(userApiKey) || !_apiKeyValidation.IsValidApiToken(userApiToken))
            context.Result = new UnauthorizedResult();
    }
}