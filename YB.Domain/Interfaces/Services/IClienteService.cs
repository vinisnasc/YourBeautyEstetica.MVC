using YB.Domain.Models;

namespace YB.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task CadastrarCliente(Cliente cliente);
        Task<Cliente> BuscarCliente(Guid id);
        Task<Cliente> BuscarCliente(string email);
    }
}