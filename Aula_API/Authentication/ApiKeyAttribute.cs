using System;
using Microsoft.AspNetCore.Mvc;

namespace Aula_API.Authentication;

public class ApiKeyAttribute : ServiceFilterAttribute
{
    public ApiKeyAttribute()
        : base(typeof(ApiKeyAuthFilter))
    {
    }
}