using Moq;
using ProjetoSinistroAPI.Controllers;
using ProjetoSinistroAPI.Model;
using ProjetoSinistroAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace ProjetoSinistroAPI.Tests
{
    public class PacienteControllerTests
    {
        private readonly Mock<IPacienteRepository> _mockRepo;
        private readonly PacienteController _controller;

        public PacienteControllerTests()
        {
            _mockRepo = new Mock<IPacienteRepository>();
            _controller = new PacienteController(_mockRepo.Object);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithListOfPacientes()
        {
            // Arrange
            var pacientes = new List<PacienteModel>
            {
                new PacienteModel { PacienteId = 1, Nome = "John Doe" },
                new PacienteModel { PacienteId = 2, Nome = "Jane Smith" }
            };
            _mockRepo.Setup(repo => repo.List()).Returns(pacientes);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<PacienteModel>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public void Get_ReturnsNotFound_WhenNoPacientes()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.List()).Returns((List<PacienteModel>)null);

            // Act
            var result = _controller.Get();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Não Encontrado", notFoundResult.Value);
        }
    }
}
