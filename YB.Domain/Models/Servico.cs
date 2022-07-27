namespace YB.Domain.Models
{
    public class Servico : BaseEntity
    {
        public string NomeServico { get; set; }
        public Guid FuncionarioId { get; set; }
        public DateTime TempoNecessario { get; set; }
        public double Valor { get; set; }

        public IEnumerable<Agendamento> Agendamentos { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}