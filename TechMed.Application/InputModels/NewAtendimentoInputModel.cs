namespace TechMed.Application.InputModels
{
    public class NewAtendimentoInputModel
    {
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public DateTime DataHora { get; set; }
    }
}
