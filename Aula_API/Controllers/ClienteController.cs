using Aula_API.Authentication;
using Aula_API.DataAccess;
using Aula_API.Models;
using Microsoft.AspNetCore.Mvc;

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
    [ApiKey]
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
    [ApiKey]
    public IActionResult Get(int id)
    {
        try
        {
            var cliente = _dbContext.Clientes.FirstOrDefault(e => e.Id == id);

            if (cliente != null)
            {
                return Ok(new object[] { cliente, 200 });
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
    [ApiKey]
    public IActionResult Post(Cliente cliente)
    {
        try
        {
            var result = _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();

            var resultado = new ApiResponse
            {
                Msg = "Cadastrado com sucesso!"
            };

            return Ok(new object[] { resultado, 200 });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while adding the Cliente. Error: " + ex.Message);
        }
    }

    [HttpPut(Name = "PutCliente")]
    [ApiKey]
    public IActionResult Put(Cliente cliente)
    {
        try
        {
            var result = _dbContext.Clientes.Update(cliente);
            _dbContext.SaveChanges();
            var resultado = new ApiResponse
            {
                Msg = "Atualizado com sucesso!"
            };

            return Ok(new object[] { resultado, 200 });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while updating the Cliente. Error: " + ex.Message);
        }
    }

    [HttpDelete("{id:int}", Name = "DeleteCliente")]
    [ApiKey]
    public IActionResult Delete(int id)
    {
        try
        {
            var cliente = _dbContext.Clientes.FirstOrDefault(e => e.Id == id);

            if (cliente != null)
            {
                var result = _dbContext.Clientes.Remove(cliente);
                _dbContext.SaveChanges();

                var resultado = new ApiResponse
                {
                    Msg = "Deletado com sucesso!"
                };

                return Ok(new object[] { resultado, 200 });
            }
            else
            {
                var resultado = new ApiResponse
                {
                    Msg = "Erro ao deletar!"
                };

                return StatusCode(404, new object[] { resultado, 200 });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while deleting the Cliente. Error: " + ex.Message);
        }
    }
}

