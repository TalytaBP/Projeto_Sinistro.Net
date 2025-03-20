using Microsoft.AspNetCore.Mvc;
using ProjetoSinistroAPI.Model;
using ProjetoSinistroAPI.Repositories.Interface;

namespace ProjetoSinistroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Tags("Cadastro de Pacientes")]
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;


        public PacienteController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;

        }

        [HttpGet]
        [Route("List")]

        public ActionResult Get()
        {
            var pac = _pacienteRepository.List();

            if (pac == null)
                return NotFound("Não Encontrado");

            return Ok(pac);
        }


        [HttpPost]
        [Route("Add")]
        public ActionResult Post([FromBody] PacienteModel pac)
        {

            if (pac == null)
                return BadRequest();
            _pacienteRepository.Add(pac);


            return Ok("Adicionado com sucesso");
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Put([FromBody] PacienteModel pac)
        {
            if (pac == null)
                return BadRequest();

            var pacResponse = _pacienteRepository.Update(pac);
            if (pacResponse.PacienteId == 0)
                return BadRequest();

            return Ok(pacResponse);
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int id)
        {

            if (id == 0)
                return BadRequest();

            var pac = _pacienteRepository.Get(id);
            if (pac == null)
                return NoContent();

            var status = _pacienteRepository.Delete(id);

            if (!status)
                return BadRequest();


            return Ok("Excluido com Sucesso");
        }
    }
}
