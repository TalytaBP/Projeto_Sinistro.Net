using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSinistroAPI.Model
{
    [Table("PacienteSP3")]
    public class PacienteModel
    {
        [Key]
        [Column("Paciente_ID")]
        [Required(ErrorMessage = "Id do Paciente é requerido")]
        public int PacienteId { get; set; }

        [Column("Nome_Paciente")]
        [Required(ErrorMessage = "Nome do Paciente é requerido")]
        [StringLength(100, ErrorMessage = "Tamanho máximo é de 100 caracteres")]
        public string Nome { get; set; }

        [Column("Email_Paciente")]
        [Required(ErrorMessage = "Email do Paciente é requerido")]
        [StringLength(100, ErrorMessage = "Tamanho máximo é de 100 caracteres")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
