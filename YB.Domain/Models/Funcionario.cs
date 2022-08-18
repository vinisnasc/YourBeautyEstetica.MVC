namespace YB.Domain.Models
{
    public class Funcionario : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Servico> Servicos { get; set; }
    }
}