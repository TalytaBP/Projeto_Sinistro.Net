using Microsoft.AspNetCore.Mvc;
using ProjetoSinistroAPI.Dtos;
using ProjetoSinistroAPI.Services;
using System.Linq;

namespace ProjetoSinistroAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Tags("Identificador de Doenças")]
    public class SintomasController : Controller
    {
        private readonly ISymptomClassificationService _symptomService;

        public SintomasController(ISymptomClassificationService symptomService)
        {
            _symptomService = symptomService;
        }

        [HttpPost("identificar")]
        public IActionResult IdentificarSintomas([FromBody] IdentificarSintomasRequestDto request)
        {
            if (request?.Sintomas == null || !request.Sintomas.Any())
            {
                return BadRequest("A lista de sintomas não pode estar vazia.");
            }

            var symptomsText = string.Join(", ", request.Sintomas);
            var disease = _symptomService.PredictDisease(symptomsText);
            var recommendation = _symptomService.GenerateRecommendation(disease);

            var response = new IdentificarSintomasResponseDto
            {
                Doenca = disease,
                Recomendacao = recommendation
            };

            return Ok(response);
        }

        [HttpPost("gerar-recomendacao")]
        public IActionResult GerarRecomendacao([FromBody] IdentificarSintomasRequestDto request)
        {
            if (request?.Sintomas == null || !request.Sintomas.Any())
            {
                return BadRequest("A lista de sintomas não pode estar vazia.");
            }

            var symptomsText = string.Join(", ", request.Sintomas);
            var recommendation = _symptomService.GenerateRecommendation(symptomsText);

            return Ok(new { Recomendacao = recommendation });
        }
    }
}
