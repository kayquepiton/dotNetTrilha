namespace TechMed.Core.Exceptions;

public class AtendimentoAlreadyExistsException : Exception
{
    public AtendimentoAlreadyExistsException() : base("Atendimento já cadastrado.") { }
}

public class AtendimentoNotFoundException : Exception
{
    public AtendimentoNotFoundException() : base("Atendimento não encontrado.") { }
}
