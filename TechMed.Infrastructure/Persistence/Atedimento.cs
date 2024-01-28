using System.Collections.Generic;
using System.Linq;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Infrastructure.Persistence;
public class AtendimentoDB : IAtendimentoCollection
{
    private readonly List<Atendimento> _atendimentos = new List<Atendimento>();
    private int _id = 0;

    public int Create(Atendimento atendimento)
    {
        if (_atendimentos.Count > 0)
            _id = _atendimentos.Max(m => m.AtendimentoId);
        atendimento.AtendimentoId = ++_id;
        _atendimentos.Add(atendimento);
        return atendimento.AtendimentoId;
    }
    public void Update(int id, Atendimento atendimento)
    {
        var AtendimentoDB = _atendimentos.FirstOrDefault(m => m.AtendimentoId == id);
        if (AtendimentoDB != null)
        {
            AtendimentoDB.DataHora = atendimento.DataHora;
        }
    }
    public void Delete(int id)
    {
        _atendimentos.RemoveAll(m => m.AtendimentoId == id);
    }
    public Atendimento? GetById(int id)
    {
        return _atendimentos.FirstOrDefault(m => m.AtendimentoId == id);
    }
    public ICollection<Atendimento> GetAll()
    {
        return _atendimentos.ToArray();
    }

}

