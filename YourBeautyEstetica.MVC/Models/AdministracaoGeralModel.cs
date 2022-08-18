using Microsoft.AspNetCore.Identity;

namespace YourBeautyEstetica.MVC.Models
{
    public class AdministracaoGeralModel : AdministracaoSimplesModel
    {
        public List<IdentityUser> Usuarios { get; set; }
        public Guid UsuarioId { get; set; }
        public string Role { get; set; }
        public UserManager<IdentityUser> UserManager { get; set; }
    }
}