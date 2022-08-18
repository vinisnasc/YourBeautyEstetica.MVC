using YB.Domain.Models;

namespace YB.Domain.Interfaces.Services
{
    public interface IFuncionarioService
    {
        Task CriarFuncionario(Funcionario funcionario);
        Task<Funcionario> BuscarFuncionario(string email);
        Task InativarFuncionario(Funcionario funcionario);
        Task AtivarFuncionario(Funcionario funcionario);
    }
}