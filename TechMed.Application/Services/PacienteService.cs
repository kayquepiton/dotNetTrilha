using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Infrastructure.Persistence.Interfaces;
using TechMed.Core.Entities;

namespace TechMed.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly ITechMedContext _context;

        public PacienteService(ITechMedContext context)
        {
            _context = context;
        }

        public int Create(NewPacienteInputModel paciente)
        {
            if (paciente == null)
            {
                throw new ArgumentNullException(nameof(paciente));
            }

            var novoPaciente = new Paciente
            {
                Nome = paciente.Nome ?? throw new ArgumentNullException(nameof(paciente.Nome))
            };

            return _context.PacientesCollection.Create(novoPaciente);
        }

        public void Delete(int id)
        {
            _context.PacientesCollection.Delete(id);
        }

        public List<PacienteViewModel> GetAll()
        {
            var pacientes = _context.PacientesCollection.GetAll().Select(p => new PacienteViewModel
            {
                PacienteId = p.PacienteId,
                Nome = p.Nome
            }).ToList();

            return pacientes;
        }

        public PacienteViewModel? GetByCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public PacienteViewModel? GetById(int id)
        {
            var paciente = _context.PacientesCollection.GetById(id);

            if (paciente is null)
                return null;

            var pacienteViewModel = new PacienteViewModel
            {
                PacienteId = paciente.PacienteId,
                Nome = paciente.Nome
            };

            return pacienteViewModel;
        }

        public void Update(int id, NewPacienteInputModel paciente)
        {
            if (paciente == null)
            {
                throw new ArgumentNullException(nameof(paciente));
            }

            var novoPaciente = new Paciente
            {
                Nome = paciente.Nome ?? throw new ArgumentNullException(nameof(paciente.Nome))
            };

            _context.PacientesCollection.Update(id, novoPaciente);
        }
    }
}
