using ProjetoSinistroAPI.Model;

namespace ProjetoSinistroAPI.Repositories.Interface
{
    public interface IPacienteRepository
    {

        PacienteModel Get(int id);

        PacienteModel Add(PacienteModel model);

        IEnumerable<PacienteModel> List();

        PacienteModel Update(PacienteModel model);

        bool Delete(int id);
    }
}
