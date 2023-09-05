using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace FuncionarioControllerTests
{
    public class FuncionarioControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        private FuncionarioControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        public async Task Get_ReturnsStatusCode201(int id)
        {
            // Arrange

            // Act
            var response = await _client.GetAsync($"/api/Funcionario/{id}");

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Get_WithNegativeId_ReturnsBadRequest()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("/api/Funcionario/-1");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}