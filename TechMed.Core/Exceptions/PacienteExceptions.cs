namespace TechMed.Core.Exceptions;

public class PacienteAlreadyExistsException : Exception
{
    public PacienteAlreadyExistsException() : base("Paciente já cadastrado.") { }
}

public class PacienteNotFoundException : Exception
{
    public PacienteNotFoundException() : base("Paciente não encontrado.") { }
}
