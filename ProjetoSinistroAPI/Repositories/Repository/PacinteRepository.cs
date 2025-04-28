using ProjetoSinistroAPI.Context;
using ProjetoSinistroAPI.Model;
using ProjetoSinistroAPI.Repositories.Interface;

namespace ProjetoSinistroAPI.Repositories.Repository
{
    public class PacienteRepository : IPacienteRepository
    {

        private readonly AppContextDb _context;

        public PacienteRepository(AppContextDb context)
        {
            _context = context;
        }

        public PacienteModel Add(PacienteModel model)
        {
            _context.Paciente.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool Delete(int id)
        {
            bool status = false;

            try
            {
                var pac = _context.Paciente.Find(id);

                if (pac != null)
                {
                    _context.Paciente.Remove(pac);
                    _context.SaveChanges();

                }
                status = true;
            }
            catch { }
            return status;
        }

        public PacienteModel Get(int id)
        {
            var pac = _context.Paciente.FirstOrDefault(m => m.PacienteId == id);
            return pac;
        }

        public IEnumerable<PacienteModel> List()
        {
            return [.. _context.Paciente];
        }

        public PacienteModel Update(PacienteModel model)
        {
            _context.Paciente.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
