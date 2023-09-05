using System;
using Aula_API;
using Aula_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;

namespace Aula_API_Tests;

public class FuncionarioControllerTests
{
    private readonly FuncionarioController _controller;

    public FuncionarioControllerTests()
    {
        var loggerMock = new Mock<ILogger<FuncionarioController>>();
        _controller = new FuncionarioController(loggerMock.Object);
    }

    [Fact]
    public void Get_ReturnsOkResultForGetAll()
    {
        // Act
        var result = _controller.Get() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("get TODOS executado", result.Value);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    public void Get_ReturnsOkResultForGetById(int id)
    {
        // Act
        var result = _controller.Get(id) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("get UM executado", result.Value);
    }

    [Fact]
    public void Post_ReturnsOkResult()
    {
        // Act
        var result = _controller.Post() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("post executado", result.Value);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    public void Put_ReturnsCreatedResult(int id)
    {
        // Act
        var result = _controller.Put(id) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
        Assert.Equal("put executado", result.Value);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    public void Delete_ReturnsCreatedResult(int id)
    {
        // Act
        var result = _controller.Delete(id) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
        Assert.Equal("delete executado", result.Value);
    }
}
