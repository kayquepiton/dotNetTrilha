using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.Interfaces;
public interface IAtendimentoService
{
   public int Create(AtendimentoInputModel atendimento);
   
   public List<AtendimentoViewModel> GetByPacienteId(int pacienteId);
   public List<AtendimentoViewModel> GetByMedicoId(int medicoId);

   public List<AtendimentoViewModel> GetAll();
   public AtendimentoViewModel? GetById(int id);
   
}
