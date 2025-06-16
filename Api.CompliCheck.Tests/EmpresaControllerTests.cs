using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;

namespace Api.CompliCheck.Tests
{
    public class EmpresaControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public EmpresaControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetEmpresas_ReturnsHttpStatusCode200()
        {
            // Arrange
            var request = "/api/empresa";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode(); // Verifica se é 200 OK
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
