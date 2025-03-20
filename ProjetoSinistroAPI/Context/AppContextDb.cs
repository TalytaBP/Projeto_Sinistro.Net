using Microsoft.EntityFrameworkCore;
using ProjetoSinistroAPI.Model;

namespace ProjetoSinistroAPI.Context
{
    public class AppContextDb : DbContext
    {
        public AppContextDb(DbContextOptions<AppContextDb> options) : base(options) { }

        public DbSet<PacienteModel> Paciente { get; set; }
    }
}
