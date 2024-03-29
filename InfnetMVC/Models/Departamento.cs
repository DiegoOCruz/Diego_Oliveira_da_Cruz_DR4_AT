using System.ComponentModel.DataAnnotations;

namespace InfnetMVC.Models
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public ICollection<Funcionario>? Funcionarios { get; set; }
    }
}
