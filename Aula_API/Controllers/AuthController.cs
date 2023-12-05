using Aula_API.Authentication;
using Aula_API.DataAccess;
using Aula_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula_API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly MyDbContext _dbContext;
    private readonly ILogger<AuthController> _logger;

    public AuthController(MyDbContext dbContext, ILogger<AuthController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    [HttpPost]
    [ApiKey]
    public IActionResult Login([FromBody] Credentials credentials)
    {
        try
        {
            var funcionario = _dbContext.Funcionarios.FirstOrDefault(e => e.Cpf == credentials.Cpf);

            if (funcionario != null && funcionario.Senha == credentials.Senha)
            {
                return Ok(new object[] { funcionario, 200 });
            }
            else
            {
                return NotFound("Credenciais incorretas");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while Getting the Funcionario. Error: " + ex.Message);
        }
    }
}