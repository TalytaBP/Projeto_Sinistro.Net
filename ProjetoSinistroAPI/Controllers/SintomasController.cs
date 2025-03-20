using Microsoft.AspNetCore.Mvc;
using ProjetoSinistroAPI.Dtos;

namespace ProjetoSinistroAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Tags("Identificador de Doenças")]
    public class SintomasController : Controller
    {
        [HttpPost("identificar")]
        public IActionResult IdentificarSintomas([FromBody] IdentificarSintomasRequestDto request)
        {
            if (request?.Sintomas == null || !request.Sintomas.Any())
            {
                return BadRequest("A lista de sintomas não pode estar vazia.");
            }

            var response = new IdentificarSintomasResponseDto();

            if (request.Sintomas.Contains("dor de dente"))
            {
                response.Doenca = "Cárie";
           
                response.Recomendacao = "Agendar consulta com dentista especialista.";
            }
            else if (request.Sintomas.Contains("sensibilidade ao frio"))
            {
                response.Doenca = "Hipersensibilidade dentária";
             
                response.Recomendacao = "Usar creme dental para dentes sensíveis.";
            }
            else if (request.Sintomas.Contains("sangramento nas gengivas"))
            {
                response.Doenca = "Gengivite";
               
                response.Recomendacao = "Visitar um dentista para limpeza.";
            }
            else
            {
                response.Doenca = "Desconhecida";
               
                response.Recomendacao = "Agende uma consulta ao dentista.";
            }

            return Ok(response);
        }
    }
}
