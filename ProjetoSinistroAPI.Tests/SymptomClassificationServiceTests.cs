using ProjetoSinistroAPI.Services;
using Xunit;

namespace ProjetoSinistroAPI.Tests
{
    public class SymptomClassificationServiceTests
    {
        private readonly SymptomClassificationService _service;

        public SymptomClassificationServiceTests()
        {
            _service = new SymptomClassificationService();
        }

        [Theory]
        [InlineData("dor de dente", "Cárie")]
        [InlineData("sensibilidade ao frio", "Hipersensibilidade dentária")]
        [InlineData("sangramento nas gengivas", "Gengivite")]
        [InlineData("sintoma desconhecido", "Desconhecida")]
        public void PredictDisease_ReturnsExpectedDisease(string symptoms, string expectedDisease)
        {
            var result = _service.PredictDisease(symptoms);
            Assert.Equal(expectedDisease, result);
        }

        [Theory]
        [InlineData("Cárie", "Agendar consulta com dentista especialista.")]
        [InlineData("Hipersensibilidade dentária", "Usar creme dental para dentes sensíveis.")]
        [InlineData("Gengivite", "Visitar um dentista para limpeza.")]
        [InlineData("Desconhecida", "Agende uma consulta ao dentista.")]
        public void GenerateRecommendation_ReturnsExpectedRecommendation(string disease, string expectedRecommendation)
        {
            var result = _service.GenerateRecommendation(disease);
            Assert.Equal(expectedRecommendation, result);
        }

        [Fact]
        public void GenerateRecommendation_ReturnsDefaultRecommendation_ForUnknownDisease()
        {
            var result = _service.GenerateRecommendation("Doença Inexistente");
            Assert.Equal("Agende uma consulta ao dentista.", result);
        }
    }
}
