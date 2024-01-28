using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Application.Services;
public class ExameService : BaseService, IExameService
{
   private readonly IAtendimentoService _atendimentoService;
   public ExameService(ITechMedContext context, IAtendimentoService atendimentoService) : base(context)
   {
      _atendimentoService = atendimentoService;
   }

   public int Create(ExameInputModel exame)
   {
      return _context.ExameCollection.Create(new Exame
      {
         Nome = exame.Nome,
         DataHora = exame.DataHora,
         AtendimentoId = exame.AtendimentoId
      });
   }

   public List<ExameViewModel> GetAll()
   {

      return _context.ExameCollection.GetAll().Select(m => new ExameViewModel
      {
         ExameId = m.ExameId,
         Nome = m.Nome,
         DataHora = m.DataHora,
         Atendimento = _atendimentoService.GetById(m.AtendimentoId)
      }).ToList();
   }
}