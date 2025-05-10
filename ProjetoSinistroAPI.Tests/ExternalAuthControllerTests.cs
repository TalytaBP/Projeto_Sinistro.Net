using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Moq.Protected;
using ProjetoSinistroAPI;
using ProjetoSinistroAPI.Services;
using Xunit;
using System.Threading;
using System.Net.Http.Headers;
using System;

namespace ProjetoSinistroAPI.Tests
{
    public class ExternalAuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;

        public ExternalAuthControllerTests(WebApplicationFactory<Program> factory)
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            var httpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://mock-auth-service/")
            };

            var clientFactoryMock = new Mock<IHttpClientFactory>();
            clientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            var factoryWithMock = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddHttpClient<IExternalAuthService, ExternalAuthService>()
                        .ConfigurePrimaryHttpMessageHandler(() => _mockHttpMessageHandler.Object);
                });
            });

            _client = factoryWithMock.CreateClient();
        }

        [Fact]
        public async Task Authenticate_ReturnsBadRequest_WhenUsernameOrPasswordMissing()
        {
            var response = await _client.PostAsJsonAsync("/api/ExternalAuth/authenticate", new { Username = "", Password = "" });
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Authenticate_ReturnsUnauthorized_WhenInvalidCredentials()
        {
            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("Unauthorized")
                });

            var response = await _client.PostAsJsonAsync("/api/ExternalAuth/authenticate", new { Username = "invalid", Password = "invalid" });
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
