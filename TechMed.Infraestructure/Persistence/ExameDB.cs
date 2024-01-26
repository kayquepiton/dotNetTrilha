using System.Collections.Generic;
using System.Linq;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence.Interfaces;
using TechMed.Core.Exceptions;

namespace TechMed.Infrastructure.Persistence
{
    public class ExameDB : IExameCollection
    {
        private readonly List<Exame> _exames = new List<Exame>();
        private int _id = 0;

        public int Create(Exame exame)
        {
            if (_exames.Count > 0)
                _id = _exames.Max(m => m.ExameId);
            exame.ExameId = ++_id;
            _exames.Add(exame);
            return exame.ExameId;
        }

        public void Delete(int id)
        {
            var exameToRemove = GetById(id);
            if (exameToRemove != null)
                _exames.Remove(exameToRemove);
        }

        public ICollection<Exame> GetAll()
        {
            return _exames.ToArray();
        }

        public Exame GetById(int id)
        {
            return _exames.FirstOrDefault(e => e.ExameId == id) ?? throw new ExameNotFoundException();
        }

        public void Update(int id, Exame exame)
        {
            // Não há campos para atualizar na entidade Exame
            // A lógica de atualização pode ser deixada vazia ou removida, dependendo dos requisitos do sistema
        }
    }
}
