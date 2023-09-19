namespace Aula_API.Authentication;

public interface IApiKeyValidation
{
    bool IsValidApiKey(string userApiKey);
    bool IsValidApiToken(string userApiToken);
}