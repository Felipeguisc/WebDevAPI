namespace Aula_API.Authentication;

public class ApiKeyValidation : IApiKeyValidation
{
    private readonly IConfiguration _configuration;

    public ApiKeyValidation(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool IsValidApiKey(string userApiKey)
    {
        if (string.IsNullOrWhiteSpace(userApiKey))
            return false;

        string? apiKey = _configuration.GetValue<string>(Constants.ApiKeyName);

        if (apiKey == null || apiKey != userApiKey)
            return false;

        return true;
    }

    public bool IsValidApiToken(string userApiToken)
    {
        if (string.IsNullOrWhiteSpace(userApiToken))
            return false;

        string? apiKey = _configuration.GetValue<string>(Constants.ApiTokenName);

        if (apiKey == null || apiKey != userApiToken)
            return false;

        return true;
    }
}