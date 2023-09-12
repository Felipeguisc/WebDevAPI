using Aula_API.Controllers;
using Aula_API.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Aula_API_Tests;

public class ClienteControllerTests
{
    private readonly MyDbContext _dbContext;
    private readonly ClienteController _controller;

    public ClienteControllerTests()
    {
        // Configure DbContextOptions for in-memory database
        var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase") // Provide a unique name for the in-memory database
            .Options;

        // Create an instance of the testing DbContext
        _dbContext = new MyDbContext(options);

        var loggerMock = new Mock<ILogger<ClienteController>>();
        _controller = new ClienteController(_dbContext, loggerMock.Object);
    }

    [Fact]
    public void Get_ReturnsOkResultForGetAll_01()
    {
        // Adding entities
        Cliente cliente = new Cliente
        {
            Nome = "Example Entity",
            Cpf = "Teste Descricao",
            Telefone = "Teste Descricao",
            CompraFiado = 1,
            Senha = "Example Password",
        };

        Cliente cliente2 = new Cliente
        {
            Nome = "Example Entity",
            Cpf = "Teste Descricao",
            Telefone = "Teste Descricao",
            CompraFiado = 1,
            Senha = "Example Password",
        };

        var resultPost = _controller.Post(cliente) as OkObjectResult;
        var resultPost2 = _controller.Post(cliente2) as OkObjectResult;

        _dbContext.SaveChanges();

        // Act
        var result = _controller.Get() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void Get_ReturnsOkResultForGetById()
    {
        Cliente cliente = new Cliente
        {
            Nome = "Example Entity",
            Cpf = "Teste Descricao",
            Telefone = "Teste Descricao",
            CompraFiado = 1,
            Senha = "Example Password",
        };

        // Act
        var resultPost = _controller.Post(cliente) as OkObjectResult;

        _dbContext.SaveChanges();

        var result = _controller.Get(cliente.Id) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void Post_ReturnsOkResult()
    {
        Cliente cliente = new Cliente
        {
            Nome = "Example Entity",
            Cpf = "Teste Descricao",
            Telefone = "Teste Descricao",
            CompraFiado = 1,
            Senha = "Example Password",
        };

        // Act
        var result = _controller.Post(cliente) as OkObjectResult;

        _dbContext.SaveChanges();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void Put_ReturnsCreatedResult()
    {
        Cliente cliente = new Cliente
        {
            Nome = "Example Entity",
            Cpf = "Teste Descricao",
            Telefone = "Teste Descricao",
            CompraFiado = 1,
            Senha = "Example Password",
        };

        var resultPost = _controller.Post(cliente) as OkObjectResult;

        Cliente clienteUpdate = new Cliente
        {
            Nome = "Example Entity",
            Cpf = "Teste Descricao",
            Telefone = "Teste Descricao",
            CompraFiado = 1,
            Senha = "Example Password",
        };

        var resultGet = _controller.Get() as OkObjectResult;

        // Act
        var result = _controller.Put(clienteUpdate) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
    }

    [Theory]
    [InlineData(5)]
    public void Delete_ReturnsCreatedResult(int id)
    {
        Cliente cliente = new Cliente
        {
            Id = id,
            Nome = "Example Entity",
            Cpf = "Teste Descricao",
            Telefone = "Teste Descricao",
            CompraFiado = 1,
            Senha = "Example Password",
        };

        // Act
        var resultPost = _controller.Post(cliente) as OkObjectResult;

        var result = _controller.Delete(cliente.Id) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
    }
}
