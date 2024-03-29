using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InfnetMVC.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [ForeignKey("DepartamentoId")]
        public int DepartamentoId { get; set; }

        public virtual Departamento? Departamento { get; set; }
    }
}
