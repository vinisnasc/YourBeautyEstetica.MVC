namespace YB.Domain.Models
{
    public class Agendamento : BaseEntity
    {
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Guid ServicoId { get; set; }
        public Servico Servico { get; set; }

        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }
    }
}