﻿using System.Collections.Generic;
using System.Linq;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Infrastructure.Persistence;
public class ExameDB : IExameCollection
{
    private readonly List<Exame> _exames = new List<Exame>();
    private int _id = 0;

    public int Create(Exame exame)
    {
        if (_exames.Count > 0)
            _id = _exames.Max(m => m.ExameId);
        _exames.Add(exame);
        exame.ExameId = ++_id;
        return exame.ExameId;
    }
    public void Update(int id, Exame obj)
    {
        var exameDB = _exames.FirstOrDefault(m => m.ExameId == id);
        if(exameDB is not null)
        {
            exameDB.DataHora = obj.DataHora;
            exameDB.Nome = obj.Nome;
        }
    }
    public void Delete(int id)
    {
        _exames.RemoveAll(m => m.ExameId == id);
    }
    public Exame? GetById(int id)
    {
        return _exames.FirstOrDefault(m => m.ExameId == id);
    }
    public ICollection<Exame> GetAll()
    {
        return _exames.ToArray();
    }

}

