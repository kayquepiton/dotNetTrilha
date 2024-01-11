using System;
using Techmed;

class Program
{
    static void Main()
    {
        using var db = new TechmedContext();

        // Criar uma instância de Pessoa
        var pessoa = new Pessoa
        {
            Nome = "Dr. João Silva",
            DataNascimento = new DateTime(1980, 1, 1),
            Telefone = "(11) 1234-5678",
            Email = "joao.silva@example.com"
            // Outras propriedades da Pessoa, se houver
        };

        // Criar uma instância de Medico
        var medico = new Medico
        {
            CRM = "12345",
            Especialidade = "Cardiologia",
            Salario = 10000.50m, // Exemplo de salário
            // Outras propriedades do Medico, se houver

            // Relacionar o Medico com a Pessoa
            Pessoa = pessoa
        };

        // Adicionar Medico ao contexto
        db.Medicos?.Add(medico);

        // Salvar as mudanças no banco de dados
        db.SaveChanges();

        Console.WriteLine("Dados do médico adicionados com sucesso!");
    }
}
