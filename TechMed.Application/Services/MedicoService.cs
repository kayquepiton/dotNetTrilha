using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Core.Exceptions;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Application.Services;
public class MedicoService : IMedicoService
{
  private readonly ITechMedContext _context;
  public MedicoService(ITechMedContext context)
  {
    _context = context;
  }

  public int Create(MedicoInputModel medico)
  {
    return _context.MedicoCollection.Create(new Medico
    {
      Nome = medico.Nome
    });

  }

  public int CreateAtendimento(int medicoId, AtendimentoInputModel atendimento)
  {
    var medico = _context.MedicoCollection.GetById(medicoId);
    if (medico is null)
      throw new MedicoNotFoundException();

    var paciente = _context.PacienteCollection.GetById(atendimento.PacienteId);
    if (paciente is null)
      throw new PacienteNotFoundException();

    return _context.AtendimentoCollection.Create(new Atendimento
    {
      DataHora = atendimento.DataHora,
      Medico = medico,
      Paciente = paciente
    });
  }

  public void Update(int id, MedicoInputModel medico)
  {
    _context.MedicoCollection.Update(id, new Medico
    {
      Nome = medico.Nome
    });
  }

  public void Delete(int id)
  {
    _context.MedicoCollection.Delete(id);
  }

  public List<MedicoViewModel> GetAll()
  {
    var medicos = _context.MedicoCollection.GetAll().Select(m => new MedicoViewModel
    {
      MedicoId = m.MedicoId,
      Nome = m.Nome
    }).ToList();

    return medicos;

  }

  public MedicoViewModel? GetById(int id)
  {
    var medico = _context.MedicoCollection.GetById(id);

    if (medico is null)
      return null;

    var MedicoViewModel = new MedicoViewModel
    {
      MedicoId = medico.MedicoId,
      Nome = medico.Nome
    };
    return MedicoViewModel;
  }

}
