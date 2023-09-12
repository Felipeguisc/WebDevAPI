using System;
using Aula_API;
using Aula_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;
using Aula_API_Tests.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Aula_API.DataAccess;

namespace Aula_API_Tests;

public class ProdutoControllerTests
{
    private readonly MyDbContext _dbContext;
    private readonly ProdutoController _controller;

    public ProdutoControllerTests()
    {
        // Configure DbContextOptions for in-memory database
        var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase") // Provide a unique name for the in-memory database
            .Options;

        // Create an instance of the testing DbContext
        _dbContext = new MyDbContext(options);

        var loggerMock = new Mock<ILogger<ProdutoController>>();
        _controller = new ProdutoController(_dbContext, loggerMock.Object);
    }

    [Fact]
    public void Get_ReturnsOkResultForGetAll()
    {
        Produto produto = new Produto
        {
            Nome = "Example Entity",
            Descricao = "Teste Descricao",
            Foto = new byte[1],
            ValorUnitario = 1.22m,
        };

        Produto produto2 = new Produto
        {
            Nome = "Example Entity",
            Descricao = "Teste Descricao",
            Foto = new byte[1],
            ValorUnitario = 1.22m,
        };

        // Act
        var resultPost = _controller.Post(produto) as OkObjectResult;
        var resultPost2 = _controller.Post(produto2) as OkObjectResult;

        _dbContext.SaveChanges();

        var result = _controller.Get() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void Get_ReturnsOkResultForGetById()
    {
        Produto produto = new Produto
        {
            Id = 1,
            Nome = "Example Entity",
            Descricao = "Teste Descricao",
            Foto = new byte[1],
            ValorUnitario = 1.22m,
        };

        // Act
        var resultPost = _controller.Post(produto) as OkObjectResult;

        _dbContext.SaveChanges();

        var result = _controller.Get(produto.Id) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void Post_ReturnsOkResult()
    {
        Produto produto = new Produto
        {
            Nome = "Example Entity",
            Descricao = "Teste Descricao",
            Foto = new byte[1],
            ValorUnitario = 1.22m,
        };

        // Act
        var result = _controller.Post(produto) as OkObjectResult;

        _dbContext.SaveChanges();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void Put_ReturnsCreatedResult()
    {
        Produto produto = new Produto
        {
            Nome = "Example Entity",
            Descricao = "Teste Descricao",
            Foto = new byte[1],
            ValorUnitario = 1.22m,
        };

        var resultPost = _controller.Post(produto) as OkObjectResult;

        _dbContext.SaveChanges();

        Produto produtoUpdate = new Produto
        {
            Id = 1,
            Nome = "Example Entity",
            Descricao = "Teste Descricao Update",
            Foto = new byte[1],
            ValorUnitario = 1.22m,
        };

        var resultGet = _controller.Get() as OkObjectResult;

        // Act
        var result = _controller.Put(produtoUpdate) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    public void Delete_ReturnsCreatedResult(int id)
    {
        Produto produto = new Produto
        {
            Id = id,
            Nome = "Example Entity",
            Descricao = "Teste Descricao",
            Foto = new byte[1],
            ValorUnitario = 1.22m,
        };

        // Act
        var resultPost = _controller.Post(produto) as OkObjectResult;

        var result = _controller.Delete(produto.Id) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
    }
}
