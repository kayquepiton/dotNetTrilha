using System;

namespace TechMed.Core.Exceptions
{
    public class AtendimentoAlreadyExistsException : Exception
    {
        public AtendimentoAlreadyExistsException() :
            base("Já existe um atendimento com esses dados.")
        {
        }
    }

    public class AtendimentoNotFoundException : Exception
    {
        public AtendimentoNotFoundException() :
            base("Atendimento não encontrado.")
        {
        }
    }
}
