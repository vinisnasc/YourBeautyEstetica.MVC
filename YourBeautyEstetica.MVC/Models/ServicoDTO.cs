namespace YourBeautyEstetica.MVC.Models
{
    public class ServicoDTO
    {
        public string NomeServico { get; set; }
        public Guid FuncionarioId { get; set; }
        public TimeOnly TempoNecessario { get; set; }
        public double Valor { get; set; }
        public string Imagem { get; set; }
        public IFormFile ImagemUpload { get; set; }

        public IEnumerable<AgendamentoDTO> Agendamentos { get; set; }
        public FuncionarioDTO Funcionario { get; set; }
    }
}