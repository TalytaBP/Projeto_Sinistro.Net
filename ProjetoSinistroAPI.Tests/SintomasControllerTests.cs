using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjetoSinistroAPI.Controllers;
using ProjetoSinistroAPI.Dtos;
using ProjetoSinistroAPI.Services;
using System.Collections.Generic;
using Xunit;

namespace ProjetoSinistroAPI.Tests
{
    public class SintomasControllerTests
    {
        private readonly Mock<ISymptomClassificationService> _mockService;
        private readonly SintomasController _controller;

        public SintomasControllerTests()
        {
            _mockService = new Mock<ISymptomClassificationService>();
            _controller = new SintomasController(_mockService.Object);
        }

        [Fact]
        public void IdentificarSintomas_ReturnsBadRequest_WhenSymptomsListIsEmpty()
        {
            var request = new IdentificarSintomasRequestDto { Sintomas = new List<string>() };

            var result = _controller.IdentificarSintomas(request);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("A lista de sintomas não pode estar vazia.", badRequestResult.Value);
        }

        [Fact]
        public void IdentificarSintomas_ReturnsOkResult_WithPredictionAndRecommendation()
        {
            var request = new IdentificarSintomasRequestDto { Sintomas = new List<string> { "dor de dente" } };
            _mockService.Setup(s => s.PredictDisease(It.IsAny<string>())).Returns("Cárie");
            _mockService.Setup(s => s.GenerateRecommendation(It.IsAny<string>())).Returns("Agendar consulta com dentista especialista.");

            var result = _controller.IdentificarSintomas(request);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<IdentificarSintomasResponseDto>(okResult.Value);
            Assert.Equal("Cárie", response.Doenca);
            Assert.Equal("Agendar consulta com dentista especialista.", response.Recomendacao);
        }

        [Fact]
        public void GerarRecomendacao_ReturnsBadRequest_WhenSymptomsListIsEmpty()
        {
            var request = new IdentificarSintomasRequestDto { Sintomas = new List<string>() };

            var result = _controller.GerarRecomendacao(request);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("A lista de sintomas não pode estar vazia.", badRequestResult.Value);
        }

        [Fact]
        public void GerarRecomendacao_ReturnsOkResult_WithRecommendation()
        {
            var request = new IdentificarSintomasRequestDto { Sintomas = new List<string> { "dor de dente" } };
            _mockService.Setup(s => s.GenerateRecommendation(It.IsAny<string>())).Returns("Agendar consulta com dentista especialista.");

            var result = _controller.GerarRecomendacao(request);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<Dictionary<string, string>>(okResult.Value);
            Assert.True(response.ContainsKey("Recomendacao"));
            Assert.Equal("Agendar consulta com dentista especialista.", response["Recomendacao"]);
        }
    }
}
