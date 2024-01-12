using System;

namespace TechMed_EFCore.Models
{
    public class Exame
    {
        public int Id { get; set; }
        public string? Local { get; set; } // ou string? se pode ser nulo
        public DateTime DataHora { get; set; }
        public Atendimento? Atendimento { get; set; }
    }
}
