using YB.Domain.Interfaces.Repository;
using YB.Domain.Interfaces.Services;

namespace YB.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}