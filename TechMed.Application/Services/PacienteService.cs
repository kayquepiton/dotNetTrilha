using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Infrastructure.Persistence.Interfaces;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Application.Services;
public class PacienteService : IPacienteService
{
  private readonly ITechMedContext _context;
  public PacienteService(ITechMedContext context)
  {
    _context = context;
  }

    public int Create(PacienteInputModel medico)
    {
        return _context.PacienteCollection.Create(new Paciente{
        Nome = medico.Nome
        });
    }

    public void Update(int id, PacienteInputModel medico)
    {
        _context.PacienteCollection.Update(id, new Paciente{
        Nome = medico.Nome
        });
    }

    public void Delete(int id)
    {
        _context.PacienteCollection.Delete(id);
    }

    public List<PacienteViewModel> GetAll()
    {
        var pacientes = _context.PacienteCollection.GetAll().Select(m => new PacienteViewModel{
        PacienteId = m.PacienteId,
        Nome = m.Nome
        }).ToList();

        return pacientes;
    }

    public PacienteViewModel? GetById(int id)
    {
        var paciente = _context.PacienteCollection.GetById(id);
        
        if(paciente is null)
        return null;

        var PacienteViewModel = new PacienteViewModel{
        PacienteId = paciente.PacienteId,
        Nome = paciente.Nome
        };
        return PacienteViewModel;
    }

}
