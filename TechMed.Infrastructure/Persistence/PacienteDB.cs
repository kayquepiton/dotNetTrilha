using System.Collections.Generic;
using System.Linq;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Infrastructure.Persistence;
public class PacienteDB : IPacienteCollection
{
    private readonly List<Paciente> _pacientes = new List<Paciente>();
    private int _id = 0;

    public PacienteDB(){
      _pacientes.Add(new Paciente{PacienteId = 1, Nome = "Emily Rose"});
      _pacientes.Add(new Paciente{PacienteId = 2, Nome = "Vovozinha"});
   }

    public int Create(Paciente paciente)
    {
        if (_pacientes.Count > 0)
            _id = _pacientes.Max(m => m.PacienteId);
        paciente.PacienteId = ++_id;
        _pacientes.Add(paciente);
        return paciente.PacienteId;
    }
    public void Update(int id, Paciente paciente)
    {
        var PacienteDB = _pacientes.FirstOrDefault(m => m.PacienteId == id);
        if (PacienteDB != null)
        {
            PacienteDB.Nome = paciente.Nome;
        }
    }
    public void Delete(int id)
    {
        _pacientes.RemoveAll(m => m.PacienteId == id);
    }
    public Paciente? GetById(int id)
    {
        return _pacientes.FirstOrDefault(m => m.PacienteId == id);
    }
    public ICollection<Paciente> GetAll()
    {
        return _pacientes.ToArray();
    }

}

