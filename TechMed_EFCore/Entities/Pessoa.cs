namespace TechMed_EFCore.Models
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
    }
}
