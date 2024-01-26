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

        public int CreateExame(NewExameInputModel exameInputModel)
        {
            // Implementação para criar um novo exame
            throw new NotImplementedException();
        }

        public ExameViewModel GetExameById(int id)
        {
            // Implementação para obter um exame pelo ID
            throw new NotImplementedException();
        }

        public List<ExameViewModel> GetAllExames()
        {
            // Implementação para obter todos os exames
            throw new NotImplementedException();
        }
    }
}
