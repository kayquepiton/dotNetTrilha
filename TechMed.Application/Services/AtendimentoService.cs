using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Infrastructure.Persistence.Interfaces;
using TechMed.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TechMed.Application.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly ITechMedContext _context;

        public AtendimentoService(ITechMedContext context)
        {
            _context = context;
        }

        public int Create(NewAtendimentoInputModel atendimento)
        {
            if (atendimento == null)
            {
                throw new ArgumentNullException(nameof(atendimento));
            }

            // Carregar o médico e o paciente associados ao atendimento
            var medico = _context.MedicosCollection.GetById(atendimento.MedicoId);
            var paciente = _context.PacientesCollection.GetById(atendimento.PacienteId);

            if (medico == null)
            {
                throw new ArgumentException("Médico não encontrado", nameof(atendimento));
            }

            if (paciente == null)
            {
                throw new ArgumentException("Paciente não encontrado", nameof(atendimento));
            }

            var novoAtendimento = new Atendimento
            {
                Medico = medico,
                Paciente = paciente,
                DataHora = atendimento.DataHora
            };

            return _context.AtendimentosCollection.Create(novoAtendimento);
        }

        public void Delete(int id)
        {
            _context.AtendimentosCollection.Delete(id);
        }

        public List<AtendimentoViewModel> GetAll()
        {
            var atendimentos = _context.AtendimentosCollection.GetAll().Select(a => new AtendimentoViewModel
            {
                AtendimentoId = a.AtendimentoId,
                DataHora = a.DataHora,
                MedicoId = a.MedicoId,
                PacienteId = a.PacienteId
            }).ToList();

            return atendimentos;
        }

        public AtendimentoViewModel? GetById(int id)
        {
            var atendimento = _context.AtendimentosCollection.GetById(id);

            if (atendimento is null)
                return null;

            var atendimentoViewModel = new AtendimentoViewModel
            {
                AtendimentoId = atendimento.AtendimentoId,
                DataHora = atendimento.DataHora,
                MedicoId = atendimento.MedicoId,
                PacienteId = atendimento.PacienteId
            };

            return atendimentoViewModel;
        }

        public void Update(int id, NewAtendimentoInputModel atendimento)
        {
            if (atendimento == null)
            {
                throw new ArgumentNullException(nameof(atendimento));
            }

            // Carregar o médico e o paciente associados ao atendimento
            var medico = _context.MedicosCollection.GetById(atendimento.MedicoId);
            var paciente = _context.PacientesCollection.GetById(atendimento.PacienteId);

            if (medico == null)
            {
                throw new ArgumentException("Médico não encontrado", nameof(atendimento));
            }

            if (paciente == null)
            {
                throw new ArgumentException("Paciente não encontrado", nameof(atendimento));
            }

            var novoAtendimento = new Atendimento
            {
                Medico = medico,
                Paciente = paciente,
                DataHora = atendimento.DataHora
            };

            _context.AtendimentosCollection.Update(id, novoAtendimento);
        }
    }
}
