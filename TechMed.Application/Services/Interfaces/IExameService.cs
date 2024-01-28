using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.Interfaces;
public interface IExameService
{
   public int Create(ExameInputModel exame);
    public List<ExameViewModel> GetAll();
}
