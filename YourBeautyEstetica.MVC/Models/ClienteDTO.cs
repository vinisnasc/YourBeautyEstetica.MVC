namespace YourBeautyEstetica.MVC.Models
{
    public class ClienteDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public IEnumerable<AgendamentoDTO> Agendamentos { get; set; }
    }
}
