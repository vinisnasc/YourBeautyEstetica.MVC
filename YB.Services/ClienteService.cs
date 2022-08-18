using YB.Domain.Interfaces.Repository;
using YB.Domain.Interfaces.Services;
using YB.Domain.Models;
using YB.Domain.Models.Validations;

namespace YB.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteService(IUnitOfWork unitOfWork, INotificador notificador) : base(notificador)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task CadastrarCliente(Cliente cliente)
        {
            if(!ExecutarValidacao(new ClienteValidation(), cliente))

            if (_unitOfWork.ClienteRepository.Buscar(e => e.Email == cliente.Email).Result.Any())
            {
                Notificar("Já existe um cliente com esse e-mail");
                return;
            }

            await _unitOfWork.ClienteRepository.Incluir(cliente);
        }

        public async Task<Cliente> BuscarCliente(Guid id)
        {
            return await _unitOfWork.ClienteRepository.SelecionarPorId(id);
        }
        
        public async Task<Cliente> BuscarCliente(string email)
        {
            return (await _unitOfWork.ClienteRepository.Buscar(x => x.Email == email)).FirstOrDefault();
        }
    }
}