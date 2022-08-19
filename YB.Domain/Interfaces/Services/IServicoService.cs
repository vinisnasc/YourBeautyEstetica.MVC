using YB.Domain.Models;

namespace YB.Domain.Interfaces.Services
{
    public interface IServicoService
    {
        Task CadastrarServico(Servico servico);
    }
}