namespace TechMed.Application.Services.Interfaces
{
    using TechMed.Application.InputModels;
    using TechMed.Application.ViewModels;
    using System.Collections.Generic;

    public interface IAtendimentoService
    {
        public List<AtendimentoViewModel> GetAll();
        public AtendimentoViewModel? GetById(int id);
        public int Create(NewAtendimentoInputModel atendimento);
        public void Update(int id, NewAtendimentoInputModel atendimento);
        public void Delete(int id);
    }
}
