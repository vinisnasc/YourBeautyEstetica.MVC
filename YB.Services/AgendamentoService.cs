using YB.Domain.Interfaces.Repository;
using YB.Domain.Interfaces.Services;

namespace YB.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AgendamentoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}