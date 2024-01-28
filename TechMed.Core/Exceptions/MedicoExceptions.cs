namespace TechMed.Core.Exceptions;

public class MedicoAlreadyExistsException : Exception
{
    public MedicoAlreadyExistsException() : base("Medico já cadastrado.") { }
}

public class MedicoNotFoundException : Exception
{
    public MedicoNotFoundException() : base("Medico não encontrado.") { }
}   
