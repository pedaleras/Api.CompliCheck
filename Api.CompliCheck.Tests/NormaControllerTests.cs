using System.Net;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Api.CompliCheck.Tests
{
    public class NormaControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public NormaControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetNormas_ReturnsHttpStatusCode200()
        {
            // Arrange
            var request = "/api/norma";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode(); // Verifica se é 200 OK
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
