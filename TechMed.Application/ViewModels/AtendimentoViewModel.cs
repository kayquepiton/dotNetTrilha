namespace TechMed.Application.ViewModels
{
    public class AtendimentoViewModel
    {
        public int AtendimentoId { get; set; }
        public DateTime DataHora { get; set; }
        public int MedicoId { get; set; }
        public string? NomeMedico { get; set; } // Alteração feita aqui
        public int PacienteId { get; set; }
        public string? NomePaciente { get; set; } // Alteração feita aqui
    }
}
