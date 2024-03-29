using System.Collections.Generic;

namespace TechMed_EFCore.Models
{
    public class Paciente : Pessoa
    {
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public ICollection<Atendimento>? Atendimentos { get; set; }
    }
}
