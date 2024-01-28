namespace TechMed.Application.InputModels
{
   public class ExameInputModel
   {
      public required string Nome { get; set; }
      public DateTime DataHora { get; set; }
      public int AtendimentoId { get; set; }
   }
}
