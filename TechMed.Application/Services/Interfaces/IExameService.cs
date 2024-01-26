using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using System.Collections.Generic;

namespace TechMed.Application.Services.Interfaces
{
    public interface IExameService
    {
        List<ExameViewModel> GetAllExames();
        ExameViewModel GetExameById(int id);
        int CreateExame(NewExameInputModel exameInputModel);
    }
}
