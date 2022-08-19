using YB.Domain.Interfaces.Repository;
using YB.Domain.Interfaces.Services;
using YB.Domain.Models;

namespace YB.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task CadastrarServico(Servico servico)
        {
            await _unitOfWork.ServicoRepository.Incluir(servico);
        }
    }
}