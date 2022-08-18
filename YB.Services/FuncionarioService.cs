using YB.Domain.Interfaces.Repository;
using YB.Domain.Interfaces.Services;
using YB.Domain.Models;

namespace YB.Services
{
    public class FuncionarioService : BaseService, IFuncionarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FuncionarioService(IUnitOfWork unitOfWork, INotificador notificador) : base(notificador)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Funcionario> BuscarFuncionario(string email)
        {
            return (_unitOfWork.FuncionarioRepository.Buscar(e => e.Email == email)).Result.FirstOrDefault();
        }

        public async Task CriarFuncionario(Funcionario funcionario)
        {
            var funcionarioBD = (await _unitOfWork.FuncionarioRepository.Buscar(e => e.Email == funcionario.Email)).FirstOrDefault();

            if (funcionarioBD == null)
            {
                await _unitOfWork.FuncionarioRepository.Incluir(funcionario);
                return;
            }

            else if (!funcionarioBD.Ativo)
            {
                funcionarioBD.Ativo = true;
                await _unitOfWork.FuncionarioRepository.Alterar(funcionarioBD);
                return;
            }

            else
                return;
        }

        public async Task InativarFuncionario(Funcionario funcionario)
        {
            funcionario.Ativo = false;
            await _unitOfWork.FuncionarioRepository.Alterar(funcionario);
        } 
        
        public async Task AtivarFuncionario(Funcionario funcionario)
        {
            funcionario.Ativo = true;
            await _unitOfWork.FuncionarioRepository.Alterar(funcionario);
        }
    }
}