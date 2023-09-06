using Microsoft.AspNetCore.Mvc;

namespace Aula_API.Controllers;

[ApiController]
[Route("[controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly ILogger<FuncionarioController> _logger;

    public FuncionarioController(ILogger<FuncionarioController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetFuncionarios")]
    public IActionResult Get()
    {
        return Ok("get TODOS executado");
    }

    [HttpGet("{id:int}", Name = "GetFuncionario")]
    public IActionResult Get(int id)
    {
        return Ok("get UM executado");
    }

    [HttpPost(Name = "PostFuncionario")]
    public IActionResult Post()
    {
        return Ok("post executado");
    }

    [HttpPut("{id:int}", Name = "PutFuncionario")]
    public IActionResult Put(int id)
    {
        return StatusCode(201, "put executado");
    }

    [HttpDelete("{id:int}", Name = "DeleteFuncionario")]
    public IActionResult Delete(int id)
    {
        return StatusCode(201, "delete executado");
    }
}

