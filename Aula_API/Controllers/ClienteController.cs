using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly MyDbContext _dbContext;
    private readonly ILogger<ClienteController> _logger;

    public ClienteController(MyDbContext dbContext, ILogger<ClienteController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    [HttpGet(Name = "GetCliente")]
    public IActionResult Get()
    {
        var clients = _dbContext.Clientes.ToList();

        return Ok(clients);
    }
}

