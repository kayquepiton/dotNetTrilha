using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.Interfaces;
public interface IPacienteService
{
      public int Create(PacienteInputModel medico);
      public void Update(int id, PacienteInputModel medico);
      public void Delete(int id);
      public List<PacienteViewModel> GetAll();
      public PacienteViewModel? GetById(int id);
      
}
