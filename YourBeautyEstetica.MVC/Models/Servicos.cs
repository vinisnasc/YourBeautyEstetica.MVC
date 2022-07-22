namespace YourBeautyEstetica.MVC.Models
{
    public class Servicos : BaseEntity
    {
        public string NomeServico { get; set; }
        public Guid IdFuncionario { get; set; }
    }
}
