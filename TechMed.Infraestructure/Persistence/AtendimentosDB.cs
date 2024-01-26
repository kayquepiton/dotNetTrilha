using TechMed.Infrastructure.Persistence.Interfaces;
using TechMed.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using TechMed.Core.Exceptions;

namespace TechMed.Infrastructure.Persistence
{
    public class AtendimentosDB : IAtendimentoCollection
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

        public void Delete(int id)
        {
            var atendimentoToRemove = GetById(id);
            if (atendimentoToRemove != null)
                _atendimentos.Remove(atendimentoToRemove);
        }

        public ICollection<Atendimento> GetAll()
        {
            return _atendimentos.ToArray();
        }

        public Atendimento GetById(int id)
        {
            var atendimento = _atendimentos.FirstOrDefault(m => m.AtendimentoId == id);
            return atendimento ?? throw new AtendimentoNotFoundException();
        }


        public void Update(int id, Atendimento atendimento)
        {
            var atendimentoDB = GetById(id);
            if (atendimentoDB != null)
            {
                atendimentoDB.DataHora = atendimento.DataHora;
            }
        }
    }
}
