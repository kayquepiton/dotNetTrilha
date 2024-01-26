using System.Collections.Generic;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.Interfaces
{
    public interface IExameService
    {
        List<ExameViewModel> GetAllExames();
        ExameViewModel GetExameById(int id);
        int CreateExameForAtendimento(int atendimentoId);
    }
}
