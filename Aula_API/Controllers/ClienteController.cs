using Aula_API.DataAccess;
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

    [HttpGet(Name = "GetClientes")]
    public IActionResult Get()
    {
        try
        {
            var clientes = _dbContext.Clientes.ToList();

            return Ok(clientes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while Getting the GetClientes. Error: " + ex.Message);
        }
    }

    [HttpGet("{id:int}", Name = "GetCliente")]
    public IActionResult Get(int id)
    {
        try
        {
            var cliente = _dbContext.Clientes.FirstOrDefault(e => e.Id == id);

            if (cliente != null)
            {
                return Ok(cliente);
            }
            else
            {
                return NotFound("Nenhum Cliente encontrado");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while Getting the Cliente. Error: " + ex.Message);
        }
    }

    [HttpPost(Name = "PostCliente")]
    public IActionResult Post(Cliente cliente)
    {
        try
        {
            var result = _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();
            return Ok("post executado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while adding the Cliente. Error: " + ex.Message);
        }
    }

    [HttpPut(Name = "PutCliente")]
    public IActionResult Put(Cliente cliente)
    {
        try
        {
            var result = _dbContext.Clientes.Update(cliente);
            _dbContext.SaveChanges();
            return StatusCode(201, "put executado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while updating the Cliente. Error: " + ex.Message);
        }
    }

    [HttpDelete("{id:int}", Name = "DeleteCliente")]
    public IActionResult Delete(int id)
    {
        try
        {
            var cliente = _dbContext.Clientes.FirstOrDefault(e => e.Id == id);

            if (cliente != null)
            {
                var result = _dbContext.Clientes.Remove(cliente);
                _dbContext.SaveChanges();

                return StatusCode(201, $"Entity with ID {cliente.Id} has been deleted.");
            }
            else
            {
                return StatusCode(404, "Entity not found, so it cannot be deleted.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while deleting the Cliente. Error: " + ex.Message);
        }
    }
}

