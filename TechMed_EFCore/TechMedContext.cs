using Microsoft.EntityFrameworkCore;

namespace TechMed_EFCore.Models
{
    public class TechMedContext : DbContext
    {
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Exame> Exames { get; set; }
        

    }
}
