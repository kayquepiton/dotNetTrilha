using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Infrastructure.Persistence.Interfaces;

public interface IDatabaseFake
{
    public IMedicoCollection MedicoCollection { get; }
    public IPacienteCollection PacienteCollection { get; }
    public IAtendimentoCollection AtendimentoCollection { get; }
    public IExameCollection ExameCollection { get; }

}
