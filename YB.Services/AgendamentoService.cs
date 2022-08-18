using YB.Domain.Interfaces.Repository;
using YB.Domain.Interfaces.Services;

namespace YB.Services
{
    public class AgendamentoService : BaseService, IAgendamentoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AgendamentoService(IUnitOfWork unitOfWork, INotificador notificador) : base(notificador)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}