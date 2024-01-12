using System.Collections.Generic;

namespace TechMed_EFCore.Models
{
    public class Medico : Pessoa
    {
        public string? CRM { get; set; }
        public string? Especialidade { get; set; }
        public decimal? Salario { get; set; }
        public ICollection<Atendimento>? Atendimentos { get; set; }
    }
}
