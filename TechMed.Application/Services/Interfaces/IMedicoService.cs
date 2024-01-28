namespace TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
public interface IMedicoService
{
      public int Create(MedicoInputModel medico);
      public int CreateAtendimento(int medicoId,AtendimentoInputModel atendimento);
      public void Update(int id, MedicoInputModel medico);
      public void Delete(int id);
      public List<MedicoViewModel> GetAll();
      public MedicoViewModel? GetById(int id);
}
