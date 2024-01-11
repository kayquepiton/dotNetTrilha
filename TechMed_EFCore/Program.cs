using TechMed_EFCore.Models;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var context = new TechMedContext();

        // Remover todos os exames
        context.Exames.RemoveRange(context.Exames);
        context.SaveChanges();

        // Remover todos os atendimentos
        context.Atendimentos.RemoveRange(context.Atendimentos);
        context.SaveChanges();

        // Remover todos os médicos
        context.Medicos.RemoveRange(context.Medicos);
        context.SaveChanges();

        // Remover todos os pacientes
        context.Pacientes.RemoveRange(context.Pacientes);
        context.SaveChanges();

        // Inserir um médico
        var novoMedico = new Medico
        {
            Nome = "Dr. Kayque",
            CPF = "111.222.333-44",
            CRM = "654321",
            Especialidade = "Cardiologista",
            Salario = 12000
        };
        context.Medicos.Add(novoMedico);
        context.SaveChanges();

        Console.WriteLine("Médico inserido com sucesso.");

        // Inserir um paciente
        var novoPaciente = new Paciente
        {
            Nome = "Valber",
            CPF = "444.555.666-77",
            Endereco = "Rua B, 1",
            Telefone = "9876-5432"
        };
        context.Pacientes.Add(novoPaciente);
        context.SaveChanges();

        Console.WriteLine("Paciente inserido com sucesso.");

        // Inserir um atendimento
        var novoAtendimento = new Atendimento
        {
            DataHora = DateTime.Now,
            MedicoId = novoMedico.Id,
            Medico = novoMedico,
            PacienteId = novoPaciente.Id,
            Paciente = novoPaciente
        };
        context.Atendimentos.Add(novoAtendimento);
        context.SaveChanges();

        Console.WriteLine("Atendimento inserido com sucesso.");

        // Inserir um exame associado ao atendimento
        var novoExame = new Exame
        {
            Local = "Laboratório XYZ",
            DataHora = DateTime.Now,
            Atendimento = novoAtendimento
        };
        context.Exames.Add(novoExame);
        context.SaveChanges();

        Console.WriteLine("Exame inserido com sucesso.");

        // Buscar e exibir todos os médicos
        Console.WriteLine("\nMédicos no banco de dados:");
        foreach (var medico in context.Medicos)
        {
            Console.WriteLine($"Id: {medico.Id} - Nome: {medico.Nome} - CRM: {medico.CRM}");
        }

        // Buscar e exibir todos os pacientes
        Console.WriteLine("\nPacientes no banco de dados:");
        foreach (var paciente in context.Pacientes)
        {
            Console.WriteLine($"Id: {paciente.Id} - Nome: {paciente.Nome} - CPF: {paciente.CPF}");
        }

        // Buscar e exibir todos os atendimentos
        Console.WriteLine("\nAtendimentos no banco de dados:");
        foreach (var atendimento in context.Atendimentos)
        {
            Console.WriteLine($"Id: {atendimento.Id} - DataHora: {atendimento.DataHora} - Médico: {atendimento.Medico.Nome} - Paciente: {atendimento.Paciente.Nome}");
        }

        // Buscar e exibir todos os exames
        Console.WriteLine("\nExames no banco de dados:");
        foreach (var exame in context.Exames)
        {
            Console.WriteLine($"Id: {exame.Id} - Local: {exame.Local} - DataHora: {exame.DataHora} - Médico: {exame.Atendimento.Medico.Nome} - Paciente: {exame.Atendimento.Paciente.Nome} - DataHora Atendimento: {exame.Atendimento.DataHora}");
        }

        Console.WriteLine("\nFinalizando o programa.");
    }
}
