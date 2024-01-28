namespace TechMed.Core.Exceptions;

public class ExameAlreadyExistsException : Exception
{
    public ExameAlreadyExistsException() : base("Exame já cadastrado.") { }
}

public class ExameNotFoundException : Exception
{
    public ExameNotFoundException() : base("Exame não encontrado.") { }
}
