using Microsoft.AspNetCore.Mvc;

namespace Aula_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly ILogger<ProdutoController> _logger;

    public ProdutoController(ILogger<ProdutoController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProduto")]
    public IActionResult Get()
    {
        return Ok("get TODOS executado");
    }
}

