using Aula_API.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Aula_API.Controllers;

[ApiController]
[Route("[controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly MyDbContext _dbContext;
    private readonly ILogger<FuncionarioController> _logger;

    public FuncionarioController(MyDbContext dbContext, ILogger<FuncionarioController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    [HttpGet(Name = "GetFuncionarios")]
    public IActionResult Get()
    {
        try
        {
            var funcionarios = _dbContext.Funcionarios.ToList();

            return Ok(funcionarios);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while Getting the Funcionarios. Error: " + ex.Message);
        }
    }

    [HttpGet("{id:int}", Name = "GetFuncionario")]
    public IActionResult Get(int id)
    {
        try
        {
            var funcionario = _dbContext.Funcionarios.FirstOrDefault(e => e.Id == id);

            if (funcionario != null)
            {
                return Ok(funcionario);
            }
            else
            {
                return NotFound("Nenhum Funcionario encontrado");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while Getting the Funcionario. Error: " + ex.Message);
        }
    }

    [HttpPost(Name = "PostFuncionario")]
    public IActionResult Post(Funcionario funcionario)
    {
        try
        {
            var result = _dbContext.Funcionarios.Add(funcionario);
            _dbContext.SaveChanges();
            return Ok("post executado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while adding the Funcionario. Error: " + ex.Message);
        }
    }

    [HttpPut(Name = "PutFuncionario")]
    public IActionResult Put(Funcionario funcionario)
    {
        try
        {
            var result = _dbContext.Funcionarios.Update(funcionario);
            _dbContext.SaveChanges();
            return StatusCode(201, "put executado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while updating the Funcionario. Error: " + ex.Message);
        }
    }

    [HttpDelete("{id:int}", Name = "DeleteFuncionario")]
    public IActionResult Delete(int id)
    {
        try
        {
            var funcionario = _dbContext.Funcionarios.FirstOrDefault(e => e.Id == id);

            if (funcionario != null)
            {
                var result = _dbContext.Funcionarios.Remove(funcionario);
                _dbContext.SaveChanges();

                return StatusCode(201, $"Entity with ID {funcionario.Id} has been deleted.");
            }
            else
            {
                return StatusCode(404, "Entity not found, so it cannot be deleted.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while deleting the Funcionario. Error: " + ex.Message);
        }
    }
}

