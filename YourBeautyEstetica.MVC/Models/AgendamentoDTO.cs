namespace YourBeautyEstetica.MVC.Models
{
    public class AgendamentoDTO
    {
        public Guid ClienteId { get; set; }
        public ClienteDTO Cliente { get; set; }
        public Guid ServicoId { get; set; }
        public ServicoDTO Servico { get; set; }

        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }
    }
}