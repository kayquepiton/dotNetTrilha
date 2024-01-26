using System;
using System.Collections.Generic;
using System.Linq;
using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Core.Exceptions;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Application.Services
{
    public class ExameService : BaseService, IExameService
    {
        public ExameService(ITechMedContext context) : base(context)
        {
        }

        public int CreateExameForAtendimento(int atendimentoId)
        {
            Exame exame = new Exame
            {
                AtendimentoId = atendimentoId
            };

            _context.Exames.Add(exame);
            _context.SaveChanges();

            return exame.ExameId;
        }

        public ExameViewModel GetExameById(int id)
        {
            Exame exame = _context.Exames.FirstOrDefault(e => e.ExameId == id);

            if (exame == null)
            {
                throw new ExameNotFoundException();
            }

            return new ExameViewModel
            {
                ExameId = exame.ExameId,
                AtendimentoId = exame.AtendimentoId
            };
        }

        public List<ExameViewModel> GetAllExames()
        {
            List<Exame> exames = _context.Exames.ToList();

            List<ExameViewModel> exameViewModels = exames.Select(e => new ExameViewModel
            {
                ExameId = e.ExameId,
                AtendimentoId = e.AtendimentoId
            }).ToList();

            return exameViewModels;
        }
    }
}
