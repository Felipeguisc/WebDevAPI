using Aula_API.DataAccess;
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
    public IActionResult Get(int id)
    {
        try
        {
            var produto = _dbContext.Produtos.FirstOrDefault(e => e.Id == id);

            if (produto != null)
            {
                return Ok(produto);
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
    public IActionResult Post(Produto produto)
    {
        try
        {
            var result = _dbContext.Produtos.Add(produto);
            _dbContext.SaveChanges();
            return Ok("post executado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while adding the Produto. Error: " + ex.Message);
        }
    }

    [HttpPut(Name = "PutProduto")]
    public IActionResult Put(Produto produto)
    {
        try
        {
            var result = _dbContext.Produtos.Update(produto);
            _dbContext.SaveChanges();
            return StatusCode(201, "put executado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while updating the Produto. Error: " + ex.Message);
        }
    }

    [HttpDelete("{id:int}", Name = "DeleteProduto")]
    public IActionResult Delete(int id)
    {
        try
        {
            var produto = _dbContext.Produtos.FirstOrDefault(e => e.Id == id);

            if (produto != null)
            {
                var result = _dbContext.Produtos.Remove(produto);
                _dbContext.SaveChanges();

                return StatusCode(201, $"Entity with ID {produto.Id} has been deleted.");
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

