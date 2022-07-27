using YB.Domain.Interfaces.Repository;
using YB.Domain.Interfaces.Services;

namespace YB.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FuncionarioService(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}