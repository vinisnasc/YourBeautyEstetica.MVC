namespace YourBeautyEstetica.MVC.Models
{
    public class FuncionarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public IEnumerable<ServicoDTO> Servicos { get; set; }
    }
}