using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace Techmed
{
    public class TechmedContext : DbContext
    {
        public DbSet<Paciente>? Pacientes { get; set; }
        public DbSet<Medico>? Medicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure a conexão MySQL aqui
            base.OnConfiguring(optionsBuilder);

            var stringConexao = "Server=localhost;User=dotnet;Password=tic2023;Database=techmed;";
            var serverVersion = ServerVersion.AutoDetect(stringConexao);

            optionsBuilder.UseMySql(stringConexao, serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais de mapeamento podem ser feitas aqui

            // Exemplo: Configurar uma restrição única para a propriedade CPF na entidade Paciente
            //modelBuilder.Entity<Paciente>().HasIndex(p => p.CPF).IsUnique();

            // Exemplo: Configurar uma restrição única para a propriedade CRM na entidade Medico
            modelBuilder.Entity<Medico>().HasIndex(m => m.CRM).IsUnique();

            // Configurar propriedade Salario na entidade Medico
            modelBuilder.Entity<Medico>().Property(m => m.Salario).HasColumnType("decimal(18,2)");
        }
    }

    public class Pessoa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public Paciente? Paciente { get; set; }
    }

    public class Paciente
    {
        public int Id { get; set; }
        public string? CPF { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public int PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
    }

    public class Medico
    {
        public int Id { get; set; }
        public string? CRM { get; set; }
        public string? Especialidade { get; set; }
        public decimal Salario { get; set; }

        public int PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
    }
}
