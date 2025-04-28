using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSinistroAPI.Model
{
    [Table("PACIENTESP3")]
    public class PacienteModel
    {
        [Key]
        [Column("PACIENTE_ID")]
        [Required(ErrorMessage = "Id do Paciente é requerido")]
        public int PacienteId { get; set; }

        [Column("NOME_PACIENTE")]
        [Required(ErrorMessage = "Nome do Paciente é requerido")]
        [StringLength(100, ErrorMessage = "Tamanho máximo é de 100 caracteres")]
        public string Nome { get; set; }

        [Column("EMAIL_PACIENTE")]
        [Required(ErrorMessage = "Email do Paciente é requerido")]
        [StringLength(100, ErrorMessage = "Tamanho máximo é de 100 caracteres")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DATANASCIMENTO { get; set; }
    }
}
