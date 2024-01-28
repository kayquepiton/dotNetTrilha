using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Infrastructure.Persistence;

public class TechMedContext : ITechMedContext, IDatabaseFake
{
    public IMedicoCollection MedicoCollection { get; } = new MedicoDB();
    public IPacienteCollection PacienteCollection { get; } = new PacienteDB();
    public IAtendimentoCollection AtendimentoCollection { get; } = new AtendimentoDB();
    public IExameCollection ExameCollection { get; } = new ExameDB();
}
