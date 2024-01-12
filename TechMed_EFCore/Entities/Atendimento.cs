using System;
using System.Collections.Generic;

namespace TechMed_EFCore.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int MedicoId { get; set; }
        public Medico? Medico { get; set; }
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
        public ICollection<Exame>? Exames { get; set; }
    }
}
