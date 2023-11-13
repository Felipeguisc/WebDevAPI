using Aula_API.Authentication;
using Aula_API.DataAccess;
using Aula_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly MyDbContext _dbContext;
    private readonly ILogger<ProdutoController> _logger;

    public ProdutoController(MyDbContext dbContext, ILogger<ProdutoController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    [HttpGet(Name = "GetProdutos")]
    [ApiKey]
    public IActionResult Get()
    {
        try
        {
            var produtos = _dbContext.Produtos.ToList();

            return Ok(produtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while Getting the GetProdutos. Error: " + ex.Message);
        }
    }

    [HttpGet("{id:int}", Name = "GetProduto")]
    [ApiKey]
    public IActionResult Get(int id)
    {
        try
        {
            var produto = _dbContext.Produtos.FirstOrDefault(e => e.Id == id);

            if (produto != null)
            {
                return Ok(new object[] { produto, 200 });
            }
            else
            {
                return NotFound("Nenhum Produto encontrado");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while Getting the Produto. Error: " + ex.Message);
        }
    }

    [HttpPost(Name = "PostProduto")]
    [ApiKey]
    public IActionResult Post(Produto produto)
    {
        try
        {
            var result = _dbContext.Produtos.Add(produto);
            _dbContext.SaveChanges();

            var resultado = new ApiResponse
            {
                Msg = "Cadastrado com sucesso!"
            };

            return Ok(new object[] { resultado, 200 });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while adding the Produto. Error: " + ex.Message);
        }
    }

    [HttpPut(Name = "PutProduto")]
    [ApiKey]
    public IActionResult Put(Produto produto)
    {
        try
        {
            var result = _dbContext.Produtos.Update(produto);
            _dbContext.SaveChanges();

            var resultado = new ApiResponse
            {
                Msg = "Atualizado com sucesso!"
            };

            return Ok(new object[] { resultado, 200 });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while updating the Produto. Error: " + ex.Message);
        }
    }

    [HttpDelete("{id:int}", Name = "DeleteProduto")]
    [ApiKey]
    public IActionResult Delete(int id)
    {
        try
        {
            var produto = _dbContext.Produtos.FirstOrDefault(e => e.Id == id);

            if (produto != null)
            {
                var result = _dbContext.Produtos.Remove(produto);
                _dbContext.SaveChanges();

                var resultado = new ApiResponse
                {
                    Msg = "Deletado com sucesso!"
                };

                return Ok(new object[] { resultado, 200 });
            }
            else
            {
                return StatusCode(404, "Entity not found, so it cannot be deleted.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while deleting the Produto. Error: " + ex.Message);
        }
    }
}

