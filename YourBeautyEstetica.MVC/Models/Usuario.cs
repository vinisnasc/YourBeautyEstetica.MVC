using YourBeautyEstetica.MVC.Models.Enums;

namespace YourBeautyEstetica.MVC.Models
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public IEnumerable<Servicos> Servicos { get; set; }
    }
}
