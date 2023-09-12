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

public class FuncionarioControllerTests
{
    private readonly MyDbContext _dbContext;
    private readonly FuncionarioController _controller;

    public FuncionarioControllerTests()
    {
        // Configure DbContextOptions for in-memory database
        var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase") // Provide a unique name for the in-memory database
            .Options;

        // Create an instance of the testing DbContext
        _dbContext = new MyDbContext(options);

        var loggerMock = new Mock<ILogger<FuncionarioController>>();
        _controller = new FuncionarioController(_dbContext, loggerMock.Object);
    }

    [Fact]
    public void Get_ReturnsOkResultForGetAll()
    {
        Funcionario funcionario = new Funcionario
        {
            Id = 1,
            Nome = "Example Entity",
            Matricula = "123334",
            Cpf = "000000000000",
            Telefone = "1231231233",
            Grupo = 1,
            Senha = "123123",
        };

        Funcionario funcionario2 = new Funcionario
        {
            Id = 2,
            Nome = "Example 2",
            Matricula = "123334",
            Cpf = "000000000000",
            Telefone = "1231231233",
            Grupo = 1,
            Senha = "123123",
        };

        // Act
        var resultPost = _controller.Post(funcionario) as OkObjectResult;
        var resultPost2 = _controller.Post(funcionario2) as OkObjectResult;

        _dbContext.SaveChanges();

        var result = _controller.Get() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void Get_ReturnsOkResultForGetById()
    {
        Funcionario funcionario = new Funcionario
        {
            Nome = "Example Entity",
            Matricula = "123334",
            Cpf = "000000000000",
            Telefone = "1231231233",
            Grupo = 1,
            Senha = "123123",
        };

        // Act
        var resultPost = _controller.Post(funcionario) as OkObjectResult;

        _dbContext.SaveChanges();

        var result = _controller.Get(funcionario.Id) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void Post_ReturnsOkResult()
    {
        Funcionario funcionario = new Funcionario
        {
            Nome = "Example Entity",
            Matricula = "123334",
            Cpf = "000000000000",
            Telefone = "1231231233",
            Grupo = 1,
            Senha = "123123",
        };

        // Act
        var result = _controller.Post(funcionario) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("post executado", result.Value);
    }

    [Fact]
    public void Put_ReturnsCreatedResult()
    {
        Funcionario funcionario = new Funcionario
        {
            Id = 1,
            Nome = "Example Entity",
            Matricula = "123334",
            Cpf = "000000000000",
            Telefone = "1231231233",
            Grupo = 1,
            Senha = "123123",
        };

        // Act
        var result = _controller.Put(funcionario) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    public void Delete_ReturnsCreatedResult(int id)
    {
        Funcionario funcionario = new Funcionario
        {
            Id = id,
            Nome = "Example Entity",
            Matricula = "123334",
            Cpf = "000000000000",
            Telefone = "1231231233",
            Grupo = 1,
            Senha = "123123",
        };

        // Act
        var resultPost = _controller.Post(funcionario) as OkObjectResult;

        _dbContext.SaveChanges();

        var result = _controller.Delete(funcionario.Id) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
    }
}
