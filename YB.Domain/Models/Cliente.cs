namespace YB.Domain.Models
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public IEnumerable<Agendamento> Agendamentos { get; set; }
    }
}